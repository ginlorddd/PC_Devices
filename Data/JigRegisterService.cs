using System;
using System.Data;
using System.Data.SqlClient;

namespace JigFlow.Data
{
    public class JigRegisterService
    {
        public DataTable GetJigTypes()
        {
            const string SQL_QUERY = "SELECT JIG_TYPE_CODE, JIG_TYPE_NAME FROM dbo.JIG_TYPE_MASTER WHERE IS_ACTIVE = 1 ORDER BY JIG_TYPE_NAME";
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

        public int CreateRegisterRequest(
            string DEPARTMENT,
            string FACTORY,
            string MANAGEMENT_NO,
            string JIG_NAME,
            string JIG_TYPE_CODE,
            string JIG_SIZE,
            string USE_PRODUCT,
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
    JIG_SIZE VARCHAR(50),
    USE_PRODUCT NVARCHAR(300),
    LOCATION_CODE VARCHAR(50),
    DEPARTMENT VARCHAR(50),
    CHECK_FREQUENCY NVARCHAR(50),
    LAST_CHECK_DATE DATE
);

INSERT INTO @REQ(MANAGEMENT_NO, JIG_NAME, JIG_TYPE_CODE, JIG_SIZE, USE_PRODUCT, LOCATION_CODE, DEPARTMENT, CHECK_FREQUENCY, LAST_CHECK_DATE)
SELECT MANAGEMENT_NO, JIG_NAME, JIG_TYPE_CODE, JIG_SIZE, USE_PRODUCT, LOCATION_CODE, DEPARTMENT, CHECK_FREQUENCY, LAST_CHECK_DATE
FROM dbo.JIG_REGISTER_REQUEST
WHERE REQUEST_ID = @REQUEST_ID
  AND REQUEST_STATUS = 'WAITING_APPROVE';

IF NOT EXISTS(SELECT 1 FROM @REQ) RETURN;

MERGE dbo.JIG_MASTER AS T
USING (SELECT * FROM @REQ) AS S
ON T.CONTROL_NO = S.MANAGEMENT_NO
WHEN MATCHED THEN
    UPDATE SET
        T.JIG_NAME = S.JIG_NAME,
        T.JIG_TYPE_CODE = S.JIG_TYPE_CODE,
        T.JIG_SIZE = S.JIG_SIZE,
        T.USE_PRODUCT = S.USE_PRODUCT,
        T.LOCATION_CODE = S.LOCATION_CODE,
        T.LAST_CHECK_DATE = S.LAST_CHECK_DATE,
        T.STATUS_USE = N'Đang sử dụng',
        T.USE_SECTION = S.DEPARTMENT,
        T.CHECK_FREQUENCY = S.CHECK_FREQUENCY,
        T.IS_ACTIVE = 1,
        T.UPDATED_AT = GETDATE()
WHEN NOT MATCHED THEN
    INSERT (CONTROL_NO, JIG_NAME, JIG_TYPE_CODE, JIG_SIZE, USE_PRODUCT, LOCATION_CODE, LAST_CHECK_DATE, STATUS_USE, USE_SECTION, CHECK_FREQUENCY, IS_ACTIVE, CREATED_AT)
    VALUES (S.MANAGEMENT_NO, S.JIG_NAME, S.JIG_TYPE_CODE, S.JIG_SIZE, S.USE_PRODUCT, S.LOCATION_CODE, S.LAST_CHECK_DATE, N'Đang sử dụng', S.DEPARTMENT, S.CHECK_FREQUENCY, 1, GETDATE());

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
    }
}
