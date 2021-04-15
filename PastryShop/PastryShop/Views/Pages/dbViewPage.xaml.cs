using PastryShop.Classes;
using PastryShop.Models;
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

namespace PastryShop.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для dbViewPage.xaml
    /// </summary>
    public partial class dbViewPage : Page
    {
        public dbViewPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            dbListView.ItemsSource = ConnectClass.db.Computer.ToList();
        }

        private void btnADD_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ADDPage());
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Computer removeComputer = (Computer)dbListView.SelectedItem;
                if (removeComputer != null)
                {
                    ConnectClass.db.Computer.Remove(removeComputer);
                    ConnectClass.db.SaveChanges();
                    Page_Loaded(null, null);
                }

                else
                {
                    MessageBox.Show("Вы уверены что хотите удалить данный элемент?", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void dbListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedItem = (Computer)dbListView.SelectedItem;

            if (selectedItem != null)
            {
                NavigationService.Navigate(new EditPage(selectedItem));
            }

            else
            {
                MessageBox.Show("Выберите элемент!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void txbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            dbListView.ItemsSource = ConnectClass.db.Computer.Where(item => item.CPU.Contains(txbSearch.Text)).ToList();
        }
    }    
}
