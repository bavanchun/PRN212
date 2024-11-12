using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.Models;
using WpfApp1.Utils;

namespace WpfApp1.WPF
{
    /// <summary>
    /// Interaction logic for CustomerMainWindow.xaml
    /// </summary>
    public partial class CustomerMainWindow : Window
    {
        private User user;
        private Booking booking;
        private CustomerViewTicket ticket;
        private CustomerSelfManagement selfEdit;
        private LoginWindow login;

        public CustomerMainWindow(User user)
        {
            InitializeComponent();
            this.user = user;
            booking = new Booking(user);
            ticket = new CustomerViewTicket(user);
            selfEdit = new CustomerSelfManagement(user);
            login = new LoginWindow();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void BookRoute_Click(object sender, RoutedEventArgs e)
        {
            booking.Show();
            this.Close();
        }

        private void TicketView_Click(object sender, RoutedEventArgs e)
        {
            ticket.Show();
            this.Close();
        }

        private void SelfEdit_Click(object sender, RoutedEventArgs e)
        {
            selfEdit.Show();
            this.Close();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            login.Show();

            this.Close();
        }
    }
}