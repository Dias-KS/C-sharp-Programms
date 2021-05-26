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
    /// Логика взаимодействия для ViewOrderAndClientPageU.xaml
    /// </summary>
    public partial class ViewOrderAndClientPageU : Page
    {
        public ViewOrderAndClientPageU()
        {
            InitializeComponent();
        }

        

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btnClean_Click(object sender, RoutedEventArgs e)
        {
            txbSearch.Text = "";
        }

        private void btnViewOrder_Click(object sender, RoutedEventArgs e)
        {
            var viewOorder = (ClientAndOrder)listViewData.SelectedItem;

            if (viewOorder != null)
            {

                NavigationService.Navigate(new ViewOrderAndClientMorePageU(viewOorder));

            }

            else
            {
                MessageBox.Show("Вы не выбрали ни одного элемента!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void txbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
             listViewData.ItemsSource = ConnectClass.db.ClientAndOrder.Where(item => item.ClientRegister.FirstName.Contains(txbSearch.Text) || item.ClientRegister.LastName.Contains(txbSearch.Text) || item.ClientRegister.ClientMoreInfo.Telephone.Contains(txbSearch.Text)).ToList();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = (ClientAndOrder)listViewData.SelectedItem;

            if (selectedItem != null)
            {
                NavigationService.Navigate(new EditOrderAndClientPageU(selectedItem));
            }
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            ClientAndOrder RemoveClient = (ClientAndOrder)listViewData.SelectedItem;

            if (RemoveClient != null)
            {
                if (MessageBox.Show("Вы действительно хотите удалить данный элемент?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {


                    ConnectClass.db.ClientAndOrder.Remove(RemoveClient);
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
            listViewData.ItemsSource = ConnectClass.db.ClientAndOrder.ToList();
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
