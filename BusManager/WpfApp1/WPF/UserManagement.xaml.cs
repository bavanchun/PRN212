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

namespace WpfApp1.WPF
{
    /// <summary>
    /// Interaction logic for UserManagement.xaml
    /// </summary>
    public partial class UserManagement : Window
    {
        private UserService _service = new();

        public UserManagement()
        {
            InitializeComponent();
        }

        private void BtnHome(object sender, RoutedEventArgs e)
        {
            AdminMainWindow adminWindow = new AdminMainWindow();
            adminWindow.Show();

            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillDataGrid();
        }

        private void FillDataGrid()
        {
            UsersDataGrid.ItemsSource = null;
            UsersDataGrid.ItemsSource = _service.GetAllUser();
            
        }

        
        
        private void CreateUser_Click(object sender, RoutedEventArgs e)
        {
            CreateUpdateUser createUpdateUser = new CreateUpdateUser();
            createUpdateUser.ShowDialog();

            FillDataGrid();
            
        }
    }
}
