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

namespace PastryShopApp.Views.Pages.Admin
{
    /// <summary>
    /// Логика взаимодействия для AdminMenuPage.xaml
    /// </summary>
    public partial class AdminMenuPage : Page
    {
        public AdminMenuPage()
        {
            InitializeComponent();
        }

        
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btnRegistration_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegUserPage());
        }

        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Вы можете использовать следующие опции: \n\n- Регистрация пользователя - переход на страницу\n  регистрации нового пользователя.\n\n- Регистрация клиента - переход на страницу регистрации \n  нового клиента, а также его заказа. \n\n- Просмотр записей - просмотр текущих записей, \n  а также некоторые манипуляции с ними.", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnRegClient_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegOrderAndClientPage());
        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ViewRecordsMenuPage());
        }
    }
}
