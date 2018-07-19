using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoThread
{
    class Program
    {
        static void Main(string[] args)
        {
            MongoClient mongoClient = new MongoClient("mongodb://localhost:27017");
            IMongoDatabase mongoDatabase = mongoClient.GetDatabase("WIP");
            IMongoCollection<BsonDocument> mongoCollection = mongoDatabase.GetCollection<BsonDocument>("WipHeaderHistory");

            BsonDocument document = MongoDB.Bson.Serialization.BsonSerializer.Deserialize<BsonDocument>("{ PartCode : '" + args[0] + "' }");

            string param = "{$set: { NextStationCode: 90 } }";
            string filter = "{ PartCode : '" + args[0] + "' }";
            BsonDocument filterDoc = MongoDB.Bson.Serialization.BsonSerializer.Deserialize<BsonDocument>(filter);
            BsonDocument doc = MongoDB.Bson.Serialization.BsonSerializer.Deserialize<BsonDocument>(param);


            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            /* List<BsonDocument> list = */
            IFindFluent<BsonDocument, BsonDocument> find = mongoCollection.Find(new QueryDocument(document)).Project("{ PartUniqueID : 1 }"); /*.ToList(); */
            stopWatch.Stop();
            long tsSelect = stopWatch.ElapsedMilliseconds;

            // System.IO.File.WriteAllText(@"C:\Users\Edoardo\source\repos\StressTest\StressTest\MongoLogsSelect\mongolog" + args[1] + ".txt", "" + tsSelect);
            System.IO.File.WriteAllText(@"..\..\output\MongoLogsSelect\mongolog" + args[1] + ".txt", "" + tsSelect);
            
            try
            {
                stopWatch.Start();
                mongoCollection.UpdateOne(filterDoc, doc);
                stopWatch.Stop();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
            
            long tsUpdate = stopWatch.ElapsedMilliseconds;
            //   System.IO.File.WriteAllText(@"C:\Users\Edoardo\source\repos\StressTest\StressTest\MongoLogsUpdate\mongolog" + args[1] + ".txt", "" + tsUpdate);
                 System.IO.File.WriteAllText(@"..\..\output\MongoLogsUpdate\mongolog" + args[1] + ".txt", "" + tsUpdate);
            /*
            foreach (BsonDocument doc in list)
            {
                Console.WriteLine(doc.ToString());
            }
             
            Console.ReadLine();
            */


        }
    }
}
