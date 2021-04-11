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
    /// Логика взаимодействия для AdminEditPage.xaml
    /// </summary>
    public partial class AdminEditPage : Page
    {
        public AdminEditPage()
        {
            InitializeComponent();
        }

        private ConnectCompany selectedItem;

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ConnectCompany save = dbContext.db.ConnectCompanies.FirstOrDefault(item => item.ID == selectedItem.ID);
                save.Company.NameCompany = txtNameCompany.Text;
                save.Company.MainTypeProduct = txtMainTypeProduct.Text;
                save.Company.Price = txtPrice.Text;
                save.Company.AdvancedOr = txtAdvancedOr.Text;
                save.Company.DateOfRegistration = Convert.ToDateTime(txtDateRegistration.Text);
                save.Company.Comment = txtComment.Text;
                save.Company.QuantityOfEmployees = txtQuantityOfEmployeers.Text;
                save.Company.TypeOfPproperty = txtTypeOfProperty.Text;
                dbContext.db.SaveChanges();
                MessageBox.Show("Данные успешно изменены!", "Действие", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.GoBack();
              
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }


        public AdminEditPage(ConnectCompany selectedItem)
        {
            InitializeComponent();
            this.selectedItem = selectedItem;
            txtAdvancedOr.Text = selectedItem.Company.AdvancedOr;
            txtComment.Text = selectedItem.Company.Comment;
            txtDateRegistration.Text = Convert.ToString(selectedItem.Company.DateOfRegistration);
            txtMainTypeProduct.Text = selectedItem.Company.MainTypeProduct;
            txtNameCompany.Text = selectedItem.Company.NameCompany;
            txtPrice.Text = selectedItem.Company.Price;
            txtQuantityOfEmployeers.Text = selectedItem.Company.QuantityOfEmployees;
            txtTypeOfProperty.Text = selectedItem.Company.TypeOfPproperty;
            

        }
        private void btnDelete_Click_1(object sender, RoutedEventArgs e)
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
    }
}
