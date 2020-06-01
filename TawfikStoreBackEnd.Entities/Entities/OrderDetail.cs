using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TawfikStoreBackEnd.Entities.Entities
{
    public class OrderDetail
    {
        [Key]
        [Column(Order = 1)]
        public int orderId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int productId { get; set; }

        public int quantity { get; set; }

    }
}
