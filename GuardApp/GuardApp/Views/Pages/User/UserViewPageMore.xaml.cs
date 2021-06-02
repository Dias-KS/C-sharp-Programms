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
    /// Логика взаимодействия для UserViewPageMore.xaml
    /// </summary>
    public partial class UserViewPageMore : Page
    {

        private GuardInfoPesonal selectedItem;

        public UserViewPageMore(GuardInfoPesonal selectedItem)
        {
            InitializeComponent();
            this.selectedItem = selectedItem;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            dataView.ItemsSource = ConnectClass.db.Object.Where(item => item.ObjectID == selectedItem.Object.ObjectID).ToList();
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
