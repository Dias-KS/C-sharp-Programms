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
    /// Логика взаимодействия для AddProductionPageAxaml.xaml
    /// </summary>
    public partial class AddProductionPageAxaml : Page
    {
        public AddProductionPageAxaml()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            cmbPeriod.ItemsSource = ConnectClass.db.Period.Select(item => item.Title).ToList();
            cmbDepartmentProd.ItemsSource = ConnectClass.db.DepartmentProd.Select(item => item.Title).ToList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FinishedProducts newProduction = new FinishedProducts();

                newProduction.Name = txbName.Text;
                newProduction.Count = txbCount.Text;
                newProduction.DateProduction = Convert.ToDateTime(dtAccouting.SelectedDate);
              

                var currentPeriod = ConnectClass.db.Period.FirstOrDefault(item => item.Title == cmbPeriod.Text);
                newProduction.IDPeriod = currentPeriod.ID;

                var currentDepartmentProd = ConnectClass.db.DepartmentProd.FirstOrDefault(item => item.Title == cmbDepartmentProd.Text);
                newProduction.IDDepartmentProd = currentDepartmentProd.ID;

                
               
                ConnectClass.db.FinishedProducts.Add(newProduction);
                ConnectClass.db.SaveChanges();

                MessageBox.Show("Данные о продукции успешно добавлены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);


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
    }
}
