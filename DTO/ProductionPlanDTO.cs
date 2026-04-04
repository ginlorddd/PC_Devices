using DM_OHD.DB;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DM_OHD.DTO
{
    public class ProductionPlanDTO
    {
        public DataTable GetPlanFY() => DBUtils.GetData("SELECT PRODUCT_NO, DIE_NO, DIE_NAME, CAVITY, PLAN_YEAR, PLAN_MONTH, FY_SHOTS FROM OHD_PLAN_FY ORDER BY PLAN_YEAR, PLAN_MONTH, DIE_NO");
        public DataTable GetMachineRatio() => DBUtils.GetData("SELECT DIE_NO, DIE_NAME, CAVITY, PLAN_YEAR, PLAN_MONTH, RUN_RATIO FROM OHD_MACHINE_RATIO ORDER BY PLAN_YEAR, PLAN_MONTH, DIE_NO");
        public DataTable GetDieOutput() => DBUtils.GetData("SELECT DIE_NO, DIE_NAME, CAVITY, PLAN_YEAR, PLAN_MONTH, OUTPUT_QTY FROM OHD_DIE_OUTPUT ORDER BY PLAN_YEAR, PLAN_MONTH, DIE_NO");
        public DataTable GetMaster() => DBUtils.GetData("SELECT DIE_NO, DIE_NAME, CAVITY, PLAN_YEAR, PLAN_MONTH, FY_SHOTS, RUN_RATIO, REQUIRED_QTY, OHD_MOC FROM OHD_PLAN_MASTER ORDER BY PLAN_YEAR, PLAN_MONTH, DIE_NO");

        public void SavePlanFY(DataTable dt)
        {
            DBUtils.Exec("DELETE FROM OHD_PLAN_FY");
            foreach (DataRow r in dt.Rows)
            {
                if (r.RowState == DataRowState.Deleted) continue;
                string dieNo = Convert.ToString(r["DIE_NO"]);
                if (string.IsNullOrWhiteSpace(dieNo)) continue;
                DBUtils.Exec(@"INSERT INTO OHD_PLAN_FY(PRODUCT_NO,DIE_NO,DIE_NAME,CAVITY,PLAN_YEAR,PLAN_MONTH,FY_SHOTS)
                               VALUES(@P,@D,@N,@C,@Y,@M,@S)",
                    new SqlParameter("@P", Convert.ToString(r["PRODUCT_NO"] ?? string.Empty)),
                    new SqlParameter("@D", dieNo),
                    new SqlParameter("@N", Convert.ToString(r["DIE_NAME"] ?? string.Empty)),
                    new SqlParameter("@C", ToInt(r["CAVITY"])),
                    new SqlParameter("@Y", ToInt(r["PLAN_YEAR"])),
                    new SqlParameter("@M", ToInt(r["PLAN_MONTH"])),
                    new SqlParameter("@S", ToDecimal(r["FY_SHOTS"])));
            }
        }

        public void SaveMachineRatio(DataTable dt)
        {
            DBUtils.Exec("DELETE FROM OHD_MACHINE_RATIO");
            foreach (DataRow r in dt.Rows)
            {
                if (r.RowState == DataRowState.Deleted) continue;
                string dieNo = Convert.ToString(r["DIE_NO"]);
                if (string.IsNullOrWhiteSpace(dieNo)) continue;
                DBUtils.Exec(@"INSERT INTO OHD_MACHINE_RATIO(DIE_NO,DIE_NAME,CAVITY,PLAN_YEAR,PLAN_MONTH,RUN_RATIO)
                               VALUES(@D,@N,@C,@Y,@M,@R)",
                    new SqlParameter("@D", dieNo),
                    new SqlParameter("@N", Convert.ToString(r["DIE_NAME"] ?? string.Empty)),
                    new SqlParameter("@C", ToInt(r["CAVITY"])),
                    new SqlParameter("@Y", ToInt(r["PLAN_YEAR"])),
                    new SqlParameter("@M", ToInt(r["PLAN_MONTH"])),
                    new SqlParameter("@R", ToDecimal(r["RUN_RATIO"])));
            }
        }

        public void SaveDieOutput(DataTable dt)
        {
            DBUtils.Exec("DELETE FROM OHD_DIE_OUTPUT");
            foreach (DataRow r in dt.Rows)
            {
                if (r.RowState == DataRowState.Deleted) continue;
                string dieNo = Convert.ToString(r["DIE_NO"]);
                if (string.IsNullOrWhiteSpace(dieNo)) continue;
                DBUtils.Exec(@"INSERT INTO OHD_DIE_OUTPUT(DIE_NO,DIE_NAME,CAVITY,PLAN_YEAR,PLAN_MONTH,OUTPUT_QTY)
                               VALUES(@D,@N,@C,@Y,@M,@Q)",
                    new SqlParameter("@D", dieNo),
                    new SqlParameter("@N", Convert.ToString(r["DIE_NAME"] ?? string.Empty)),
                    new SqlParameter("@C", ToInt(r["CAVITY"])),
                    new SqlParameter("@Y", ToInt(r["PLAN_YEAR"])),
                    new SqlParameter("@M", ToInt(r["PLAN_MONTH"])),
                    new SqlParameter("@Q", ToDecimal(r["OUTPUT_QTY"])));
            }
        }

        public void GenerateMasterPlan()
        {
            string sql = @"
                DELETE FROM OHD_PLAN_MASTER;
                INSERT INTO OHD_PLAN_MASTER(DIE_NO,DIE_NAME,CAVITY,PLAN_YEAR,PLAN_MONTH,FY_SHOTS,RUN_RATIO,REQUIRED_QTY,OHD_MOC)
                SELECT fy.DIE_NO,
                       ISNULL(fy.DIE_NAME,''),
                       ISNULL(fy.CAVITY,0),
                       fy.PLAN_YEAR,
                       fy.PLAN_MONTH,
                       ISNULL(fy.FY_SHOTS,0),
                       ISNULL(r.RUN_RATIO,0),
                       ROUND(ISNULL(fy.FY_SHOTS,0) * ISNULL(r.RUN_RATIO,0) / 100.0,0) AS REQUIRED_QTY,
                       CASE
                           WHEN ISNULL(fy.CAVITY,0) <= 0 THEN 0
                           ELSE
                               CASE
                                   WHEN FLOOR((ISNULL(fy.FY_SHOTS,0) * ISNULL(r.RUN_RATIO,0) / 100.0) / NULLIF(fy.CAVITY,0) / 30.0) * 30 > 240 THEN 240
                                   ELSE FLOOR((ISNULL(fy.FY_SHOTS,0) * ISNULL(r.RUN_RATIO,0) / 100.0) / NULLIF(fy.CAVITY,0) / 30.0) * 30
                               END
                       END AS OHD_MOC
                FROM OHD_PLAN_FY fy
                LEFT JOIN OHD_MACHINE_RATIO r ON fy.DIE_NO = r.DIE_NO AND fy.PLAN_YEAR=r.PLAN_YEAR AND fy.PLAN_MONTH=r.PLAN_MONTH;";
            DBUtils.Exec(sql);
        }

        private int ToInt(object value) => int.TryParse(Convert.ToString(value), out int x) ? x : 0;
        private decimal ToDecimal(object value) => decimal.TryParse(Convert.ToString(value), out decimal x) ? x : 0;
    }
}
