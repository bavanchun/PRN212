using System;
using System.Windows;
using WpfApp1.BLL;
using WpfApp1.Models;
using WpfApp1.DAL;
using WpfApp1.DAL.Repositories;
using Microsoft.Identity.Client.NativeInterop;

namespace WpfApp1.WPF
{
    public partial class BusManagement : Window
    {
        private readonly BusService _busService;
        private readonly RouteService _routeService;
        private readonly BusManagementSystemContext _context = new();

        public User CurrentAccount { get; set; }

        public BusManagement(User currentAccount)
        {
            InitializeComponent();
            _busService = new BusService(new BusRepository(_context));
            _routeService = new RouteService(_context);
            CurrentAccount = currentAccount;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadBuses();
            FillComboBoxes();
        }

        private void BtnHome(object sender, RoutedEventArgs e)
        {
            AdminMainWindow adminWindow = new AdminMainWindow(CurrentAccount);
            adminWindow.Show();
            this.Close();
        }

        private void LoadBuses()
        {
            var buses = _busService.GetAllBuses();

            if (buses == null)
            {
                MessageBox.Show("Can't load Buses", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                BusesDataGrid.ItemsSource = buses;
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

        private void CreateBus_Click(object sender, RoutedEventArgs e)
        {
            var createUpdateBus = new CreateUpdateBus(_busService, _routeService);
            if (createUpdateBus.ShowDialog() == true)
            {
                LoadBuses();
            }
        }

        private void UpdateBus_Click(object sender, RoutedEventArgs e)
        {
            Bus? selectedBus = BusesDataGrid.SelectedItem as Bus;
            if (selectedBus == null)
            {
                MessageBox.Show("Please select a bus to update", "Select a Bus", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            var createUpdateBus = new CreateUpdateBus(_busService, _routeService, selectedBus);
            if (createUpdateBus.ShowDialog() == true)
            {
                LoadBuses();
            }
        }

        private void DeleteBus_Click(object sender, RoutedEventArgs e)
        {
            Bus? selectedBus = BusesDataGrid.SelectedItem as Bus;
            if (selectedBus == null)
            {
                MessageBox.Show("Please select a bus to delete", "Select a Bus", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this bus?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No)
            {
                return;
            }

            _busService.DeleteBus(selectedBus);
            LoadBuses();
        }
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string busModel = NameTextBox.Text?.Trim();
            int? routeId = RouteComboBox.SelectedValue as int?;

            // Retrieve all buses first
            var buses = _busService.GetAllBuses();

            // Filter by model if provided
            if (!string.IsNullOrEmpty(busModel))
            {
                buses = buses.Where(b => b.Model.Contains(busModel, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            // Filter by route ID if selected
            if (routeId.HasValue)
            {
                buses = buses.Where(b => b.RouteId == routeId.Value).ToList();
            }

            // Update DataGrid with the filtered list
            BusesDataGrid.ItemsSource = buses;

            // Display a message if no results are found
            if (!buses.Any())
            {
                MessageBox.Show("No buses found with the given model.", "Search Result", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

    }
}
