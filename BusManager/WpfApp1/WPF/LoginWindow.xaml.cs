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

namespace WpfApp1.WPF
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private UserService _service = new();

        public LoginWindow()
        {
            InitializeComponent();

        }



        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(UsernameBox.Text) || string.IsNullOrEmpty(PasswordBox.Password))
            {
                MessageBox.Show("Please enter username and password", "Missing credentials", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            User? account = _service.Authenticate(UsernameBox.Text, PasswordBox.Password);
            if (account == null)
            {
                MessageBox.Show("Invalid username or password", "Wrong credentials", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
                //check wrong username or password

            }

            if (account.RoleId == 2)
            {
                MainWindow mainWindow = new MainWindow(account);
                mainWindow.Show();
                this.Hide();
            }
            else if (account.RoleId == 3 || account.RoleId == 4)
            {

                AdminMainWindow adminWindow = new AdminMainWindow();
                adminWindow.CurrentAccount = account;
                adminWindow.Show();

                this.Hide();
            }

        }
    }
}
