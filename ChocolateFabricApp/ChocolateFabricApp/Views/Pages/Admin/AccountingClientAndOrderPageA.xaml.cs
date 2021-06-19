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
    /// Логика взаимодействия для AccountingClientAndOrderPageA.xaml
    /// </summary>
    public partial class AccountingClientAndOrderPageA : Page
    {
        public AccountingClientAndOrderPageA()
        {
            InitializeComponent();
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

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddClientAndOrderPageA());
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            ClientAndOrder editClientAndOrder = (ClientAndOrder)dataView.SelectedItem;
            if (editClientAndOrder != null)
            {
                NavigationService.Navigate(new EditClientAndOrderPageA(editClientAndOrder));
            }

            else
            {
                MessageBox.Show("Вы не выбрали ни одного элемента!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            ClientAndOrder deleteClientAndOrder = (ClientAndOrder)dataView.SelectedItem;
            if (deleteClientAndOrder != null)
            {
                if (MessageBox.Show("Вы уверены, что хотите удалить данного клиента?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {

                    ConnectClass.db.ClientAndOrder.Remove(deleteClientAndOrder);
                    ConnectClass.db.SaveChanges();
                    Page_Loaded(null, null);
                    MessageBox.Show("Вы успешно удалили клиента!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

                }
            }

            else
            {
                MessageBox.Show("Вы не выбрали ни одного элемента!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnMoreInfo_Click(object sender, RoutedEventArgs e)
        {
            var viewOrder = (ClientAndOrder)dataView.SelectedItem;

            if (viewOrder != null)
            {

                NavigationService.Navigate(new AccoutingClientAndOrderMorePageA(viewOrder));

            }

            else
            {
                MessageBox.Show("Вы не выбрали ни одного элемента!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            dataView.ItemsSource = ConnectClass.db.ClientAndOrder.ToList();
        }

        private void txbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            dataView.ItemsSource = ConnectClass.db.ClientAndOrder.Where(item => item.Client.NameClient.Contains(txbSearch.Text) || item.Client.City.Contains(txbSearch.Text)).ToList();
        }
    }
}
