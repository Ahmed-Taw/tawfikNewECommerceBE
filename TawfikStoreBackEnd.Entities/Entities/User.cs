using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TawfikStoreBackEnd.Entities.Entities
{
    public class User
    {
        public int id { get; set; }
        [MaxLength(50)]
        public string firstName { get; set; }
        [MaxLength(50)]
        public string lastName { get; set; }

        [Required]
        [EmailAddress]
        public string email { get; set; }
        [DataType(DataType.Password)]
        public string password { get; set; }

        public bool isAdmin { get; set; }

        public ICollection<Order> orders { get; set; }
    }
}
