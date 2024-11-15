using System;
using System.ComponentModel;
using System.Windows;
using WpfApp1.BLL;
using WpfApp1.Models;

namespace WpfApp1.WPF
{
    public partial class CreateUpdateRoute : Window
    {
        private readonly RouteService _routeService;
        private readonly StationService _stationService;
        private bool _isDirty = false;

        public Route EditedRoute { get; set; }

        // Constructor for creating a new bus
        public CreateUpdateRoute(RouteService routeService, StationService stationService, Route editedRoute = null)
        {
            InitializeComponent();
            _routeService = routeService;
            _stationService = stationService;

            EditedRoute = editedRoute;
            this.Closing += CreateUpdateRoute_Closing;

            // Load Routes into ComboBox and initialize fields
            Loaded += Window_Loaded;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillComboBoxes();

            // Fill Fields if editing an existing bus
            if (EditedRoute != null)
            {
                CreateUpdateWindowModeLabel.Content = "Update Route Information";
                RouteIDTextBox.IsEnabled = false;
                FillElements(EditedRoute);
            }
            else
            {
                CreateUpdateWindowModeLabel.Content = "Create Route Information";
                RouteIDTextBox.IsEnabled = false;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (EditedRoute == null)
            {
                // Create new bus
                var newRoute = new Route
                {
                    Name = NameTextBox.Text,
                    Stations = StationsListBox.ItemsSource.Cast<Station>().ToList()
                };

                try
                {
                    _routeService.AddRoute(newRoute);
                    MessageBox.Show("Route added successfully.");
                    _isDirty = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
            else
            {
                // Update existing bus
                EditedRoute.Name = NameTextBox.Text;
                EditedRoute.Stations = StationsListBox.ItemsSource.Cast<Station>().ToList();

                try
                {
                    _routeService.UpdateRoute(EditedRoute);
                    MessageBox.Show("Route updated successfully.");
                    _isDirty = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }

            DialogResult = true;
            this.Close();
        }

        private void FillElements(Route route)
        {
            RouteIDTextBox.Text = route.RouteId.ToString();
            NameTextBox.Text = route.Name;
        }

        private void FillComboBoxes()
        {
            StationsListBox.ItemsSource = _stationService.GetStations();
            StationsListBox.DisplayMemberPath = "Location";
            StationsListBox.SelectedValuePath = "StationId";

            // Select elements from EditedRoute.Stations
            if (EditedRoute != null)
            {
                foreach (var station in EditedRoute.Stations)
                {
                    foreach (var item in StationsListBox.Items)
                    {
                        if (item is Station listBoxStation && listBoxStation.StationId == station.StationId)
                        {
                            StationsListBox.SelectedItems.Add(item);
                            break;
                        }
                    }
                }
            }
            StationsListBox.Focus();
        }

        private void CreateUpdateRoute_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_isDirty)
            {
                var result = MessageBox.Show("Information has not been saved, do you want to close?", "Confirm close",
                    MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void OnDataChanged(object sender, RoutedEventArgs e)
        {
            _isDirty = true;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
