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

namespace PastryShopApp.Views.Pages.Admin
{
    /// <summary>
    /// Логика взаимодействия для EditUserPage.xaml
    /// </summary>
    public partial class EditUserPage : Page
    {
        public EditUserPage()
        {
            InitializeComponent();
            
        }

        private SignIn selectedItem;


        public EditUserPage(SignIn selectedItem)
        {
            InitializeComponent();
            this.selectedItem = selectedItem;

            txbFirstname.Text = selectedItem.FirstName;
            txbLastname.Text = selectedItem.LastName;
            pswPassword.Password = selectedItem.Password;
            cmbRole.SelectedItem = selectedItem.Role.IDRole;

            if (selectedItem.PictureUA != null)
            {

                BitmapImage bitmap = new BitmapImage();
                using (MemoryStream stream = new MemoryStream(selectedItem.PictureUA))
                {
                    bitmap.BeginInit();
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.StreamSource = stream;
                    bitmap.EndInit();
                }
                PictureBoxUA.ImageSource = bitmap;

            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btnCleanTwo_Click(object sender, RoutedEventArgs e)
        {
            PictureBoxUA.ImageSource = null;
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Image (*.jpg; *.png; *.jpeg;) | *.jpg; *.png; *.jpeg;";
            if (file.ShowDialog() == true)
            {
                BitmapImage bitmap = new BitmapImage(new Uri(file.FileName));
                PictureBoxUA.ImageSource = bitmap;
            }

        }

        private void btnClean_Click(object sender, RoutedEventArgs e)
        {
            txbFirstname.Text = "";
            txbLastname.Text = "";
            pswPassword.Password = "";
            cmbRole.SelectedItem = null;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

            try
            {

                var editSignIn = ConnectClass.db.SignIn.FirstOrDefault(item => item.ID == selectedItem.ID);

                editSignIn.FirstName = txbFirstname.Text;
                editSignIn.LastName = txbLastname.Text;
                editSignIn.Password = pswPassword.Password;
                editSignIn.RoleID = cmbRole.Text;


                MemoryStream stream = new MemoryStream();
                JpegBitmapEncoder encorder = new JpegBitmapEncoder();
                encorder.Frames.Add(BitmapFrame.Create((BitmapImage)PictureBoxUA.ImageSource));
                encorder.Save(stream);
                editSignIn.PictureUA = stream.ToArray();

                ConnectClass.db.SaveChanges();
                MessageBox.Show("Данные успешно изменены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void txbFirstname_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txbFirstname.Text != "" & txbLastname.Text != "" & pswPassword.Password != "" & cmbRole.SelectedItem != null)
            {
                btnSave.IsEnabled = true;
            }

            else
            {
                btnSave.IsEnabled = false;
            }
        }

        private void txbFirstname_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            if (txbFirstname.Text != "" & txbLastname.Text != "" & pswPassword.Password != "" & cmbRole.SelectedItem != null)
            {
                btnSave.IsEnabled = true;
            }

            else
            {
                btnSave.IsEnabled = false;
            }
        }

        private void txbLastname_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txbFirstname.Text != "" & txbLastname.Text != "" & pswPassword.Password != "" & cmbRole.SelectedItem != null)
            {
                btnSave.IsEnabled = true;
            }

            else
            {
                btnSave.IsEnabled = false;
            }
        }

        private void pswPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (txbFirstname.Text != "" & txbLastname.Text != "" & pswPassword.Password != "" & cmbRole.SelectedItem != null)
            {
                btnSave.IsEnabled = true;
            }

            else
            {
                btnSave.IsEnabled = false;
            }
        }

        private void cmbRole_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (txbFirstname.Text != "" & txbLastname.Text != "" & pswPassword.Password != "" & cmbRole.SelectedItem != null)
            {
                btnSave.IsEnabled = true;
            }

            else
            {
                btnSave.IsEnabled = false;
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            cmbRole.ItemsSource = ConnectClass.db.Role.Select(item => item.IDRole).ToList();

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
