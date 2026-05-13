using System;
using System.Data;
using System.Data.SqlClient;

namespace JigFlow.Data
{
    public class JigRegisterService
    {
        public DataTable GetJigTypes()
        {
            const string SQL_QUERY = @"
SELECT JTM.JIG_TYPE_CODE, JTM.JIG_TYPE_NAME, JTM.DEFAULT_DRAWING_CODE, DM.DRAWING_NAME
FROM dbo.JIG_TYPE_MASTER JTM
LEFT JOIN dbo.JIG_DRAWING_MASTER DM ON JTM.DEFAULT_DRAWING_CODE = DM.DRAWING_CODE
WHERE JTM.IS_ACTIVE = 1
ORDER BY JTM.JIG_TYPE_NAME";
            return DbUtils.GetData(SQL_QUERY);
        }

        public DataTable GetFormMasters()
        {
            const string SQL_QUERY = "SELECT FORM_CODE, FORM_NAME FROM dbo.FORM_MASTER WHERE IS_ACTIVE = 1 ORDER BY FORM_NAME";
            return DbUtils.GetData(SQL_QUERY);
        }

        public DataTable GetDrawings()
        {
            const string SQL_QUERY = "SELECT DRAWING_CODE, DRAWING_NAME FROM dbo.JIG_DRAWING_MASTER WHERE IS_ACTIVE = 1 ORDER BY DRAWING_NAME";
            return DbUtils.GetData(SQL_QUERY);
        }

        public int GetNextSequenceByPrefix(string PREFIX)
        {
            const string SQL_QUERY = @"
SELECT ISNULL(MAX(CAST(RIGHT(MANAGEMENT_NO, 3) AS INT)), 0) AS MAX_SEQ
FROM dbo.JIG_REGISTER_REQUEST
WHERE MANAGEMENT_NO LIKE @PREFIX + '%';";
            var DT = DbUtils.GetData(SQL_QUERY, new SqlParameter("@PREFIX", PREFIX));
            return Convert.ToInt32(DT.Rows[0]["MAX_SEQ"]) + 1;
        }

        public bool IsManagementNoDuplicated(string MANAGEMENT_NO, int? EXCLUDE_REQUEST_ID = null)
        {
            const string SQL_QUERY = @"
DECLARE @NORMALIZED_NO NVARCHAR(100) = UPPER(LTRIM(RTRIM(@MANAGEMENT_NO)));

SELECT CASE WHEN EXISTS
(
    SELECT 1
    FROM dbo.JIG_MASTER
    WHERE IS_ACTIVE = 1
      AND UPPER(LTRIM(RTRIM(CONTROL_NO))) = @NORMALIZED_NO
)
OR EXISTS
(
    SELECT 1
    FROM dbo.JIG_REGISTER_REQUEST
    WHERE UPPER(LTRIM(RTRIM(MANAGEMENT_NO))) = @NORMALIZED_NO
      AND (@EXCLUDE_REQUEST_ID IS NULL OR REQUEST_ID <> @EXCLUDE_REQUEST_ID)
)
THEN 1 ELSE 0 END AS IS_DUPLICATED;";

            var DT = DbUtils.GetData(
                SQL_QUERY,
                new SqlParameter("@MANAGEMENT_NO", (object)MANAGEMENT_NO ?? DBNull.Value),
                new SqlParameter("@EXCLUDE_REQUEST_ID", (object)EXCLUDE_REQUEST_ID ?? DBNull.Value));

            return DT.Rows.Count > 0 && Convert.ToInt32(DT.Rows[0]["IS_DUPLICATED"]) == 1;
        }

