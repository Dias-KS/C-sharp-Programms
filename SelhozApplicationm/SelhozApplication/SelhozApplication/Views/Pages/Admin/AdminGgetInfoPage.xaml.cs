using SelhozApplication.Classes;
using SelhozApplication.Model;
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

namespace SelhozApplication.Views.Pages.Admin
{
    /// <summary>
    /// Логика взаимодействия для AdminGgetInfoPage.xaml
    /// </summary>
    public partial class AdminGgetInfoPage : Page
    {
        private Companies selectedItem;

        public AdminGgetInfoPage()
        {
            InitializeComponent();
        }

        public AdminGgetInfoPage (Companies selectedItem)
        {
            InitializeComponent();
            this.selectedItem = selectedItem;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {   //Отображение дополнительных данных
            dbGetInfo.ItemsSource = ConnectClass.db.Companies.Where(item => item.IDProducts == selectedItem.Products.ID && item.IDSupply == selectedItem.Supply.ID).ToList();
        }
    }
}
