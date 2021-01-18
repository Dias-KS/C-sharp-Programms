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
    /// Логика взаимодействия для AdminEditPage.xaml
    /// </summary>
    public partial class AdminEditPage : Page
    {
        private Companies selectedItem;

        public AdminEditPage()
        {
            InitializeComponent();
        }


        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            txtAdvancedOr.Text = "";
            txtComment.Text = "";
            dtDateOfRegistration.SelectedDate = null;
            dtDateOfSupply.SelectedDate = null;
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

        public AdminEditPage (Companies selectedItem)
        {
            InitializeComponent();
            this.selectedItem = selectedItem;
            txtAdvancedOr.Text = selectedItem.AdvancedOr;
            txtComment.Text = selectedItem.Comment;
            dtDateOfRegistration.SelectedDate = selectedItem.DateOfRegistration;
            dtDateOfSupply.SelectedDate = selectedItem.Supply.DateOfSupply;
            txtMainTypeProduct.Text = selectedItem.MainTypeProduct;
            txtNameCompany.Text = selectedItem.NameCompany;
            txtNameProduct.Text = selectedItem.Products.NameProduct;
            txtNumberOfEmployees.Text = selectedItem.NumberOfEmployees.ToString();
            txtPrice.Text = Convert.ToString(selectedItem.Price);
            txtPurchasePrice.Text = Convert.ToString(selectedItem.Products.PurchasePrice);
            txtSuppliersCostPrice.Text = Convert.ToString(selectedItem.Supply.SuppliersCostPrice);
            txtTypeOfProperty.Text = selectedItem.TypeOfProperty;
            txtUnitOfMeasurement.Text = selectedItem.Products.UnitOfMeasurement;
            txtVolume.Text = selectedItem.Supply.Volume;
            
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {   //Код редактирования данных
            try
            {   
                Companies save = ConnectClass.db.Companies.FirstOrDefault(item => item.ID == selectedItem.ID);

                save.NameCompany = txtNameCompany.Text;
                save.DateOfRegistration = Convert.ToDateTime(dtDateOfRegistration.SelectedDate);
                save.TypeOfProperty = txtTypeOfProperty.Text;
                save.NumberOfEmployees = txtNumberOfEmployees.Text;
                save.MainTypeProduct = txtMainTypeProduct.Text;
                save.AdvancedOr = txtAdvancedOr.Text;
                save.Price = Convert.ToInt32(txtPrice.Text);
                save.Comment = txtComment.Text;
                save.Supply.DateOfSupply = Convert.ToDateTime(dtDateOfSupply.SelectedDate);
                save.Supply.Volume = txtVolume.Text;
                save.Supply.SuppliersCostPrice = Convert.ToInt32(txtSuppliersCostPrice.Text);
                save.Products.NameProduct = txtNameProduct.Text;
                save.Products.PurchasePrice = Convert.ToInt32(txtPurchasePrice.Text);
                save.Products.UnitOfMeasurement = txtUnitOfMeasurement.Text;

                ConnectClass.db.SaveChanges();
                MessageBox.Show("Данные успешно изменены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.GoBack();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Source, ex.Message, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
