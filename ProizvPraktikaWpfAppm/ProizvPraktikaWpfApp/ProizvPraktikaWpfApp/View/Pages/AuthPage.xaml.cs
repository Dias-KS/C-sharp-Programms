using ProizvPraktikaWpfApp.Context;
using ProizvPraktikaWpfApp.Properties;
using ProizvPraktikaWpfApp.View.Pages.Admin;
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

namespace ProizvPraktikaWpfApp.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
            txbLogin.Text = Settings.Default.login;
            pswPassword.Password = Settings.Default.password;
            check.IsChecked = Settings.Default.IsRemember;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
            if (check.IsChecked == true)
            {
                Settings.Default.IsRemember = true;


                Settings.Default.password = pswPassword.Password;
                Settings.Default.login = txbLogin.Text;
                Settings.Default.Save();

            }


            else
            {
                Settings.Default.login = "";
                Settings.Default.password = "";
                Settings.Default.IsRemember = false;
                Settings.Default.Save();
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (check.IsChecked == true)
            {
                Settings.Default.IsRemember = true;


                Settings.Default.password = pswPassword.Password;
                Settings.Default.login = txbLogin.Text;
                Settings.Default.Save();

            }
            

            else
            {
                Settings.Default.login = "";
                Settings.Default.password = "";
                Settings.Default.IsRemember = false;
                Settings.Default.Save();
            }


            var currentUser = connectClass.db.SignIns.FirstOrDefault(Item => Item.Username == txbLogin.Text && Item.Password == pswPassword.Password);
            if (currentUser != null)
            {

                switch (currentUser.IDRole)
                {
                    case "A" :
                        MessageBox.Show("Привет Администратор " + txbLogin.Text + "!", "Добро пожаловать!",  MessageBoxButton.OK , MessageBoxImage.Information);
                        NavigationService.Navigate(new AdminViewPage());
                        break;

                    case "U":
                        MessageBox.Show("Привет Пользователь " + txbLogin.Text + "!", "Добро пожаловать!", MessageBoxButton.OK, MessageBoxImage.Information);
                        break;
                }

            }

            else
            {

                MessageBox.Show("Неверный логин или пароль, пожалуйста повторите попытку!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);

            }

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            txbLogin.Text = "";
            pswPassword.Password = "";
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
