using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TawfikStoreBackEnd.DAL.Mongo.Context;
using TawfikStoreBackEnd.Entities.Entities;

namespace TawfikStoreBackEnd.DAL.Mongo.Repositories
{
    public class OrderRepository
    {
        private MongoDBContext mongoContext;
        public OrderRepository()
        {
            mongoContext = new MongoDBContext();
        }

        public async Task<IList<Order>> LoadOrders() =>  await mongoContext.Orders.Find(new BsonDocument()).ToListAsync();//.Find(Builders<Order>.Filter.Ne(p => p.name, "Jack")).ToList();

        public async Task<IList<Order>> LoadOrdersWithFilters(string name, double totalAmout)
        {
            return await mongoContext.Orders
                .Find(GetFilterDefinition(name, totalAmout))
                .ToListAsync();
        }

        public IEnumerable<object> GetOrdersAggregiations()
        {
            var aggreg = mongoContext.Orders.Aggregate()
                .Project(o => new { TotalAmount = o.totalAmount, TotalAmountRange = o.totalAmount - o.totalAmount % 10 })
                .Group(o => o.TotalAmountRange , g => new { GroupTotalAmount = g.Key, Count = g.Count()})
                .ToList();

            return aggreg;

        }
        public FilterDefinition<Order> GetFilterDefinition(string name , double totalAmount)
        {
            var filterDefinition = Builders<Order>.Filter.Empty;

            if (!string.IsNullOrEmpty(name))
                filterDefinition = Builders<Order>.Filter.Where(o => o.name.Contains(name));
            if (totalAmount > 0)
                filterDefinition = filterDefinition & Builders<Order>.Filter.Where(o => o.totalAmount >= totalAmount);

            return filterDefinition;
        }
        public object GetbuildInfo()
        {
            BsonDocument buildInfo = new BsonDocument("buildInfo", 1);
            var buildIn = mongoContext.defaultDB.RunCommand<BsonDocument>(buildInfo);
            return buildIn.ToJson();
        }

        public void CreateOrder(Order order)
        {
            mongoContext.Orders.InsertOne(order);
        }


        public IList<object> GetOrderDetails()
        {

            var aggreg = mongoContext.Orders.Aggregate()
                .Lookup("OrderDetail", "_id", "orderId", "OrderDetails")
                .As<BsonDocument>()
                .ToList();
                //.Project(o => new { Order = "$_id", details = "$OrderDetails" })
                

            return aggreg.ToList<object>();
        }

        public IList<object> GetOrderDetailsByLinq()
        {
            //The types of the properties used with the equals expression must match. So for example is Table1.SomeID is Int32 and Table2.SomeID is Nullable<Int32>, then they don't match.
           // Func<Order, IEnumerable<OrderDetail>, Order> f = ((a, b) => { a.details = b.ToList(); return a; });
            var orderDetails = mongoContext.OrderDetails.AsQueryable();

            var query = from p in mongoContext.Orders.AsQueryable()
                        join o in orderDetails on 
                        p._id  
                        equals 
                        o.orderId into OrderDetails
                        select new { p, OrderDetails };
            //foreach (var item in query)
            //{
            //    f(item.p, item.joined);
            //}
            return query.ToList<object>();
        }
    }
}
