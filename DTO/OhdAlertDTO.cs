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
                                           DUE_DATE,
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

        public DataTable GetObsoleteProgressRows()
        {
            return DBUtils.GetData(@";WITH src AS (
                                        SELECT p.DIE_NO,
                                               p.OHD_MOC,
                                               CAST(DATEFROMPARTS(p.PLAN_YEAR, p.PLAN_MONTH, 1) AS date) AS TRACK_DATE
                                        FROM OHD_PLAN_MASTER p
                                        WHERE p.OHD_MOC > 0
                                     )
                                     SELECT pr.ID,
                                            pr.DIE_NO,
                                            pr.DIE_NAME,
                                            pr.NEXT_OHD_MOC,
                                            pr.TRACK_START_DATE
                                     FROM OHD_ALERT_PROGRESS pr
                                     WHERE NOT EXISTS (
                                        SELECT 1
                                        FROM src s
                                        WHERE s.DIE_NO = pr.DIE_NO
                                          AND s.OHD_MOC = pr.NEXT_OHD_MOC
                                          AND s.TRACK_DATE = CAST(pr.TRACK_START_DATE AS date)
                                     )
                                     ORDER BY pr.DIE_NO, pr.TRACK_START_DATE, pr.NEXT_OHD_MOC");
        }

        public int DeleteProgressByIds(DataTable ids)
        {
            if (ids == null || ids.Rows.Count == 0) return 0;
            int affected = 0;
            foreach (DataRow row in ids.Rows)
            {
                int id = ToInt(row["ID"]);
                if (id <= 0) continue;
                affected += DBUtils.Exec("DELETE FROM OHD_ALERT_PROGRESS WHERE ID=@ID", new SqlParameter("@ID", id));
            }
            return affected;
        }

        public DataTable GetRules()
        {
            EnsureRuleWorkflowColumns();
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
                                           EXACT_DAY_IN_MONTH,
                                           SEND_MAIL_AFTER_FINAL_DONE,
                                           MAIL_DELAY_DAYS,
                                           RULE_NOTE
                                    FROM OHD_ALERT_RULE
                                    ORDER BY ID");
        }

        public DataTable GetUsers()
        {
            return DBUtils.GetData("SELECT USER_ID, FULL_NAME, EMAIL FROM APP_USER WHERE IS_ACTIVE = 1 ORDER BY USER_ID");
        }

        public void SaveRules(DataTable dt)
        {
            EnsureRuleWorkflowColumns();
            if (dt == null) return;
            foreach (DataRow row in dt.Rows)
            {
                if (row.RowState == DataRowState.Deleted)
                {
                    int deletedId = ToInt(row["ID", DataRowVersion.Original]);
                    if (deletedId > 0)
                    {
                        string deletedContent = Convert.ToString(row["ALERT_CONTENT", DataRowVersion.Original] ?? string.Empty);
                        DBUtils.Exec("DELETE FROM OHD_ALERT_PROGRESS WHERE ISNULL(APPROVED,0)=0 AND ALERT_CONTENT=@C", new SqlParameter("@C", deletedContent));
                        DBUtils.Exec("DELETE FROM OHD_ALERT_RULE WHERE ID=@ID", new SqlParameter("@ID", deletedId));
                    }
                    continue;
                }

                string owner = Convert.ToString(row["OWNER_USER_ID"] ?? string.Empty).Trim();
                string content = Convert.ToString(row["ALERT_CONTENT"] ?? string.Empty).Trim();
                if (string.IsNullOrWhiteSpace(content)) continue;

                int id = ToInt(row["ID"]);
                if (id <= 0)
                {
                    DBUtils.Exec(@"INSERT INTO OHD_ALERT_RULE(OWNER_USER_ID,ALERT_CONTENT,DUE_DAYS_30,DUE_DAYS_60,DUE_DAYS_90,DUE_DAYS_120,DUE_DAYS_150,DUE_DAYS_180,DUE_DAYS_210,DUE_DAYS_240,ALERT_BG_COLOR,ALERT_FG_COLOR,USE_MONTH_FIRST_DAY,EXACT_DAY_IN_MONTH,SEND_MAIL_AFTER_FINAL_DONE,MAIL_DELAY_DAYS,RULE_NOTE)
                                   VALUES(@U,@C,@D30,@D60,@D90,@D120,@D150,@D180,@D210,@D240,@BG,@FG,@M1,@EX,@MAIL,@DELAY,@NOTE)",
                        new SqlParameter("@U", owner),
                        new SqlParameter("@C", content),
                        new SqlParameter("@D30", ToInt(row["DUE_DAYS_30"])),
                        new SqlParameter("@D60", ToInt(row["DUE_DAYS_60"])),
                        new SqlParameter("@D90", ToInt(row["DUE_DAYS_90"])),
                        new SqlParameter("@D120", ToInt(row["DUE_DAYS_120"])),
                        new SqlParameter("@D150", ToInt(row["DUE_DAYS_150"])),
                        new SqlParameter("@D180", ToInt(row["DUE_DAYS_180"])),
                        new SqlParameter("@D210", ToInt(row["DUE_DAYS_210"])),
                        new SqlParameter("@D240", ToInt(row["DUE_DAYS_240"])),
                        new SqlParameter("@BG", NormalizeColor(row["ALERT_BG_COLOR"], "#FFF3CD")),
                        new SqlParameter("@FG", NormalizeColor(row["ALERT_FG_COLOR"], "#7A4E00")),
                        new SqlParameter("@M1", ToBool(row["USE_MONTH_FIRST_DAY"])),
                        new SqlParameter("@EX", ToNullableInt(row["EXACT_DAY_IN_MONTH"])),
                        new SqlParameter("@MAIL", ToBool(row["SEND_MAIL_AFTER_FINAL_DONE"])),
                        new SqlParameter("@DELAY", Math.Max(0, ToInt(row["MAIL_DELAY_DAYS"]))),
                        new SqlParameter("@NOTE", Convert.ToString(row["RULE_NOTE"] ?? string.Empty)));
                    continue;
                }

                string originalContent = row.RowState == DataRowState.Modified ? Convert.ToString(row["ALERT_CONTENT", DataRowVersion.Original] ?? string.Empty) : content;

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
                                   EXACT_DAY_IN_MONTH=@EX,
                                   SEND_MAIL_AFTER_FINAL_DONE=@MAIL,
                                   MAIL_DELAY_DAYS=@DELAY,
                                   RULE_NOTE=@NOTE
                               WHERE ID=@ID",
                    new SqlParameter("@U", owner),
                    new SqlParameter("@C", content),
                    new SqlParameter("@D30", ToInt(row["DUE_DAYS_30"])),
                    new SqlParameter("@D60", ToInt(row["DUE_DAYS_60"])),
                    new SqlParameter("@D90", ToInt(row["DUE_DAYS_90"])),
                    new SqlParameter("@D120", ToInt(row["DUE_DAYS_120"])),
                    new SqlParameter("@D150", ToInt(row["DUE_DAYS_150"])),
                    new SqlParameter("@D180", ToInt(row["DUE_DAYS_180"])),
                    new SqlParameter("@D210", ToInt(row["DUE_DAYS_210"])),
                    new SqlParameter("@D240", ToInt(row["DUE_DAYS_240"])),
                    new SqlParameter("@BG", NormalizeColor(row["ALERT_BG_COLOR"], "#FFF3CD")),
                    new SqlParameter("@FG", NormalizeColor(row["ALERT_FG_COLOR"], "#7A4E00")),
                    new SqlParameter("@M1", ToBool(row["USE_MONTH_FIRST_DAY"])),
                    new SqlParameter("@EX", ToNullableInt(row["EXACT_DAY_IN_MONTH"])),
                    new SqlParameter("@MAIL", ToBool(row["SEND_MAIL_AFTER_FINAL_DONE"])),
                    new SqlParameter("@DELAY", Math.Max(0, ToInt(row["MAIL_DELAY_DAYS"]))),
                    new SqlParameter("@NOTE", Convert.ToString(row["RULE_NOTE"] ?? string.Empty)),
                    new SqlParameter("@ID", id));

                if (!string.Equals(originalContent, content, StringComparison.Ordinal))
                {
                    DBUtils.Exec(@"UPDATE OHD_ALERT_PROGRESS
                                   SET ALERT_CONTENT=@NEW
                                   WHERE ISNULL(APPROVED,0)=0 AND ALERT_CONTENT=@OLD",
                        new SqlParameter("@NEW", content),
                        new SqlParameter("@OLD", originalContent));
                }
            }
        }

        public int ApplyRulesToAllProgress()
        {
            if (HasFullDueRuleColumns())
            {
                return DBUtils.Exec(@";WITH map_rule AS (
                                        SELECT p.ID,
                                               r.OWNER_USER_ID,
                                               r.ALERT_CONTENT,
                                               r.ALERT_BG_COLOR,
                                               r.ALERT_FG_COLOR,
                                               CASE
                                                   WHEN p.NEXT_OHD_MOC IS NULL OR p.NEXT_OHD_MOC <= 0 THEN NULL
                                                   ELSE (((p.NEXT_OHD_MOC - 1) % 240) + 1)
                                               END AS NORMALIZED_MOC,
                                               CASE
                                                   WHEN (((p.NEXT_OHD_MOC - 1) % 240) + 1) BETWEEN 1 AND 30 THEN r.DUE_DAYS_30
                                                   WHEN (((p.NEXT_OHD_MOC - 1) % 240) + 1) BETWEEN 31 AND 60 THEN r.DUE_DAYS_60
                                                   WHEN (((p.NEXT_OHD_MOC - 1) % 240) + 1) BETWEEN 61 AND 90 THEN r.DUE_DAYS_90
                                                   WHEN (((p.NEXT_OHD_MOC - 1) % 240) + 1) BETWEEN 91 AND 120 THEN r.DUE_DAYS_120
                                                   WHEN (((p.NEXT_OHD_MOC - 1) % 240) + 1) BETWEEN 121 AND 150 THEN r.DUE_DAYS_150
                                                   WHEN (((p.NEXT_OHD_MOC - 1) % 240) + 1) BETWEEN 151 AND 180 THEN r.DUE_DAYS_180
                                                   WHEN (((p.NEXT_OHD_MOC - 1) % 240) + 1) BETWEEN 181 AND 210 THEN r.DUE_DAYS_210
                                                   WHEN (((p.NEXT_OHD_MOC - 1) % 240) + 1) BETWEEN 211 AND 240 THEN r.DUE_DAYS_240
                                                   ELSE NULL
                                               END AS DUE_DAYS
                                        FROM OHD_ALERT_PROGRESS p
                                        OUTER APPLY (
                                            SELECT TOP 1 rr.OWNER_USER_ID,
                                                         rr.ALERT_CONTENT,
                                                         rr.ALERT_BG_COLOR,
                                                         rr.ALERT_FG_COLOR,
                                                         rr.DUE_DAYS_30,
                                                         rr.DUE_DAYS_60,
                                                         rr.DUE_DAYS_90,
                                                         rr.DUE_DAYS_120,
                                                         rr.DUE_DAYS_150,
                                                         rr.DUE_DAYS_180,
                                                         rr.DUE_DAYS_210,
                                                         rr.DUE_DAYS_240
                                            FROM OHD_ALERT_RULE rr
                                            ORDER BY CASE WHEN ISNULL(rr.ALERT_CONTENT,'') = ISNULL(p.ALERT_CONTENT,'') THEN 0 ELSE 1 END, rr.ID
                                        ) r
                                        WHERE r.ALERT_CONTENT IS NOT NULL
                                      )
                                      UPDATE p
                                      SET p.OWNER_USER_ID = m.OWNER_USER_ID,
                                          p.ALERT_CONTENT = m.ALERT_CONTENT,
                                          p.ALERT_BG_COLOR = m.ALERT_BG_COLOR,
                                          p.ALERT_FG_COLOR = m.ALERT_FG_COLOR,
                                          p.DUE_DATE = CASE WHEN m.DUE_DAYS IS NULL THEN NULL ELSE DATEADD(day, -m.DUE_DAYS, CAST(p.TRACK_START_DATE AS date)) END
                                      FROM OHD_ALERT_PROGRESS p
                                      INNER JOIN map_rule m ON p.ID = m.ID
                                      WHERE ISNULL(p.OWNER_USER_ID,'') <> ISNULL(m.OWNER_USER_ID,'')
                                         OR ISNULL(p.ALERT_CONTENT,'') <> ISNULL(m.ALERT_CONTENT,'')
                                         OR ISNULL(p.ALERT_BG_COLOR,'') <> ISNULL(m.ALERT_BG_COLOR,'')
                                         OR ISNULL(p.ALERT_FG_COLOR,'') <> ISNULL(m.ALERT_FG_COLOR,'')
                                         OR ISNULL(CONVERT(varchar(10), p.DUE_DATE, 23),'') <> ISNULL(CONVERT(varchar(10), CASE WHEN m.DUE_DAYS IS NULL THEN NULL ELSE DATEADD(day, -m.DUE_DAYS, CAST(p.TRACK_START_DATE AS date)) END, 23),'');");
            }

            return DBUtils.Exec(@";WITH map_rule AS (
                                    SELECT p.ID,
                                           r.OWNER_USER_ID,
                                           r.ALERT_CONTENT,
                                           r.ALERT_BG_COLOR,
                                           r.ALERT_FG_COLOR
                                    FROM OHD_ALERT_PROGRESS p
                                    OUTER APPLY (
                                        SELECT TOP 1 rr.OWNER_USER_ID,
                                                     rr.ALERT_CONTENT,
                                                     rr.ALERT_BG_COLOR,
                                                     rr.ALERT_FG_COLOR
                                        FROM OHD_ALERT_RULE rr
                                        ORDER BY rr.ID
                                    ) r
                                    WHERE r.ALERT_CONTENT IS NOT NULL
                                  )
                                  UPDATE p
                                  SET p.OWNER_USER_ID = m.OWNER_USER_ID,
                                      p.ALERT_CONTENT = m.ALERT_CONTENT,
                                      p.ALERT_BG_COLOR = m.ALERT_BG_COLOR,
                                      p.ALERT_FG_COLOR = m.ALERT_FG_COLOR,
                                      p.DUE_DATE = NULL
                                  FROM OHD_ALERT_PROGRESS p
                                  INNER JOIN map_rule m ON p.ID = m.ID
                                  WHERE ISNULL(p.OWNER_USER_ID,'') <> ISNULL(m.OWNER_USER_ID,'')
                                     OR ISNULL(p.ALERT_CONTENT,'') <> ISNULL(m.ALERT_CONTENT,'')
                                     OR ISNULL(p.ALERT_BG_COLOR,'') <> ISNULL(m.ALERT_BG_COLOR,'')
                                     OR ISNULL(p.ALERT_FG_COLOR,'') <> ISNULL(m.ALERT_FG_COLOR,'')
                                     OR p.DUE_DATE IS NOT NULL;");
        }

        private bool HasFullDueRuleColumns()
        {
            object count = DBUtils.ExecScalar(@"SELECT COUNT(1)
                                                FROM sys.columns
                                                WHERE object_id = OBJECT_ID('dbo.OHD_ALERT_RULE')
                                                  AND name IN ('DUE_DAYS_30','DUE_DAYS_60','DUE_DAYS_90','DUE_DAYS_120','DUE_DAYS_150','DUE_DAYS_180','DUE_DAYS_210','DUE_DAYS_240')");
            return Convert.ToInt32(count) == 8;
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

        public int ApplyPostFinalCompletionMailRules()
        {
            EnsureRuleWorkflowColumns();
            return DBUtils.Exec(@";WITH final_done AS (
                                    SELECT DIE_NO,
                                           NEXT_OHD_MOC,
                                           CAST(TRACK_START_DATE AS date) AS TRACK_DATE,
                                           MAX(COMPLETED_AT) AS FINAL_COMPLETED_AT
                                    FROM OHD_ALERT_PROGRESS
                                    WHERE ISNULL(APPROVED,0)=1
                                      AND COMPLETED_AT IS NOT NULL
                                      AND ALERT_CONTENT = N'Hoàn thiện part'
                                    GROUP BY DIE_NO, NEXT_OHD_MOC, CAST(TRACK_START_DATE AS date)
                                  ), mail_rule AS (
                                    SELECT OWNER_USER_ID,
                                           ALERT_CONTENT,
                                           ALERT_BG_COLOR,
                                           ALERT_FG_COLOR,
                                           MAIL_DELAY_DAYS,
                                           RULE_NOTE
                                    FROM OHD_ALERT_RULE
                                    WHERE ISNULL(SEND_MAIL_AFTER_FINAL_DONE,0)=1
                                  )
                                  UPDATE p
                                  SET p.OWNER_USER_ID = r.OWNER_USER_ID,
                                      p.ALERT_BG_COLOR = r.ALERT_BG_COLOR,
                                      p.ALERT_FG_COLOR = r.ALERT_FG_COLOR,
                                      p.DUE_DATE = DATEADD(day, ISNULL(r.MAIL_DELAY_DAYS,1), CAST(f.FINAL_COMPLETED_AT AS date)),
                                      p.REVIEW_NOTE = CASE
                                            WHEN ISNULL(p.APPROVED,0)=1 THEN p.REVIEW_NOTE
                                            ELSE ISNULL(NULLIF(r.RULE_NOTE,''), N'Chờ gửi mail sau khi Hoàn thiện part được xác nhận OK')
                                      END
                                  FROM OHD_ALERT_PROGRESS p
                                  INNER JOIN mail_rule r ON ISNULL(p.ALERT_CONTENT,'') = ISNULL(r.ALERT_CONTENT,'')
                                  INNER JOIN final_done f ON f.DIE_NO = p.DIE_NO
                                                         AND f.NEXT_OHD_MOC = p.NEXT_OHD_MOC
                                                         AND f.TRACK_DATE = CAST(p.TRACK_START_DATE AS date)
                                  WHERE ISNULL(CONVERT(varchar(10), p.DUE_DATE, 23),'') <> ISNULL(CONVERT(varchar(10), DATEADD(day, ISNULL(r.MAIL_DELAY_DAYS,1), CAST(f.FINAL_COMPLETED_AT AS date)), 23),'')
                                     OR ISNULL(p.OWNER_USER_ID,'') <> ISNULL(r.OWNER_USER_ID,'')
                                     OR ISNULL(p.ALERT_BG_COLOR,'') <> ISNULL(r.ALERT_BG_COLOR,'')
                                     OR ISNULL(p.ALERT_FG_COLOR,'') <> ISNULL(r.ALERT_FG_COLOR,'')
                                     OR (ISNULL(p.APPROVED,0)=0 AND ISNULL(p.REVIEW_NOTE,'') <> ISNULL(NULLIF(r.RULE_NOTE,''), N'Chờ gửi mail sau khi Hoàn thiện part được xác nhận OK'));");
        }

        public int RefreshProgressFromPlan()
        {
            EnsureRuleWorkflowColumns();
            return DBUtils.Exec(@";WITH src AS (
                                    SELECT p.DIE_NO,
                                           ISNULL(p.DIE_NAME,'') AS DIE_NAME,
                                           ISNULL(p.TOTAL_CAVITY,0) AS TOTAL_CAVITY,
                                           p.OHD_MOC,
                                           DATEFROMPARTS(p.PLAN_YEAR, p.PLAN_MONTH, 1) AS TRACK_DATE,
                                           CASE
                                               WHEN p.OHD_MOC IS NULL OR p.OHD_MOC <= 0 THEN NULL
                                               ELSE (((p.OHD_MOC - 1) % 240) + 1)
                                           END AS CYCLE_MOC
                                    FROM OHD_PLAN_MASTER p
                                    WHERE p.OHD_MOC > 0
                                  ), rule_src AS (
                                    SELECT r.ID,
                                           ISNULL(r.OWNER_USER_ID,'admin') AS OWNER_USER_ID,
                                           ISNULL(r.ALERT_CONTENT,N'Theo dõi mốc OHD') AS ALERT_CONTENT,
                                           ISNULL(r.ALERT_BG_COLOR,'#FFF3CD') AS ALERT_BG_COLOR,
                                           ISNULL(r.ALERT_FG_COLOR,'#7A4E00') AS ALERT_FG_COLOR,
                                           r.DUE_DAYS_30,
                                           r.DUE_DAYS_60,
                                           r.DUE_DAYS_90,
                                           r.DUE_DAYS_120,
                                           r.DUE_DAYS_150,
                                           r.DUE_DAYS_180,
                                           r.DUE_DAYS_210,
                                           r.DUE_DAYS_240
                                    FROM OHD_ALERT_RULE r
                                    UNION ALL
                                    SELECT 0 AS ID,
                                           'admin' AS OWNER_USER_ID,
                                           N'Theo dõi mốc OHD' AS ALERT_CONTENT,
                                           '#FFF3CD' AS ALERT_BG_COLOR,
                                           '#7A4E00' AS ALERT_FG_COLOR,
                                           NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL
                                    WHERE NOT EXISTS (SELECT 1 FROM OHD_ALERT_RULE)
                                  )
                                  INSERT INTO OHD_ALERT_PROGRESS(DIE_NO,DIE_NAME,TOTAL_CAVITY,NEXT_OHD_MOC,TRACK_START_DATE,DUE_DATE,ALERT_CONTENT,ALERT_BG_COLOR,ALERT_FG_COLOR,REVIEW_NOTE,OWNER_USER_ID,APPROVED)
                                  SELECT s.DIE_NO,
                                         s.DIE_NAME,
                                         s.TOTAL_CAVITY,
                                         s.OHD_MOC,
                                         s.TRACK_DATE,
                                         CASE
                                            WHEN due_info.DUE_DAYS IS NULL THEN NULL
                                            ELSE DATEADD(day, -due_info.DUE_DAYS, CAST(s.TRACK_DATE AS date))
                                         END AS DUE_DATE,
                                         r.ALERT_CONTENT,
                                         r.ALERT_BG_COLOR,
                                         r.ALERT_FG_COLOR,
                                         N'Chưa hoàn thành',
                                         r.OWNER_USER_ID,
                                         0
                                  FROM src s
                                  INNER JOIN rule_src r ON 1 = 1
                                  OUTER APPLY (
                                      SELECT CASE
                                          WHEN s.CYCLE_MOC BETWEEN 1 AND 30 THEN r.DUE_DAYS_30
                                          WHEN s.CYCLE_MOC BETWEEN 31 AND 60 THEN r.DUE_DAYS_60
                                          WHEN s.CYCLE_MOC BETWEEN 61 AND 90 THEN r.DUE_DAYS_90
                                          WHEN s.CYCLE_MOC BETWEEN 91 AND 120 THEN r.DUE_DAYS_120
                                          WHEN s.CYCLE_MOC BETWEEN 121 AND 150 THEN r.DUE_DAYS_150
                                          WHEN s.CYCLE_MOC BETWEEN 151 AND 180 THEN r.DUE_DAYS_180
                                          WHEN s.CYCLE_MOC BETWEEN 181 AND 210 THEN r.DUE_DAYS_210
                                          WHEN s.CYCLE_MOC BETWEEN 211 AND 240 THEN r.DUE_DAYS_240
                                          ELSE NULL
                                      END AS DUE_DAYS
                                  ) due_info
                                  WHERE NOT EXISTS (
                                      SELECT 1
                                      FROM OHD_ALERT_PROGRESS p
                                      WHERE p.DIE_NO = s.DIE_NO
                                        AND p.NEXT_OHD_MOC = s.OHD_MOC
                                        AND CAST(p.TRACK_START_DATE AS date) = CAST(s.TRACK_DATE AS date)
                                        AND ISNULL(p.ALERT_CONTENT,'') = ISNULL(r.ALERT_CONTENT,'')
                                  );");
        }

        public DataTable ValidateAndFixProgressByRules()
        {
            DataTable dt = DBUtils.GetData(@"SELECT p.ID,
                                                    p.NEXT_OHD_MOC,
                                                    p.ALERT_CONTENT,
                                                    p.OWNER_USER_ID,
                                                    p.ALERT_BG_COLOR,
                                                    p.ALERT_FG_COLOR,
                                                    r.OWNER_USER_ID AS RULE_OWNER_USER_ID,
                                                    r.ALERT_CONTENT AS RULE_ALERT_CONTENT,
                                                    r.ALERT_BG_COLOR AS RULE_ALERT_BG_COLOR,
                                                    r.ALERT_FG_COLOR AS RULE_ALERT_FG_COLOR
                                             FROM OHD_ALERT_PROGRESS p
                                             OUTER APPLY (
                                                SELECT TOP 1 *
                                                FROM OHD_ALERT_RULE r
                                                WHERE p.NEXT_OHD_MOC IN (r.DUE_DAYS_30, r.DUE_DAYS_60, r.DUE_DAYS_90, r.DUE_DAYS_120, r.DUE_DAYS_150, r.DUE_DAYS_180, r.DUE_DAYS_210, r.DUE_DAYS_240)
                                                ORDER BY r.ID
                                             ) r
                                             WHERE ISNULL(p.APPROVED,0)=0");

            DataTable result = new DataTable();
            result.Columns.Add("FIXED_OWNER", typeof(int));
            result.Columns.Add("FIXED_COLOR", typeof(int));
            result.Columns.Add("FIXED_CONTENT", typeof(int));
            DataRow summary = result.NewRow();
            summary["FIXED_OWNER"] = 0;
            summary["FIXED_COLOR"] = 0;
            summary["FIXED_CONTENT"] = 0;

            foreach (DataRow row in dt.Rows)
            {
                int id = ToInt(row["ID"]);
                if (id <= 0) continue;

                string expectedOwner = Convert.ToString(row["RULE_OWNER_USER_ID"] ?? string.Empty);
                string expectedContent = Convert.ToString(row["RULE_ALERT_CONTENT"] ?? string.Empty);
                string expectedBg = Convert.ToString(row["RULE_ALERT_BG_COLOR"] ?? string.Empty);
                string expectedFg = Convert.ToString(row["RULE_ALERT_FG_COLOR"] ?? string.Empty);
                if (string.IsNullOrWhiteSpace(expectedContent)) continue;

                string currentOwner = Convert.ToString(row["OWNER_USER_ID"] ?? string.Empty);
                string currentContent = Convert.ToString(row["ALERT_CONTENT"] ?? string.Empty);
                string currentBg = Convert.ToString(row["ALERT_BG_COLOR"] ?? string.Empty);
                string currentFg = Convert.ToString(row["ALERT_FG_COLOR"] ?? string.Empty);

                bool ownerChanged = !string.Equals(currentOwner, expectedOwner, StringComparison.OrdinalIgnoreCase);
                bool contentChanged = !string.Equals(currentContent, expectedContent, StringComparison.Ordinal);
                bool colorChanged = !string.Equals(currentBg, expectedBg, StringComparison.OrdinalIgnoreCase)
                                    || !string.Equals(currentFg, expectedFg, StringComparison.OrdinalIgnoreCase);

                if (!ownerChanged && !contentChanged && !colorChanged) continue;

                DBUtils.Exec(@"UPDATE OHD_ALERT_PROGRESS
                               SET OWNER_USER_ID=@U,
                                   ALERT_CONTENT=@C,
                                   ALERT_BG_COLOR=@BG,
                                   ALERT_FG_COLOR=@FG
                               WHERE ID=@ID",
                    new SqlParameter("@U", expectedOwner),
                    new SqlParameter("@C", expectedContent),
                    new SqlParameter("@BG", expectedBg),
                    new SqlParameter("@FG", expectedFg),
                    new SqlParameter("@ID", id));

                if (ownerChanged) summary["FIXED_OWNER"] = ToInt(summary["FIXED_OWNER"]) + 1;
                if (contentChanged) summary["FIXED_CONTENT"] = ToInt(summary["FIXED_CONTENT"]) + 1;
                if (colorChanged) summary["FIXED_COLOR"] = ToInt(summary["FIXED_COLOR"]) + 1;
            }

            result.Rows.Add(summary);
            return result;
        }

        private void EnsureRuleWorkflowColumns()
        {
            DBUtils.Exec(@"IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('dbo.OHD_ALERT_RULE') AND name = 'ALERT_BG_COLOR')
                              ALTER TABLE dbo.OHD_ALERT_RULE ADD ALERT_BG_COLOR NVARCHAR(20) NOT NULL CONSTRAINT DF_OHD_ALERT_RULE_BG DEFAULT('#FFF3CD');
                          IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('dbo.OHD_ALERT_RULE') AND name = 'ALERT_FG_COLOR')
                              ALTER TABLE dbo.OHD_ALERT_RULE ADD ALERT_FG_COLOR NVARCHAR(20) NOT NULL CONSTRAINT DF_OHD_ALERT_RULE_FG DEFAULT('#7A4E00');
                          IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('dbo.OHD_ALERT_RULE') AND name = 'DUE_DAYS_30')
                              ALTER TABLE dbo.OHD_ALERT_RULE ADD DUE_DAYS_30 INT NOT NULL CONSTRAINT DF_OHD_ALERT_RULE_D30 DEFAULT(30);
                          IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('dbo.OHD_ALERT_RULE') AND name = 'DUE_DAYS_60')
                              ALTER TABLE dbo.OHD_ALERT_RULE ADD DUE_DAYS_60 INT NOT NULL CONSTRAINT DF_OHD_ALERT_RULE_D60 DEFAULT(60);
                          IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('dbo.OHD_ALERT_RULE') AND name = 'DUE_DAYS_90')
                              ALTER TABLE dbo.OHD_ALERT_RULE ADD DUE_DAYS_90 INT NOT NULL CONSTRAINT DF_OHD_ALERT_RULE_D90 DEFAULT(90);
                          IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('dbo.OHD_ALERT_RULE') AND name = 'DUE_DAYS_120')
                              ALTER TABLE dbo.OHD_ALERT_RULE ADD DUE_DAYS_120 INT NOT NULL CONSTRAINT DF_OHD_ALERT_RULE_D120 DEFAULT(120);
                          IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('dbo.OHD_ALERT_RULE') AND name = 'DUE_DAYS_150')
                              ALTER TABLE dbo.OHD_ALERT_RULE ADD DUE_DAYS_150 INT NOT NULL CONSTRAINT DF_OHD_ALERT_RULE_D150 DEFAULT(150);
                          IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('dbo.OHD_ALERT_RULE') AND name = 'DUE_DAYS_180')
                              ALTER TABLE dbo.OHD_ALERT_RULE ADD DUE_DAYS_180 INT NOT NULL CONSTRAINT DF_OHD_ALERT_RULE_D180 DEFAULT(180);
                          IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('dbo.OHD_ALERT_RULE') AND name = 'DUE_DAYS_210')
                              ALTER TABLE dbo.OHD_ALERT_RULE ADD DUE_DAYS_210 INT NOT NULL CONSTRAINT DF_OHD_ALERT_RULE_D210 DEFAULT(210);
                          IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('dbo.OHD_ALERT_RULE') AND name = 'DUE_DAYS_240')
                              ALTER TABLE dbo.OHD_ALERT_RULE ADD DUE_DAYS_240 INT NOT NULL CONSTRAINT DF_OHD_ALERT_RULE_D240 DEFAULT(240);
                          IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('dbo.OHD_ALERT_RULE') AND name = 'USE_MONTH_FIRST_DAY')
                              ALTER TABLE dbo.OHD_ALERT_RULE ADD USE_MONTH_FIRST_DAY BIT NOT NULL CONSTRAINT DF_OHD_ALERT_RULE_M1 DEFAULT(1);
                          IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('dbo.OHD_ALERT_RULE') AND name = 'EXACT_DAY_IN_MONTH')
                              ALTER TABLE dbo.OHD_ALERT_RULE ADD EXACT_DAY_IN_MONTH INT NULL;
                          IF EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('dbo.OHD_ALERT_RULE') AND name = 'OWNER_USER_ID' AND max_length < 1000)
                              ALTER TABLE dbo.OHD_ALERT_RULE ALTER COLUMN OWNER_USER_ID NVARCHAR(500) NULL;
                          IF EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('dbo.OHD_ALERT_PROGRESS') AND name = 'OWNER_USER_ID' AND max_length < 1000)
                              ALTER TABLE dbo.OHD_ALERT_PROGRESS ALTER COLUMN OWNER_USER_ID NVARCHAR(500) NULL;
                          IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('dbo.OHD_ALERT_RULE') AND name = 'SEND_MAIL_AFTER_FINAL_DONE')
                              ALTER TABLE dbo.OHD_ALERT_RULE ADD SEND_MAIL_AFTER_FINAL_DONE BIT NOT NULL CONSTRAINT DF_OHD_ALERT_RULE_MAIL_FINAL DEFAULT(0);
                          IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('dbo.OHD_ALERT_RULE') AND name = 'MAIL_DELAY_DAYS')
                              ALTER TABLE dbo.OHD_ALERT_RULE ADD MAIL_DELAY_DAYS INT NOT NULL CONSTRAINT DF_OHD_ALERT_RULE_MAIL_DELAY DEFAULT(1);
                          IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('dbo.OHD_ALERT_RULE') AND name = 'RULE_NOTE')
                              ALTER TABLE dbo.OHD_ALERT_RULE ADD RULE_NOTE NVARCHAR(500) NULL;
                          IF NOT EXISTS (SELECT 1 FROM dbo.OHD_ALERT_RULE WHERE ALERT_CONTENT = N'Check sau khi hoàn thiện')
                              INSERT INTO dbo.OHD_ALERT_RULE(OWNER_USER_ID, ALERT_CONTENT, ALERT_BG_COLOR, ALERT_FG_COLOR, DUE_DAYS_30, DUE_DAYS_60, DUE_DAYS_90, DUE_DAYS_120, DUE_DAYS_150, DUE_DAYS_180, DUE_DAYS_210, DUE_DAYS_240, USE_MONTH_FIRST_DAY, SEND_MAIL_AFTER_FINAL_DONE, MAIL_DELAY_DAYS, RULE_NOTE)
                              VALUES (N'Kỹ sư', N'Check sau khi hoàn thiện', '#FFF2CC', '#7A4E00', 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, N'Gửi mail vào ngày hôm sau khi mục số 5 được xác nhận OK');");
        }

        private string NormalizeColor(object value, string fallback)
        {
            string text = Convert.ToString(value ?? string.Empty).Trim();
            return string.IsNullOrWhiteSpace(text) ? fallback : text;
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
