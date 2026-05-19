using System;
using System.Data;
using System.Data.SqlClient;

namespace JigFlow.Data
{
    public class FormMasterService
    {
        public DataRow GetDefaultFormByJigType(string jigTypeCode)
        {
            const string sql = @"
SELECT TOP 1 FM.*
FROM dbo.JIG_TYPE_MASTER JTM
INNER JOIN dbo.FORM_MASTER FM ON JTM.DEFAULT_FORM_CODE = FM.FORM_CODE
WHERE JTM.JIG_TYPE_CODE = @JIG_TYPE_CODE
  AND FM.IS_ACTIVE = 1;";
            var dt = DbUtils.GetData(sql, new SqlParameter("@JIG_TYPE_CODE", (object)jigTypeCode ?? DBNull.Value));
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        public DataTable GetFormMasters()
        {
            const string sql = @"
SELECT ROW_NUMBER() OVER(ORDER BY FORM_NAME) STT, FORM_ID, FORM_CODE, FORM_NAME, FORM_VERSION, DESCRIPTION,
       TEMPLATE_FILE_PATH, PART_NAME_CELL, CONTROL_NO_CELL, CHECK_DATE_CELL, IS_ACTIVE
FROM dbo.FORM_MASTER
ORDER BY FORM_NAME;";
            return DbUtils.GetData(sql);
        }

        public string GetNextFormCode()
        {
            const string sql = @"SELECT ISNULL(MAX(CAST(RIGHT(FORM_CODE, 3) AS INT)),0)+1 NEXT_SEQ FROM dbo.FORM_MASTER WHERE FORM_CODE LIKE 'FM-%';";
            var dt = DbUtils.GetData(sql);
            return $"FM-{Convert.ToInt32(dt.Rows[0]["NEXT_SEQ"]):000}";
        }

        public int UpsertFormMaster(string code, string name, string version, string description, string templatePath,
            string partNameCell, string controlNoCell, string checkDateCell, bool isActive)
        {
            const string sql = @"
IF EXISTS(SELECT 1 FROM dbo.FORM_MASTER WHERE FORM_CODE=@FORM_CODE)
BEGIN
    UPDATE dbo.FORM_MASTER
    SET FORM_NAME=@FORM_NAME, FORM_VERSION=@FORM_VERSION, DESCRIPTION=@DESCRIPTION,
        TEMPLATE_FILE_PATH=@TEMPLATE_FILE_PATH, PART_NAME_CELL=@PART_NAME_CELL, CONTROL_NO_CELL=@CONTROL_NO_CELL, CHECK_DATE_CELL=@CHECK_DATE_CELL,
        IS_ACTIVE=@IS_ACTIVE, UPDATED_AT=GETDATE()
    WHERE FORM_CODE=@FORM_CODE;
END
ELSE
BEGIN
    INSERT INTO dbo.FORM_MASTER(FORM_CODE, FORM_NAME, FORM_VERSION, DESCRIPTION, TEMPLATE_FILE_PATH, PART_NAME_CELL, CONTROL_NO_CELL, CHECK_DATE_CELL, IS_ACTIVE)
    VALUES(@FORM_CODE,@FORM_NAME,@FORM_VERSION,@DESCRIPTION,@TEMPLATE_FILE_PATH,@PART_NAME_CELL,@CONTROL_NO_CELL,@CHECK_DATE_CELL,@IS_ACTIVE);
END
";
            return DbUtils.Execute(sql,
                new SqlParameter("@FORM_CODE", (object)code ?? DBNull.Value),
                new SqlParameter("@FORM_NAME", (object)name ?? DBNull.Value),
                new SqlParameter("@FORM_VERSION", (object)version ?? DBNull.Value),
                new SqlParameter("@DESCRIPTION", (object)description ?? DBNull.Value),
                new SqlParameter("@TEMPLATE_FILE_PATH", (object)templatePath ?? DBNull.Value),
                new SqlParameter("@PART_NAME_CELL", (object)partNameCell ?? DBNull.Value),
                new SqlParameter("@CONTROL_NO_CELL", (object)controlNoCell ?? DBNull.Value),
                new SqlParameter("@CHECK_DATE_CELL", (object)checkDateCell ?? DBNull.Value),
                new SqlParameter("@IS_ACTIVE", isActive));
        }
    }
}
