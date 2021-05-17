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
    /// Логика взаимодействия для ViewRecordsMenuPage.xaml
    /// </summary>
    public partial class ViewRecordsMenuPage : Page
    {
        public ViewRecordsMenuPage()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Вы можете использовать следующие опции: \n\n- Просмотр пользователей - переход на страницу\n  просмотра текущих пользователей.\n\n- Просмотр клиентов/заказов - переход на страницу  просмотра текущих клиентв, а также их заказов.", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnUserView_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ViewUserPage());
        }

        private void btnClientOrderView_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ViewOrderAndClientPage());
        }
    }
}
