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
using WpfApp1.BLL;
using WpfApp1.Models;
using WpfApp1.DAL;

namespace WpfApp1.WPF
{
    /// <summary>
    /// Interaction logic for CustomerViewTicket.xaml
    /// </summary>
    public partial class CustomerViewTicket : Window
    {
        private User user;
        private readonly TicketService ticketService;
        private readonly BusManagementSystemContext _context = new();

        public CustomerViewTicket(User user)
        {
            InitializeComponent();
            ticketService = new TicketService(_context);
            this.user = user;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadTickets();
        }

        private async void LoadTickets()
        {
            var tickets = ticketService.GetTicketsByCustomerId(user.UserId);

            tickets.Select(tickets => new
            {
                tickets.TicketId,
                tickets.OrderId,
                tickets.Status,
                tickets.FinalPrice,
                // use  bus repo here (pass route id)
                //Buses = string.Join(", ", tickets.Route),
            });

            if (tickets == null)
            {
                MessageBox.Show("Can't load Tickets", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                tickets = tickets.OrderBy(t => t.Status == "available" ? 0 : 1).ToList();

                Dispatcher.Invoke(() =>
                {
                    dgTicket.ItemsSource = tickets;
                });
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            CustomerMainWindow customerMainWindow = new CustomerMainWindow(user);
            customerMainWindow.ShowDialog();

            this.Close();
        }
    }
}
