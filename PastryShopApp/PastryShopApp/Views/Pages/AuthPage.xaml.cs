using PastryShopApp.Classes;
using PastryShopApp.Views.Pages.Admin;
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

namespace PastryShopApp.Views.Pages
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
            var currentUser = ConnectClass.db.SignIn.FirstOrDefault(item => item.FirstName == txbFirstName.Text && item.LastName == txbLastName.Text && item.Password == pswBox.Password);
            if (currentUser != null)
            {
                switch(currentUser.RoleID)
                {

                    case "A":
                        MessageBox.Show("Добро пожаловать, админ " + txbFirstName.Text + "!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                        NavigationService.Navigate(new AdminMenuPage());
                        break;


                    case "U":
                        MessageBox.Show("Добро пожаловать, пользователь " + txbFirstName.Text + "!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                        //NavigationService.Navigate(new AdminMenuPage());
                        break;


                }
            }

            else
            {
                MessageBox.Show("Вы неправильно ввели данные, пожалуйста повторите попытку!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txbFirstName.Text = "";
            txbLastName.Text = "";
            pswBox.Password = "";
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
           if(MessageBox.Show("Вы уверены, что хотите выйти из программы?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }
    }
}
