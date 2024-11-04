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
using WpfApp1.BOs;

namespace WpfApp1.WPF
{
    /// <summary>
    /// Interaction logic for CreateUpdateUser.xaml
    /// </summary>
    public partial class CreateUpdateUser : Window
    {
        private UserService _service = new();
        private RoleService _roleService = new();
        private UserTypeService _userTypeService = new();
        public CreateUpdateUser()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            User user = new User();
            user.Username = UsernameTextBox.Text;
            user.Password = PasswordBox.Password; // Fix: Use Password property instead of Text
            user.Name = NameTextBox.Text;
            //user.RoleId = 2; // Fix: Convert string to int
            //user.UserTypeId = 1; // Fix: Convert string to int
            user.RoleId = (int)RoleComboBox.SelectedValue; // Fix: Cast SelectedValue to int
            user.UserTypeId = (int)UserTypeComboBox.SelectedValue; // Fix: Cast SelectedValue to int

            _service.AddUser(user);

            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillComboBoxes();
        }

        private void FillComboBoxes()
        {
            
            RoleComboBox.ItemsSource = _roleService.GetAll();
            RoleComboBox.DisplayMemberPath = "RoleName";
            RoleComboBox.SelectedValuePath = "RoleId";

            
            UserTypeComboBox.ItemsSource = _userTypeService.GetAll();
            UserTypeComboBox.DisplayMemberPath = "TypeName";
            UserTypeComboBox.SelectedValuePath = "UserTypeId";
        }
    }
}
