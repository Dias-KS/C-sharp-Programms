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
    /// Логика взаимодействия для AccoutingEmployeesPageA.xaml
    /// </summary>
    public partial class AccoutingEmployeesPageA : Page
    {
        public AccoutingEmployeesPageA()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            dataView.ItemsSource = ConnectClass.db.EmployeesAndProduct.ToList();
            cmbDepartment.ItemsSource = ConnectClass.db.DepartmentEmpl.Select(item => item.Title).ToList();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите закрыть программу?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEmployeesPageA());
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            EmployeesAndProduct editEmployees = (EmployeesAndProduct)dataView.SelectedItem;
            if(editEmployees != null)
            {
                NavigationService.Navigate(new EditEmployeesPageA(editEmployees));
            }

            else
            {
                MessageBox.Show("Вы не выбрали ни одного элемента!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            EmployeesAndProduct deleteEmployees = (EmployeesAndProduct)dataView.SelectedItem;
            if (deleteEmployees != null)
            {
                if (MessageBox.Show("Вы уверены, что хотите удалить данного работника?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {

                    ConnectClass.db.EmployeesAndProduct.Remove(deleteEmployees);
                    ConnectClass.db.SaveChanges();
                    Page_Loaded(null, null);
                    MessageBox.Show("Вы успешно удалили работника!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

                }

                else
                {
                    MessageBox.Show("Вы не выбрали ни одного элемента!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            else
            {
                MessageBox.Show("Вы не выбрали ни одного элемента!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        
        private void txbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            dataView.ItemsSource = ConnectClass.db.EmployeesAndProduct.Where(item => item.Employees.FirstName.Contains(txbSearch.Text) || item.Employees.LastName.Contains(txbSearch.Text) || item.Employees.MonthlySalary.Contains(txbSearch.Text)).ToList();
        }

        private void cmbDepartment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {

                Page_Loaded(null, null);
                dataView.ItemsSource = ConnectClass.db.EmployeesAndProduct.Where(item => item.Employees.DepartmentEmpl.Title.Contains(cmbDepartment.Text)).ToList();

            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, ex.Source, MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
    }
}