        public int CreateRegisterRequest(
            string DEPARTMENT,
            string FACTORY,
            string MANAGEMENT_NO,
            string JIG_NAME,
            string JIG_TYPE_CODE,
            string JIG_SIZE,
            string USE_PRODUCT,
            string PURPOSE_USE,
            string LOCATION_CODE,
            DateTime? LAST_CHECK_DATE,
            string CHECK_FREQUENCY,
            string REPORT_FORM_CODE,
            string FIRST_CHECK_RESULT_FILE,
            string DRAWING_CODE,
            string REQUEST_BY)
        {
            const string SQL_QUERY = @"
INSERT INTO dbo.JIG_REGISTER_REQUEST
(
    REQUEST_TYPE,
    REQUEST_STATUS,
    REQUEST_BY,
    DEPARTMENT,
    FACTORY,
    MANAGEMENT_NO,
    JIG_NAME,
    JIG_TYPE_CODE,
    JIG_SIZE,
    USE_PRODUCT,
    PURPOSE_USE,
    LOCATION_CODE,
    LAST_CHECK_DATE,
    CHECK_FREQUENCY,
    REPORT_FORM_CODE,
    FIRST_CHECK_RESULT_FILE,
    DRAWING_CODE,
    STATUS_USE
)
VALUES
(
    'NEW',
    'WAITING_APPROVE',
    @REQUEST_BY,
    @DEPARTMENT,
    @FACTORY,
    @MANAGEMENT_NO,
    @JIG_NAME,
    @JIG_TYPE_CODE,
    @JIG_SIZE,
    @USE_PRODUCT,
    @PURPOSE_USE,
    @LOCATION_CODE,
    @LAST_CHECK_DATE,
    @CHECK_FREQUENCY,
    @REPORT_FORM_CODE,
    @FIRST_CHECK_RESULT_FILE,
    @DRAWING_CODE,
    N'Chờ duyệt'
);";

            return DbUtils.Execute(
                SQL_QUERY,
                new SqlParameter("@REQUEST_BY", REQUEST_BY),
                new SqlParameter("@DEPARTMENT", (object)DEPARTMENT ?? DBNull.Value),
                new SqlParameter("@FACTORY", (object)FACTORY ?? DBNull.Value),
                new SqlParameter("@MANAGEMENT_NO", (object)MANAGEMENT_NO ?? DBNull.Value),
                new SqlParameter("@JIG_NAME", (object)JIG_NAME ?? DBNull.Value),
                new SqlParameter("@JIG_TYPE_CODE", (object)JIG_TYPE_CODE ?? DBNull.Value),
                new SqlParameter("@JIG_SIZE", (object)JIG_SIZE ?? DBNull.Value),
                new SqlParameter("@USE_PRODUCT", (object)USE_PRODUCT ?? DBNull.Value),
                new SqlParameter("@PURPOSE_USE", (object)PURPOSE_USE ?? DBNull.Value),
                new SqlParameter("@LOCATION_CODE", (object)LOCATION_CODE ?? DBNull.Value),
                new SqlParameter("@LAST_CHECK_DATE", (object)LAST_CHECK_DATE ?? DBNull.Value),
                new SqlParameter("@CHECK_FREQUENCY", (object)CHECK_FREQUENCY ?? DBNull.Value),
                new SqlParameter("@REPORT_FORM_CODE", (object)REPORT_FORM_CODE ?? DBNull.Value),
                new SqlParameter("@FIRST_CHECK_RESULT_FILE", (object)FIRST_CHECK_RESULT_FILE ?? DBNull.Value),
                new SqlParameter("@DRAWING_CODE", (object)DRAWING_CODE ?? DBNull.Value));
        }

        public DataTable GetWaitingApproveRequests()
        {
            const string SQL_QUERY = @"
SELECT
    ROW_NUMBER() OVER(ORDER BY REQUEST_AT DESC) AS STT,
    REQUEST_ID,
    MANAGEMENT_NO,
    JIG_NAME,
    JIG_TYPE_CODE,
    JIG_SIZE,
    USE_PRODUCT,
    PURPOSE_USE,
    LOCATION_CODE,
    FIRST_CHECK_RESULT_FILE,
    DEPARTMENT,
    FACTORY,
    CHECK_FREQUENCY,
    STATUS_USE,
    REQUEST_STATUS,
    REQUEST_BY,
    REQUEST_AT
FROM dbo.JIG_REGISTER_REQUEST
WHERE REQUEST_STATUS = 'WAITING_APPROVE'
ORDER BY REQUEST_AT DESC;";
            return DbUtils.GetData(SQL_QUERY);
        }

