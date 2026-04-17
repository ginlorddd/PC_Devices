using System.Data;

namespace JigFlow.Data
{
    public class JigFunctionService
    {
        public DataTable GetJigFunctionList()
        {
            const string SQL_QUERY = @"
SELECT
    ROW_NUMBER() OVER (ORDER BY JM.JIG_ID) AS STT,
    JM.CONTROL_NO,
    JM.JIG_NAME,
    JM.JIG_TYPE,
    JM.JIG_SIZE,
    JM.USE_PRODUCT,
    JM.LOCATION_CODE,
    JM.STATUS_USE,
    JM.USE_SECTION,
    JM.LAST_CHECK_DATE,
    JM.NEXT_CHECK_PLAN_DATE,
    JM.CHECK_RESULT,
    JM.CHECK_FREQUENCY
FROM dbo.JIG_MASTER JM
WHERE JM.IS_ACTIVE = 1
ORDER BY JM.JIG_ID";
            return DbUtils.GetData(SQL_QUERY);
        }
    }
}
