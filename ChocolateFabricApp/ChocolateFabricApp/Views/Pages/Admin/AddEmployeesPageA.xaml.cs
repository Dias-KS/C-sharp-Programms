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
    /// Логика взаимодействия для AddEmployeesPageA.xaml
    /// </summary>
    public partial class AddEmployeesPageA : Page
    {
        public AddEmployeesPageA()
        {
            InitializeComponent();
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


        private void btnAdd_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                EmployeesAndProduct newEmployeesAndProduct = new EmployeesAndProduct();
                Employees newEmployees = new Employees();

                newEmployees.FirstName = txbFirstName.Text;
                newEmployees.LastName = txbLastName.Text;
                newEmployees.Age = txbAge.Text;
                newEmployees.MonthlySalary = txbMonthlySalary.Text;

                var currentGender = ConnectClass.db.Gender.FirstOrDefault(item => item.Title == cmbGender.Text);
                newEmployees.IDGender = currentGender.ID;

                var currentPost = ConnectClass.db.Post.FirstOrDefault(item => item.Title == cmbPost.Text);
                newEmployees.IDPost = currentPost.ID;

                var currentDepartment = ConnectClass.db.DepartmentEmpl.FirstOrDefault(item => item.Title == cmbDepartmentEmpl.Text);
                newEmployees.IDDepartmentEmpl = currentDepartment.ID;

                newEmployeesAndProduct.IDEmployees = newEmployees.ID;

                ConnectClass.db.Employees.Add(newEmployees);
                ConnectClass.db.EmployeesAndProduct.Add(newEmployeesAndProduct);
                ConnectClass.db.SaveChanges();

                MessageBox.Show("Данные о работнике успешно добавлены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);


            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnClean_Click_1(object sender, RoutedEventArgs e)
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
