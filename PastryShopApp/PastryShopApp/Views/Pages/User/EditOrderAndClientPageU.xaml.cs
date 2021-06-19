using Microsoft.Win32;
using PastryShopApp.Classes;
using PastryShopApp.Model;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для EditOrderAndClientPageU.xaml
    /// </summary>
    public partial class EditOrderAndClientPageU : Page
    {
        public EditOrderAndClientPageU()
        {
            InitializeComponent();
        }

        private ClientRegister selectedItem;

        public EditOrderAndClientPageU(ClientRegister selectedItem)
        {

            InitializeComponent();
            this.selectedItem = selectedItem;

            txbFirstname.Text = selectedItem.FirstName;
            txbLastName.Text = selectedItem.LastName;
            txbAdress.Text = selectedItem.ClientMoreInfo.Adress;
            txbTelephone.Text = selectedItem.ClientMoreInfo.Telephone;
            dtDateAccept.SelectedDate = selectedItem.DateAccept;
            dtDateReadness.SelectedDate = selectedItem.DateReadness;
            dtDateRegistration.SelectedDate = selectedItem.DateRegistration;
          
        }

        private void btnCleanOne_Click(object sender, RoutedEventArgs e)
        {
            txbFirstname.Text = "";
            txbLastName.Text = "";
            txbTelephone.Text = "";
            dtDateAccept.SelectedDate = null;
            dtDateRegistration.SelectedDate = null;
            txbAdress.Text = "";
            dtDateReadness.SelectedDate = null;
        }


        private void btnAddOne_Click(object sender, RoutedEventArgs e)
        {


            var editOrderAndClient = ConnectClass.db.ClientRegister.FirstOrDefault(item => item.ID == selectedItem.ID);


            editOrderAndClient.FirstName = txbFirstname.Text;
            editOrderAndClient.LastName = txbLastName.Text;
            editOrderAndClient.ClientMoreInfo.Adress = txbAdress.Text;
            editOrderAndClient.ClientMoreInfo.Telephone = txbTelephone.Text;
            editOrderAndClient.DateAccept = (DateTime)dtDateAccept.SelectedDate;
            editOrderAndClient.DateRegistration = (DateTime)dtDateRegistration.SelectedDate;
            editOrderAndClient.DateReadness = dtDateReadness.SelectedDate;

            ConnectClass.db.SaveChanges();
            MessageBox.Show("Вы успешно изменили данные!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
           
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
