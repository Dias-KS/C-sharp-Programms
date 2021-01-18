using SelhozApplication.Classes;
using SelhozApplication.Views.Pages.Admin;
using SelhozApplication.Views.Pages.User;
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

namespace SelhozApplication.Views.Pages
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

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            txtLogin.Text = "";
            pswPassword.Password = "";
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
           
            

                var currentUser = ConnectClass.db.SignIn.FirstOrDefault(item => item.Username == txtLogin.Text && item.Password == pswPassword.Password);
                if (currentUser != null)
                {

                    switch (currentUser.RoleID)
                    {
                        case "A":
                            MessageBox.Show("Привет Администратор " + txtLogin.Text + "!", "Добро пожаловать!", MessageBoxButton.OK, MessageBoxImage.Information);
                            NavigationService.Navigate(new AdminViewPage());
                            break;


                        case "U":
                            MessageBox.Show("Добро пожавловать пользователь " + txtLogin.Text + "!", "Добро пожаловать", MessageBoxButton.OK, MessageBoxImage.Information);
                            NavigationService.Navigate(new UserViewPage());
                            break;
                    }

                }

                else
                {
                    MessageBox.Show("Неверный логин или пароль, пожалуйста повторите попытку!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите выйти?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            { 
                Application.Current.Shutdown();
            }
        }
    }
}
