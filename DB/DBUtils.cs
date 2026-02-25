using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace PC_Devices.DB
{
    public class DBUtils
    {
        //=========================================
        // LẤY IP LOCAL CỦA PC
        //=========================================
        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                    return ip.ToString();
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        public static string IpAddress = GetLocalIPAddress();

        //=========================================
        // CHUỖI KẾT NỐI
        //=========================================
        public static string _stringConnection = "";

        public static void SetDataInit()
        {
            string ipAdressSqlServer = "172.17.140.55";

            using (Ping pinger = new Ping())
            {
                PingReply reply = pinger.Send(ipAdressSqlServer);

                if (reply.Status == IPStatus.Success)
                {
                    _stringConnection =
                        @"Data Source=172.17.140.11;Initial Catalog=PU_TEST;Persist Security Info=True;User ID=sa;Password=H9401811cv2";
                }
                else
                {
                    _stringConnection =
                        @"Data Source=10.220.100.1;Initial Catalog=PU_TEST;Persist Security Info=True;User ID=sa;Password=H9401811cv2";
                }
            }
        }

        //=========================================
        // HÀM SELECT (TRẢ VỀ DATATABLE)
        //=========================================
        public static DataTable _getData(string query)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_stringConnection))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    SqlDataAdapter ad = new SqlDataAdapter(query, conn);
                    ad.Fill(dt);
                    conn.Close();
                    return dt;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        //=========================================
        // HÀM EXECUTE (INSERT / UPDATE / DELETE)
        //=========================================
        public static int _exec(string query)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_stringConnection))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    int rows = cmd.ExecuteNonQuery();
                    conn.Close();
                    return rows;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return -1;
            }
        }

        //=========================================
        // HÀM EXECUTE PARAMETER AN TOÀN (TÙY CHỌN)
        //=========================================
        public static int _exec(string query, SqlParameter[] prms)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_stringConnection))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddRange(prms);
                    int rows = cmd.ExecuteNonQuery();
                    conn.Close();
                    return rows;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return -1;
            }
        }
    }
}
