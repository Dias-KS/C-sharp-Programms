using Authorization.Context;
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

namespace Authorization.Views.Pages
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

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            txbLogin.Text = "";
            pswPassword.Password = "";
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Э " + txbLogin.Text +  " ты уверен что хочешь закрыть программу?" , "Вопрос", MessageBoxButton.YesNo, MessageBoxImage.Question)== MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
            

        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var currentUser = ConnectClass.db.SgnIns.FirstOrDefault(item => item.Username == txbLogin.Text && item.Password == pswPassword.Password);
            if(currentUser != null)
            {
                

                switch (currentUser.RoleID)
                {
                    case "A":
                        MessageBox.Show("Привет Администратор " + txbLogin.Text + "!", "Добро пожаловать!", MessageBoxButton.OK, MessageBoxImage.Information);
                        NavigationService.Navigate(new AdminViewPage());
                        break;


                    case "U":
                        MessageBox.Show("Привет Пользователь " + txbLogin.Text + "!", "Добро пожаловать!", MessageBoxButton.OK, MessageBoxImage.Information);
                        NavigationService.Navigate(new UserViewPage());
                        break;


                }
            }

            else
            {
                MessageBox.Show("Ты че ска тут хотел сам че то навыдумывать иди нах!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
