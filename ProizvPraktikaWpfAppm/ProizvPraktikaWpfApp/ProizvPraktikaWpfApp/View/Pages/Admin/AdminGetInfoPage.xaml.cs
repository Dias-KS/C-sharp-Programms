using ProizvPraktikaWpfApp.Context;
using ProizvPraktikaWpfApp.Model;
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

namespace ProizvPraktikaWpfApp.View.Pages.Admin
{
    /// <summary>
    /// Логика взаимодействия для AdminGetInfoPage.xaml
    /// </summary>
    public partial class AdminGetInfoPage : Page
    {

        private Company selectedItem;

        public AdminGetInfoPage()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        public AdminGetInfoPage (Company selectedItem)
        {
            InitializeComponent();
            this.selectedItem = selectedItem;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            
            dbGetInfoView.ItemsSource = connectClass.db.Companies.Where(item => item.SupplyID == selectedItem.ID).ToList(); 

        }
    }
}
