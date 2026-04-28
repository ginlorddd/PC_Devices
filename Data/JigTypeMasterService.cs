using System;
using System.Data;
using System.Data.SqlClient;

namespace JigFlow.Data
{
    public class JigTypeMasterService
    {
        public DataTable GetJigTypeMasters()
        {
            const string SQL_QUERY = @"
SELECT
    ROW_NUMBER() OVER (ORDER BY JIG_TYPE_CODE) AS STT,
    JIG_TYPE_CODE,
    JIG_TYPE_NAME,
    IS_ACTIVE
FROM dbo.JIG_TYPE_MASTER
ORDER BY JIG_TYPE_CODE;";
            return DbUtils.GetData(SQL_QUERY);
        }

        public int UpsertJigTypeMaster(string JIG_TYPE_CODE, string JIG_TYPE_NAME, bool IS_ACTIVE)
        {
            const string SQL_QUERY = @"
IF EXISTS (SELECT 1 FROM dbo.JIG_TYPE_MASTER WHERE JIG_TYPE_CODE = @JIG_TYPE_CODE)
BEGIN
    UPDATE dbo.JIG_TYPE_MASTER
    SET JIG_TYPE_NAME = @JIG_TYPE_NAME,
        IS_ACTIVE = @IS_ACTIVE,
        UPDATED_AT = GETDATE()
    WHERE JIG_TYPE_CODE = @JIG_TYPE_CODE
END
ELSE
BEGIN
    INSERT INTO dbo.JIG_TYPE_MASTER (JIG_TYPE_CODE, JIG_TYPE_NAME, IS_ACTIVE, CREATED_AT)
    VALUES (@JIG_TYPE_CODE, @JIG_TYPE_NAME, @IS_ACTIVE, GETDATE())
END";

            return DbUtils.Execute(
                SQL_QUERY,
                new SqlParameter("@JIG_TYPE_CODE", (object)JIG_TYPE_CODE ?? DBNull.Value),
                new SqlParameter("@JIG_TYPE_NAME", (object)JIG_TYPE_NAME ?? DBNull.Value),
                new SqlParameter("@IS_ACTIVE", IS_ACTIVE ? 1 : 0));
        }
    }
}
