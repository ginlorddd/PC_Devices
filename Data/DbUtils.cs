using System;
using System.Data;
using System.Data.SqlClient;
using System.Net.NetworkInformation;

namespace JigFlow.Data
{
    public static class DbUtils
    {
        public static string ConnectionString { get; private set; } = string.Empty;

        public static void SetDataInit()
        {
            const string ipAddressSqlServer = "172.16.253.2";
            using (var pinger = new Ping())
            {
                var reply = pinger.Send(ipAddressSqlServer, 1000);
                if (reply != null && reply.Status == IPStatus.Success)
                {
                    ConnectionString = @"Data Source=172.16.253.2;Initial Catalog=JigFlow;Persist Security Info=True;User ID=sa;Password=H9401811cv2";
                }
                else
                {
                    ConnectionString = @"Data Source=10.220.129.2;Initial Catalog=JigFlow;Persist Security Info=True;User ID=sa;Password=H9401811cv2";
                }
            }
        }

        public static DataTable GetData(string query, params SqlParameter[] parameters)
        {
            using (var conn = new SqlConnection(ConnectionString))
            using (var cmd = new SqlCommand(query, conn))
            using (var adapter = new SqlDataAdapter(cmd))
            {
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }

                var dt = new DataTable();
                conn.Open();
                adapter.Fill(dt);
                return dt;
            }
        }

        public static int Execute(string query, params SqlParameter[] parameters)
        {
            using (var conn = new SqlConnection(ConnectionString))
            using (var cmd = new SqlCommand(query, conn))
            {
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }

                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
