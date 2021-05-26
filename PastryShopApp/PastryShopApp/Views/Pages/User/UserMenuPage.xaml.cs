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

namespace PastryShopApp.Views.Pages.User
{
    /// <summary>
    /// Логика взаимодействия для UserMenuPage.xaml
    /// </summary>
    public partial class UserMenuPage : Page
    {
        public UserMenuPage()
        {
            InitializeComponent();
        }

        private void btnRegClient_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegOrderAndClientPageU());
        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ViewOrderAndClientPageU());
        }

        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Вы можете использовать следующие опции: \n\n- Регистрация клиента/заказа - переход на страницу регистрации нового клиента, а также его заказа. \n\n- Просмотр записей - просмотр текущих записей, \n  а также некоторые манипуляции с ними.", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены что хотите закрыть программу?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }
    }
}
