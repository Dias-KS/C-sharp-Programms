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
    /// Логика взаимодействия для AddSupplyPage.xaml
    /// </summary>
    public partial class AddSupplyPage : Page
    {
        public AddSupplyPage()
        {

            InitializeComponent();
            
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            cmbWarehouse.ItemsSource = ConnectClass.db.Warehouse.Select(item => item.Title).ToList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

            try
            {

                Supply newSupply = new Supply();

                newSupply.NameProduct = txbNameProduct.Text;
                newSupply.NameProvider = txbProvider.Text;
                newSupply.Count = txbCount.Text;
                newSupply.DateSupply = Convert.ToDateTime(dtDateSupply.SelectedDate);
                newSupply.Price = txbPrice.Text;

                var currentWarehouse = ConnectClass.db.Warehouse.FirstOrDefault(item => item.Title == cmbWarehouse.Text);
                newSupply.IDWarehouse = currentWarehouse.ID;

                ConnectClass.db.Supply.Add(newSupply);
                ConnectClass.db.SaveChanges();

                MessageBox.Show("Данные о поставке успешно добавлены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void btnClean_Click(object sender, RoutedEventArgs e)
        {
            txbNameProduct.Text = "";
            txbCount.Text = "";
            txbPrice.Text = "";
            txbProvider.Text = "";
            cmbWarehouse.SelectedItem = null;
            dtDateSupply.SelectedDate = null;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите закрыть программу?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
