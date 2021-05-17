using PastryShopApp.Classes;
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
    /// Логика взаимодействия для ViewOrderAndClientPage.xaml
    /// </summary>
    public partial class ViewOrderAndClientPage : Page
    {
        public ViewOrderAndClientPage()
        {
            InitializeComponent();
        }

        private void txbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnClean_Click(object sender, RoutedEventArgs e)
        {
            txbSearch.Text = "";
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            listViewData.ItemsSource = ConnectClass.db.ClientAndOrder.ToList();
        }

        private void listViewData_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
