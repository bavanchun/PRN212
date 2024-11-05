using Microsoft.IdentityModel.Tokens;
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
using WpfApp1.Models;

namespace WpfApp1.WPF
{
    /// <summary>
    /// Interaction logic for UserManagement.xaml
    /// </summary>
    public partial class UserManagement : Window
    {
        private UserService _service = new();
        private RoleService _roleService = new();

        public User CurrentAccount { get; set; }


        public UserManagement(User currentAccount)
        {
            InitializeComponent();
            CurrentAccount = currentAccount;
        }

        private void BtnHome(object sender, RoutedEventArgs e)
        {
            AdminMainWindow adminWindow = new AdminMainWindow();
            adminWindow.Show();

            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillCommboBoxes();
            FillDataGrid();

            if (CurrentAccount != null && CurrentAccount.RoleId == 3)
            {
                // Hide the buttons
                CreateUser.Visibility = Visibility.Collapsed;
                UpdateUser.Visibility = Visibility.Collapsed;
                DeleteUser.Visibility = Visibility.Collapsed;
            }
            
        }

        private void FillCommboBoxes()
        {
            RoleComboBox.ItemsSource = _roleService.GetAll();
            RoleComboBox.DisplayMemberPath = "RoleName";
            RoleComboBox.SelectedValuePath = "RoleId";
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

        private void UpdateUser_Click(object sender, RoutedEventArgs e)
        {
            User? selected = UsersDataGrid.SelectedItem as User;
            if (selected == null)
            {
                MessageBox.Show("Please select a/an row to update", "Select a row", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            CreateUpdateUser createUpdateUser = new();
            createUpdateUser.EditedUser = selected;
            createUpdateUser.ShowDialog();

            FillDataGrid();
        }

        private void DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            User? selected = UsersDataGrid.SelectedItem as User;
            if (selected == null)
            {
                MessageBox.Show("Please select a/an row to update", "Select a row", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this user?", "Confirm?", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No)
            {
                return;
            }
            _service.DeleteUser(selected);
            FillDataGrid();
        }

        //private void SearchButton_Click(object sender, RoutedEventArgs e)
        //{
        //    int? roleId = null;
        //    int tmpRoleId;

        //    if (RoleComboBox.SelectedValue == null || !int.TryParse(RoleComboBox.SelectedValue.ToString(), out tmpRoleId))
        //    {
        //        MessageBox.Show("Incorrect RoleId. Please select again!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        //        return;
        //    }
        //    else
        //    {
        //        roleId = tmpRoleId;
        //    }

        //    var result = _service.SearchUsersByNameAndRoleId(NameTextBox.Text, roleId);
        //    //fill data search on grid
        //    UsersDataGrid.ItemsSource = null;
        //    UsersDataGrid.ItemsSource = result;
        //}

        //private void SearchButton_Click(object sender, RoutedEventArgs e)
        //{
        //    // Khởi tạo roleId là null
        //    int? roleId = null;

        //    // Kiểm tra xem có giá trị nào được chọn trong RoleComboBox hay không
        //    if (RoleComboBox.SelectedValue != null)
        //    {
        //        // Nếu có, cố gắng chuyển đổi giá trị sang int
        //        if (int.TryParse(RoleComboBox.SelectedValue.ToString(), out int tmpRoleId))
        //        {
        //            roleId = tmpRoleId; // Gán giá trị vào roleId
        //        }
        //    }

        //    // Nếu cả ô tìm kiếm tên và roleId đều trống, lấy tất cả người dùng
        //    if (string.IsNullOrEmpty(NameTextBox.Text) && !roleId.HasValue)
        //    {
        //        MessageBox.Show("Please enter a name or select a role to search.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        //        FillDataGrid(); // Đổ lại tất cả người dùng
        //        return; // Không thực hiện tìm kiếm
        //    }

        //    // Gọi hàm tìm kiếm với NameTextBox và roleId
        //    var result = _service.SearchUsersByNameAndRoleId(NameTextBox.Text, roleId);

        //    // Cập nhật ItemsSource của DataGrid
        //    UsersDataGrid.ItemsSource = null;
        //    UsersDataGrid.ItemsSource = result;
        //}

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            // Khởi tạo roleId là null
            int? roleId = null;

            // Kiểm tra xem có giá trị nào được chọn trong RoleComboBox hay không
            if (RoleComboBox.SelectedValue != null)
            {
                // Nếu có, cố gắng chuyển đổi giá trị sang int
                if (int.TryParse(RoleComboBox.SelectedValue.ToString(), out int tmpRoleId))
                {
                    roleId = tmpRoleId; // Gán giá trị vào roleId
                }
            }

            // Kiểm tra xem ô tên có trống hay không
            string nameSearch = NameTextBox.Text;

            // Nếu cả ô tìm kiếm tên và roleId đều trống, đổ lại tất cả người dùng mà không có thông báo lỗi
            if (string.IsNullOrEmpty(nameSearch) && !roleId.HasValue)
            {
                FillDataGrid(); // Đổ lại tất cả người dùng
                return; // Không thực hiện tìm kiếm
            }

            // Gọi hàm tìm kiếm với NameTextBox và roleId
            var result = _service.SearchUsersByNameAndRoleId(nameSearch, roleId);

            // Cập nhật ItemsSource của DataGrid
            UsersDataGrid.ItemsSource = null;
            UsersDataGrid.ItemsSource = result;
        }


    }
}
