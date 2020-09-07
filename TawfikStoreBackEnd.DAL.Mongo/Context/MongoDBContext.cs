using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TawfikStoreBackEnd.Entities.Entities;

namespace TawfikStoreBackEnd.DAL.Mongo.Context
{
    public class MongoDBContext
    {
        public IMongoDatabase defaultDB;
        public MongoDBContext()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            defaultDB = client.GetDatabase("TawfikStoreDB");
            
            
        }

        public IMongoCollection<Order> Orders
        {
            get
            {
                return defaultDB.GetCollection<Order>("Order");
            }
        }

        public IMongoCollection<OrderDetail> OrderDetails
        {
            get
            {
                return defaultDB.GetCollection<OrderDetail>("OrderDetail");
            }
        }
    }
}
