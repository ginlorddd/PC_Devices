using PC_Devices.DB;
using System.Data;
using System.Data.SqlClient;

namespace PC_Devices.DTO
{
    public class DieMasterDTO
    {
        public DataTable GetAll()
        {
            return DBUtils.GetData("SELECT DIE_NO, DIE_NAME, TOTAL_CAVITY FROM DIE_MST ORDER BY DIE_NO");
        }

        public void Save(string dieNo, string dieName, int cavity)
        {
            DBUtils.Exec(@"MERGE DIE_MST AS t
                          USING (SELECT @DIE_NO DIE_NO, @DIE_NAME DIE_NAME, @TOTAL_CAVITY TOTAL_CAVITY) s
                          ON (t.DIE_NO = s.DIE_NO)
                          WHEN MATCHED THEN UPDATE SET DIE_NAME=s.DIE_NAME, TOTAL_CAVITY=s.TOTAL_CAVITY
                          WHEN NOT MATCHED THEN INSERT(DIE_NO,DIE_NAME,TOTAL_CAVITY) VALUES(s.DIE_NO,s.DIE_NAME,s.TOTAL_CAVITY);",
                new SqlParameter("@DIE_NO", dieNo),
                new SqlParameter("@DIE_NAME", dieName),
                new SqlParameter("@TOTAL_CAVITY", cavity));
        }

        public void Delete(string dieNo)
        {
            DBUtils.Exec("DELETE FROM DIE_MST WHERE DIE_NO=@DIE_NO", new SqlParameter("@DIE_NO", dieNo));
        }
    }
}
