using PC_Devices.DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PC_Devices.DTO
{
    public class UserDTO
    {
        public bool _loginUser(string userID, string pass)
        {
            try
            {
                bool check = false;
                //Constaint._DocumentType = DocumentType;

                string _query = "SELECT a.USER_ID, a.FULLNAME ,a.ID_ACCESS, a.EMAIL FROM TBL_ACCOUNT a WHERE a.USER_ID = '" + userID + "' AND a.PASSWORD='" + Constaint._md5(pass) + "'";
                //string _query = "SELECT a.USER_ID, a.SECTION_ID, a.FULLNAME ,a.ID_ACCESS, s.SECTION_SHORT_NAME FROM TBL_ACCOUNT a left join TBL_SECTION_MST s on a.SECTION_ID = s.SECTION_ID WHERE a.USER_ID = '" + userID + "' AND a.PASSWORD='" + Constaint._md5(pass) + "'";
                DataTable _data = DBUtils._getData(_query);
                if (_data.Rows.Count > 0 && _data != null)
                {
                    Constaint._userID = Convert.ToString(_data.Rows[0]["USER_ID"]);
                    Constaint._nameUser = Convert.ToString(_data.Rows[0]["FULLNAME"]);
                    Constaint._access = Convert.ToString(_data.Rows[0]["ID_ACCESS"]);
                    Constaint._email = Convert.ToString(_data.Rows[0]["EMAIL"]);
                    //Constaint._sectionShort = Convert.ToString(_data.Rows[0]["SECTION_SHORT_NAME"]);
                    //Constaint._sectionID = Convert.ToString(_data.Rows[0]["SECTION_ID"]);
                    Constaint._password = Constaint._md5(pass);
                    //Constaint._sectionName = Convert.ToString(_data.Rows[0]["SECTION_NAME"]);
                    //Constaint._postisionID = Convert.ToString(_data.Rows[0]["POSTISION_ID"]);
                    //Constaint._postisionName = Convert.ToString(_data.Rows[0]["POSTISION_NAME"]);
                    //Constaint._factoryName = Convert.ToString(_data.Rows[0]["FACTORY_NAME"]);
                    //Constaint._sectionID = Convert.ToString(_data.Rows[0]["SECTION_ID"]);
                    //Constaint._sectionShort = Convert.ToString(_data.Rows[0]["SECTION_SHORT_NAME"]);
                    MessageBox.Show("Login successfull !" + "\n" + "Welcome " + Constaint._nameUser + "!");
                    check = true;
                }
                //string queryServerFile = "SELECT * FROM TBL_SERVER_FOLDER_FILE ORDER BY ID ASC";
                //DataTable _dataServerFile = DBUtils._getData(queryServerFile);
                //if (_dataServerFile.Rows.Count > 0 && _dataServerFile != null)
                //{
                    //string ipAdressSqlServer = "172.17.140.55";
                    //using (Ping pinger = new Ping())
                    //{
                    //    PingReply reply = pinger.Send(ipAdressSqlServer);
                    //    if (reply.Status == IPStatus.Success) // Dải 1 => OK
                    //    {
                    //        Constaint._folderFormUpload = Convert.ToString(_dataServerFile.Rows[0]["PATH_SAVE_FORM"]);
                    //        Constaint._folderResultFileUpload = Convert.ToString(_dataServerFile.Rows[0]["PATH_SAVE_RESULT_FILE"]);
                    //        Constaint._folderFormUpload_ADM = Convert.ToString(_dataServerFile.Rows[0]["PATH_SAVE_FORM_ADM"]);
                    //        Constaint._folderFormUpload_Section = Convert.ToString(_dataServerFile.Rows[0]["PATH_SAVE_FORM_SECTION"]);
                    //        Constaint._folderResultFileUpload_Section = Convert.ToString(_dataServerFile.Rows[0]["PATH_SAVE_RESULT_FILE_SECTION"]);
                    //        Constaint._folderImageOpenOperation = Convert.ToString(_dataServerFile.Rows[0]["PATH_SAVE_FILE_OPEN_OPERATION"]);
                    //    }
                    //    else
                    //    {
                    //        Constaint._folderFormUpload = Convert.ToString(_dataServerFile.Rows[1]["PATH_SAVE_FORM"]);
                    //        Constaint._folderResultFileUpload = Convert.ToString(_dataServerFile.Rows[1]["PATH_SAVE_RESULT_FILE"]);
                    //        Constaint._folderFormUpload_ADM = Convert.ToString(_dataServerFile.Rows[1]["PATH_SAVE_FORM_ADM"]);
                    //        Constaint._folderFormUpload_Section = Convert.ToString(_dataServerFile.Rows[1]["PATH_SAVE_FORM_SECTION"]);
                    //        Constaint._folderResultFileUpload_Section = Convert.ToString(_dataServerFile.Rows[1]["PATH_SAVE_RESULT_FILE_SECTION"]);
                    //        Constaint._folderImageOpenOperation = Convert.ToString(_dataServerFile.Rows[1]["PATH_SAVE_FILE_OPEN_OPERATION"]);
                    //    }
                    //}
                    ////////test--------------------
                    //Constaint._folderFileUpload = @"D:\Devices";
                    //Constaint._folderResultFileUpload = @"D:\06. Software\Document control\Code\file\KQ\";
                    //Constaint._folderFormUpload_ADM = @"D:\06. Software\Document control\Code\file\ADM\";
                    //Constaint._folderFormUpload_Section = @"D:\06. Software\Document control\Code\file\SECTION\FILE_FORM\";
                    //Constaint._folderResultFileUpload_Section = @"D:\06. Software\Document control\Code\file\SECTION\RESULTS\";
                    //Constaint._folderImageOpenOperation = @"D:\06. Software\Document control\Code\file\OPEN\";
                //}
                return check;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
    }
}