        public DataTable GetRegisterHistory()
        {
            const string SQL_QUERY = @"
SELECT
    ROW_NUMBER() OVER(ORDER BY REQUEST_AT DESC) AS STT,
    R.REQUEST_ID,
    R.MANAGEMENT_NO,
    CASE
        WHEN R.REQUEST_STATUS = 'APPROVED' THEN N'Đã phê duyệt'
        ELSE N'Chưa được phê duyệt'
    END AS REQUEST_STATUS_TEXT,
    R.JIG_NAME,
    ISNULL(JTM.JIG_TYPE_NAME, R.JIG_TYPE_CODE) AS JIG_TYPE_NAME,
    R.JIG_SIZE,
    R.USE_PRODUCT,
    R.PURPOSE_USE,
    R.LOCATION_CODE,
    R.DEPARTMENT,
    R.REQUEST_AT,
    R.REQUEST_BY,
    R.FIRST_CHECK_RESULT_FILE
FROM dbo.JIG_REGISTER_REQUEST R
LEFT JOIN dbo.JIG_TYPE_MASTER JTM ON R.JIG_TYPE_CODE = JTM.JIG_TYPE_CODE
ORDER BY R.REQUEST_AT DESC;";
            return DbUtils.GetData(SQL_QUERY);
        }

        public DataRow GetRegisterRequestById(int REQUEST_ID)
        {
            const string SQL_QUERY = @"
SELECT TOP 1 *
FROM dbo.JIG_REGISTER_REQUEST
WHERE REQUEST_ID = @REQUEST_ID;";
            var DT = DbUtils.GetData(SQL_QUERY, new SqlParameter("@REQUEST_ID", REQUEST_ID));
            return DT.Rows.Count == 0 ? null : DT.Rows[0];
        }

        public int UpdateRegisterRequest(
            int REQUEST_ID,
            string DEPARTMENT,
            string FACTORY,
            string MANAGEMENT_NO,
            string JIG_NAME,
            string JIG_TYPE_CODE,
            string JIG_SIZE,
            string USE_PRODUCT,
            string PURPOSE_USE,
            string LOCATION_CODE,
            DateTime? LAST_CHECK_DATE,
            string CHECK_FREQUENCY,
            string REPORT_FORM_CODE,
            string FIRST_CHECK_RESULT_FILE,
            string DRAWING_CODE,
            string UPDATED_BY)
        {
            const string SQL_QUERY = @"
UPDATE dbo.JIG_REGISTER_REQUEST
SET
    DEPARTMENT = @DEPARTMENT,
    FACTORY = @FACTORY,
    MANAGEMENT_NO = @MANAGEMENT_NO,
    JIG_NAME = @JIG_NAME,
    JIG_TYPE_CODE = @JIG_TYPE_CODE,
    JIG_SIZE = @JIG_SIZE,
    USE_PRODUCT = @USE_PRODUCT,
    PURPOSE_USE = @PURPOSE_USE,
    LOCATION_CODE = @LOCATION_CODE,
    LAST_CHECK_DATE = @LAST_CHECK_DATE,
    CHECK_FREQUENCY = @CHECK_FREQUENCY,
    REPORT_FORM_CODE = @REPORT_FORM_CODE,
    FIRST_CHECK_RESULT_FILE = @FIRST_CHECK_RESULT_FILE,
    DRAWING_CODE = @DRAWING_CODE,
    REQUEST_BY = @UPDATED_BY
WHERE REQUEST_ID = @REQUEST_ID
  AND REQUEST_STATUS = 'WAITING_APPROVE';";

            return DbUtils.Execute(
                SQL_QUERY,
                new SqlParameter("@REQUEST_ID", REQUEST_ID),
                new SqlParameter("@DEPARTMENT", (object)DEPARTMENT ?? DBNull.Value),
                new SqlParameter("@FACTORY", (object)FACTORY ?? DBNull.Value),
                new SqlParameter("@MANAGEMENT_NO", (object)MANAGEMENT_NO ?? DBNull.Value),
                new SqlParameter("@JIG_NAME", (object)JIG_NAME ?? DBNull.Value),
                new SqlParameter("@JIG_TYPE_CODE", (object)JIG_TYPE_CODE ?? DBNull.Value),
                new SqlParameter("@JIG_SIZE", (object)JIG_SIZE ?? DBNull.Value),
                new SqlParameter("@USE_PRODUCT", (object)USE_PRODUCT ?? DBNull.Value),
                new SqlParameter("@PURPOSE_USE", (object)PURPOSE_USE ?? DBNull.Value),
                new SqlParameter("@LOCATION_CODE", (object)LOCATION_CODE ?? DBNull.Value),
                new SqlParameter("@LAST_CHECK_DATE", (object)LAST_CHECK_DATE ?? DBNull.Value),
                new SqlParameter("@CHECK_FREQUENCY", (object)CHECK_FREQUENCY ?? DBNull.Value),
                new SqlParameter("@REPORT_FORM_CODE", (object)REPORT_FORM_CODE ?? DBNull.Value),
                new SqlParameter("@FIRST_CHECK_RESULT_FILE", (object)FIRST_CHECK_RESULT_FILE ?? DBNull.Value),
                new SqlParameter("@DRAWING_CODE", (object)DRAWING_CODE ?? DBNull.Value),
                new SqlParameter("@UPDATED_BY", (object)UPDATED_BY ?? DBNull.Value));
        }

