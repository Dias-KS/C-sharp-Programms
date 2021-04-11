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
using WpfAuthSystem.Context;
using WpfAuthSystem.Models;

namespace WpfAuthSystem.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdminADDPage.xaml
    /// </summary>
    public partial class AdminADDPage : Page
    {
        public AdminADDPage()
        {
            InitializeComponent();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            txtNameCompany.Text = "";
            txtDateRegistration.Text = "";
            txtMainTypeProduct.Text = "";
            txtPrice.Text = "";
            txtQuantityOfEmployeers.Text = "";
            txtTypeOfProperty.Text = "";
            txtAdvancedOr.Text = "";
            txtComment.Text = "";
           
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Company company = new Company();
                company.NameCompany = txtNameCompany.Text;
                company.DateOfRegistration = Convert.ToDateTime(txtDateRegistration.Text);
                company.TypeOfPproperty = txtTypeOfProperty.Text;
                company.QuantityOfEmployees = txtQuantityOfEmployeers.Text;
                company.MainTypeProduct = txtMainTypeProduct.Text;
                company.AdvancedOr = txtAdvancedOr.Text;
                company.Price = txtPrice.Text;
                company.Comment = txtComment.Text;
                dbContext.db.Companies.Add(company);
                dbContext.db.SaveChanges();
                MessageBox.Show("Данные сохранены!", "Выполнено" , MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.GoBack();

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

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
