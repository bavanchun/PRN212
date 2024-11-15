using System;
using System.Windows;
using WpfApp1.BLL;
using WpfApp1.Models;

namespace WpfApp1.WPF
{
    public partial class CreateUpdateBus : Window
    {
        private readonly BusService _busService;
        private readonly RouteService _routeService;
        private bool _isDirty = false;

        public Bus EditedBus { get; set; }

        // Constructor for creating a new bus
        public CreateUpdateBus(BusService busService, RouteService routeService, Bus editedBus = null)
        {
            InitializeComponent();
            _busService = busService;
            _routeService = routeService;
            EditedBus = editedBus;
            this.Closing += CreateUpdateBus_Closing;

            // Load Routes into ComboBox and initialize fields
            Loaded += Window_Loaded;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillComboBoxes();

            // Fill Fields if editing an existing bus
            if (EditedBus != null)
            {
                CreateUpdateWindowModeLabel.Content = "Update Bus Information";
                BusIDTextBox.IsEnabled = false;
                FillElements(EditedBus);
            }
            else
            {
                CreateUpdateWindowModeLabel.Content = "Create Bus Information";
                BusIDTextBox.IsEnabled = false;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (EditedBus == null)
            {
                // Create new bus
                var newBus = new Bus
                {
                    Model = ModelTextBox.Text,
                    RouteId = (int)RouteComboBox.SelectedValue,
                    LicensePlate = LicensePlateTextBox.Text,
                    Seats = int.Parse(SeatsTextBox.Text),
                    BasePrice = decimal.Parse(BasePriceTextBox.Text)
                };

                try
                {
                    _busService.AddBus(newBus);
                    MessageBox.Show("Bus added successfully.");
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
                EditedBus.Model = ModelTextBox.Text;
                EditedBus.RouteId = (int)RouteComboBox.SelectedValue;
                EditedBus.LicensePlate = LicensePlateTextBox.Text;
                EditedBus.Seats = int.Parse(SeatsTextBox.Text);
                EditedBus.BasePrice = decimal.Parse(BasePriceTextBox.Text);

                try
                {
                    _busService.UpdateBus(EditedBus);
                    MessageBox.Show("Bus updated successfully.");
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

        private void FillElements(Bus bus)
        {
            BusIDTextBox.Text = bus.BusId.ToString();
            ModelTextBox.Text = bus.Model;
            LicensePlateTextBox.Text = bus.LicensePlate;
            SeatsTextBox.Text = bus.Seats.ToString();
            BasePriceTextBox.Text = bus.BasePrice.ToString("F2");
            RouteComboBox.SelectedValue = bus.RouteId;
        }

        private void FillComboBoxes()
        {
            RouteComboBox.ItemsSource = _routeService.GetRoutes();
            RouteComboBox.DisplayMemberPath = "Name";
            RouteComboBox.SelectedValuePath = "RouteId";
        }

        private void CreateUpdateBus_Closing(object sender, System.ComponentModel.CancelEventArgs e)
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
