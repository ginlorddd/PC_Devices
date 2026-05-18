using System;
using System.Data;
using System.Data.SqlClient;

namespace JigFlow.Data
{
    public class FormMasterService
    {
        public DataTable GetFormMasters()
        {
            const string sql = @"
SELECT ROW_NUMBER() OVER(ORDER BY FORM_NAME) STT, FORM_ID, FORM_CODE, FORM_NAME, FORM_VERSION, DESCRIPTION,
       TEMPLATE_FILE_PATH, PART_NAME_CELL, CONTROL_NO_CELL, CHECK_DATE_CELL, IS_DEFAULT, IS_ACTIVE
FROM dbo.FORM_MASTER
ORDER BY FORM_NAME;";
            return DbUtils.GetData(sql);
        }

        public int UpsertFormMaster(string code, string name, string version, string description, string templatePath,
            string partNameCell, string controlNoCell, string checkDateCell, bool isDefault, bool isActive)
        {
            const string sql = @"
IF EXISTS(SELECT 1 FROM dbo.FORM_MASTER WHERE FORM_CODE=@FORM_CODE)
BEGIN
    UPDATE dbo.FORM_MASTER
    SET FORM_NAME=@FORM_NAME, FORM_VERSION=@FORM_VERSION, DESCRIPTION=@DESCRIPTION,
        TEMPLATE_FILE_PATH=@TEMPLATE_FILE_PATH, PART_NAME_CELL=@PART_NAME_CELL, CONTROL_NO_CELL=@CONTROL_NO_CELL, CHECK_DATE_CELL=@CHECK_DATE_CELL,
        IS_DEFAULT=@IS_DEFAULT, IS_ACTIVE=@IS_ACTIVE, UPDATED_AT=GETDATE()
    WHERE FORM_CODE=@FORM_CODE;
END
ELSE
BEGIN
    INSERT INTO dbo.FORM_MASTER(FORM_CODE, FORM_NAME, FORM_VERSION, DESCRIPTION, TEMPLATE_FILE_PATH, PART_NAME_CELL, CONTROL_NO_CELL, CHECK_DATE_CELL, IS_DEFAULT, IS_ACTIVE)
    VALUES(@FORM_CODE,@FORM_NAME,@FORM_VERSION,@DESCRIPTION,@TEMPLATE_FILE_PATH,@PART_NAME_CELL,@CONTROL_NO_CELL,@CHECK_DATE_CELL,@IS_DEFAULT,@IS_ACTIVE);
END
IF @IS_DEFAULT = 1
    UPDATE dbo.FORM_MASTER SET IS_DEFAULT = CASE WHEN FORM_CODE=@FORM_CODE THEN 1 ELSE 0 END;";
            return DbUtils.Execute(sql,
                new SqlParameter("@FORM_CODE", (object)code ?? DBNull.Value),
                new SqlParameter("@FORM_NAME", (object)name ?? DBNull.Value),
                new SqlParameter("@FORM_VERSION", (object)version ?? DBNull.Value),
                new SqlParameter("@DESCRIPTION", (object)description ?? DBNull.Value),
                new SqlParameter("@TEMPLATE_FILE_PATH", (object)templatePath ?? DBNull.Value),
                new SqlParameter("@PART_NAME_CELL", (object)partNameCell ?? DBNull.Value),
                new SqlParameter("@CONTROL_NO_CELL", (object)controlNoCell ?? DBNull.Value),
                new SqlParameter("@CHECK_DATE_CELL", (object)checkDateCell ?? DBNull.Value),
                new SqlParameter("@IS_DEFAULT", isDefault),
                new SqlParameter("@IS_ACTIVE", isActive));
        }
    }
}
