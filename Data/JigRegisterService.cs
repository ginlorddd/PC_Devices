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
    }
}
