using DevExpress.XtraGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraPrinting;
using System.Diagnostics;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;


namespace PC_Devices.DB
{
    public static class Constaint
    {
        public static int isLoginOK = 0;
        public static int Count = 0;
        public static string _userID;
        public static string _nameUser;
        public static string _password;
        public static string _access;
        public static string _email;
        public static string _DocumentType;
        //public static string _sectionID;
        //public static string _sectionName;
        //public static string _postisionID;
        //public static string _postisionName;
        //public static string MoldType;
        //public static string _sectionShort;
        public static string _folderFileUpload = @"\\172.17.140.9\PC_Devices";
        //public static string PathMeeting = "";
        //public const string GeneralManager = "S01";
        //public const string SeniorAdvisor = "S02";
        //public const string Manager = "S03";
        //public const string AssistantManager = "S04";
        //public const string SeniorStaff = "S05";
        //public const string Saff = "S06";
        //public const string Leader = "S08";
        //public const string Operator = "S09";
        //public const string Administrator = "S099";

        public static void _messageAdd(string message)
        {
            MessageBox.Show("Insert successful!" + "\n" + message);
        }
        public static void _messageAdd()
        {
            MessageBox.Show("Insert successful!", _userID);
        }
        public static void _messageSave()
        {
            MessageBox.Show("Save successful!", _userID);
        }
        public static void _messageUpdate()
        {
            MessageBox.Show("Update successful!", _userID);
        }
        public static void _messageDel()
        {
            MessageBox.Show("Delete successful!", _userID);
        }
        public static void _messsWarningFieldName(string caption)
        {
            MessageBox.Show("Không được để trống !", _userID, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void _messageImport()
        {
            MessageBox.Show("Import successful!", _userID);
        }
        public static void _messageExport()
        {
            MessageBox.Show("Export successful!", _userID);
        }

        public static byte[] encryptData(string data)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider md5Hasher = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] hashedBytes;
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            hashedBytes = md5Hasher.ComputeHash(encoder.GetBytes(data));
            return hashedBytes;
        }

        public static string _md5(string data)
        {
            return BitConverter.ToString(encryptData(data)).Replace("-", "").ToLower();
        }
        public static string _createMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
        public static DataTable ToDataTable<T>(this IList<T> data)
        {
            DataTable table = null;
            try
            {
                PropertyDescriptorCollection props =
                TypeDescriptor.GetProperties(typeof(T));
                table = new DataTable();
                for (int i = 0; i < props.Count; i++)
                {
                    PropertyDescriptor prop = props[i];
                    table.Columns.Add(prop.Name, prop.PropertyType);
                }
                object[] values = new object[props.Count];
                foreach (T item in data)
                {
                    for (int i = 0; i < values.Length; i++)
                    {
                        values[i] = props[i].GetValue(item);
                    }
                    table.Rows.Add(values);
                }
                return table;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return table;
            }
        }
        public static void _exportGridViewXlsx(GridView gridview, GridControl gridControl)
        {
            try
            {
                using (SaveFileDialog saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "Excel (.xlsx)|*.xlsx";
                    if (saveDialog.ShowDialog() != DialogResult.Cancel)
                    {
                        string exportFilePath = saveDialog.FileName;
                        string fileExtenstion = new System.IO.FileInfo(exportFilePath).Extension;
                        switch (fileExtenstion)
                        {
                            case ".xlsx":
                                gridControl.ExportToXlsx(exportFilePath);
                                break;
                            default:
                                break;
                        }

                        if (File.Exists(exportFilePath))
                        {
                            try
                            {
                                //Try to open the file and let windows decide how to open it.
                                System.Diagnostics.Process.Start(exportFilePath);
                            }
                            catch
                            {
                                String msg = "The file could not be opened." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                                MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            String msg = "The file could not be saved." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                            MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), _userID);
            }
        }
    }
    public enum ROLE
    {
        ALL,
        SAVE,
        DELETE,
        IMPORT,
        EXPORT,
        PRINT,
        MAINTENANCE
    }
}
