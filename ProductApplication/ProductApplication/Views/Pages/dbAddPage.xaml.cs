using ProductApplication.Classes;
using ProductApplication.Models;
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

namespace ProductApplication.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для dbAddPage.xaml
    /// </summary>
    public partial class dbAddPage : Page
    {
        public dbAddPage()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        //Очистка данных из текстбоксов
        private void btnClean_Click(object sender, RoutedEventArgs e)
        {

            txtAdress.Text = "";
            txtComment.Text = "";
            txtDateCancel.SelectedDate = null;
            txtDateInstallSpecification.SelectedDate = null;
            txtNameCompany.Text = "";
            txtNameMaterial.Text = "";
            txtNameProduct.Text = "";
            txtNoteUse.Text = "";
            txtPriceUnit.Text = "";
            txtQuantityMaterial.Text = "";
            txtTypeMaterial.Text = "";
            txtTypeOr.Text = "";
            txtUnitOfMeasurement.Text = "";
            txtVolumeRelease.Text = "";
            txtYearRelease.SelectedDate = null;
            txtYearVolumeRelease.Text = "";
            txtTelephone.Text = "";
            
        }

        //Логика добавления 
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Product newProduct = new Product();
            Specification newSpecification = new Specification();
            Material newMaterial = new Material();
            Company newCompany = new Company();


            newSpecification.QuantityMaterial = Convert.ToInt32(txtQuantityMaterial.Text);
            newSpecification.DateInstallSpecification = Convert.ToDateTime(txtDateInstallSpecification.SelectedDate);
            newSpecification.DateCancel = Convert.ToDateTime(txtDateCancel.SelectedDate);

            newMaterial.NameMaterial = txtNameMaterial.Text;
            newMaterial.TypeMaterial = txtTypeMaterial.Text;
            newMaterial.UnitOfMeasurement = txtUnitOfMeasurement.Text;
            newMaterial.PriceUnit = Convert.ToInt32(txtPriceUnit.Text);
            newMaterial.NoteUse = txtNoteUse.Text;

            newCompany.NameCompany = txtNameCompany.Text;
            newCompany.Adress = txtAdress.Text;
            newCompany.Telephone = txtTelephone.Text;
            newCompany.YearRelease = Convert.ToDateTime(txtYearRelease.Text);
            newCompany.VolumeRelease = txtVolumeRelease.Text;

            newProduct.NameProduct = txtNameProduct.Text;
            newProduct.TypeOr = txtTypeOr.Text;
            newProduct.YearVolumeRelease = txtYearVolumeRelease.Text;
            newProduct.Comment = txtComment.Text;

            newProduct.IDCompany = newCompany.ID;
            newProduct.IDMaterial = newMaterial.ID;
            newProduct.IDSpecification = newSpecification.ID;

            ConnectClass.db.Material.Add(newMaterial);
            ConnectClass.db.Company.Add(newCompany);
            ConnectClass.db.Specification.Add(newSpecification);
            ConnectClass.db.Product.Add(newProduct);
            ConnectClass.db.SaveChanges();
            MessageBox.Show("Данные успешно добавлены", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            NavigationService.GoBack();
           

        }
    }
}
