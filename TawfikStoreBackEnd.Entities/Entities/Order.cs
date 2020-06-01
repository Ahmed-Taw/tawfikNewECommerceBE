using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TawfikStoreBackEnd.Entities.Entities
{
    public class Order
    {
        public Order()
        {
            details = new Collection<OrderDetail>();
        }
        public int id { get; set; }

        public string name { get; set; }

        public int userId { get; set; }

        public string address { get; set; }

        public string phone { get; set; }

        public DateTime creationDate { get; set; }

        public bool isDeliverd { get; set; }

        public ICollection<OrderDetail> details { get; set; }

        public decimal totalAmount { get; set; }
    }
}
