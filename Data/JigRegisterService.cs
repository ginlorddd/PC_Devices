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
    }
}
