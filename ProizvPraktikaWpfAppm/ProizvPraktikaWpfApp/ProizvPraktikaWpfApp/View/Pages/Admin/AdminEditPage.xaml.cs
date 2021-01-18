using ProizvPraktikaWpfApp.Context;
using ProizvPraktikaWpfApp.Model;
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

namespace ProizvPraktikaWpfApp.View.Pages.Admin
{
    /// <summary>
    /// Логика взаимодействия для AdminEditPage.xaml
    /// </summary>
    public partial class AdminEditPage : Page
    {

        private Company selectedItem;

        public AdminEditPage()
        {
            InitializeComponent();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Company save = connectClass.db.Companies.FirstOrDefault(item => item.ID == selectedItem.ID);
               
                
                save.NameCompany = txtNameCompany.Text;
                save.DateOfRegistration = Convert.ToDateTime(txtDateOfRegistration.Text);
                save.TypeOfPproperty = txtTypeOfProperty.Text;
                save.QuantityOfEmployees = txtUnits.Text;
                save.MainTypeProduct = txtMainTypeProduct.Text;
                save.AdvancedOr = txtAdvancedOr.Text;
                save.Price = txtProfit.Text;
                save.Comment = txtComment.Text;
                save.Supply.DateOfSupply = Convert.ToDateTime(txtDateOfSupply.Text);
                save.Product.Unit = txtUnitOfMeasurement.Text;
                connectClass.db.SaveChanges();
                MessageBox.Show("Данные успешно изменены!", "Действие", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.GoBack();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButton.OK, MessageBoxImage.Error); 
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            txtAdvancedOr.Text = "";
            txtComment.Text = "";
            txtDateOfRegistration.Text = "";
            txtMainTypeProduct.Text = "";
            txtNameCompany.Text = "";
            txtProfit.Text = "";
            txtTypeOfProperty.Text = "";
            txtUnits.Text = "";
            txtDateOfSupply.SelectedDate = null;
            txtUnitOfMeasurement.Text = "";
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        public AdminEditPage(Company selectedItem)
        {
            InitializeComponent();
            this.selectedItem = selectedItem;


            
            txtAdvancedOr.Text = selectedItem.AdvancedOr;
            txtComment.Text = selectedItem.Comment;
            txtDateOfRegistration.SelectedDate = selectedItem.DateOfRegistration;
            txtMainTypeProduct.Text = selectedItem.MainTypeProduct;
            txtNameCompany.Text = selectedItem.NameCompany;
            txtProfit.Text = selectedItem.Price;
            txtTypeOfProperty.Text = selectedItem.TypeOfPproperty;
            txtUnits.Text = selectedItem.QuantityOfEmployees;

            txtUnitOfMeasurement.Text = selectedItem.Product.Unit;
            txtDateOfSupply.Text = Convert.ToString(selectedItem.Supply.DateOfSupply);
        }
    }
}
