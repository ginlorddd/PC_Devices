using System;
using System.Data;
using System.Data.SqlClient;
using System.Net.NetworkInformation;

namespace PC_Devices.DB
{
    public static class DBUtils
    {
        public static string _stringConnection = string.Empty;

        public static void SetDataInit()
        {
            string ipAdressSqlServer = "172.16.253.2";
            using (Ping pinger = new Ping())
            {
                PingReply reply = pinger.Send(ipAdressSqlServer);
                if (reply.Status == IPStatus.Success)
                {
                    _stringConnection = @"Data Source=172.16.253.2;Initial Catalog=DM_OHD;Persist Security Info=True;User ID=sa;Password=H9401811cv2";
                }
                else
                {
                    _stringConnection = @"Data Source=10.220.129.2;Initial Catalog=DM_OHD;Persist Security Info=True;User ID=sa;Password=H9401811cv2";
                }
            }
        }

        public static DataTable GetData(string query, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(_stringConnection))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
            {
                if (parameters != null && parameters.Length > 0)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                DataTable dt = new DataTable();
                conn.Open();
                ad.Fill(dt);
                return dt;
            }
        }

        public static int Exec(string query, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(_stringConnection))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                if (parameters != null && parameters.Length > 0)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public static object ExecScalar(string query, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(_stringConnection))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                if (parameters != null && parameters.Length > 0)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                conn.Open();
                return cmd.ExecuteScalar();
            }
        }
    }
}
