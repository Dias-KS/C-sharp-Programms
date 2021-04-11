using PastryShop.Classes;
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
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {

            InitializeComponent();

        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {

            var currentUser = ConnectClass.db.SignIn.FirstOrDefault(item => item.Username == txtLogin.Text & item.Password == pswPassword.Password);

            if(currentUser != null)
            {
                switch (currentUser.IDRole)
                {
                    case "A":
                        MessageBox.Show("Добро пожаловать Админ " + txtLogin.Text + "!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                        NavigationService.Navigate(new RegPage());
                        break;

                    case "U":
                        MessageBox.Show("Добро пожаловать пользователь " + txtLogin.Text + "!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                        NavigationService.Navigate(new RegPage());
                        break;


                            
                }
            }

            else
            {
                MessageBox.Show("Вы неправильно ввели логин или пароль, пожалуйста повторите попытку!", "Уведолмение", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {

            txtLogin.Text = "";

            pswPassword.Password = "";

        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {

           if ( MessageBox.Show("Вы действительно хотите закрыть данную программу?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)

           {

                Application.Current.Shutdown();

           }
                
        }

        private void btnRegistration_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegPage());
        }
    }
}
