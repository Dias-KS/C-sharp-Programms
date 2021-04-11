using ProductApplication.Classes;
using ProductApplication.Models;
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

namespace ProductApplication.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для dbGetInfoPage.xaml
    /// </summary>
    public partial class dbGetInfoPage : Page
    {
        private Product selectedItem;

        public dbGetInfoPage()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        public dbGetInfoPage(Product selectedItem)
        {
            InitializeComponent();
            this.selectedItem = selectedItem;

        }


        //Логика отображения дополнительных данных
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            dbGetInfo.ItemsSource = ConnectClass.db.Product.Where(item => item.IDSpecification == selectedItem.Specification.ID && item.IDMaterial == selectedItem.Material.ID).ToList();
        }
    }
}
