using ProgrammProductsApp.Classes;
using ProgrammProductsApp.Models;
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

namespace ProgrammProductsApp.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для dbEditPage.xaml
    /// </summary>
    public partial class dbEditPage : Page
    {
        public dbEditPage()
        {
            InitializeComponent();
        }

        private Product selectedItem;

        
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Product save = dbConnectClass.db.Product.FirstOrDefault(item => item.ID == selectedItem.ID);
            save.NameProduct = txtNameProduct.Text;
            save.Firm = txtFirm.Text;
            var currentApplicationArea = dbConnectClass.db.ApplicationArea.FirstOrDefault(item => item.Title == cmbApplicationArea.Text);
            save.IDApplicationArea = currentApplicationArea.ID;
            var currentTypeProduct = dbConnectClass.db.TypeProduct.FirstOrDefault(item => item.Title == cmbTypeProduct.Text);
            save.IDType = currentTypeProduct.ID;
            save.ReleaseDate = Convert.ToDateTime(dtReleaseDate.SelectedDate);
            save.CostOfLicense = Convert.ToInt32(txtCostOfLicense.Text);
            save.Service.CostOfInstallation = Convert.ToInt32(txtCostOfInstallation.Text);
            save.Service.DateOfDeinstallation = Convert.ToDateTime(dtDateOfInstallation.SelectedDate);
            save.Service.DateOfDeinstallation = Convert.ToDateTime(dtDateOfDeinstallation.SelectedDate);
            save.Service.QuantityLicense = Convert.ToInt32(txtQuantityLicense.Text);
            save.User.NameUser = txtNameUser.Text;
            save.User.Region = txtRegion.Text;
            save.User.ScopeOfApplication = txtScopeOfApplication.Text;

            dbConnectClass.db.SaveChanges();
            MessageBox.Show("Данные успешно изменены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            NavigationService.GoBack();
           
        }

        public dbEditPage (Product selectedItem)
        {
            InitializeComponent();
            this.selectedItem = selectedItem;
            txtCostOfInstallation.Text = Convert.ToString(selectedItem.Service.CostOfInstallation);
            txtCostOfLicense.Text = Convert.ToString(selectedItem.CostOfLicense);
            txtFirm.Text = selectedItem.Firm;
            txtNameProduct.Text = selectedItem.NameProduct;
            txtNameUser.Text = selectedItem.User.NameUser;
            txtQuantityLicense.Text = Convert.ToString(selectedItem.Service.QuantityLicense);
            txtRegion.Text = selectedItem.User.Region;
            txtScopeOfApplication.Text = selectedItem.User.ScopeOfApplication;
            txtVersion.Text = selectedItem.Version;
            dtDateOfDeinstallation.SelectedDate = selectedItem.Service.DateOfDeinstallation;
            dtDateOfInstallation.SelectedDate = selectedItem.Service.DateOfInstallation;
            dtReleaseDate.SelectedDate = selectedItem.ReleaseDate;
            //cmbTypeProduct.ItemsSource = selectedItem.TypeProduct.Title;
            //cmbApplicationArea.ItemsSource = selectedItem.ApplicationArea.Title;
            


        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            txtCostOfInstallation.Text = "";
            txtCostOfLicense.Text = "";
            txtFirm.Text = "";
            txtNameProduct.Text = "";
            txtNameUser.Text = "";
            txtQuantityLicense.Text = "";
            txtRegion.Text = "";
            txtScopeOfApplication.Text = "";
            txtVersion.Text = "";
            cmbApplicationArea.Text = null;
            cmbTypeProduct.Text = null;
            dtDateOfDeinstallation.SelectedDate = null;
            dtDateOfInstallation.SelectedDate = null;
            dtReleaseDate.SelectedDate = null;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            cmbApplicationArea.ItemsSource = dbConnectClass.db.ApplicationArea.Select(item => item.Title).ToList();
            cmbTypeProduct.ItemsSource = dbConnectClass.db.TypeProduct.Select(item => item.Title).ToList();
        }
    }
}
