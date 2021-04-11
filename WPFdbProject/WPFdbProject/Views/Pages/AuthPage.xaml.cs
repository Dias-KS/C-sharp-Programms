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

namespace WPFdbProject.Views.Pages
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

        string login = "Dias";
        int password = 1234;

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            if(txbLogin.Text == login && Convert.ToInt32(pswBox.Password) == password)
            {
                MessageBox.Show("Вы успешно вошли в систему!");
                NavigationService.Navigate(new dbPage());
            }
           
            else
            {
                MessageBox.Show("Вы не правильно ввели логин или пароль, повторите попытку!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            txbLogin.Text = "";
            pswBox.Password = "";
        }
    }
}