        public int DeleteRegisterRequest(int REQUEST_ID)
        {
            const string SQL_QUERY = @"
DELETE FROM dbo.JIG_REGISTER_REQUEST
WHERE REQUEST_ID = @REQUEST_ID
  AND REQUEST_STATUS = 'WAITING_APPROVE';";
            return DbUtils.Execute(SQL_QUERY, new SqlParameter("@REQUEST_ID", REQUEST_ID));
        }

        public int ApproveRegisterRequest(int REQUEST_ID, string APPROVE_BY)
        {
            const string SQL_QUERY = @"
DECLARE @REQ TABLE
(
    MANAGEMENT_NO VARCHAR(100),
    JIG_NAME NVARCHAR(200),
    JIG_TYPE_CODE VARCHAR(50),
    JIG_TYPE NVARCHAR(100),
    JIG_SIZE VARCHAR(50),
    USE_PRODUCT NVARCHAR(300),
    PURPOSE_USE NVARCHAR(300),
    LOCATION_CODE VARCHAR(50),
    FACTORY VARCHAR(50),
    DEPARTMENT VARCHAR(50),
    CHECK_FREQUENCY NVARCHAR(50),
    LAST_CHECK_DATE DATE
);

INSERT INTO @REQ(MANAGEMENT_NO, JIG_NAME, JIG_TYPE_CODE, JIG_TYPE, JIG_SIZE, USE_PRODUCT, PURPOSE_USE, LOCATION_CODE, FACTORY, DEPARTMENT, CHECK_FREQUENCY, LAST_CHECK_DATE)
SELECT
    R.MANAGEMENT_NO,
    R.JIG_NAME,
    R.JIG_TYPE_CODE,
    ISNULL(NULLIF(JTM.JIG_TYPE_NAME, ''), ISNULL(NULLIF(R.JIG_TYPE_CODE, ''), N'JIG_UNKNOWN')),
    R.JIG_SIZE,
    R.USE_PRODUCT,
    R.PURPOSE_USE,
    R.LOCATION_CODE,
    R.FACTORY,
    R.DEPARTMENT,
    R.CHECK_FREQUENCY,
    R.LAST_CHECK_DATE
FROM dbo.JIG_REGISTER_REQUEST R
LEFT JOIN dbo.JIG_TYPE_MASTER JTM ON R.JIG_TYPE_CODE = JTM.JIG_TYPE_CODE
WHERE REQUEST_ID = @REQUEST_ID
  AND REQUEST_STATUS = 'WAITING_APPROVE';

IF NOT EXISTS(SELECT 1 FROM @REQ) RETURN;

MERGE dbo.JIG_MASTER AS T
USING (SELECT * FROM @REQ) AS S
ON T.CONTROL_NO = S.MANAGEMENT_NO
WHEN MATCHED THEN
    UPDATE SET
        T.JIG_NAME = S.JIG_NAME,
        T.JIG_TYPE = S.JIG_TYPE,
        T.JIG_TYPE_CODE = S.JIG_TYPE_CODE,
        T.JIG_SIZE = S.JIG_SIZE,
        T.USE_PRODUCT = S.USE_PRODUCT,
        T.PURPOSE_USE = S.PURPOSE_USE,
        T.LOCATION_CODE = S.LOCATION_CODE,
        T.FACTORY = S.FACTORY,
        T.LAST_CHECK_DATE = S.LAST_CHECK_DATE,
        T.NEXT_CHECK_PLAN_DATE = CASE S.CHECK_FREQUENCY
            WHEN N'1 tháng' THEN DATEADD(MONTH, 1, S.LAST_CHECK_DATE)
            WHEN N'3 tháng' THEN DATEADD(MONTH, 3, S.LAST_CHECK_DATE)
            WHEN N'6 tháng' THEN DATEADD(MONTH, 6, S.LAST_CHECK_DATE)
            WHEN N'1 năm' THEN DATEADD(YEAR, 1, S.LAST_CHECK_DATE)
            WHEN N'2 năm' THEN DATEADD(YEAR, 2, S.LAST_CHECK_DATE)
            ELSE NULL
        END,
        T.STATUS_USE = N'Đang sử dụng',
        T.USE_SECTION = S.DEPARTMENT,
        T.CHECK_FREQUENCY = S.CHECK_FREQUENCY,
        T.IS_ACTIVE = 1,
        T.UPDATED_AT = GETDATE()
WHEN NOT MATCHED THEN
    INSERT (CONTROL_NO, JIG_NAME, JIG_TYPE, JIG_TYPE_CODE, JIG_SIZE, USE_PRODUCT, PURPOSE_USE, LOCATION_CODE, FACTORY, LAST_CHECK_DATE, NEXT_CHECK_PLAN_DATE, STATUS_USE, USE_SECTION, CHECK_FREQUENCY, IS_ACTIVE, CREATED_AT)
    VALUES (
        S.MANAGEMENT_NO, S.JIG_NAME, S.JIG_TYPE, S.JIG_TYPE_CODE, S.JIG_SIZE, S.USE_PRODUCT, S.PURPOSE_USE, S.LOCATION_CODE, S.FACTORY,
        S.LAST_CHECK_DATE,
        CASE S.CHECK_FREQUENCY
            WHEN N'1 tháng' THEN DATEADD(MONTH, 1, S.LAST_CHECK_DATE)
            WHEN N'3 tháng' THEN DATEADD(MONTH, 3, S.LAST_CHECK_DATE)
            WHEN N'6 tháng' THEN DATEADD(MONTH, 6, S.LAST_CHECK_DATE)
            WHEN N'1 năm' THEN DATEADD(YEAR, 1, S.LAST_CHECK_DATE)
            WHEN N'2 năm' THEN DATEADD(YEAR, 2, S.LAST_CHECK_DATE)
            ELSE NULL
        END,
        N'Đang sử dụng', S.DEPARTMENT, S.CHECK_FREQUENCY, 1, GETDATE());

UPDATE dbo.JIG_REGISTER_REQUEST
SET REQUEST_STATUS = 'APPROVED',
    APPROVE_BY = @APPROVE_BY,
    APPROVE_AT = GETDATE(),
    STATUS_USE = N'Đang sử dụng'
WHERE REQUEST_ID = @REQUEST_ID
  AND REQUEST_STATUS = 'WAITING_APPROVE';";

            return DbUtils.Execute(
                SQL_QUERY,
                new SqlParameter("@REQUEST_ID", REQUEST_ID),
                new SqlParameter("@APPROVE_BY", (object)APPROVE_BY ?? DBNull.Value));
        }

