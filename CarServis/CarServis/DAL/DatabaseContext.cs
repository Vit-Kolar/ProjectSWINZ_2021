using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServis.DAL
{
    class DatabaseContext : DbContext
    {
        public DatabaseContext(): base("ServisOrders"){

        }
        public DbSet<Order> Order { get; set; }
    }
}
