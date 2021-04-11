using GeografiaApplication.Classes;
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

namespace GeografiaApplication.Views.Pages
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
            var currentUser = dbConnect.db.SignIns.FirstOrDefault(item => item.Username == txtLogin.Text && item.Password == pswPassword.Password);
            if(currentUser != null)
            {
                switch (currentUser.RoleID)
                {
                    case "A":
                        MessageBox.Show("Добро пожаловать админ " + txtLogin.Text + "!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                        break;

                    case "U":
                        MessageBox.Show("Добро пожаловать пользователь " + txtLogin.Text + "!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                        break;
                }
            }

            else
            {
                MessageBox.Show("Вы неверно ввели логин или пароль, пожалуйста повторите попытку!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            txtLogin.Text = "";
            pswPassword.Password = "";
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Вы уверены, что хотите закрыть программу?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {

                Application.Current.Shutdown();

            }
        }
    }
}
