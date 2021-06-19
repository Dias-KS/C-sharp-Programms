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

namespace ChocolateFabricApp.Views.Pages.Admin
{
    /// <summary>
    /// Логика взаимодействия для AdminNavigatePage.xaml
    /// </summary>
    public partial class AdminNavigatePage : Page
    {
        public AdminNavigatePage()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите выйти из программы?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        private void btnUserAccouting_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AccoutingUserPage());
        }

        private void btnOrderAndClientAccouting_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AccountingClientAndOrderPageA());
        }

        private void btnSupplyAccouting_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AccoutingSupplyPageA());
        }

        private void btnpProductionAccouting_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AccoutingProductionPageA());
        }

        private void btnEmployeesAccouting_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AccoutingEmployeesPageA());
        }
    }
}
