using GuardApp.Classes;
using GuardApp.Model;
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

namespace GuardApp.Views.Pages.User
{
    /// <summary>
    /// Логика взаимодействия для UserViewPage.xaml
    /// </summary>
    public partial class UserViewPage : Page
    {
        public UserViewPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            dataView.ItemsSource = ConnectClass.db.GuardInfoPesonal.ToList();

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

        private void btnViewMore_Click(object sender, RoutedEventArgs e)
        {
            GuardInfoPesonal viewMore = (GuardInfoPesonal)dataView.SelectedItem;
            if (viewMore != null)
            {
                NavigationService.Navigate(new UserViewPageMore(viewMore));
            }

            else
            {
                MessageBox.Show("Вы не выбрали ни одного элемента!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void txbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            dataView.ItemsSource = ConnectClass.db.GuardInfoPesonal.Where(item => item.FirstName.Contains(txbSearch.Text) || item.SurName.Contains(txbSearch.Text) || item.GuardInfoGun.TypeGun.Contains(txbSearch.Text) || item.Podrazdelenie.NameDivision.Contains(txbSearch.Text)).ToList();
        }
    }
}
