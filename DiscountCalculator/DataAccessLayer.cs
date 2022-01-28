using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;

namespace DiscountCalculator
{
    public static class DataAccessLayer
    {
        public static DataTable DBconn()
        {
            DataTable dt = null;
            try
            {
                string connstring = ConfigurationManager.AppSettings.Get("userconnection");
                SqlConnection conn = new SqlConnection(connstring);
                conn.Open();
                SqlCommand command = new SqlCommand("sp_getusers", conn);
                command.CommandType = CommandType.StoredProcedure;
                dt = new DataTable("AllUsers");                
                SqlDataAdapter data = new SqlDataAdapter(command);                    
                data.Fill(dt);
                conn.Close();                
            }
            catch(Exception ex)
            {
                ErrorLogging(ex);
                Console.WriteLine("Connection Error. Please Try Again.");
                Console.ReadKey();
            }
            return dt;                       
        }

        public static void ErrorLogging(Exception ex)
        {
            string path = ConfigurationManager.AppSettings.Get("path");
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
            }
            using (StreamWriter writer = File.AppendText(path))
            {
                writer.WriteLine("======ERROR LOGGING======");
                writer.WriteLine("DATETIME: " + DateTime.Now);
                writer.WriteLine("Error Message: " + ex.Message);
                writer.WriteLine("Stack Trace: " + ex.StackTrace);
                writer.WriteLine();
            }
        }
    }
}
