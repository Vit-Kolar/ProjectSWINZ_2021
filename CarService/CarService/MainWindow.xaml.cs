﻿using CarService.DAL;
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
using System.Data.Entity;




namespace CarService
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DatabaseContext db = new DAL.DatabaseContext();
        private const int HourOnFirstIndex = 7;
        private SelectedOrders selectedOrders;
        private bool changingExistingOrder = false;
        private Order existingOrderToChange; 

        public MainWindow()
        {
            InitializeComponent();
            OrderTime.ItemsSource = new String[]{"7:00", "8:00" , "9:00" , "10:00" , "11:00" , "12:00", "13:00", "14:00", "15:00", "16:00", "17:00", "18:00" };
            OrdersBoxDisableAndMessage("Zadejte prosím datum a čas obědnávky.");
            selectedOrders = new SelectedOrders( db, this);
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
          
            SaveNewOrder();
            ClearInputs();

        }

        private void ClearForm_Click(object sender, RoutedEventArgs e)
        {
            ClearInputs();
            changingExistingOrder = false;
        }

        public void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DatePicker.SelectedDate.Value != null && OrderTime.SelectedIndex != -1)
            {
                selectedOrders.SetOrderBox(DatePicker.SelectedDate.Value.AddHours(OrderTime.SelectedIndex + HourOnFirstIndex));
            }
            else
            {
                OrdersBoxDisableAndMessage("Zadejte prosím datum a čas obědnávky.");
            }
        }
        private void DisableOrdersBoxControls()
        {
            OrdersBox.Items.Clear();
            OrdersBox.IsEnabled = false;
            ShowSelectedOrderBt.IsEnabled = false;
            EditSelectedOrderBt.IsEnabled = false;
            DeleteSelectedOrderBt.IsEnabled = false;
        }
        public void EnableListboxControls()
        {
            OrdersBox.Items.Clear();
            OrdersBox.IsEnabled = true;
            ShowSelectedOrderBt.IsEnabled = true;
            EditSelectedOrderBt.IsEnabled = true;
            DeleteSelectedOrderBt.IsEnabled = true;
        }
        public void OrdersBoxDisableAndMessage(string message)
        {
            DisableOrdersBoxControls();
            OrdersBox.Items.Add(message);
        }
        private void SaveNewOrder()
        {
            Order order = new Order();
            order.Name = NameTextBox.Text;
            order.Surname = SurnameTextBox.Text;
            order.PhoneNumber = PhoneNumberTextBox.Text;
            order.Email = EmailTextBox.Text;
            order.Description = DescriptionTextBox.Text;
            order.OrderDateTime = DatePicker.SelectedDate.Value.AddHours(OrderTime.SelectedIndex + HourOnFirstIndex);
            if (changingExistingOrder)
            {
                selectedOrders.ChangeOrder(existingOrderToChange,order);
                changingExistingOrder = false;
            }
            else
            {         
                db.Order.Add(order);
                db.SaveChanges();
                
            }
            selectedOrders.SetOrderBox(order.OrderDateTime);
        }
           
        private void ClearInputs()
        {
            NameTextBox.Text = "";
            SurnameTextBox.Text = "";
            PhoneNumberTextBox.Text = "";
            EmailTextBox.Text = "";
            DescriptionTextBox.Text = "";

        }

        private void OrderTime_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine(DatePicker.SelectedDate.ToString());
            if (DatePicker.SelectedDate != null && OrderTime.SelectedIndex != -1)
            {
                selectedOrders.SetOrderBox(DatePicker.SelectedDate.Value.AddHours(OrderTime.SelectedIndex + HourOnFirstIndex));
            }
            else
            {
                OrdersBoxDisableAndMessage("Zadejte prosím datum a čas obědnávky.");
            }
        }

        private void DeleteSelectedOrderBt_Click(object sender, RoutedEventArgs e)
        {
            selectedOrders.DeleteSelectedOrder();
        }

        private void EditSelectedOrderBt_Click(object sender, RoutedEventArgs e)
        {
            if (OrdersBox.SelectedIndex != -1)
            {
                existingOrderToChange = selectedOrders.GetSelectedorder();
                NameTextBox.Text = existingOrderToChange.Name;
                SurnameTextBox.Text = existingOrderToChange.Surname;
                PhoneNumberTextBox.Text = existingOrderToChange.PhoneNumber;
                EmailTextBox.Text = existingOrderToChange.Email;
                DescriptionTextBox.Text = existingOrderToChange.Description;
                changingExistingOrder = true;
                OrdersBoxDisableAndMessage("Nyní můžete upravit obědnávku.");
            }
        }
    }
}
