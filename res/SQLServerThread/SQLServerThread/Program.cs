using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLServerThread
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = args[2];
            conn.Open();
            string selectString = "Select PartUniqueID From[WIP_Test].[dbo].[WipHeaderHistory] Where[PartCode] = '" + args[0] + "' ;";
            string updateString = "update [WIP_Test].[dbo].[WipHeaderHistory] set [NextStationCode] = 90 where [PartCode] = '" + args[0] + "' ;";
            SqlCommand command = new SqlCommand(selectString, conn);
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            SqlDataReader reader =  command.ExecuteReader();
            stopWatch.Stop();
            long tsSelect = stopWatch.ElapsedMilliseconds;
            //System.IO.File.WriteAllText(@"C:\Users\Edoardo\source\repos\StressTest\StressTest\SQLServerLogsSelect\sqlserverlog" + args[1] + ".txt", "" + tsSelect);
            System.IO.File.WriteAllText(@"..\..\output\SQLServerLogsSelect\sqlserverlog" + args[1] + ".txt", "" + tsSelect);
            reader.Close();

            SqlCommand command2 = new SqlCommand(selectString, conn);
            
            try
            {
                stopWatch.Start();
                command2.ExecuteNonQuery();
                stopWatch.Stop();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
           
            long tsUpdate = stopWatch.ElapsedMilliseconds;
            //System.IO.File.WriteAllText(@"C:\Users\Edoardo\source\repos\StressTest\StressTest\SQLServerLogsUpdate\sqlserverlog" + args[1] + ".txt", "" + tsUpdate);
            System.IO.File.WriteAllText(@"..\..\output\SQLServerLogsUpdate\sqlserverlog" + args[1] + ".txt", "" + tsUpdate);
            conn.Close();
        }
    }
}
