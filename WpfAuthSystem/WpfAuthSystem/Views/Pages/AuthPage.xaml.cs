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
using WpfAuthSystem.Context;


namespace WpfAuthSystem.Views.Pages
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

        private void btnADD_Click(object sender, RoutedEventArgs e)
        {
            var currentUser = dbContext.db.SignIns.FirstOrDefault(item => item.Username == txtLogin.Text && item.Password == pswPassword.Password);
            if (currentUser != null)
            {
                switch (currentUser.IDRole)
                {
                    case "A" :
                        MessageBox.Show("Добро пожаловать в систему Админ " + txtLogin.Text + "!", "Вход выполнен успешно.",  MessageBoxButton.OK, MessageBoxImage.Information);
                        NavigationService.Navigate(new AdminViewPage());
                    break;

                    case "U":
                        MessageBox.Show("Привет пользователь " + txtLogin.Text + "!", "Вход выполнен успешно.", MessageBoxButton.OK, MessageBoxImage.Information);
                        NavigationService.Navigate(new UserViewPage());
                    break;

                }
            }

            else
            {
                MessageBox.Show("Введён неверный логин или пароль, повторите попытку!", "Ты че то попутал!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            txtLogin.Text = "";
            pswPassword.Password = "";
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
