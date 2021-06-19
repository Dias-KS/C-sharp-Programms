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
    /// Логика взаимодействия для EditClientAndOrderPageA.xaml
    /// </summary>
    public partial class EditClientAndOrderPageA : Page
    {
        public EditClientAndOrderPageA()
        {
            InitializeComponent();
        }

        private ClientAndOrder selectedItem;

        public EditClientAndOrderPageA(ClientAndOrder selectedItem)
        {
            InitializeComponent();
            this.selectedItem = selectedItem;

            txbNameClient.Text = selectedItem.Client.NameClient;
            txbAdress.Text = selectedItem.Client.Adress;
            txbCity.Text = selectedItem.Client.City;

            txbNameOrder.Text = selectedItem.Order.NameOrder;
            txbPrice.Text = selectedItem.Order.Price;
            txbCount.Text = selectedItem.Order.Count;
            dtDateOrdered.SelectedDate = selectedItem.Order.DateOrdered;

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

            try
            {

                var editOrderAndClient = ConnectClass.db.ClientAndOrder.FirstOrDefault(item => item.ID == selectedItem.ID);


                editOrderAndClient.Client.NameClient = txbNameClient.Text;
                editOrderAndClient.Client.Adress = txbAdress.Text;
                editOrderAndClient.Client.City = txbCity.Text;

                editOrderAndClient.Order.NameOrder = txbNameOrder.Text;
                editOrderAndClient.Order.Count = txbCount.Text;
                editOrderAndClient.Order.Price = txbPrice.Text;
                editOrderAndClient.Order.DateOrdered = Convert.ToDateTime(dtDateOrdered.SelectedDate);
               
                ConnectClass.db.SaveChanges();

                MessageBox.Show("Данные о клиенте и его заказе успешно изменены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButton.OK, MessageBoxImage.Error);
            }

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
    }
}
