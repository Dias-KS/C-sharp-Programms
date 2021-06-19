using ChocolateFabricApp.Classes;
using ChocolateFabricApp.Views.Pages.Admin;
using ChocolateFabricApp.Views.Pages.User;
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

namespace ChocolateFabricApp.Views.Pages
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
            if(MessageBox.Show("Вы уверены, что хотите выйти из программы?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        private void btnClean_Click(object sender, RoutedEventArgs e)
        {
            txbFirstName.Text = "";
            txbLastName.Text = "";
            pswPassword.Password = ""; 
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var current = ConnectClass.db.SignIn.FirstOrDefault(item => item.FirstName == txbFirstName.Text && item.LastName == txbLastName.Text && item.Password == pswPassword.Password);
            if (current != null)
            {
                switch (current.RoleID)
                {

                    case "A":
                        MessageBox.Show("Добро пожаловать, администратор " + txbFirstName.Text + "!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                        NavigationService.Navigate(new AdminNavigatePage());
                        break;


                    case "U":
                        MessageBox.Show("Добро пожаловать, пользователь " + txbFirstName.Text + "!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                        NavigationService.Navigate(new UserNavigatePage());
                        break;


                }
            }

            else
            {
                MessageBox.Show("Вы неправильно ввели данные, пожалуйста повторите попытку!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
