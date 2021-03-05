using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarService.DAL;
using System.Windows;
using System.Windows.Controls;

namespace CarService
{
    class SelectedOrders
    {
        MainWindow window;
        private List<Order> orders;
        private List<String> orderBoxItems;
       

        public SelectedOrders(DateTime selectionDate, DatabaseContext db, MainWindow window)
        {
            this.window = window;
            var query = db.Order.Where(d => d.OrderDateTime == selectionDate).Select(d => d);
            orders = query.ToList();
            if(orders.Count == 0)
            {
                window.OrdersBoxDisableAndMessage("Pro daný datum a čas neexistují žádné obědnávky.");
            }
            else
            {
                window.EnableListboxControls();
            }
            foreach (Order order in orders)
            {
                window.OrdersBox.Items.Add(order.OrderDateTime.ToString() + " " + order.Name + " " + order.Surname);
            }
            
            
        }
    }
}
