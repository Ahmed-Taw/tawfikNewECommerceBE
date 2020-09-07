using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TawfikStoreBackEnd.Entities.Entities;

namespace TawfikStoreBackEnd.Controllers
{
    public class OrderController : ApiController
    {
        private readonly DAL.Mongo.Repositories.OrderRepository orderRepository;
        public OrderController()
        {
            orderRepository = new DAL.Mongo.Repositories.OrderRepository();
        }
        //[HttpGet]
        //[Route("Orders")]
        //public async Task<IList<Order>> Get()
        //{
        //    return await orderRepository.LoadOrders();
        //}

        [HttpGet]
        [Route("Orders")]
        public async Task<IList<Order>> Get(string orderName = "", double totalAmount = 0)
        {
            //if (string.IsNullOrEmpty(orderName))
            //    return await orderRepository.LoadOrders();
            return await orderRepository.LoadOrdersWithFilters(orderName, totalAmount);
        }

        [HttpGet]
        [Route("Orders/TotalsRange")]
        public IList<object> GetTotalsRange(string orderName = "", double totalAmount = 0)
        {
            //if (string.IsNullOrEmpty(orderName))
            //    return await orderRepository.LoadOrders();
            return  orderRepository.GetOrdersAggregiations().ToList();//.LoadOrdersWithFilters(orderName, totalAmount);
        }

        [HttpGet]
        [Route("Orders/Details")]
        public IList<object> GetOrderWithDetails(string orderName = "", double totalAmount = 0)
        {
            //if (string.IsNullOrEmpty(orderName))
            //    return await orderRepository.LoadOrders();
            return orderRepository.GetOrderDetailsByLinq().ToList();//.LoadOrdersWithFilters(orderName, totalAmount);
        }
        [HttpPost]
        public IHttpActionResult Post(Order order)
        {
            orderRepository.CreateOrder(order);

            return Ok();
        }

        [HttpGet]
        [Route("BuildInfo")]
        public IHttpActionResult GetBuildInfo()
        {
            var buildInformation = orderRepository.GetbuildInfo();

            return Content(HttpStatusCode.OK,buildInformation);

        }
    }
}
