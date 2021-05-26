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
    /// Логика взаимодействия для RegOrderAndClientPageU.xaml
    /// </summary>
    public partial class RegOrderAndClientPageU : Page
    {
        public RegOrderAndClientPageU()
        {
            InitializeComponent();
            cmbStatus.ItemsSource = ConnectClass.db.StatusOrder.Select(item => item.Title).ToList();
            cmbTypeProduct.ItemsSource = ConnectClass.db.TypeProduct.Select(item => item.Title).ToList();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btnCleanOne_Click(object sender, RoutedEventArgs e)
        {
            txbFirstname.Text = "";
            txbLastName.Text = "";
            txbTelephone.Text = "";
            dtDateAccept.SelectedDate = null;
            dtDateRegistration.SelectedDate = null;
            txbAdress.Text = "";

        }

        private void btnCleanTwo_Click(object sender, RoutedEventArgs e)
        {

            txbCount.Text = "";
            txbPrice.Text = "";
            cmbStatus.SelectedItem = null;
            cmbTypeProduct.SelectedItem = null;
            dtDateReadness.SelectedDate = null;
            txbNameProduct.Text = "";
        }


        private void btnCleanThree_Click(object sender, RoutedEventArgs e)
        {
            PictureBox.Source = null; 
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Image (*.jpg; *.png; *.jpeg;) | *.jpg; *.png; *.jpeg;";
            if (file.ShowDialog() == true)
            {
                BitmapImage bitmap = new BitmapImage(new Uri(file.FileName));
                PictureBox.Source = bitmap;
            }
        }

        private void btnAddOne_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                ClientRegister newClient = new ClientRegister();
                ClientMoreInfo newClientMoreInfo = new ClientMoreInfo();
                ClientAndOrder newClientAndOrder = new ClientAndOrder();
                OrderRegister newOrder = new OrderRegister();

                newClient.FirstName = txbFirstname.Text;
                newClient.LastName = txbLastName.Text;
                newClientMoreInfo.Adress = txbAdress.Text;
                newClientMoreInfo.Telephone = txbTelephone.Text;
                newClient.DateAccept = (DateTime)dtDateAccept.SelectedDate;
                newClient.DateRegistration = (DateTime)dtDateRegistration.SelectedDate;
                newClient.DateReadness = dtDateReadness.SelectedDate;

                var currenTypeProduct = ConnectClass.db.TypeProduct.FirstOrDefault(item => item.Title == cmbTypeProduct.Text);
                newOrder.IDTypeProduct = currenTypeProduct.ID;

                var currentStatus = ConnectClass.db.StatusOrder.FirstOrDefault(item => item.Title == cmbStatus.Text);
                newOrder.IDStatus = currentStatus.ID;

                newOrder.NameProduct = txbNameProduct.Text;
                newOrder.Price = txbPrice.Text;
                newOrder.Count = txbCount.Text;

                newClientAndOrder.ClientRegisterID = newClient.ID;
                newClientAndOrder.OrderRegisterID = newOrder.ID;


                MemoryStream stream = new MemoryStream();
                JpegBitmapEncoder encorder = new JpegBitmapEncoder();
                encorder.Frames.Add(BitmapFrame.Create((BitmapImage)PictureBox.Source));
                encorder.Save(stream);
                newOrder.Picture = stream.ToArray();

                ConnectClass.db.ClientRegister.Add(newClient);
                ConnectClass.db.ClientMoreInfo.Add(newClientMoreInfo);
                ConnectClass.db.ClientAndOrder.Add(newClientAndOrder);
                ConnectClass.db.OrderRegister.Add(newOrder);

                ConnectClass.db.SaveChanges();

                MessageBox.Show("Данные клиента и его заказа успешно сохранены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButton.OK, MessageBoxImage.Error);
            }

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