        public DataTable GetJigsAvailableForCancel()
        {
            const string SQL_QUERY = @"
SELECT
    JIG_ID,
    CONTROL_NO,
    JIG_NAME,
    USE_SECTION
FROM dbo.JIG_MASTER
WHERE IS_ACTIVE = 1
  AND ISNULL(STATUS_USE, N'') <> N'Ngưng sử dụng'
ORDER BY CONTROL_NO;";
            return DbUtils.GetData(SQL_QUERY);
        }

        public bool HasWaitingCancelRequest(int JIG_ID)
        {
            const string SQL_QUERY = @"
SELECT CASE WHEN EXISTS
(
    SELECT 1
    FROM dbo.JIG_CANCEL_REQUEST
    WHERE JIG_ID = @JIG_ID
      AND REQUEST_STATUS = 'WAITING_APPROVE'
)
THEN 1 ELSE 0 END AS HAS_WAITING;";
            var DT = DbUtils.GetData(SQL_QUERY, new SqlParameter("@JIG_ID", JIG_ID));
            return DT.Rows.Count > 0 && Convert.ToInt32(DT.Rows[0]["HAS_WAITING"]) == 1;
        }

        public int CreateCancelRequest(int JIG_ID, string CANCEL_REASON, string REQUEST_BY)
        {
            const string SQL_QUERY = @"
INSERT INTO dbo.JIG_CANCEL_REQUEST(JIG_ID, REQUEST_STATUS, CANCEL_REASON, REQUEST_BY)
VALUES (@JIG_ID, 'WAITING_APPROVE', @CANCEL_REASON, @REQUEST_BY);";
            return DbUtils.Execute(
                SQL_QUERY,
                new SqlParameter("@JIG_ID", JIG_ID),
                new SqlParameter("@CANCEL_REASON", (object)CANCEL_REASON ?? DBNull.Value),
                new SqlParameter("@REQUEST_BY", (object)REQUEST_BY ?? DBNull.Value));
        }

