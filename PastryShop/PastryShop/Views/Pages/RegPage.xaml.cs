using PastryShop.Classes;
using PastryShop.Models;
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

namespace PastryShop.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        public RegPage()
        {
            InitializeComponent();
        }

        private void btnClean_Click(object sender, RoutedEventArgs e)
        {
            txbLogin.Text = "";
            pswPassword.Password = "";
            pswPasswordDouble.Password = "";
        }

        private void btnRegistration_Click(object sender, RoutedEventArgs e)
        {

            if (ConnectClass.db.SignIn.Count(x => x.Username == txbLogin.Text) > 0)
            {

                MessageBox.Show("Пользователь с таким именем уже есть!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;

            }

            else
            {

                try
                {

                    SignIn userExp = new SignIn()
                    {

                        Username = txbLogin.Text,
                        Password = pswPassword.Password,
                        IDRole = "U"

                    };

                    ConnectClass.db.SignIn.Add(userExp);
                    ConnectClass.db.SaveChanges();

                    MessageBox.Show("Пользователь создан!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

                }

                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка работы приложения: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); 
                }

            }

        }

        private void pswPasswordDouble_PasswordChanged(object sender, RoutedEventArgs e)
        {

            if (pswPassword.Password == pswPasswordDouble.Password & pswPassword.Password != "" & pswPasswordDouble.Password != "")
            {
                btnRegistration.IsEnabled = true;
            }

            else
            {
                btnRegistration.IsEnabled = false;
            }

        }

        private void pswPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {

            if (pswPassword.Password == pswPasswordDouble.Password & pswPassword.Password != "" & pswPasswordDouble.Password != "")
            {
                btnRegistration.IsEnabled = true;
            }

            else
            {
                btnRegistration.IsEnabled = false;
            }

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
