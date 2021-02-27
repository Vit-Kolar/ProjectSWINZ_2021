using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.DAL
{
    class DatabaseContext : DbContext
    {
        public DatabaseContext(): base("ServiceOrders"){

        }
        public DbSet<Order> Order { get; set; }
    }
}
