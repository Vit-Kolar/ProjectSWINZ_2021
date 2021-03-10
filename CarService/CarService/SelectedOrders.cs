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
        DatabaseContext db;
        private List<Order> orders;
        DateTime activeSelectionDate;




        public SelectedOrders(DatabaseContext db, MainWindow window)
        {
            this.window = window;
            this.db = db;
            
                        
        }
        public void SetOrderBox(DateTime selectionDate)
        {
            var query = db.Order.Where(d => d.OrderDateTime == selectionDate).Select(d => d);
            orders = query.ToList();
            if (orders.Count == 0)
            {
                window.OrdersBoxDisableAndMessage("Pro daný datum a čas neexistují žádné obědnávky.");
            }
            else
            {
                window.EnableListboxControls();
                foreach (Order order in orders)
                {
                    window.OrdersBox.Items.Add(order.OrderDateTime.ToString() + " " + order.Name + " " + order.Surname);
                }
                activeSelectionDate = selectionDate;
            }
            
        }
        public void DeleteSelectedOrder()
        {
            if(window.OrdersBox.SelectedIndex != -1)
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Opravdu chcete odstaranit záznam?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    db.Order.Remove(orders[window.OrdersBox.SelectedIndex]);
                    db.SaveChanges();
                    SetOrderBox(activeSelectionDate);
                }
            }
            
           
        }
    }
}
