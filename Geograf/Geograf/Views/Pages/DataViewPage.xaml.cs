using Geograf.Classes;
using Geograf.Context;
using Geograf.Model;
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

namespace Geograf.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для DataViewPage.xaml
    /// </summary>
    public partial class DataViewPage : Page
    {
        public DataViewPage()
        {
            InitializeComponent();
            LoadDataFromDB.LoadLanguageInCombo(cmbSelectedLanguage);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddDataPage());
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Country country = (Country)dbViewData.SelectedItem;
            if(country!= null)
            {
                NavigationService.Navigate(new EditDataPage(country));
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Country country = (Country)dbViewData.SelectedItem;
            if (country != null)
            {
                if(MessageBox.Show("Вы хотите удалить эти данные, они будут удалены на всегда", "Удалить?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    var selectedRemove = dbContext.db.Countries.FirstOrDefault(item => item.ID == country.ID);
                    dbContext.db.Countries.Remove(country);
                    dbContext.db.SaveChanges();
                    Page_Loaded(null, null);
                }
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            dbViewData.ItemsSource = dbContext.db.Countries.ToList();
        }

        private void cmbSelectedLanguage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dbViewData.ItemsSource = dbContext.db.Countries.Where(item => item.Ethnic.Language.Title == cmbSelectedLanguage.SelectedItem.ToString()).ToList();
        }

        private void txbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            dbViewData.ItemsSource = dbContext.db.Countries.Where(item => item.Title.Contains(txbSearch.Text) || item.Region.Contains(txbSearch.Text) ||
            item.Square.Contains(txbSearch.Text) || item.Capital.Contains(txbSearch.Text)).ToList();
        }
    }
}
