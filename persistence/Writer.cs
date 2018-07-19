using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StressTest.persistence
{
    public class Writer
    {
        public List<long> SQLSelectResults;
        public List<long> MongoSelectResults;

        public List<long> SQLUpdateResults;
        public List<long> MongoUpdateResults;

        public Writer()
        {
            SQLSelectResults = new List<long>();
            MongoSelectResults = new List<long>();
            SQLUpdateResults = new List<long>();
            MongoUpdateResults = new List<long>();
        }

        public void Read(int numberOfStations)
        {
            foreach (string file in Directory.GetFiles(@"..\..\output\SQLServerLogsSelect"))

            {
                if (int.Parse(file.Substring(file.LastIndexOf('\\') + 1).Replace("sqlserverlog", "").Replace(".txt", "").Trim()) >= numberOfStations) { 
                    System.IO.File.Delete(file);
                    continue;
                }
                string text = System.IO.File.ReadAllText(file);
                long ts = long.Parse(text);
                SQLSelectResults.Add(ts);
                
            }

            foreach (string file in Directory.GetFiles(@"..\..\output\MongoLogsSelect"))
            {
                if (int.Parse(file.Substring(file.LastIndexOf('\\') + 1).Replace(".txt", "").Replace("mongolog", "").Trim()) >= numberOfStations)
                {
                    System.IO.File.Delete(file);
                    continue;
                }
                string text = System.IO.File.ReadAllText(file);
                long ts = long.Parse(text);
                MongoSelectResults.Add(ts);
                
            }

            foreach (string file in Directory.GetFiles(@"..\..\output\SQLServerLogsUpdate"))
            {
                if (int.Parse(file.Substring(file.LastIndexOf('\\') + 1).Replace("sqlserverlog", "").Replace(".txt", "").Trim()) >= numberOfStations)
                {
                    System.IO.File.Delete(file);
                    continue;
                }
                string text = System.IO.File.ReadAllText(file);
                long ts = long.Parse(text);
                SQLUpdateResults.Add(ts);

            }

            foreach (string file in Directory.GetFiles(@"..\..\output\MongoLogsUpdate"))
            {
                if (int.Parse(file.Substring(file.LastIndexOf('\\') + 1).Replace("mongolog", "").Replace(".txt", "").Trim()) >= numberOfStations)
                {
                    System.IO.File.Delete(file);
                    continue;
                }
                string text = System.IO.File.ReadAllText(file);
                long ts = long.Parse(text);
                MongoUpdateResults.Add(ts);

            }
        }


        public void CalcolateAverageAndWrite()
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"..\..\output\Results\resultSelect.txt"))
            {
                file.WriteLine("SQLServer Select");
                long sqlSum = 0;
                foreach (long num in SQLSelectResults)
                {
                    sqlSum += num;
                    file.Write("" + num + " ");
                }
                file.WriteLine();
                long sqlAverage = sqlSum / SQLSelectResults.Count;
                file.WriteLine("average: " + sqlAverage);

                file.WriteLine();

                file.WriteLine("MongoDB Find");
                long mongoSum = 0;
                foreach (long num in MongoSelectResults)
                {
                    mongoSum += num;
                    file.Write("" + num + " ");
                }
                file.WriteLine();
                long mongoAverage = mongoSum / MongoSelectResults.Count;
                file.WriteLine("average: " + mongoAverage);
            }

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"..\..\output\Results\resultUpdate.txt"))
            {
                file.WriteLine("SQLServer Update");
                long sqlSum = 0;
                foreach (long num in SQLUpdateResults)
                {
                    sqlSum += num;
                    file.Write("" + num + " ");
                }
                file.WriteLine();
                long sqlAverage = sqlSum / SQLUpdateResults.Count;
                file.WriteLine("average: " + sqlAverage);

                file.WriteLine();

                file.WriteLine("MongoDB Update");
                long mongoSum = 0;
                foreach (long num in MongoUpdateResults)
                {
                    mongoSum += num;
                    file.Write("" + num + " ");
                }
                file.WriteLine();
                long mongoAverage = mongoSum / MongoUpdateResults.Count;
                file.WriteLine("average: " + mongoAverage);
            }
        }
    }

}
