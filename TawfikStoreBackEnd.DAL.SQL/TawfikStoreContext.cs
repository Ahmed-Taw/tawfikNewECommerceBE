using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TawfikStoreBackEnd.Entities.Entities;

namespace TawfikStoreBackEnd.DAL.SQL
{
    public class TawfikStoreContext : DbContext
    {
        public TawfikStoreContext():base("data source=.;initial catalog=TawfikStore;Integrated Security=SSPI")
        {

        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}
