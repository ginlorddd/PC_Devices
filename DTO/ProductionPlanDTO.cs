using DM_OHD.DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DM_OHD.DTO
{
    public class ProductionPlanDTO
    {
        private const int StartYear = 2025;
        private const int EndYear = 2030;

        public DataTable GetPlanFY()
        {
            DataTable raw = DBUtils.GetData("SELECT PRODUCT_NO, DIE_NO, DIE_NAME, CAVITY, PLAN_YEAR, PLAN_MONTH, FY_SHOTS FROM OHD_PLAN_FY ORDER BY DIE_NO, CAVITY, PLAN_YEAR, PLAN_MONTH");
            return BuildWideTable(raw, "FY_SHOTS", includeProductNo: true);
        }

        public DataTable GetMachineRatio()
        {
            DataTable raw = DBUtils.GetData("SELECT DIE_NO, DIE_NAME, CAVITY, PLAN_YEAR, PLAN_MONTH, RUN_RATIO FROM OHD_MACHINE_RATIO ORDER BY DIE_NO, CAVITY, PLAN_YEAR, PLAN_MONTH");
            return BuildWideTable(raw, "RUN_RATIO");
        }

        public DataTable GetDieOutput()
        {
            DataTable raw = DBUtils.GetData("SELECT DIE_NO, DIE_NAME, CAVITY, PLAN_YEAR, PLAN_MONTH, OUTPUT_QTY FROM OHD_DIE_OUTPUT ORDER BY DIE_NO, CAVITY, PLAN_YEAR, PLAN_MONTH");
            return BuildWideTable(raw, "OUTPUT_QTY");
        }

        public DataTable GetMaster() => DBUtils.GetData("SELECT DIE_NO, DIE_NAME, CAVITY, PLAN_YEAR, PLAN_MONTH, FY_SHOTS, RUN_RATIO, REQUIRED_QTY, OHD_MOC FROM OHD_PLAN_MASTER ORDER BY PLAN_YEAR, PLAN_MONTH, DIE_NO");

        public void SavePlanFY(DataTable wideTable)
        {
            SaveWideTable(wideTable, "OHD_PLAN_FY", "FY_SHOTS", includeProductNo: true);
        }

        public void SaveMachineRatio(DataTable wideTable)
        {
            SaveWideTable(wideTable, "OHD_MACHINE_RATIO", "RUN_RATIO");
        }

        public void SaveDieOutput(DataTable wideTable)
        {
            SaveWideTable(wideTable, "OHD_DIE_OUTPUT", "OUTPUT_QTY");
        }

        public void GenerateMasterPlan()
        {
            string sql = @"
                DELETE FROM OHD_PLAN_MASTER;
                INSERT INTO OHD_PLAN_MASTER(DIE_NO,DIE_NAME,CAVITY,PLAN_YEAR,PLAN_MONTH,FY_SHOTS,RUN_RATIO,REQUIRED_QTY,OHD_MOC)
                SELECT fy.DIE_NO,
                       ISNULL(fy.DIE_NAME,''),
                       ISNULL(fy.CAVITY,''),
                       fy.PLAN_YEAR,
                       fy.PLAN_MONTH,
                       ISNULL(fy.FY_SHOTS,0),
                       ISNULL(r.RUN_RATIO,0),
                       ROUND(ISNULL(fy.FY_SHOTS,0) * ISNULL(r.RUN_RATIO,0) / 100.0,0) AS REQUIRED_QTY,
                       CASE
                           WHEN ISNULL(TRY_CONVERT(decimal(18,4), fy.CAVITY),0) <= 0 THEN 0
                           ELSE
                               CASE
                                   WHEN FLOOR((ISNULL(fy.FY_SHOTS,0) * ISNULL(r.RUN_RATIO,0) / 100.0) / NULLIF(TRY_CONVERT(decimal(18,4), fy.CAVITY),0) / 30.0) * 30 > 240 THEN 240
                                   ELSE FLOOR((ISNULL(fy.FY_SHOTS,0) * ISNULL(r.RUN_RATIO,0) / 100.0) / NULLIF(TRY_CONVERT(decimal(18,4), fy.CAVITY),0) / 30.0) * 30
                               END
                       END AS OHD_MOC
                FROM OHD_PLAN_FY fy
                LEFT JOIN OHD_MACHINE_RATIO r ON fy.DIE_NO = r.DIE_NO AND fy.PLAN_YEAR=r.PLAN_YEAR AND fy.PLAN_MONTH=r.PLAN_MONTH;";
            DBUtils.Exec(sql);
        }

        private DataTable BuildWideTable(DataTable raw, string valueColumn, bool includeProductNo = false)
        {
            DataTable wide = new DataTable();
            if (includeProductNo) wide.Columns.Add("PRODUCT_NO", typeof(string));
            wide.Columns.Add("DIE_NO", typeof(string));
            wide.Columns.Add("DIE_NAME", typeof(string));
            wide.Columns.Add("CAVITY", typeof(string));

            foreach (var ym in YearMonths())
            {
                wide.Columns.Add(BuildMonthColumnName(ym.year, ym.month), typeof(decimal));
            }

            var grouped = raw.AsEnumerable().GroupBy(r => new
            {
                ProductNo = includeProductNo ? Convert.ToString(r["PRODUCT_NO"]) : string.Empty,
                DieNo = Convert.ToString(r["DIE_NO"]),
                DieName = Convert.ToString(r["DIE_NAME"]),
                Cavity = Convert.ToString(r["CAVITY"])
            });

            foreach (var g in grouped)
            {
                DataRow row = wide.NewRow();
                if (includeProductNo) row["PRODUCT_NO"] = g.Key.ProductNo;
                row["DIE_NO"] = g.Key.DieNo;
                row["DIE_NAME"] = g.Key.DieName;
                row["CAVITY"] = g.Key.Cavity;

                foreach (DataRow src in g)
                {
                    int y = ToInt(src["PLAN_YEAR"]);
                    int m = ToInt(src["PLAN_MONTH"]);
                    string col = BuildMonthColumnName(y, m);
                    if (wide.Columns.Contains(col)) row[col] = ToDecimal(src[valueColumn]);
                }
                wide.Rows.Add(row);
            }

            return wide;
        }

        private void SaveWideTable(DataTable wideTable, string tableName, string valueColumn, bool includeProductNo = false)
        {
            DBUtils.Exec($"DELETE FROM {tableName}");
            if (wideTable == null) return;

            foreach (DataRow row in wideTable.Rows)
            {
                if (row.RowState == DataRowState.Deleted) continue;
                string dieNo = Convert.ToString(row["DIE_NO"]);
                if (string.IsNullOrWhiteSpace(dieNo)) continue;

                foreach (var ym in YearMonths())
                {
                    string monthCol = BuildMonthColumnName(ym.year, ym.month);
                    decimal value = ToDecimal(row[monthCol]);
                    if (value == 0) continue;

                    string sql = includeProductNo
                        ? $@"INSERT INTO {tableName}(PRODUCT_NO,DIE_NO,DIE_NAME,CAVITY,PLAN_YEAR,PLAN_MONTH,{valueColumn})
                            VALUES(@P,@D,@N,@C,@Y,@M,@V)"
                        : $@"INSERT INTO {tableName}(DIE_NO,DIE_NAME,CAVITY,PLAN_YEAR,PLAN_MONTH,{valueColumn})
                            VALUES(@D,@N,@C,@Y,@M,@V)";

                    var parameters = new List<SqlParameter>
                    {
                        new SqlParameter("@D", dieNo),
                        new SqlParameter("@N", Convert.ToString(row["DIE_NAME"] ?? string.Empty)),
                        new SqlParameter("@C", Convert.ToString(row["CAVITY"] ?? string.Empty)),
                        new SqlParameter("@Y", ym.year),
                        new SqlParameter("@M", ym.month),
                        new SqlParameter("@V", value)
                    };

                    if (includeProductNo)
                    {
                        parameters.Insert(0, new SqlParameter("@P", Convert.ToString(row["PRODUCT_NO"] ?? string.Empty)));
                    }

                    DBUtils.Exec(sql, parameters.ToArray());
                }
            }
        }

        private IEnumerable<(int year, int month)> YearMonths()
        {
            for (int year = StartYear; year <= EndYear; year++)
            {
                for (int month = 1; month <= 12; month++)
                {
                    yield return (year, month);
                }
            }
        }

        private string BuildMonthColumnName(int year, int month) => $"M{year}{month:00}";

        private int ToInt(object value) => int.TryParse(Convert.ToString(value), out int x) ? x : 0;
        private decimal ToDecimal(object value) => decimal.TryParse(Convert.ToString(value), out decimal x) ? x : 0;
    }
}
