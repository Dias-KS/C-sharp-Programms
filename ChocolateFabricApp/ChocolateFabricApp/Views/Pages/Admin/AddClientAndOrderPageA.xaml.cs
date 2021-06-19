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
    /// Логика взаимодействия для AddClientAndOrderPageA.xaml
    /// </summary>
    public partial class AddClientAndOrderPageA : Page
    {
        public AddClientAndOrderPageA()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                ClientAndOrder newClientAndOrder = new ClientAndOrder();
                Client newClient = new Client();
                Order newOrder = new Order();

                newClient.NameClient = txbNameClient.Text;
                newClient.Adress = txbAdress.Text;
                newClient.City = txbCity.Text;

                newOrder.NameOrder = txbNameOrder.Text;
                newOrder.Count = txbCount.Text;
                newOrder.Price = txbPrice.Text;
                newOrder.DateOrdered = Convert.ToDateTime(dtDateOrdered.SelectedDate);

                newClientAndOrder.IDClient = newClient.ID;
                newClientAndOrder.IDOrder = newOrder.ID;

                ConnectClass.db.Client.Add(newClient);
                ConnectClass.db.Order.Add(newOrder);
                ConnectClass.db.ClientAndOrder.Add(newClientAndOrder);
                ConnectClass.db.SaveChanges();

                MessageBox.Show("Данные о клиенте и его заказе успешно добавлены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnClean_Click(object sender, RoutedEventArgs e)
        {
            txbAdress.Text = "";
            txbCity.Text = "";
            txbCount.Text = "";
            txbNameClient.Text = "";
            txbNameOrder.Text = "";
            txbPrice.Text = "";
            dtDateOrdered.SelectedDate = null;
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
