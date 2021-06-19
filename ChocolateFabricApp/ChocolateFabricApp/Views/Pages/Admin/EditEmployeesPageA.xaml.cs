using ChocolateFabricApp.Classes;
using ChocolateFabricApp.Model;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChocolateFabricApp.Views.Pages.Admin
{
    /// <summary>
    /// Логика взаимодействия для EditEmployeesPageA.xaml
    /// </summary>
    public partial class EditEmployeesPageA : Page
    {
        public EditEmployeesPageA()
        {
            InitializeComponent();
        }

        private EmployeesAndProduct selectedItem;

        public EditEmployeesPageA (EmployeesAndProduct selectedItem)
        {
            InitializeComponent();
            this.selectedItem = selectedItem;

            txbFirstName.Text = selectedItem.Employees.FirstName;
            txbLastName.Text = selectedItem.Employees.LastName;
            txbAge.Text = selectedItem.Employees.Age;
            txbMonthlySalary.Text = selectedItem.Employees.MonthlySalary;
            cmbDepartmentEmpl.SelectedItem = selectedItem.Employees.DepartmentEmpl.Title;
            cmbGender.SelectedItem = selectedItem.Employees.Gender.Title;
            cmbPost.SelectedItem = selectedItem.Employees.Post.Title;

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                var editEmployees = ConnectClass.db.EmployeesAndProduct.FirstOrDefault(item => item.ID == selectedItem.ID);

                editEmployees.Employees.FirstName = txbFirstName.Text;
                editEmployees.Employees.LastName = txbLastName.Text;
                editEmployees.Employees.Age = txbAge.Text;
                editEmployees.Employees.MonthlySalary = txbMonthlySalary.Text;

                var currentGender = ConnectClass.db.Gender.FirstOrDefault(item => item.Title == cmbGender.Text);
                editEmployees.Employees.IDGender = currentGender.ID;

                var currentPost = ConnectClass.db.Post.FirstOrDefault(item => item.Title == cmbPost.Text);
                editEmployees.Employees.IDPost = currentPost.ID;

                var currentDepartment = ConnectClass.db.DepartmentEmpl.FirstOrDefault(item => item.Title == cmbDepartmentEmpl.Text);
                editEmployees.Employees.IDDepartmentEmpl = currentDepartment.ID;


                ConnectClass.db.SaveChanges();

                MessageBox.Show("Вы успешно изменили данные!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите закрыть программу?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        private void btnClean_Click(object sender, RoutedEventArgs e)
        {
            txbFirstName.Text = "";
            txbAge.Text = "";
            txbMonthlySalary.Text = "";
            txbLastName.Text = "";
            cmbDepartmentEmpl.SelectedItem = null;
            cmbGender.SelectedItem = null;
            cmbPost.SelectedItem = null;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            cmbPost.ItemsSource = ConnectClass.db.Post.Select(item => item.Title).ToList();
            cmbGender.ItemsSource = ConnectClass.db.Gender.Select(item => item.Title).ToList();
            cmbDepartmentEmpl.ItemsSource = ConnectClass.db.DepartmentEmpl.Select(item => item.Title).ToList();
        }
    }
}
