//using BBL;
//using Models;
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
using WpfApp1.BLL;
using WpfApp1.Models;

namespace WpfApp1.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class CustomerSelfManagement : Window
    {
        private User user;
        private readonly UserService userService;

        public CustomerSelfManagement(User user)
        {
            InitializeComponent();
            userService = new UserService();
            this.user = user;
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        //private void Window_Loaded(object sender, RoutedEventArgs e)
        //{
        //    //LoadCustomer();
        //}

        //public void LoadCustomer()
        //{
        //    try
        //    {
        //        Customer customer = customerService.GetCustomers()[0];

        //        txtCustomerID.Text = customer.CustomerId.ToString();
        //        txtCustomerFullName.Text = customer.CustomerFullName;
        //        txtTelephone.Text = customer.Telephone;
        //        txtEmailAddress.Text = customer.EmailAddress;
        //        dpCustomerBirthday.SelectedDate = customer.CustomerBirthday.Value.ToDateTime(TimeOnly.MinValue);
        //        txtPassword.Text = customer.Password;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Error on load list of customers");
        //    }
        //}

        //private void btnUpdate_Click(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        if (txtCustomerID.Text.Length > 0)
        //        {
        //            Customer customer = customerService.GetCustomerById(Int32.Parse(txtCustomerID.Text));

        //            customer.CustomerFullName = txtCustomerFullName.Text;
        //            customer.Telephone = txtTelephone.Text;
        //            customer.EmailAddress = txtEmailAddress.Text;
        //            customer.CustomerBirthday = dpCustomerBirthday.SelectedDate.HasValue ? DateOnly.FromDateTime(dpCustomerBirthday.SelectedDate.Value) : null;
        //            customer.CustomerStatus = 1;
        //            customer.Password = txtPassword.Text;

        //            customerService.UpdateCustomer(customer);
        //        }
        //        else
        //        {
        //            MessageBox.Show("You must select a Customer!");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    finally
        //    {
        //        LoadCustomer();
        //    }
        //}

        //private void btnClose_Click(object sender, RoutedEventArgs e)
        //{
        //    //this.Close();
        //}

        //private void txtCustomerID_TextChanged(object sender, TextChangedEventArgs e)
        //{

        //}

        //private void btnUpdate_Click(object sender, RoutedEventArgs e)
        //{

        //}
    }
}