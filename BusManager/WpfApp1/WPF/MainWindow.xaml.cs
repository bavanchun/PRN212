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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private User user;
        public MainWindow(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void BookRoute_Click(object sender, RoutedEventArgs e)
        {
            Booking booking = new Booking();
            booking.ShowDialog();
        }

        private void TicketView_Click(object sender, RoutedEventArgs e)
        {
            CustomerViewTicket ticket = new CustomerViewTicket(user);
            ticket.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void SelfEdit_Click(object sender, RoutedEventArgs e)
        {
            var selfEdit = new CustomerSelfManagement(user);
            selfEdit.ShowDialog();
        }
    }
}