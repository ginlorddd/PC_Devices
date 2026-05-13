using System;
using System.Data;
using System.Data.SqlClient;

namespace JigFlow.Data
{
    public class JigFunctionService
    {
        public DataTable GetJigFunctionList()
        {
            const string SQL_QUERY = @"
SELECT
    ROW_NUMBER() OVER (ORDER BY JM.JIG_ID) AS STT,
    JM.JIG_ID,
    JM.CONTROL_NO,
    JM.JIG_NAME,
    COALESCE(JTM.JIG_TYPE_NAME, JM.JIG_TYPE) AS JIG_TYPE_NAME,
    JM.JIG_TYPE_CODE,
    JM.JIG_SIZE,
    JM.USE_PRODUCT,
    JM.PURPOSE_USE,
    JM.LOCATION_CODE,
    JM.FACTORY,
    JM.STATUS_USE,
    JM.USE_SECTION,
    JM.LAST_CHECK_DATE,
    JM.NEXT_CHECK_PLAN_DATE,
    JM.CHECK_RESULT,
    JM.CHECK_FREQUENCY
FROM dbo.JIG_MASTER JM
LEFT JOIN dbo.JIG_TYPE_MASTER JTM ON JM.JIG_TYPE_CODE = JTM.JIG_TYPE_CODE
WHERE JM.IS_ACTIVE = 1
  AND ISNULL(JTM.JIG_TYPE_MAIN, 'FUNCTION') = 'FUNCTION'
ORDER BY JM.JIG_ID";
            return DbUtils.GetData(SQL_QUERY);
        }



        public DataTable GetJigVisualList()
        {
            const string SQL_QUERY = @"
SELECT
    ROW_NUMBER() OVER (ORDER BY JM.JIG_ID) AS STT,
    JM.JIG_ID,
    JM.CONTROL_NO,
    JM.JIG_NAME,
    COALESCE(JTM.JIG_TYPE_NAME, JM.JIG_TYPE) AS JIG_TYPE_NAME,
    JM.JIG_TYPE_CODE,
    JM.JIG_SIZE,
    JM.USE_PRODUCT,
    JM.PURPOSE_USE,
    JM.LOCATION_CODE,
    JM.FACTORY,
    JM.STATUS_USE,
    JM.USE_SECTION,
    JM.LAST_CHECK_DATE,
    JM.NEXT_CHECK_PLAN_DATE,
    JM.CHECK_RESULT,
    JM.CHECK_FREQUENCY
FROM dbo.JIG_MASTER JM
LEFT JOIN dbo.JIG_TYPE_MASTER JTM ON JM.JIG_TYPE_CODE = JTM.JIG_TYPE_CODE
WHERE JM.IS_ACTIVE = 1
  AND ISNULL(JTM.JIG_TYPE_MAIN, 'VISUAL') = 'VISUAL'
ORDER BY JM.JIG_ID";
            return DbUtils.GetData(SQL_QUERY);
        }

        public DataTable GetNotCheckedJigs(DateTime MONTH_REFERENCE)
        {
            var MONTH_START = new DateTime(MONTH_REFERENCE.Year, MONTH_REFERENCE.Month, 1);
            var NEXT_MONTH_START = MONTH_START.AddMonths(1);

            const string SQL_QUERY = @"
SELECT
    ROW_NUMBER() OVER (ORDER BY JM.NEXT_CHECK_PLAN_DATE, JM.JIG_ID) AS STT,
    JM.CONTROL_NO,
    JM.JIG_NAME,
    COALESCE(JTM.JIG_TYPE_NAME, JM.JIG_TYPE) AS JIG_TYPE_NAME,
    JM.JIG_SIZE,
    JM.NEXT_CHECK_PLAN_DATE,
    JM.USE_SECTION,
    JM.CHECK_RESULT
FROM dbo.JIG_MASTER JM
LEFT JOIN dbo.JIG_TYPE_MASTER JTM ON JM.JIG_TYPE_CODE = JTM.JIG_TYPE_CODE
WHERE JM.IS_ACTIVE = 1
  AND JM.NEXT_CHECK_PLAN_DATE IS NOT NULL
  AND JM.NEXT_CHECK_PLAN_DATE < @NEXT_MONTH_START
ORDER BY JM.NEXT_CHECK_PLAN_DATE, JM.JIG_ID;";

            return DbUtils.GetData(
                SQL_QUERY,
                new SqlParameter("@NEXT_MONTH_START", NEXT_MONTH_START));
        }

        public DataTable GetJigCheckHistory()
        {
            const string SQL_QUERY = @"
SELECT
    ROW_NUMBER() OVER (ORDER BY JM.LAST_CHECK_DATE DESC, JM.JIG_ID DESC) AS STT,
    JM.JIG_ID,
    JM.CONTROL_NO,
    JM.JIG_NAME,
    COALESCE(JTM.JIG_TYPE_NAME, JM.JIG_TYPE) AS JIG_TYPE_NAME,
    JM.JIG_SIZE,
    JM.USE_PRODUCT,
    JM.PURPOSE_USE,
    JM.LOCATION_CODE,
    JM.STATUS_USE,
    JM.USE_SECTION,
    JM.LAST_CHECK_DATE,
    ISNULL(NULLIF(JM.CHECK_RESULT, ''), CH.CHECK_RESULT) AS CHECK_RESULT,
    CH.REPORT_FILE,
    CH.CHECK_BY,
    CH.CHECKER_BY,
    CH.APPROVE_BY,
    CH.NOTE
FROM dbo.JIG_MASTER JM
LEFT JOIN dbo.JIG_TYPE_MASTER JTM ON JM.JIG_TYPE_CODE = JTM.JIG_TYPE_CODE
OUTER APPLY
(
    SELECT TOP 1 H.CHECK_RESULT, H.CHECK_BY, H.CHECKER_BY, H.APPROVE_BY, H.REPORT_FILE, H.CHECK_NOTE AS NOTE
    FROM dbo.JIG_CHECK_HISTORY H
    WHERE H.JIG_ID = JM.JIG_ID
    ORDER BY H.CHECK_ID DESC
) CH
WHERE JM.IS_ACTIVE = 1
  AND JM.LAST_CHECK_DATE IS NOT NULL
ORDER BY JM.LAST_CHECK_DATE DESC, JM.JIG_ID DESC;";
            return DbUtils.GetData(SQL_QUERY);
        }