        public DataTable GetCancelWaitingApproveRequests()
        {
            const string SQL_QUERY = @"
SELECT
    ROW_NUMBER() OVER(ORDER BY CR.REQUEST_AT DESC) AS STT,
    CR.CANCEL_ID,
    JM.CONTROL_NO,
    JM.JIG_NAME,
    ISNULL(JM.JIG_TYPE, JM.JIG_TYPE_CODE) AS JIG_TYPE,
    JM.JIG_SIZE,
    JM.USE_PRODUCT,
    JM.PURPOSE_USE,
    JM.LOCATION_CODE,
    JM.USE_SECTION,
    CR.REQUEST_AT,
    CR.REQUEST_BY,
    CR.CANCEL_REASON
FROM dbo.JIG_CANCEL_REQUEST CR
INNER JOIN dbo.JIG_MASTER JM ON CR.JIG_ID = JM.JIG_ID
WHERE CR.REQUEST_STATUS = 'WAITING_APPROVE'
ORDER BY CR.REQUEST_AT DESC;";
            return DbUtils.GetData(SQL_QUERY);
        }

        public int DeleteCancelRequest(int CANCEL_ID)
        {
            const string SQL_QUERY = @"
DELETE FROM dbo.JIG_CANCEL_REQUEST
WHERE CANCEL_ID = @CANCEL_ID
  AND REQUEST_STATUS = 'WAITING_APPROVE';";
            return DbUtils.Execute(SQL_QUERY, new SqlParameter("@CANCEL_ID", CANCEL_ID));
        }

        public int ApproveCancelRequest(int CANCEL_ID, string APPROVE_BY)
        {
            const string SQL_QUERY = @"
DECLARE @JIG_ID INT;
SELECT @JIG_ID = JIG_ID
FROM dbo.JIG_CANCEL_REQUEST
WHERE CANCEL_ID = @CANCEL_ID
  AND REQUEST_STATUS = 'WAITING_APPROVE';

IF @JIG_ID IS NULL RETURN;

UPDATE dbo.JIG_CANCEL_REQUEST
SET REQUEST_STATUS = 'APPROVED',
    APPROVE_BY = @APPROVE_BY,
    APPROVE_AT = GETDATE()
WHERE CANCEL_ID = @CANCEL_ID
  AND REQUEST_STATUS = 'WAITING_APPROVE';

UPDATE dbo.JIG_MASTER
SET STATUS_USE = N'Ngưng sử dụng',
    IS_ACTIVE = 0,
    UPDATED_AT = GETDATE()
WHERE JIG_ID = @JIG_ID;";
            return DbUtils.Execute(
                SQL_QUERY,
                new SqlParameter("@CANCEL_ID", CANCEL_ID),
                new SqlParameter("@APPROVE_BY", (object)APPROVE_BY ?? DBNull.Value));
        }

