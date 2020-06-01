using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TawfikStoreBackEnd.Entities.Entities
{
    public class Product
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string title { get; set; }
        [Required]
        public decimal price { get; set; }

        public string image { get; set; }

        public int AvilableInStock { get; set; }


    }
}
