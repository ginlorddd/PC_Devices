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
            DataTable raw = DBUtils.GetData("SELECT f.PRODUCT_NO, f.DIE_NO, ISNULL(m.DIE_NAME,f.DIE_NAME) AS DIE_NAME, f.CAVITY, f.PLAN_YEAR, f.PLAN_MONTH, f.FY_SHOTS FROM OHD_PLAN_FY f INNER JOIN DIE_MST m ON f.DIE_NO = m.DIE_NO ORDER BY f.DIE_NO, f.CAVITY, f.PLAN_YEAR, f.PLAN_MONTH");
            return BuildWideTable(raw, "FY_SHOTS", includeProductNo: true);
        }

        public DataTable GetMachineRatio()
        {
            DataTable raw = DBUtils.GetData("SELECT r.DIE_NO, ISNULL(m.DIE_NAME,r.DIE_NAME) AS DIE_NAME, r.CAVITY, r.PLAN_YEAR, r.PLAN_MONTH, r.RUN_RATIO FROM OHD_MACHINE_RATIO r INNER JOIN DIE_MST m ON r.DIE_NO = m.DIE_NO ORDER BY r.DIE_NO, r.CAVITY, r.PLAN_YEAR, r.PLAN_MONTH");
            return BuildWideTable(raw, "RUN_RATIO");
        }

        public DataTable GetDieOutput()
        {
            DataTable raw = DBUtils.GetData("SELECT o.DIE_NO, ISNULL(m.DIE_NAME,o.DIE_NAME) AS DIE_NAME, o.CAVITY, o.PLAN_YEAR, o.PLAN_MONTH, o.OUTPUT_QTY FROM OHD_DIE_OUTPUT o INNER JOIN DIE_MST m ON o.DIE_NO = m.DIE_NO ORDER BY o.DIE_NO, o.CAVITY, o.PLAN_YEAR, o.PLAN_MONTH");
            return BuildWideTable(raw, "OUTPUT_QTY");
        }

        public DataTable GetMaster()
        {
            DataTable raw = DBUtils.GetData("SELECT p.DIE_NO, ISNULL(m.DIE_NAME,p.DIE_NAME) AS DIE_NAME, p.CAVITY AS CAVITY_DETAIL, ISNULL(m.TOTAL_CAVITY,0) AS TOTAL_CAVITY, p.PLAN_YEAR, p.PLAN_MONTH, p.FY_SHOTS, p.RUN_RATIO, p.REQUIRED_QTY, p.OHD_MOC FROM OHD_PLAN_MASTER p INNER JOIN DIE_MST m ON p.DIE_NO = m.DIE_NO ORDER BY p.DIE_NO, p.CAVITY, p.PLAN_YEAR, p.PLAN_MONTH");
            return BuildWideMasterTable(raw);
        }

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

                ;WITH src AS (
                    SELECT o.DIE_NO,
                           ISNULL(o.DIE_NAME,'') AS DIE_NAME,
                           ISNULL(o.CAVITY,'') AS CAVITY,
                           o.PLAN_YEAR,
                           o.PLAN_MONTH,
                           ISNULL(o.OUTPUT_QTY,0) AS MONTHLY_SHOTS,
                           ISNULL(r.RUN_RATIO,0) AS RUN_RATIO,
                           ISNULL(dm.TOTAL_CAVITY,0) AS TOTAL_CAVITY,
                           CASE
                               WHEN ISNULL(dm.TOTAL_CAVITY,0) <= 0 THEN 0
                               ELSE ISNULL(o.OUTPUT_QTY,0) / NULLIF(CONVERT(decimal(18,4), dm.TOTAL_CAVITY),0)
                           END AS SHOT_PER_CAVITY
                    FROM OHD_DIE_OUTPUT o
                    LEFT JOIN OHD_MACHINE_RATIO r ON o.DIE_NO = r.DIE_NO AND o.CAVITY = r.CAVITY AND o.PLAN_YEAR = r.PLAN_YEAR AND o.PLAN_MONTH = r.PLAN_MONTH
                    LEFT JOIN DIE_MST dm ON o.DIE_NO = dm.DIE_NO
                ), agg AS (
                    SELECT DIE_NO,
                           DIE_NAME,
                           CAVITY,
                           PLAN_YEAR,
                           PLAN_MONTH,
                           MONTHLY_SHOTS,
                           RUN_RATIO,
                           SUM(SHOT_PER_CAVITY) OVER(PARTITION BY DIE_NO, CAVITY ORDER BY PLAN_YEAR, PLAN_MONTH ROWS BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW) AS SHOT_CUMULATIVE
                    FROM src
                )
                INSERT INTO OHD_PLAN_MASTER(DIE_NO,DIE_NAME,CAVITY,PLAN_YEAR,PLAN_MONTH,FY_SHOTS,RUN_RATIO,REQUIRED_QTY,OHD_MOC)
                SELECT DIE_NO,
                       DIE_NAME,
                       CAVITY,
                       PLAN_YEAR,
                       PLAN_MONTH,
                       MONTHLY_SHOTS,
                       RUN_RATIO,
                       SHOT_CUMULATIVE,
                       CASE
                           WHEN SHOT_CUMULATIVE < 30000000 THEN 0
                           WHEN FLOOR(SHOT_CUMULATIVE / 30000000.0) * 30 > 240 THEN 240
                           ELSE FLOOR(SHOT_CUMULATIVE / 30000000.0) * 30
                       END AS OHD_MOC
                FROM agg;";
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


        private DataTable BuildWideMasterTable(DataTable raw)
        {
            DataTable wide = new DataTable();
            wide.Columns.Add("DIE_NO", typeof(string));
            wide.Columns.Add("DIE_NAME", typeof(string));
            wide.Columns.Add("CAVITY_DETAIL", typeof(string));
            wide.Columns.Add("TOTAL_CAVITY", typeof(int));
            wide.Columns.Add("QTY_TYPE", typeof(string));

            foreach (var ym in YearMonths())
            {
                wide.Columns.Add(BuildMonthColumnName(ym.year, ym.month), typeof(decimal));
            }

            var grouped = raw.AsEnumerable().GroupBy(r => (
                DieNo: Convert.ToString(r["DIE_NO"]),
                DieName: Convert.ToString(r["DIE_NAME"]),
                CavityDetail: Convert.ToString(r["CAVITY_DETAIL"]),
                TotalCavity: ToInt(r["TOTAL_CAVITY"]) ));

            foreach (var g in grouped)
            {
                AddMasterTypeRow(wide, g, "FY_SHOTS", "Số shot SX theo FY");
                AddMasterTypeRow(wide, g, "REQUIRED_QTY", "Shot cộng dồn qua tháng");
                AddMasterTypeRow(wide, g, "OHD_MOC", "Mốc OHD");
            }

            return wide;
        }

        private void AddMasterTypeRow(DataTable target, IGrouping<(string DieNo, string DieName, string CavityDetail, int TotalCavity), DataRow> group, string valueField, string qtyType)
        {
            DataRow row = target.NewRow();
            row["DIE_NO"] = group.Key.DieNo;
            row["DIE_NAME"] = group.Key.DieName;
            row["CAVITY_DETAIL"] = group.Key.CavityDetail;
            row["TOTAL_CAVITY"] = group.Key.TotalCavity;
            row["QTY_TYPE"] = qtyType;

            foreach (DataRow src in group)
            {
                int y = ToInt(src["PLAN_YEAR"]);
                int m = ToInt(src["PLAN_MONTH"]);
                string col = BuildMonthColumnName(y, m);
                if (target.Columns.Contains(col)) row[col] = ToDecimal(src[valueField]);
            }

            target.Rows.Add(row);
        }

        private void SaveWideTable(DataTable wideTable, string tableName, string valueColumn, bool includeProductNo = false)
        {
            DBUtils.Exec($"DELETE FROM {tableName}");
            if (wideTable == null) return;
            HashSet<string> validDieNoSet = GetValidDieNoSet();

            foreach (DataRow row in wideTable.Rows)
            {
                if (row.RowState == DataRowState.Deleted) continue;
                string dieNo = Convert.ToString(row["DIE_NO"]);
                if (string.IsNullOrWhiteSpace(dieNo)) continue;
                if (!validDieNoSet.Contains(dieNo)) continue;

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

        private HashSet<string> GetValidDieNoSet()
        {
            DataTable dt = DBUtils.GetData("SELECT DIE_NO FROM DIE_MST");
            var set = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (DataRow row in dt.Rows)
            {
                string dieNo = Convert.ToString(row["DIE_NO"]);
                if (!string.IsNullOrWhiteSpace(dieNo)) set.Add(dieNo);
            }
            return set;
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
