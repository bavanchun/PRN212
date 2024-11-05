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
    /// Interaction logic for CreateUpdateUser.xaml
    /// </summary>
    public partial class CreateUpdateUser : Window
    {
        private UserService _service = new();
        private RoleService _roleService = new();
        private UserTypeService _userTypeService = new();
        private bool _isDirty = false;

        public User EditedUser { get; set; } = null;
        public CreateUpdateUser()
        {
            InitializeComponent();
            this.Closing += CreateUpdateUser_Closing;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (EditedUser == null)
            {
                // Tạo người dùng mới
                User newUser = new User
                {
                    Username = UsernameTextBox.Text,
                    Password = PasswordBox.Password,
                    Name = NameTextBox.Text,
                    RoleId = (int)RoleComboBox.SelectedValue,
                    UserTypeId = (int)UserTypeComboBox.SelectedValue
                };

                try
                {
                    _service.AddUser(newUser);
                    MessageBox.Show("User added successfully.");
                    _isDirty = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
            else
            {
                // Cập nhật người dùng hiện tại
                EditedUser.Password = PasswordBox.Password;
                EditedUser.Name = NameTextBox.Text;
                EditedUser.RoleId = (int)RoleComboBox.SelectedValue;
                EditedUser.UserTypeId = (int)UserTypeComboBox.SelectedValue;

                try
                {
                    _service.UpdateUser(EditedUser);
                    MessageBox.Show("User updated successfully.");
                    _isDirty = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }

            this.Close();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillComboBoxes();
            FillElements(EditedUser);
            //fill label
            if (EditedUser != null)
            {
                CreateUpdateWindowModeLabel.Content = "Update User Information";
                IDTextBox.IsEnabled = false;
                UsernameTextBox.IsEnabled = false;
            }
            else
            {
                CreateUpdateWindowModeLabel.Content = "Create User Information";
                IDTextBox.IsEnabled = false;

            }
        }

        private void FillElements(User users)
        {
            if (users == null)
            {
                return;
            }

            IDTextBox.Text = users.UserId.ToString();

            UsernameTextBox.Text = users.Username;

            PasswordBox.Password = users.Password;
            NameTextBox.Text = users.Name;
            RoleComboBox.SelectedValue = users.RoleId ?? 0; // Fix: Handle nullable int
            UserTypeComboBox.SelectedValue = users.UserTypeId ?? 0; // Fix: Handle nullable int
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

        private void CreateUpdateUser_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_isDirty)
            {
                var result = MessageBox.Show("Information has not been saved, do you want to close?", "Confirm close",
                    MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.No)
                {
                    e.Cancel = true; // Hủy việc đóng cửa sổ
                }
            }
        }

        private void OnDataChanged(object sender, RoutedEventArgs e)
        {
            _isDirty = true; // Đánh dấu khi có thay đổi dữ liệu
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
