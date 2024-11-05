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
using WpfApp1.DAL.Repositories;

namespace WpfApp1.WPF
{

    public partial class Booking : Window
    {
        private readonly User user;
        BusManagementSystemContext _context;
        StationService stationService;
        RouteService routeService;
        OrderService orderService;


        public Booking(User user)
        {
            InitializeComponent();
            _context = new BusManagementSystemContext();
            stationService = new StationService(_context);
            routeService = new RouteService(_context);
            orderService = new OrderService(_context);
            this.user = user;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadStations();
        }

        private async void LoadStations()
        {
            var stations = await stationService.GetStationsAsync();

            if (stations == null)
            {
                MessageBox.Show("Can't load Stations", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Dispatcher.Invoke(() =>
                {
                    cboFrom.ItemsSource = stations;
                    cboFrom.DisplayMemberPath = "Location";
                    cboFrom.SelectedValuePath = "StationId";

                    cboTo.ItemsSource = stations;
                    cboTo.DisplayMemberPath = "Location";
                    cboTo.SelectedValuePath = "StationId";
                });
            }

        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            var from = cboFrom.SelectedValue;
            var to = cboTo.SelectedValue;

            if (from == null || to == null)
            {
                MessageBox.Show("Please select both From and To stations", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if ((int)from == (int)to)
            {
                MessageBox.Show("From and To stations cannot be the same", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var routes = routeService.GetRoutesGoThroughStation((int)from, (int)to);

            dgRoutes.ItemsSource = routes;
            dgRoutes.Items.Refresh();
        }

        private void dgRoutes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = (DataGrid)sender;
            Route route = (Route)dg.SelectedItem;

            var result = MessageBox.Show($"Book route {route.Name}?", "Booking", MessageBoxButton.YesNo, MessageBoxImage.Information);

            if (result == MessageBoxResult.No)
            {
                return;
            }

            // Use the 'tickets' list as needed
            List<Ticket> tickets = new List<Ticket>();

            Ticket ticket = new Ticket
            {
                RouteId = route.RouteId,
                Date = DateTime.Now,
                FinalPrice = 100000,
                Status = "available",
            };

            tickets.Add(ticket);

            Order order = new Order
            {
                OrderDate = DateTime.Now,
                TotalPrice = tickets[0].FinalPrice,
                UserId = user.UserId,
                Tickets = tickets
            };

            orderService.AddOrder(order);

        }
    }
}
