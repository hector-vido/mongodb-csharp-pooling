using System;
using System.Threading;
using MongoDB.Driver;
using MongoDB.Bson;

namespace root
{
    class Program
    {
        static void Main(string[] args)
        {
            for(var i = 0; i < 1000; i++) {
                new Thread(ThreadMongo.Connect).Start();
		if(i == 500)
	            Thread.Sleep(100);
	    }
	    Thread.Sleep(10000);
        }
    }

    class ThreadMongo
    {
        public static void Connect()
        {
            var client = new MongoClient("mongodb://u1:4linux@172.27.11.10:27017/BookstoreDb?authSource=admin&minPoolSize=20&maxPoolSize=40");
            var database = client.GetDatabase("BookstoreDb");
            var collection = database.GetCollection<BsonDocument>("Books");
            var document = collection.Find(new BsonDocument()).FirstOrDefault();
            Console.WriteLine(document.ToString());	
        }
    }
}
