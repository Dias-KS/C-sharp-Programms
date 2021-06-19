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
    /// Логика взаимодействия для EditSupplyPageA.xaml
    /// </summary>
    public partial class EditSupplyPageA : Page
    {
        public EditSupplyPageA()
        {
            InitializeComponent();
        }

        private Supply selectedItem;

        public EditSupplyPageA(Supply selectedItem)
        {
            InitializeComponent();
            this.selectedItem = selectedItem;

            txbNameProduct.Text = selectedItem.NameProduct;
            txbCount.Text = selectedItem.Count;
            txbPrice.Text = selectedItem.Price;
            txbProvider.Text = selectedItem.NameProvider;
            dtDateSupply.SelectedDate = selectedItem.DateSupply;
            cmbWarehouse.SelectedItem = selectedItem.Warehouse.Title;
        }
             

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            cmbWarehouse.ItemsSource = ConnectClass.db.Warehouse.Select(item => item.Title).ToList();
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

                var editSupply = ConnectClass.db.Supply.FirstOrDefault(item => item.ID == selectedItem.ID);

                editSupply.NameProduct = txbNameProduct.Text;
                editSupply.NameProvider = txbProvider.Text;
                editSupply.Price = txbPrice.Text;
                editSupply.Count = txbCount.Text;
                editSupply.DateSupply = Convert.ToDateTime(dtDateSupply.SelectedDate);

                var currentWarehouse = ConnectClass.db.Warehouse.FirstOrDefault(item => item.Title == cmbWarehouse.Text);
                editSupply.IDWarehouse = currentWarehouse.ID;

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
            txbNameProduct.Text = "";
            txbCount.Text = "";
            txbPrice.Text = "";
            txbProvider.Text = "";
            cmbWarehouse.SelectedItem = null;
            dtDateSupply.SelectedDate = null;
        }
    }
}
