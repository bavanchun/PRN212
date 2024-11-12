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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadSelf();
        }

        public void LoadSelf()
        {
            try
            {
                txtName.Text = user.Name;
                txtUsername.Text = user.Username;
                txtPassword.Password = user.Password;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on load list of customers");
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                user.Name = txtName.Text;
                user.Username = txtUsername.Text;
                user.Password = txtPassword.Password;

                userService.UpdateUser(user);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                LoadSelf();
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