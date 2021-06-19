using PastryShopApp.Classes;
using PastryShopApp.Model;
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

namespace PastryShopApp.Views.Pages.Admin
{
    /// <summary>
    /// Логика взаимодействия для ViewOrderAndClientMorePage.xaml
    /// </summary>
    public partial class ViewOrderAndClientMorePage : Page
    {
        public ViewOrderAndClientMorePage()
        {
            InitializeComponent();
        }

        private ClientRegister selectedItem;

        public ViewOrderAndClientMorePage(ClientRegister selectedItem)
        {
            InitializeComponent();
            this.selectedItem = selectedItem;
        }


        private void txbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            listViewData.ItemsSource = ConnectClass.db.ClientAndOrder.Where(item => item.OrderRegister.NameProduct.Contains(txbSearch.Text) || item.OrderRegister.StatusOrder.Title.Contains(txbSearch.Text) || item.OrderRegister.TypeProduct.Title.Contains(txbSearch.Text)).ToList();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            
            NavigationService.GoBack();
            
        }

        private void btnClean_Click(object sender, RoutedEventArgs e)
        {
            txbSearch.Text = "";
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            ClientAndOrder selectedItem = (ClientAndOrder)listViewData.SelectedItem;

            if (selectedItem != null)
            {

                NavigationService.Navigate(new EditOrderAndClientMorePage(selectedItem));

            }

            else
            {

                MessageBox.Show("Вы не выбрали ни одного элемента!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            ClientAndOrder RemoveOrder = (ClientAndOrder)listViewData.SelectedItem;

            if (RemoveOrder != null)
            {
                if (MessageBox.Show("Вы действительно хотите удалить данный элемент?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {


                    ConnectClass.db.ClientAndOrder.Remove(RemoveOrder);
                    ConnectClass.db.SaveChanges();
                    Page_Loaded(null, null);
                }

            }

            else
            {
                MessageBox.Show("Вы не выбрали ни одного элемента!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            listViewData.ItemsSource = ConnectClass.db.ClientAndOrder.Where(x => x.ClientRegisterID == selectedItem.ID).ToList();

            cmbSortTypeProduct.ItemsSource = ConnectClass.db.TypeProduct.Select(item => item.Title).ToList();

        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены что хотите закрыть программу?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        private void btnAddOrder_Click(object sender, RoutedEventArgs e)
        {
            ClientRegister clientRegister = (ClientRegister)listViewData.SelectedItem;
            if (clientRegister == null)
            {
                NavigationService.Navigate(new AddOrderPage(clientRegister));
            }      
        }

        private void cmbSortTypeProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbSortTypeProduct.SelectedItem != null)
            {
                Page_Loaded(null, null);

                listViewData.ItemsSource = ConnectClass.db.ClientAndOrder.Where(item => item.OrderRegister.TypeProduct.Title.Contains(cmbSortTypeProduct.Text) && item.ClientRegisterID == selectedItem.ID).ToList();
            }

            else
            {
                listViewData.ItemsSource = ConnectClass.db.ClientAndOrder.Where(x => x.ClientRegisterID == selectedItem.ID).ToList();
            }

            
        }

        private void btnCleanTwo_Click(object sender, RoutedEventArgs e)
        {
            cmbSortTypeProduct.SelectedItem = null;
        }
    }
}
