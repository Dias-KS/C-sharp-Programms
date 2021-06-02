using GuardApp.Classes;
using GuardApp.Views.Pages.Admin;
using GuardApp.Views.Pages.User;
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

namespace GuardApp.Views.Pages
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
            if (MessageBox.Show("Вы уверены что хотите закрыть программу?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
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

        private void btnGuest_Click(object sender, RoutedEventArgs e)
        {

            MessageBox.Show("Добро пожаловать!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            NavigationService.Navigate(new UserViewPage());
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var currentUser = ConnectClass.db.SignIn.FirstOrDefault(item => item.FirstName == txbFirstName.Text && item.SurName == txbLastName.Text && item.Password == pswPassword.Password);
            if (currentUser != null)
            {
                switch (currentUser.RoleID)
                {

                    case "A":
                        MessageBox.Show("Добро пожаловать, админ " + txbFirstName.Text + "!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                        NavigationService.Navigate(new AdminViewPage());
                        break;

                }
            }
        }
    }
}