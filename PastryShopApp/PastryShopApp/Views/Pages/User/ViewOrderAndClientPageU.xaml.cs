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
            ClientRegister viewOorder = (ClientRegister)dataView.SelectedItem;

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
             dataView.ItemsSource = ConnectClass.db.ClientAndOrder.Where(item => item.ClientRegister.FirstName.Contains(txbSearch.Text) || item.ClientRegister.LastName.Contains(txbSearch.Text) || item.ClientRegister.ClientMoreInfo.Telephone.Contains(txbSearch.Text)).ToList();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            dataView.ItemsSource = ConnectClass.db.ClientRegister.ToList();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены что хотите закрыть программу?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        private void btnEdit_Click_1(object sender, RoutedEventArgs e)
        {
            ClientRegister selectedItem = (ClientRegister)dataView.SelectedItem;

            if (selectedItem != null)
            {
                NavigationService.Navigate(new EditOrderAndClientPageU(selectedItem));
            }
        }

        private void btnRemove_Click_1(object sender, RoutedEventArgs e)
        {
            ClientRegister RemoveClient = (ClientRegister)dataView.SelectedItem;

            if (RemoveClient != null)
            {
                if (MessageBox.Show("Вы действительно хотите удалить данный элемент?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {

                    ConnectClass.db.ClientRegister.Remove(RemoveClient);
                    ConnectClass.db.SaveChanges();
                    Page_Loaded(null, null);

                }

            }

            else
            {
                MessageBox.Show("Вы не выбрали ни одного элемента!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void addOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            ClientRegister clientRegister = (ClientRegister)dataView.SelectedItem;
            if (clientRegister != null)
            {
                NavigationService.Navigate(new AddOrderPageU(clientRegister));
            }

            else
            {
                MessageBox.Show("Вы не выбрали ни одного элемента!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void dtSortDataAccept_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dtSortDataAccept.SelectedDate != null)
            {

                Page_Loaded(null, null);

                dataView.ItemsSource = ConnectClass.db.ClientRegister.Where(item => item.DateAccept == dtSortDataAccept.SelectedDate).ToList();

            }

            else
            {
                dataView.ItemsSource = ConnectClass.db.ClientRegister.ToList();
            }
        }
    }
}
