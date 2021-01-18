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
    /// Логика взаимодействия для AdminAddPage.xaml
    /// </summary>
    public partial class AdminAddPage : Page
    {
        public AdminAddPage()
        {
            InitializeComponent();
        }

        

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
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
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {



                Company newCompany = new Company();
                Supply newSupply = new Supply();
                Product newProduct = new Product();
               
                
                newSupply.DateOfSupply = Convert.ToDateTime(txtDateOfSupply.Text);
                connectClass.db.Supplies.Add(newSupply);
                newProduct.Unit = txtUnitOfMeasurement.Text;
                connectClass.db.Products.Add(newProduct);


                newCompany.NameCompany = txtNameCompany.Text;
                newCompany.DateOfRegistration = Convert.ToDateTime(txtDateOfRegistration.SelectedDate);
                newCompany.TypeOfPproperty = txtTypeOfProperty.Text;
                newCompany.QuantityOfEmployees = txtUnits.Text;
                newCompany.MainTypeProduct = txtMainTypeProduct.Text;
                newCompany.AdvancedOr = txtAdvancedOr.Text;
                newCompany.Price = txtProfit.Text;
                newCompany.Comment = txtComment.Text;


                newCompany.SupplyID = newSupply.ID;
                newCompany.ProductID = newProduct.ID;


                connectClass.db.Companies.Add(newCompany);
                connectClass.db.SaveChanges();

                MessageBox.Show("Данные успешно сохранены!", "Действие", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.GoBack();

            }

            catch(Exception ex)

            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }
    }
}
