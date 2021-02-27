using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService
{
    class Order
    {
        public int Id {get; set;}
        public String Name { get; set; }
        public String Surname { get; set; }
        public String PhoneNumber { get; set; }
        public String Email { get; set; }
        public String Description { get; set; }
        public DateTime OrderDateTime { get; set; }
    }
}
