using AiroportApplication.Classes;
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

namespace AiroportApplication.Views.Pages
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

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите закрыть программу?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {

                Application.Current.Shutdown();

            }

        }

        private void btnClean_Click(object sender, RoutedEventArgs e)
        {
            txtLogin.Text = "";
            pswPassword.Password = "";
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var currentUser = ConnectClass.db.SignIn.FirstOrDefault(item => item.Username == txtLogin.Text && item.Password == pswPassword.Password);
            if (currentUser != null)
            {
                switch(currentUser.RoleID)
                {
                    case "A":
                        MessageBox.Show("Добро пожаловать админ " + txtLogin.Text + "!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                        NavigationService.Navigate(new dbViewPage());
                    break;

                    case "U":
                        MessageBox.Show("Добро пожаловать в систему пользователь " + txtLogin.Text + "!","Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    break;

                }
          
            }

            else
            {
                MessageBox.Show("Вы неправильно ввели логин или пароль, пожалуйста повторите попытку!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void btnExit2_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Добро пожаловать в приложение AirportApplication!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
        }

    } 

}
