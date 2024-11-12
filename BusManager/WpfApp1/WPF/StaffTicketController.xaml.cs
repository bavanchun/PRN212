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
using WpfApp1.DAL;
using WpfApp1.Models;

namespace WpfApp1.WPF
{
    /// <summary>
    /// Interaction logic for AdminTicketController.xaml
    /// </summary>
    public partial class StaffTicketController : Window
    {
        private readonly BusManagementSystemContext _context;
        TicketService ticketService;
        Ticket currTicket;

        public User CurrentAccount;

        public StaffTicketController(User currentAccount)
        {
            InitializeComponent();
            _context = new BusManagementSystemContext();
            ticketService = new TicketService(_context);
            CurrentAccount = currentAccount;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void BtnHome(object sender, RoutedEventArgs e)
        {
            AdminMainWindow adminWindow = new AdminMainWindow(CurrentAccount);
            adminWindow.Show();
            this.Close();
        }

        private void UseTicket(object sender, RoutedEventArgs e)
        {
            if (currTicket == null)
            {
                MessageBox.Show("Please select a Ticket to use", "Select a Ticket", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            if (currTicket.Status == "used")
            {
                MessageBox.Show("This ticket has already been used", "Ticket Used", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            currTicket.Status = "used";

            ticketService.UpdateTicket(currTicket);

            MessageBox.Show("Ticket used", "Ticket Used", MessageBoxButton.OK, MessageBoxImage.Information);
            currTicket = null;

            id.Text = "";
            routeName.Text = "";
            username.Text = "";
            date.Text = "";
            status.Text = "";
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            int ticketId;
            if (!int.TryParse(NameTextBox.Text?.Trim(), out ticketId))
            {
                MessageBox.Show("Please enter a valid ID.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            // Retrieve all buses first
            var ticket = ticketService.GetTicketById(ticketId);

            // Display a message if no results are found
            if (ticket == null)
            {
                MessageBox.Show("No tickeet found with the given ID.", "Search Result", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            // Update DataGrid with the filtered list
            id.Text = ticket.TicketId.ToString();
            routeName.Text = ticket.Route.Name;
            username.Text = ticket.Order.User.Username;
            date.Text = ticket.Date.ToString();
            status.Text = ticket.Status;

            currTicket = ticket;

        }
    }

}
