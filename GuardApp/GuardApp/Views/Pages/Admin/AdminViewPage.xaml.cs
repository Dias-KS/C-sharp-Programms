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

namespace GuardApp.Views.Pages.Admin
{
    /// <summary>
    /// Логика взаимодействия для AdminViewPage.xaml
    /// </summary>
    public partial class AdminViewPage : Page
    {
        public AdminViewPage()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены что хотите закрыть программу?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void txbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            dataView.ItemsSource = ConnectClass.db.GuardInfoPesonal.Where(item => item.FirstName.Contains(txbSearch.Text) || item.SurName.Contains(txbSearch.Text) || item.GuardInfoGun.TypeGun.Contains(txbSearch.Text) || item.Podrazdelenie.NameDivision.Contains(txbSearch.Text)).ToList();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            dataView.ItemsSource = ConnectClass.db.GuardInfoPesonal.ToList();
        }

        private void btnViewMore_Click(object sender, RoutedEventArgs e)
        {
            GuardInfoPesonal viewMore = (GuardInfoPesonal)dataView.SelectedItem;
            if(viewMore != null)
            {
                NavigationService.Navigate(new AdminViewMorePage(viewMore));
            }

            else
            {
                MessageBox.Show("Вы не выбрали ни одного элемента!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnDelete_Click_1(object sender, RoutedEventArgs e)
        {
            var removeInfo = (GuardInfoPesonal)dataView.SelectedItem;
            if(removeInfo != null)
            {
                ConnectClass.db.GuardInfoPesonal.Remove(removeInfo);
                ConnectClass.db.SaveChanges();
                Page_Loaded(null, null);
                MessageBox.Show("Вы успешно удалили данные!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            else
            {
                MessageBox.Show("Вы не выбрали ни одного элемента!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddAdminPage());
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var editInfo = (GuardInfoPesonal)dataView.SelectedItem;
            if(editInfo != null)
            {
                NavigationService.Navigate(new EditAdminPage(editInfo));
            }
        }
    }
}
