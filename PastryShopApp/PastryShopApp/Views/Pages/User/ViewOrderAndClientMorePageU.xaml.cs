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

namespace PastryShopApp.Views.Pages.User
{
    /// <summary>
    /// Логика взаимодействия для ViewOrderAndClientMorePageU.xaml
    /// </summary>
    public partial class ViewOrderAndClientMorePageU : Page
    {
        public ViewOrderAndClientMorePageU()
        {
            InitializeComponent();
            
        }

        private ClientAndOrder selectedItem;

        public ViewOrderAndClientMorePageU(ClientAndOrder selectedItem)
        {
            InitializeComponent();
            this.selectedItem = selectedItem;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void txbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            listViewData.ItemsSource = ConnectClass.db.ClientAndOrder.Where(item => item.OrderRegister.NameProduct.Contains(txbSearch.Text) || item.OrderRegister.StatusOrder.Title.Contains(txbSearch.Text) || item.OrderRegister.TypeProduct.Title.Contains(txbSearch.Text)).ToList();
        }

        private void btnClean_Click(object sender, RoutedEventArgs e)
        {
            txbSearch.Text = "";
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = (ClientAndOrder)listViewData.SelectedItem;

            if (selectedItem != null)
            {
                NavigationService.Navigate(new EditOrderAndClientPageU(selectedItem));
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
            listViewData.ItemsSource = ConnectClass.db.ClientAndOrder.Where(item => item.OrderRegisterID == selectedItem.OrderRegister.ID).ToList();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены что хотите закрыть программу?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }
    }
}