        public int ApproveJigCheck(int JIG_ID, string APPROVE_BY)
        {
            const string SQL_QUERY = @"
UPDATE H
SET H.APPROVE_BY = @APPROVE_BY,
    H.APPROVE_AT = GETDATE()
FROM dbo.JIG_CHECK_HISTORY H
INNER JOIN
(
    SELECT TOP 1 CHECK_ID
    FROM dbo.JIG_CHECK_HISTORY
    WHERE JIG_ID = @JIG_ID
    ORDER BY CHECK_ID DESC
) LATEST ON H.CHECK_ID = LATEST.CHECK_ID;";

            return DbUtils.Execute(
                SQL_QUERY,
                new SqlParameter("@JIG_ID", JIG_ID),
                new SqlParameter("@APPROVE_BY", (object)APPROVE_BY ?? DBNull.Value));
        }

        public void UpsertJig(
            string CONTROL_NO,
            string JIG_NAME,
            string JIG_TYPE_CODE,
            string JIG_SIZE,
            string USE_PRODUCT,
            string LOCATION_CODE,
            string FACTORY,
            string STATUS_USE,
            string USE_SECTION,
            DateTime? LAST_CHECK_DATE,
            DateTime? NEXT_CHECK_PLAN_DATE,
            string CHECK_RESULT,
            string CHECK_FREQUENCY)
        {
            const string SQL_QUERY = @"
IF EXISTS (SELECT 1 FROM dbo.JIG_MASTER WHERE CONTROL_NO = @CONTROL_NO)
BEGIN
    UPDATE dbo.JIG_MASTER
    SET JIG_NAME = @JIG_NAME,
        JIG_TYPE_CODE = @JIG_TYPE_CODE,
        JIG_SIZE = @JIG_SIZE,
        USE_PRODUCT = @USE_PRODUCT,
        LOCATION_CODE = @LOCATION_CODE,
        FACTORY = @FACTORY,
        JIG_TYPE = ISNULL(NULLIF(@JIG_TYPE_CODE, ''), JIG_TYPE),
        STATUS_USE = @STATUS_USE,
        USE_SECTION = @USE_SECTION,
        LAST_CHECK_DATE = @LAST_CHECK_DATE,
        NEXT_CHECK_PLAN_DATE = @NEXT_CHECK_PLAN_DATE,
        CHECK_RESULT = @CHECK_RESULT,
        CHECK_FREQUENCY = @CHECK_FREQUENCY,
        UPDATED_AT = GETDATE()
    WHERE CONTROL_NO = @CONTROL_NO
END
ELSE
BEGIN
    INSERT INTO dbo.JIG_MASTER
    (CONTROL_NO, JIG_NAME, JIG_TYPE, JIG_TYPE_CODE, JIG_SIZE, USE_PRODUCT, LOCATION_CODE, FACTORY, STATUS_USE, USE_SECTION,
     LAST_CHECK_DATE, NEXT_CHECK_PLAN_DATE, CHECK_RESULT, CHECK_FREQUENCY, IS_ACTIVE, CREATED_AT)
VALUES
    (@CONTROL_NO, @JIG_NAME, ISNULL(NULLIF(@JIG_TYPE_CODE, ''), N'JIG_UNKNOWN'), @JIG_TYPE_CODE, @JIG_SIZE, @USE_PRODUCT, @LOCATION_CODE, @FACTORY, @STATUS_USE, @USE_SECTION,
     @LAST_CHECK_DATE, @NEXT_CHECK_PLAN_DATE, @CHECK_RESULT, @CHECK_FREQUENCY, 1, GETDATE())
END";

            DbUtils.Execute(SQL_QUERY,
                new SqlParameter("@CONTROL_NO", (object)CONTROL_NO ?? DBNull.Value),
                new SqlParameter("@JIG_NAME", (object)JIG_NAME ?? DBNull.Value),
                new SqlParameter("@JIG_TYPE_CODE", (object)JIG_TYPE_CODE ?? DBNull.Value),
                new SqlParameter("@JIG_SIZE", (object)JIG_SIZE ?? DBNull.Value),
                new SqlParameter("@USE_PRODUCT", (object)USE_PRODUCT ?? DBNull.Value),
                new SqlParameter("@LOCATION_CODE", (object)LOCATION_CODE ?? DBNull.Value),
                new SqlParameter("@FACTORY", (object)FACTORY ?? DBNull.Value),
                new SqlParameter("@STATUS_USE", (object)STATUS_USE ?? DBNull.Value),
                new SqlParameter("@USE_SECTION", (object)USE_SECTION ?? DBNull.Value),
                new SqlParameter("@LAST_CHECK_DATE", (object)LAST_CHECK_DATE ?? DBNull.Value),
                new SqlParameter("@NEXT_CHECK_PLAN_DATE", (object)NEXT_CHECK_PLAN_DATE ?? DBNull.Value),
                new SqlParameter("@CHECK_RESULT", (object)CHECK_RESULT ?? DBNull.Value),
                new SqlParameter("@CHECK_FREQUENCY", (object)CHECK_FREQUENCY ?? DBNull.Value));
        }
    }
}
