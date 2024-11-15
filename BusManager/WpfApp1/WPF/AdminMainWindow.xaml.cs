using Microsoft.Identity.Client.NativeInterop;
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
using System.Windows.Shapes;
using WpfApp1.Models;

namespace WpfApp1.WPF
{
    /// <summary>
    /// Interaction logic for AdminMainWindow.xaml
    /// </summary>
    public partial class AdminMainWindow : Window
    {
        public User CurrentAccount { get; set; }

        public AdminMainWindow(User account)
        {
            InitializeComponent();

            CurrentAccount = account;

            if (CurrentAccount.RoleId != 3)
            {
                
            }
        }

        private void BtnUserManagement(object sender, RoutedEventArgs e)
        {
            UserManagement userManagement = new UserManagement(CurrentAccount);
            userManagement.Show();

            this.Close();

        }
        private void BtnBusManagement(object sender, RoutedEventArgs e)
        {
            BusManagement busManagement = new BusManagement(CurrentAccount);
            busManagement.Show();
            this.Close();
        }
        private void BtnRouteManagement(object sender, RoutedEventArgs e)
        {
            RouteManagement routeManagement = new RouteManagement(CurrentAccount);
            routeManagement.Show();
            this.Close();
        }
        private void BtnTicketManagemtn(object sender, RoutedEventArgs e)
        {
            StaffTicketController staffTicketController = new StaffTicketController(CurrentAccount);
            staffTicketController.Show();
            this.Close();
        }
        private void BtnStationManagement(object sender, RoutedEventArgs e)
        {

        }

        private void LogOut(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.ShowDialog();

            this.Close();
        }
    }
}
