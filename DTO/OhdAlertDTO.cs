using DM_OHD.DB;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DM_OHD.DTO
{
    public class OhdAlertDTO
    {
        public DataTable GetProgress(DateTime from, DateTime to)
        {
            return DBUtils.GetData(@"SELECT ID,
                                           DIE_NO,
                                           DIE_NAME,
                                           TOTAL_CAVITY,
                                           NEXT_OHD_MOC,
                                           TRACK_START_DATE,
                                           ALERT_CONTENT,
                                           ALERT_BG_COLOR,
                                           ALERT_FG_COLOR,
                                           REVIEW_NOTE,
                                           OWNER_USER_ID,
                                           COMPLETED_AT,
                                           APPROVED,
                                           APPROVED_AT
                                    FROM OHD_ALERT_PROGRESS
                                    WHERE CAST(TRACK_START_DATE AS date) BETWEEN @F AND @T
                                    ORDER BY APPROVED ASC, TRACK_START_DATE, DIE_NO",
                new SqlParameter("@F", from.Date),
                new SqlParameter("@T", to.Date));
        }

        public DataTable GetRules()
        {
            return DBUtils.GetData(@"SELECT ID,
                                           OWNER_USER_ID,
                                           ALERT_CONTENT,
                                           ALERT_BG_COLOR,
                                           ALERT_FG_COLOR,
                                           DUE_DAYS_30,
                                           DUE_DAYS_60,
                                           DUE_DAYS_90,
                                           DUE_DAYS_120,
                                           DUE_DAYS_150,
                                           DUE_DAYS_180,
                                           DUE_DAYS_210,
                                           DUE_DAYS_240,
                                           USE_MONTH_FIRST_DAY,
                                           EXACT_DAY_IN_MONTH
                                    FROM OHD_ALERT_RULE
                                    ORDER BY ID");
        }

        public DataTable GetUsers()
        {
            return DBUtils.GetData("SELECT USER_ID, FULL_NAME, EMAIL FROM APP_USER WHERE IS_ACTIVE = 1 ORDER BY USER_ID");
        }

        public void SaveRules(DataTable dt)
        {
            if (dt == null) return;
            foreach (DataRow row in dt.Rows)
            {
                if (row.RowState == DataRowState.Deleted) continue;
                int id = ToInt(row["ID"]);
                if (id <= 0) continue;
                DBUtils.Exec(@"UPDATE OHD_ALERT_RULE
                               SET OWNER_USER_ID=@U,
                                   ALERT_CONTENT=@C,
                                   DUE_DAYS_30=@D30,
                                   DUE_DAYS_60=@D60,
                                   DUE_DAYS_90=@D90,
                                   DUE_DAYS_120=@D120,
                                   DUE_DAYS_150=@D150,
                                   DUE_DAYS_180=@D180,
                                   DUE_DAYS_210=@D210,
                                   DUE_DAYS_240=@D240,
                                   ALERT_BG_COLOR=@BG,
                                   ALERT_FG_COLOR=@FG,
                                   USE_MONTH_FIRST_DAY=@M1,
                                   EXACT_DAY_IN_MONTH=@EX
                               WHERE ID=@ID",
                    new SqlParameter("@U", Convert.ToString(row["OWNER_USER_ID"] ?? string.Empty)),
                    new SqlParameter("@C", Convert.ToString(row["ALERT_CONTENT"] ?? string.Empty)),
                    new SqlParameter("@D30", ToInt(row["DUE_DAYS_30"])),
                    new SqlParameter("@D60", ToInt(row["DUE_DAYS_60"])),
                    new SqlParameter("@D90", ToInt(row["DUE_DAYS_90"])),
                    new SqlParameter("@D120", ToInt(row["DUE_DAYS_120"])),
                    new SqlParameter("@D150", ToInt(row["DUE_DAYS_150"])),
                    new SqlParameter("@D180", ToInt(row["DUE_DAYS_180"])),
                    new SqlParameter("@D210", ToInt(row["DUE_DAYS_210"])),
                    new SqlParameter("@D240", ToInt(row["DUE_DAYS_240"])),
                    new SqlParameter("@BG", Convert.ToString(row["ALERT_BG_COLOR"] ?? "#FFF3CD")),
                    new SqlParameter("@FG", Convert.ToString(row["ALERT_FG_COLOR"] ?? "#7A4E00")),
                    new SqlParameter("@M1", ToBool(row["USE_MONTH_FIRST_DAY"])),
                    new SqlParameter("@EX", ToNullableInt(row["EXACT_DAY_IN_MONTH"])),
                    new SqlParameter("@ID", id));
            }
        }

        public DataTable GetMailConfig()
        {
            return DBUtils.GetData("SELECT TOP 1 ID, MAIL_TO, MAIL_CC, SUBJECT_TEMPLATE, BODY_TEMPLATE, SEND_FREQUENCY_DAYS, ENABLED FROM OHD_MAIL_CONFIG ORDER BY ID");
        }

        public void SaveMailConfig(string to, string cc, string subject, string body, int frequencyDays, bool enabled)
        {
            DBUtils.Exec(@"IF EXISTS(SELECT 1 FROM OHD_MAIL_CONFIG)
                               UPDATE OHD_MAIL_CONFIG
                               SET MAIL_TO=@T, MAIL_CC=@CC, SUBJECT_TEMPLATE=@S, BODY_TEMPLATE=@B, SEND_FREQUENCY_DAYS=@F, ENABLED=@E
                               WHERE ID=(SELECT TOP 1 ID FROM OHD_MAIL_CONFIG ORDER BY ID)
                           ELSE
                               INSERT INTO OHD_MAIL_CONFIG(MAIL_TO,MAIL_CC,SUBJECT_TEMPLATE,BODY_TEMPLATE,SEND_FREQUENCY_DAYS,ENABLED)
                               VALUES(@T,@CC,@S,@B,@F,@E)",
                new SqlParameter("@T", to ?? string.Empty),
                new SqlParameter("@CC", cc ?? string.Empty),
                new SqlParameter("@S", subject ?? string.Empty),
                new SqlParameter("@B", body ?? string.Empty),
                new SqlParameter("@F", Math.Max(1, frequencyDays)),
                new SqlParameter("@E", enabled));
        }

        public void ApproveProgress(int id, string reviewNote)
        {
            DBUtils.Exec(@"UPDATE OHD_ALERT_PROGRESS
                           SET APPROVED=1,
                               APPROVED_AT=GETDATE(),
                               REVIEW_NOTE=@N,
                               COMPLETED_AT=ISNULL(COMPLETED_AT, GETDATE())
                           WHERE ID=@ID",
                new SqlParameter("@N", reviewNote ?? string.Empty),
                new SqlParameter("@ID", id));
        }

        public void SaveProgress(DataTable dt)
        {
            if (dt == null) return;
            foreach (DataRow row in dt.Rows)
            {
                if (row.RowState == DataRowState.Deleted) continue;
                int id = ToInt(row["ID"]);
                if (id <= 0) continue;
                bool approved = ToBool(row["APPROVED"]);
                DateTime? completed = row["COMPLETED_AT"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["COMPLETED_AT"]);
                DBUtils.Exec(@"UPDATE OHD_ALERT_PROGRESS
                               SET REVIEW_NOTE=@N,
                                   OWNER_USER_ID=@U,
                                   APPROVED=@A,
                                   APPROVED_AT=CASE WHEN @A=1 THEN ISNULL(APPROVED_AT,GETDATE()) ELSE NULL END,
                                   COMPLETED_AT=@C
                               WHERE ID=@ID",
                    new SqlParameter("@N", Convert.ToString(row["REVIEW_NOTE"] ?? string.Empty)),
                    new SqlParameter("@U", Convert.ToString(row["OWNER_USER_ID"] ?? string.Empty)),
                    new SqlParameter("@A", approved),
                    new SqlParameter("@C", (object)completed ?? DBNull.Value),
                    new SqlParameter("@ID", id));
            }
        }

        public int RefreshProgressFromPlan()
        {
            return DBUtils.Exec(@";WITH src AS (
                                    SELECT p.DIE_NO,
                                           ISNULL(p.DIE_NAME,'') AS DIE_NAME,
                                           ISNULL(p.TOTAL_CAVITY,0) AS TOTAL_CAVITY,
                                           p.OHD_MOC,
                                           DATEFROMPARTS(p.PLAN_YEAR, p.PLAN_MONTH, 1) AS TRACK_DATE
                                    FROM OHD_PLAN_MASTER p
                                    WHERE p.OHD_MOC > 0
                                  )
                                  INSERT INTO OHD_ALERT_PROGRESS(DIE_NO,DIE_NAME,TOTAL_CAVITY,NEXT_OHD_MOC,TRACK_START_DATE,ALERT_CONTENT,ALERT_BG_COLOR,ALERT_FG_COLOR,REVIEW_NOTE,OWNER_USER_ID,APPROVED)
                                  SELECT s.DIE_NO,
                                         s.DIE_NAME,
                                         s.TOTAL_CAVITY,
                                         s.OHD_MOC,
                                         s.TRACK_DATE,
                                         ISNULL(r.ALERT_CONTENT,N'Theo dõi mốc OHD'),
                                         ISNULL(r.ALERT_BG_COLOR,'#FFF3CD'),
                                         ISNULL(r.ALERT_FG_COLOR,'#7A4E00'),
                                         N'Chưa hoàn thành',
                                         ISNULL(r.OWNER_USER_ID,'admin'),
                                         0
                                  FROM src s
                                  OUTER APPLY (
                                      SELECT TOP 1 OWNER_USER_ID, ALERT_CONTENT, ALERT_BG_COLOR, ALERT_FG_COLOR
                                      FROM OHD_ALERT_RULE
                                      ORDER BY ID
                                  ) r
                                  WHERE NOT EXISTS (
                                      SELECT 1
                                      FROM OHD_ALERT_PROGRESS p
                                      WHERE p.DIE_NO = s.DIE_NO
                                        AND p.NEXT_OHD_MOC = s.OHD_MOC
                                        AND CAST(p.TRACK_START_DATE AS date) = CAST(s.TRACK_DATE AS date)
                                  );");
        }

        private int ToInt(object value) => int.TryParse(Convert.ToString(value), out int x) ? x : 0;
        private object ToNullableInt(object value)
        {
            int x = ToInt(value);
            return x <= 0 ? (object)DBNull.Value : x;
        }
        private bool ToBool(object value)
        {
            if (value == DBNull.Value || value == null) return false;
            if (value is bool b) return b;
            return Convert.ToString(value) == "1" || Convert.ToString(value).Equals("true", StringComparison.OrdinalIgnoreCase);
        }
    }
}
