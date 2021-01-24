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


        //Очистка из текстбоксов
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


        //Логика редактирования
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

            Product editSave = ConnectClass.db.Product.FirstOrDefault(item => item.ID == selectedItem.ID);
            editSave.NameProduct = txtNameProduct.Text;
            editSave.TypeOr = txtTypeOr.Text;
            editSave.YearVolumeRelease = txtYearVolumeRelease.Text;
            editSave.Comment = txtComment.Text;
            editSave.Material.NameMaterial = txtNameMaterial.Text;
            editSave.Material.TypeMaterial = txtTypeMaterial.Text;
            editSave.Material.UnitOfMeasurement = txtUnitOfMeasurement.Text;
            editSave.Material.PriceUnit = Convert.ToInt32(txtPriceUnit.Text);
            editSave.Material.NoteUse = txtNoteUse.Text;
            editSave.Company.NameCompany = txtNameCompany.Text;
            editSave.Company.Adress = txtAdress.Text;
            editSave.Company.Telephone = txtTelephone.Text;
            editSave.Company.YearRelease = Convert.ToDateTime(txtYearRelease.SelectedDate);
            editSave.Company.VolumeRelease = txtVolumeRelease.Text;
            editSave.Specification.DateInstallSpecification = Convert.ToDateTime(txtDateInstallSpecification.SelectedDate);
            editSave.Specification.QuantityMaterial = Convert.ToInt32(txtQuantityMaterial.Text);
            editSave.Specification.DateCancel = Convert.ToDateTime(txtDateCancel.SelectedDate);

            ConnectClass.db.SaveChanges();
            MessageBox.Show("Данные успешно изменены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            NavigationService.GoBack();

        }

        //Логика выбранного элемента
        public dbEditPage (Product selectedItem)
        {
            InitializeComponent();
            this.selectedItem = selectedItem;
            txtAdress.Text = selectedItem.Company.Adress;
            txtComment.Text = selectedItem.Comment;
            txtDateCancel.SelectedDate = selectedItem.Specification.DateCancel;
            txtDateInstallSpecification.SelectedDate = selectedItem.Specification.DateInstallSpecification;
            txtNameCompany.Text = selectedItem.Company.NameCompany;
            txtNameMaterial.Text = selectedItem.Material.NameMaterial;
            txtNameProduct.Text = selectedItem.NameProduct;
            txtNoteUse.Text = selectedItem.Material.NoteUse;
            txtPriceUnit.Text = Convert.ToString(selectedItem.Material.PriceUnit);
            txtQuantityMaterial.Text = Convert.ToString(selectedItem.Specification.QuantityMaterial);
            txtTelephone.Text = selectedItem.Company.Telephone;
            txtTypeMaterial.Text = selectedItem.Material.TypeMaterial;
            txtTypeOr.Text = selectedItem.TypeOr;
            txtUnitOfMeasurement.Text = selectedItem.Material.UnitOfMeasurement;
            txtVolumeRelease.Text = selectedItem.Company.VolumeRelease;
            txtYearRelease.SelectedDate = Convert.ToDateTime(selectedItem.Company.YearRelease);
            txtYearVolumeRelease.Text = selectedItem.YearVolumeRelease;

        }

    }
}