        public DataTable GetCancelHistory()
        {
            const string SQL_QUERY = @"
SELECT
    ROW_NUMBER() OVER(ORDER BY CR.APPROVE_AT DESC, CR.REQUEST_AT DESC) AS STT,
    CR.CANCEL_ID,
    JM.CONTROL_NO,
    JM.JIG_NAME,
    ISNULL(JM.JIG_TYPE, JM.JIG_TYPE_CODE) AS JIG_TYPE,
    JM.JIG_SIZE,
    JM.USE_PRODUCT,
    JM.PURPOSE_USE,
    JM.LOCATION_CODE,
    JM.USE_SECTION,
    CR.REQUEST_AT,
    CR.REQUEST_BY,
    CR.CANCEL_REASON,
    CR.APPROVE_AT
FROM dbo.JIG_CANCEL_REQUEST CR
INNER JOIN dbo.JIG_MASTER JM ON CR.JIG_ID = JM.JIG_ID
WHERE CR.REQUEST_STATUS = 'APPROVED'
ORDER BY CR.APPROVE_AT DESC, CR.REQUEST_AT DESC;";
            return DbUtils.GetData(SQL_QUERY);
        }

        public DataRow GetJigMasterByControlNo(string CONTROL_NO)
        {
            const string SQL_QUERY = @"
SELECT TOP 1 *
FROM dbo.JIG_MASTER
WHERE CONTROL_NO = @CONTROL_NO
  AND IS_ACTIVE = 1;";
            var DT = DbUtils.GetData(SQL_QUERY, new SqlParameter("@CONTROL_NO", CONTROL_NO));
            return DT.Rows.Count == 0 ? null : DT.Rows[0];
        }

