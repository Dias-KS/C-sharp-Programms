using SelhozApplication.Classes;
using SelhozApplication.Model;
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

namespace SelhozApplication.Views.Pages.Admin
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
            txtAdvancedOr.Text = "";
            txtComment.Text = "";
            txtDateOfRegistration.SelectedDate = null;
            txtDateOfSupply.SelectedDate = null;
            txtMainTypeProduct.Text = "";
            txtNameCompany.Text = "";
            txtNameProduct.Text = "";
            txtNumberOfEmployees.Text = "";
            txtPrice.Text = "";
            txtPurchasePrice.Text = "";
            txtSuppliersCostPrice.Text = "";
            txtTypeOfProperty.Text = "";
            txtUnitOfMeasurement.Text = "";
            txtVolume.Text = "";
            

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //Добавление в базу данных
            try
            {

                Supply newSupply = new Supply();
                Products newProducts = new Products();
                Companies newCompanies = new Companies();


                newSupply.DateOfSupply = Convert.ToDateTime(txtDateOfSupply.Text);
                newSupply.Volume = txtVolume.Text;
                newSupply.SuppliersCostPrice = Convert.ToInt32(txtSuppliersCostPrice.Text);


                newProducts.NameProduct = txtNameProduct.Text;
                newProducts.UnitOfMeasurement = txtUnitOfMeasurement.Text;
                newProducts.PurchasePrice =Convert.ToInt32(txtPurchasePrice.Text);


                newCompanies.NameCompany = txtNameCompany.Text;
                newCompanies.DateOfRegistration = Convert.ToDateTime(txtDateOfRegistration.SelectedDate);
                newCompanies.TypeOfProperty = txtTypeOfProperty.Text;
                newCompanies.NumberOfEmployees = txtNumberOfEmployees.Text;
                newCompanies.MainTypeProduct = txtMainTypeProduct.Text;
                newCompanies.AdvancedOr = txtAdvancedOr.Text;
                newCompanies.Price =Convert.ToInt32(txtPrice.Text);
                newCompanies.Comment = txtComment.Text;


                newCompanies.IDProducts = newProducts.ID;
                newCompanies.IDSupply = newSupply.ID;


                ConnectClass.db.Supply.Add(newSupply);
                ConnectClass.db.Products.Add(newProducts);
                ConnectClass.db.Companies.Add(newCompanies);

                ConnectClass.db.SaveChanges();

                MessageBox.Show("Данные успешно добавлены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.GoBack();

            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
