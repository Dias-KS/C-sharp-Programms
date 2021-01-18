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
    /// Логика взаимодействия для dbAddPage.xaml
    /// </summary>
    public partial class dbAddPage : Page
    {
        public dbAddPage()
        {
            InitializeComponent();
            cmbApplicationArea.ItemsSource = dbConnectClass.db.ApplicationArea.Select(ITEM => ITEM.Title).ToList();
            cmbTypeProduct.ItemsSource = dbConnectClass.db.TypeProduct.Select(ITEM => ITEM.Title).ToList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Product newProduct = new Product();
            Service newService = new Service();
            User newUser = new User();
            TypeProduct newProductType = new TypeProduct();
            ApplicationArea newApplicationArea = new ApplicationArea();

            newService.CostOfInstallation = Convert.ToInt32(txtCostOfInstallation.Text);
            newService.DateOfInstallation = Convert.ToDateTime(dtDateOfInstallation.SelectedDate);
            newService.DateOfDeinstallation = Convert.ToDateTime(dtDateOfDeinstallation.SelectedDate);
            newService.QuantityLicense = Convert.ToInt32(txtQuantityLicense.Text);


            newUser.NameUser = txtNameUser.Text;
            newUser.Region = txtRegion.Text;
            newUser.ScopeOfApplication = txtScopeOfApplication.Text;

            var currentType = dbConnectClass.db.TypeProduct.FirstOrDefault(item => item.Title == cmbTypeProduct.Text);
            newProduct.IDType = currentType.ID;

            var currentApplicationArea = dbConnectClass.db.ApplicationArea.FirstOrDefault(item => item.Title == cmbApplicationArea.Text);
            newProduct.IDApplicationArea = currentApplicationArea.ID;
           

            newProduct.NameProduct = txtNameProduct.Text;
            newProduct.Version = txtVersion.Text;
            newProduct.Firm = txtFirm.Text;
            newProduct.ReleaseDate = Convert.ToDateTime(dtReleaseDate.SelectedDate);
            newProduct.CostOfLicense = Convert.ToInt32(txtCostOfLicense.Text);

            newProduct.IDService = newService.ID;
            newProduct.IDUser = newUser.ID;

            dbConnectClass.db.Service.Add(newService);
            dbConnectClass.db.User.Add(newUser);
            dbConnectClass.db.Product.Add(newProduct);
            dbConnectClass.db.SaveChanges();
            MessageBox.Show("Данные успешно сохранены!","Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            NavigationService.GoBack();


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

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