        public int UpdateJigMasterFromRegister(
            string OLD_CONTROL_NO,
            string NEW_CONTROL_NO,
            string DEPARTMENT,
            string FACTORY,
            string JIG_NAME,
            string JIG_TYPE_CODE,
            string JIG_SIZE,
            string USE_PRODUCT,
            string PURPOSE_USE,
            string LOCATION_CODE,
            DateTime? LAST_CHECK_DATE,
            string CHECK_FREQUENCY)
        {
            const string SQL_QUERY = @"
DECLARE @OLD_JIG_NAME NVARCHAR(200),
        @OLD_JIG_TYPE_CODE VARCHAR(50),
        @OLD_JIG_SIZE VARCHAR(50),
        @OLD_USE_PRODUCT NVARCHAR(300),
        @OLD_PURPOSE_USE NVARCHAR(300),
        @OLD_LOCATION_CODE VARCHAR(50),
        @OLD_FACTORY VARCHAR(50),
        @OLD_DEPARTMENT NVARCHAR(100);

SELECT
    @OLD_JIG_NAME = JIG_NAME,
    @OLD_JIG_TYPE_CODE = JIG_TYPE_CODE,
    @OLD_JIG_SIZE = JIG_SIZE,
    @OLD_USE_PRODUCT = USE_PRODUCT,
    @OLD_PURPOSE_USE = PURPOSE_USE,
    @OLD_LOCATION_CODE = LOCATION_CODE,
    @OLD_FACTORY = FACTORY,
    @OLD_DEPARTMENT = USE_SECTION
FROM dbo.JIG_MASTER
WHERE CONTROL_NO = @OLD_CONTROL_NO
  AND IS_ACTIVE = 1;

UPDATE dbo.JIG_MASTER
SET CONTROL_NO = @NEW_CONTROL_NO,
    JIG_NAME = @JIG_NAME,
    JIG_TYPE = ISNULL(NULLIF(@JIG_TYPE_CODE, ''), JIG_TYPE),
    JIG_TYPE_CODE = @JIG_TYPE_CODE,
    JIG_SIZE = @JIG_SIZE,
    USE_PRODUCT = @USE_PRODUCT,
    PURPOSE_USE = @PURPOSE_USE,
    LOCATION_CODE = @LOCATION_CODE,
    FACTORY = @FACTORY,
    USE_SECTION = @DEPARTMENT,
    LAST_CHECK_DATE = @LAST_CHECK_DATE,
    CHECK_FREQUENCY = @CHECK_FREQUENCY,
    NEXT_CHECK_PLAN_DATE = CASE @CHECK_FREQUENCY
        WHEN N'1 tháng' THEN DATEADD(MONTH, 1, @LAST_CHECK_DATE)
        WHEN N'3 tháng' THEN DATEADD(MONTH, 3, @LAST_CHECK_DATE)
        WHEN N'6 tháng' THEN DATEADD(MONTH, 6, @LAST_CHECK_DATE)
        WHEN N'1 năm' THEN DATEADD(YEAR, 1, @LAST_CHECK_DATE)
        WHEN N'2 năm' THEN DATEADD(YEAR, 2, @LAST_CHECK_DATE)
        ELSE NULL
    END,
    UPDATED_AT = GETDATE()
WHERE CONTROL_NO = @OLD_CONTROL_NO
  AND IS_ACTIVE = 1;

IF @@ROWCOUNT > 0
BEGIN
    INSERT INTO dbo.JIG_EDIT_HISTORY
    (
        JIG_NAME, OLD_CONTROL_NO, NEW_CONTROL_NO, JIG_TYPE_CODE, JIG_SIZE, USE_PRODUCT, PURPOSE_USE,
        LOCATION_CODE, DEPARTMENT, FACTORY, UPDATED_BY
    )
    VALUES
    (
        ISNULL(@OLD_JIG_NAME, @JIG_NAME), @OLD_CONTROL_NO, @NEW_CONTROL_NO, ISNULL(@OLD_JIG_TYPE_CODE, @JIG_TYPE_CODE),
        ISNULL(@OLD_JIG_SIZE, @JIG_SIZE), ISNULL(@OLD_USE_PRODUCT, @USE_PRODUCT), ISNULL(@OLD_PURPOSE_USE, @PURPOSE_USE),
        ISNULL(@OLD_LOCATION_CODE, @LOCATION_CODE), ISNULL(@OLD_DEPARTMENT, @DEPARTMENT), ISNULL(@OLD_FACTORY, @FACTORY), @UPDATED_BY
    );
END;";

            return DbUtils.Execute(
                SQL_QUERY,
                new SqlParameter("@OLD_CONTROL_NO", (object)OLD_CONTROL_NO ?? DBNull.Value),
                new SqlParameter("@NEW_CONTROL_NO", (object)NEW_CONTROL_NO ?? DBNull.Value),
                new SqlParameter("@DEPARTMENT", (object)DEPARTMENT ?? DBNull.Value),
                new SqlParameter("@FACTORY", (object)FACTORY ?? DBNull.Value),
                new SqlParameter("@JIG_NAME", (object)JIG_NAME ?? DBNull.Value),
                new SqlParameter("@JIG_TYPE_CODE", (object)JIG_TYPE_CODE ?? DBNull.Value),
                new SqlParameter("@JIG_SIZE", (object)JIG_SIZE ?? DBNull.Value),
                new SqlParameter("@USE_PRODUCT", (object)USE_PRODUCT ?? DBNull.Value),
                new SqlParameter("@PURPOSE_USE", (object)PURPOSE_USE ?? DBNull.Value),
                new SqlParameter("@LOCATION_CODE", (object)LOCATION_CODE ?? DBNull.Value),
                new SqlParameter("@LAST_CHECK_DATE", (object)LAST_CHECK_DATE ?? DBNull.Value),
                new SqlParameter("@CHECK_FREQUENCY", (object)CHECK_FREQUENCY ?? DBNull.Value),
                new SqlParameter("@UPDATED_BY", (object)AppSession.UserId ?? DBNull.Value));
        }

        public DataTable GetJigEditHistory()
        {
            const string SQL_QUERY = @"
SELECT
    ROW_NUMBER() OVER(ORDER BY UPDATED_AT DESC, HISTORY_ID DESC) AS STT,
    HISTORY_ID,
    JIG_NAME,
    OLD_CONTROL_NO,
    NEW_CONTROL_NO,
    JIG_TYPE_CODE,
    JIG_SIZE,
    USE_PRODUCT,
    PURPOSE_USE,
    LOCATION_CODE,
    DEPARTMENT,
    FACTORY,
    UPDATED_BY,
    UPDATED_AT
FROM dbo.JIG_EDIT_HISTORY
ORDER BY UPDATED_AT DESC, HISTORY_ID DESC;";
            return DbUtils.GetData(SQL_QUERY);
        }
    }
}
