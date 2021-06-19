using ChocolateFabricApp.Classes;
using ChocolateFabricApp.Model;
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

namespace ChocolateFabricApp.Views.Pages.Admin
{
    /// <summary>
    /// Логика взаимодействия для EditProductionPageA.xaml
    /// </summary>
    public partial class EditProductionPageA : Page
    {
        public EditProductionPageA()
        {
            InitializeComponent();
        }

        private FinishedProducts selectedItem;

        public EditProductionPageA(FinishedProducts selectedItem)
        {
            InitializeComponent();
            this.selectedItem = selectedItem;

            txbName.Text = selectedItem.Name;
            txbCount.Text = selectedItem.Count;
            cmbDepartmentProd.SelectedItem = selectedItem.DepartmentProd.Title;
            cmbPeriod.SelectedItem = selectedItem.Period.Title;
            dtAccouting.SelectedDate = selectedItem.DateProduction;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            cmbPeriod.ItemsSource = ConnectClass.db.Period.Select(item => item.Title).ToList();
            cmbDepartmentProd.ItemsSource = ConnectClass.db.DepartmentProd.Select(item => item.Title).ToList();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите закрыть программу?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                var editProduction = ConnectClass.db.FinishedProducts.FirstOrDefault(item => item.ID == selectedItem.ID);

                editProduction.Name = txbName.Text;
                editProduction.Count = txbCount.Text;
                editProduction.DateProduction = Convert.ToDateTime(dtAccouting.Text);     

                var currentPeriod = ConnectClass.db.Period.FirstOrDefault(item => item.Title == cmbPeriod.Text);
                editProduction.IDPeriod = currentPeriod.ID;

                var currentDepartment = ConnectClass.db.DepartmentProd.FirstOrDefault(item => item.Title == cmbDepartmentProd.Text);
                editProduction.IDDepartmentProd = currentDepartment.ID;

                ConnectClass.db.SaveChanges();

                MessageBox.Show("Вы успешно изменили данные!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnClean_Click(object sender, RoutedEventArgs e)
        {
            txbName.Text = "";
            txbCount.Text = "";
            cmbDepartmentProd.SelectedItem = null;
            cmbPeriod.SelectedItem = null;
            dtAccouting.SelectedDate = null;
        }
    }
}
