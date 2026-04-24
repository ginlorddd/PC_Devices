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
            const string IP_ADDRESS_SQL_SERVER = "172.16.253.2";
            using (var pinger = new Ping())
            {
                var reply = pinger.Send(IP_ADDRESS_SQL_SERVER, 1000);
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

        public static DataTable GetData(string SQL_QUERY, params SqlParameter[] SQL_PARAMETERS)
        {
            using (var conn = new SqlConnection(ConnectionString))
            using (var cmd = new SqlCommand(SQL_QUERY, conn))
            using (var adapter = new SqlDataAdapter(cmd))
            {
                if (SQL_PARAMETERS != null)
                {
                    cmd.Parameters.AddRange(SQL_PARAMETERS);
                }

                var DT_RESULT = new DataTable();
                conn.Open();
                adapter.Fill(DT_RESULT);
                return DT_RESULT;
            }
        }

        public static int Execute(string SQL_QUERY, params SqlParameter[] SQL_PARAMETERS)
        {
            using (var conn = new SqlConnection(ConnectionString))
            using (var cmd = new SqlCommand(SQL_QUERY, conn))
            {
                if (SQL_PARAMETERS != null)
                {
                    cmd.Parameters.AddRange(SQL_PARAMETERS);
                }

                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
