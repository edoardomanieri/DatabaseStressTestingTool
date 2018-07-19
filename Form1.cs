
using StressTest.persistence;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StressTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> partCodes = new List<string>();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=EDOARDO;Initial Catalog=WIP;Integrated Security=True";
            conn.Open();
            string commandString = "Select top (1000) [PartCode] From[WIP_Test].[dbo].[WipHeaderHistory]";
            SqlCommand command = new SqlCommand(commandString, conn);
            SqlDataReader reader = command.ExecuteReader();
            
            while (reader.Read())
            {
                partCodes.Add("" + reader[0]);
                
            }
            reader.Close();
            conn.Close();

            int numberOfStations = int.Parse(textBox1.Text);
                
            Random rand = new Random();
            Process[] ArrayMongoProcess = new Process[numberOfStations];
            Process[] ArraySQLProcess = new Process[numberOfStations];
            ProcessStartInfo[] ArrayMongoProcessStartInfo = new ProcessStartInfo[numberOfStations];
            ProcessStartInfo[] ArraySQLProcessStartInfo = new ProcessStartInfo[numberOfStations];

            string partCode;
            string arguments;
            for (int i = 0; i < numberOfStations; i++)
            {
                ArrayMongoProcess[i] = new Process();
                ArraySQLProcess[i] = new Process();
                partCode = partCodes[rand.Next(partCodes.Count - 1)];
                arguments = partCode + " " + i;
                //  ArrayMongoProcessStartInfo[i] = new ProcessStartInfo(@"C:\Users\Edoardo\source\repos\MongoThread\MongoThread\bin\Debug\MongoThread.exe");
                ArrayMongoProcessStartInfo[i] = new ProcessStartInfo(@"..\..\res\MongoThread\MongoThread\bin\Debug\MongoThread.exe");
                ArrayMongoProcessStartInfo[i].Arguments = arguments;
                // ArraySQLProcessStartInfo[i] = new ProcessStartInfo(@"C:\Users\Edoardo\source\repos\SQLServerThread\SQLServerThread\bin\Debug\SQLServerThread.exe");
                ArraySQLProcessStartInfo[i] = new ProcessStartInfo(@"..\..\res\SQLServerThread\SQLServerThread\bin\Debug\SQLServerThread.exe");
                ArraySQLProcessStartInfo[i].Arguments = arguments;
                ArrayMongoProcess[i].StartInfo = ArrayMongoProcessStartInfo[i];
                ArraySQLProcess[i].StartInfo = ArraySQLProcessStartInfo[i];
            }

            for (int i = 0; i < numberOfStations; i++)
            {
                ArrayMongoProcess[i].Start();
            }

            for (int i = 0; i < numberOfStations; i++)
            {
                ArrayMongoProcess[i].WaitForExit();
            }

            for (int i = 0; i < numberOfStations; i++)
            {
                ArraySQLProcess[i].Start();
            }

            for (int i = 0; i < numberOfStations; i++)
            {
                ArraySQLProcess[i].WaitForExit();
            }

            Writer wr = new Writer();
            wr.Read(numberOfStations);
            wr.CalcolateAverageAndWrite();
            getResults.Visible = true;
        }

        private void getResults_Click(object sender, EventArgs e)
        {
            Process.Start(@"..\..\output\Results\resultSelect.txt");
            Process.Start(@"..\..\output\Results\resultUpdate.txt");
        }
    }
}
