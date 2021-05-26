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

        private ClientAndOrder selectedItem;

        public EditOrderAndClientPageU(ClientAndOrder selectedItem)
        {
            InitializeComponent();
            this.selectedItem = selectedItem;

            txbFirstname.Text = selectedItem.ClientRegister.FirstName;
            txbLastName.Text = selectedItem.ClientRegister.LastName;
            txbAdress.Text = selectedItem.ClientRegister.ClientMoreInfo.Adress;
            txbTelephone.Text = selectedItem.ClientRegister.ClientMoreInfo.Telephone;
            txbPrice.Text = selectedItem.OrderRegister.Price;
            txbNameProduct.Text = selectedItem.OrderRegister.NameProduct;
            txbCount.Text = selectedItem.OrderRegister.Count;
            dtDateAccept.SelectedDate = selectedItem.ClientRegister.DateAccept;
            dtDateReadness.SelectedDate = selectedItem.ClientRegister.DateReadness;
            dtDateRegistration.SelectedDate = selectedItem.ClientRegister.DateRegistration;
            cmbStatus.SelectedItem = selectedItem.OrderRegister.StatusOrder.Title;
            cmbTypeProduct.SelectedItem = selectedItem.OrderRegister.TypeProduct.Title;

            if (selectedItem.OrderRegister.Picture != null)
            {

                BitmapImage bitmap = new BitmapImage();
                using (MemoryStream stream = new MemoryStream(selectedItem.OrderRegister.Picture))
                {
                    bitmap.BeginInit();
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.StreamSource = stream;
                    bitmap.EndInit();
                }

                PictureBox.Source = bitmap;

            }

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
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image(*.png; *.jpg; *.jpeg) | *.png; *.jpg; *.jpeg";
            if (open.ShowDialog() == true)
            {
                BitmapImage bitmap = new BitmapImage(new Uri(open.FileName));
                PictureBox.Source = bitmap;


            }
        }

        private void btnAddOne_Click(object sender, RoutedEventArgs e)
        {
            var editOrderAndClient = ConnectClass.db.ClientAndOrder.FirstOrDefault(item => item.ID == selectedItem.ID);



            editOrderAndClient.ClientRegister.FirstName = txbFirstname.Text;
            editOrderAndClient.ClientRegister.LastName = txbLastName.Text;
            editOrderAndClient.ClientRegister.ClientMoreInfo.Adress = txbAdress.Text;
            editOrderAndClient.ClientRegister.ClientMoreInfo.Telephone = txbTelephone.Text;
            editOrderAndClient.ClientRegister.DateAccept = (DateTime)dtDateAccept.SelectedDate;
            editOrderAndClient.ClientRegister.DateRegistration = (DateTime)dtDateRegistration.SelectedDate;
            editOrderAndClient.ClientRegister.DateReadness = dtDateReadness.SelectedDate;

            var currenTypeProduct = ConnectClass.db.TypeProduct.FirstOrDefault(item => item.Title == cmbTypeProduct.Text);
            editOrderAndClient.OrderRegister.IDTypeProduct = currenTypeProduct.ID;

            var currentStatus = ConnectClass.db.StatusOrder.FirstOrDefault(item => item.Title == cmbStatus.Text);
            editOrderAndClient.OrderRegister.IDStatus = currentStatus.ID;

            editOrderAndClient.OrderRegister.NameProduct = txbNameProduct.Text;
            editOrderAndClient.OrderRegister.Price = txbPrice.Text;
            editOrderAndClient.OrderRegister.Count = txbCount.Text;


            MemoryStream stream = new MemoryStream();
            JpegBitmapEncoder encorder = new JpegBitmapEncoder();
            encorder.Frames.Add(BitmapFrame.Create((BitmapImage)PictureBox.Source));
            encorder.Save(stream);
            editOrderAndClient.OrderRegister.Picture = stream.ToArray();

            ConnectClass.db.SaveChanges();
            MessageBox.Show("Вы успешно изменили данные!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            cmbStatus.ItemsSource = ConnectClass.db.StatusOrder.Select(item => item.Title).ToList();
            cmbTypeProduct.ItemsSource = ConnectClass.db.TypeProduct.Select(item => item.Title).ToList();
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
