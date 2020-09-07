using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TawfikStoreBackEnd.Entities.Entities;

namespace TawfikStoreBackEnd.DAL.Infra.IRepositories
{
    public interface IOrderRepository
    {
        IEnumerable<Order> getOrders();

        IEnumerable<Order> getOrdersByUser(int userId);

        IEnumerable<Order> getOrders(int userId);

        Order getOrderByuser(int userId, int id);

        Order GetOrder(int id);

        void Add(Order order);

        void update(Order order);

        void Delete(Order order);
        void UpdateOrderDetail(OrderDetail detail);

        void DeleteOrderDetail(OrderDetail orderDetail);

        void Save();
    }
}
