using CarService.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CarService
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /*private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            DatabaseContext db = new DAL.DatabaseContext();
            Order order = new Order();
            order.Name = "Vít";
            order.Surname = "kolář";
            order.PhoneNumber = "000000000";
            order.Email = "email@neco.eu";
            order.OrderDateTime = DateTime.Now;
            db.Order.Add(order);
            db.SaveChanges();
        }*/
    }
}
