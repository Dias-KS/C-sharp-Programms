using ChocolateFabricApp.Views.Pages.Admin;
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

namespace ChocolateFabricApp.Views.Pages.User
{
    /// <summary>
    /// Логика взаимодействия для UserNavigatePage.xaml
    /// </summary>
    public partial class UserNavigatePage : Page
    {
        public UserNavigatePage()
        {
            InitializeComponent();
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

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите закрыть программу?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }
    }
}
