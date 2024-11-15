using System;
using System.Windows;
using WpfApp1.BLL;
using WpfApp1.Models;
using WpfApp1.DAL;
using WpfApp1.DAL.Repositories;
using Microsoft.Identity.Client.NativeInterop;

namespace WpfApp1.WPF
{
    public partial class RouteManagement : Window
    {
        private readonly RouteService _routeService;
        private readonly StationService _stationService;
        private readonly BusManagementSystemContext _context = new();

        public User CurrentAccount { get; set; }

        public RouteManagement(User currentAccount)
        {
            InitializeComponent();
            _routeService = new RouteService(_context);
            _stationService = new StationService(_context);
            CurrentAccount = currentAccount;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadRoutes();
            FillComboBoxes();
        }

        private void BtnHome(object sender, RoutedEventArgs e)
        {
            AdminMainWindow adminWindow = new AdminMainWindow(CurrentAccount);
            adminWindow.Show();
            this.Close();
        }

        private void LoadRoutes()
        {
            var routes = _routeService.GetRoutes();

            if (routes == null)
            {
                MessageBox.Show("Can't load Routes", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                RoutesDataGrid.ItemsSource = routes;
            }
        }

        private void FillComboBoxes()
        {
            // Populate RouteComboBox with routes
            var routes = _routeService.GetRoutes();
            if (routes != null && routes.Any())
            {
                RouteComboBox.ItemsSource = routes;
                RouteComboBox.DisplayMemberPath = "Name"; // Assuming Route model has a RouteName property
                RouteComboBox.SelectedValuePath = "RouteId";
            }
            else
            {
                MessageBox.Show("No routes available", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CreateRoute_Click(object sender, RoutedEventArgs e)
        {
            var createUpdateRoute = new CreateUpdateRoute(_routeService, _stationService);
            if (createUpdateRoute.ShowDialog() == true)
            {
                LoadRoutes();
            }
        }

        private void UpdateRoute_Click(object sender, RoutedEventArgs e)
        {
            var selectedRoute = RoutesDataGrid.SelectedItem as Route;
            if (selectedRoute == null)
            {
                MessageBox.Show("Please select a Route to update", "Select a Route", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            var createUpdateRoute = new CreateUpdateRoute(_routeService, _stationService, selectedRoute);
            if (createUpdateRoute.ShowDialog() == true)
            {
                LoadRoutes();
            }
        }

        private void DeleteRoute_Click(object sender, RoutedEventArgs e)
        {
            Route? selectedRoute = RoutesDataGrid.SelectedItem as Route;
            if (selectedRoute == null)
            {
                MessageBox.Show("Please select a Route to delete", "Select a Route", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this Route?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No)
            {
                return;
            }

            _routeService.DeleteRoute(selectedRoute);
            LoadRoutes();
        }
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string routeModel = NameTextBox.Text?.Trim();
            int? routeId = RouteComboBox.SelectedValue as int?;

            // Retrieve all routes first
            var routes = _routeService.GetRoutes();

            // Filter by model if provided
            if (!string.IsNullOrEmpty(routeModel))
            {
                routes = routes.Where(b => b.Name.Contains(routeModel, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            // Filter by route ID if selected
            if (routeId.HasValue)
            {
                routes = routes.Where(b => b.RouteId == routeId.Value).ToList();
            }

            // Update DataGrid with the filtered list
            RoutesDataGrid.ItemsSource = routes;

            // Display a message if no results are found
            if (!routes.Any())
            {
                MessageBox.Show("No routes found with the given model.", "Search Result", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

    }
}
