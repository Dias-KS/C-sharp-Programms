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
    /// Логика взаимодействия для RegUserPage.xaml
    /// </summary>
    public partial class RegUserPage : Page
    {
        public RegUserPage()
        {
            InitializeComponent();
            cmbRole.ItemsSource = ConnectClass.db.Role.Select(item => item.IDRole).ToList();
        }

        

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }


        private void pswPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {

            if (txbFirstname.Text != "" & txbLastname.Text != "" & pswPassword.Password != "" & cmbRole.SelectedItem != null)
            {
                btnRegistration.IsEnabled = true;
            }

            else
            {
                btnRegistration.IsEnabled = false;
            }

        }

        

        private void btnClean_Click(object sender, RoutedEventArgs e)
        {
            txbFirstname.Text = "";
            txbLastname.Text = "";
            pswPassword.Password = "";
            cmbRole.SelectedItem = null;
        }

        private void btnRegistration_Click(object sender, RoutedEventArgs e)
        {
            if (ConnectClass.db.SignIn.Count(x => x.FirstName == txbFirstname.Text && x.LastName == txbLastname.Text) > 0)
            {
                MessageBox.Show("Пользователь с такими данными уже есть!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            else
            {
                try
                {
                    if (cmbRole.Text == "A")
                    {

                        SignIn newAdmin = new SignIn()
                        {
                            FirstName = txbFirstname.Text,
                            LastName = txbLastname.Text,
                            Password = pswPassword.Password,
                            RoleID = "A"
                        };


                        MemoryStream stream = new MemoryStream();
                        JpegBitmapEncoder encorder = new JpegBitmapEncoder();
                        encorder.Frames.Add(BitmapFrame.Create((BitmapImage)PictureBoxUA.ImageSource));
                        encorder.Save(stream);
                        newAdmin.PictureUA = stream.ToArray();

                        ConnectClass.db.SignIn.Add(newAdmin);
                        ConnectClass.db.SaveChanges();

                        MessageBox.Show("Пользователь успешно добавлен!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

                    }

                    if (cmbRole.Text == "U")
                    {
                        SignIn newUser = new SignIn()
                        {

                            FirstName = txbFirstname.Text,
                            LastName = txbLastname.Text,
                            Password = pswPassword.Password,
                            RoleID = "U"

                        };

                        MemoryStream stream = new MemoryStream();
                        JpegBitmapEncoder encorder = new JpegBitmapEncoder();
                        encorder.Frames.Add(BitmapFrame.Create((BitmapImage)PictureBoxUA.ImageSource));
                        encorder.Save(stream);
                        newUser.PictureUA = stream.ToArray();

                        ConnectClass.db.SignIn.Add(newUser);
                        ConnectClass.db.SaveChanges();

                        MessageBox.Show("Пользователь успешно добавлен!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    }

            }

                catch (Exception ex)

                {
                    MessageBox.Show("Ошибка работы приложения: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void cmbRole_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (txbFirstname.Text != "" & txbLastname.Text != "" & pswPassword.Password != "" & cmbRole.SelectedItem != null)
            {
                btnRegistration.IsEnabled = true;
            }

            else
            {
                btnRegistration.IsEnabled = false;
            }
        }

        private void txbFirstname_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txbFirstname.Text != "" & txbLastname.Text != "" & pswPassword.Password != "" & cmbRole.SelectedItem != null)
            {
                btnRegistration.IsEnabled = true;
            }

            else
            {
                btnRegistration.IsEnabled = false;
            }
        }

        private void txbLastname_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txbFirstname.Text != "" & txbLastname.Text != "" & pswPassword.Password != "" & cmbRole.SelectedItem != null)
            {
                btnRegistration.IsEnabled = true;
            }

            else
            {
                btnRegistration.IsEnabled = false;
            }
        }

        private void pswPassword_PasswordChanged_1(object sender, RoutedEventArgs e)
        {
            if (txbFirstname.Text != "" & txbLastname.Text != "" & pswPassword.Password != "" & cmbRole.SelectedItem != null)
            {
                btnRegistration.IsEnabled = true;
            }

            else
            {
                btnRegistration.IsEnabled = false;
            }
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

        private void btnCleanTwo_Click(object sender, RoutedEventArgs e)
        {
            PictureBoxUA.ImageSource = null;
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
