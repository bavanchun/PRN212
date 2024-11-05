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

        public AdminMainWindow()
        {
            InitializeComponent();
        }
        
        private void BtnUserManagement(object sender, RoutedEventArgs e)
        {
            UserManagement userManagement = new UserManagement(CurrentAccount);
            userManagement.Show();

            this.Close();

        }
        private void BtnBusManagement(object sender, RoutedEventArgs e)
        {

        }
        private void BtnRouteManagement(object sender, RoutedEventArgs e)
        {

        }
        private void BtnTicketManagemtn(object sender, RoutedEventArgs e)
        {

        }
        private void BtnStationManagement(object sender, RoutedEventArgs e)
        {

        }
    }
}
