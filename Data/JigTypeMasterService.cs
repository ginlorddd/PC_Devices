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
    JTM.JIG_TYPE_CODE,
    JTM.JIG_TYPE_NAME,
    JTM.JIG_TYPE_MAIN,
    JTM.DEFAULT_DRAWING_CODE,
    DM.DRAWING_NAME,
    DM.FILE_PATH AS DRAWING_FILE_PATH,
    JTM.IS_ACTIVE
FROM dbo.JIG_TYPE_MASTER JTM
LEFT JOIN dbo.JIG_DRAWING_MASTER DM ON JTM.DEFAULT_DRAWING_CODE = DM.DRAWING_CODE
ORDER BY JIG_TYPE_CODE;";
            return DbUtils.GetData(SQL_QUERY);
        }

        public int UpsertJigTypeMaster(string JIG_TYPE_CODE, string JIG_TYPE_NAME, string JIG_TYPE_MAIN, string DEFAULT_DRAWING_CODE, string DRAWING_NAME, string DRAWING_FILE_PATH, bool IS_ACTIVE)
        {
            const string SQL_QUERY = @"
IF @DEFAULT_DRAWING_CODE IS NOT NULL AND LTRIM(RTRIM(@DEFAULT_DRAWING_CODE)) <> ''
BEGIN
    IF EXISTS (SELECT 1 FROM dbo.JIG_DRAWING_MASTER WHERE DRAWING_CODE = @DEFAULT_DRAWING_CODE)
    BEGIN
        UPDATE dbo.JIG_DRAWING_MASTER
        SET DRAWING_NAME = @DRAWING_NAME,
            FILE_PATH = @DRAWING_FILE_PATH,
            IS_ACTIVE = 1
        WHERE DRAWING_CODE = @DEFAULT_DRAWING_CODE;
    END
    ELSE
    BEGIN
        INSERT INTO dbo.JIG_DRAWING_MASTER(DRAWING_CODE, DRAWING_NAME, FILE_PATH, IS_ACTIVE, CREATED_AT)
        VALUES (@DEFAULT_DRAWING_CODE, @DRAWING_NAME, @DRAWING_FILE_PATH, 1, GETDATE());
    END
END

IF EXISTS (SELECT 1 FROM dbo.JIG_TYPE_MASTER WHERE JIG_TYPE_CODE = @JIG_TYPE_CODE)
BEGIN
    UPDATE dbo.JIG_TYPE_MASTER
    SET JIG_TYPE_NAME = @JIG_TYPE_NAME,
        JIG_TYPE_MAIN = @JIG_TYPE_MAIN,
        DEFAULT_DRAWING_CODE = @DEFAULT_DRAWING_CODE,
        IS_ACTIVE = @IS_ACTIVE
    WHERE JIG_TYPE_CODE = @JIG_TYPE_CODE
END
ELSE
BEGIN
    INSERT INTO dbo.JIG_TYPE_MASTER (JIG_TYPE_CODE, JIG_TYPE_NAME, JIG_TYPE_MAIN, DEFAULT_DRAWING_CODE, IS_ACTIVE, CREATED_AT)
    VALUES (@JIG_TYPE_CODE, @JIG_TYPE_NAME, @JIG_TYPE_MAIN, @DEFAULT_DRAWING_CODE, @IS_ACTIVE, GETDATE())
END";

            return DbUtils.Execute(
                SQL_QUERY,
                new SqlParameter("@JIG_TYPE_CODE", (object)JIG_TYPE_CODE ?? DBNull.Value),
                new SqlParameter("@JIG_TYPE_NAME", (object)JIG_TYPE_NAME ?? DBNull.Value),
                new SqlParameter("@JIG_TYPE_MAIN", (object)JIG_TYPE_MAIN ?? DBNull.Value),
                new SqlParameter("@DEFAULT_DRAWING_CODE", (object)DEFAULT_DRAWING_CODE ?? DBNull.Value),
                new SqlParameter("@DRAWING_NAME", (object)DRAWING_NAME ?? DBNull.Value),
                new SqlParameter("@DRAWING_FILE_PATH", (object)DRAWING_FILE_PATH ?? DBNull.Value),
                new SqlParameter("@IS_ACTIVE", IS_ACTIVE ? 1 : 0));
        }
    }
}
