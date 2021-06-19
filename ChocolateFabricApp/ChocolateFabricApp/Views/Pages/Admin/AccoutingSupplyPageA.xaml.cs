using ChocolateFabricApp.Classes;
using ChocolateFabricApp.Model;
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

namespace ChocolateFabricApp.Views.Pages.Admin
{
    /// <summary>
    /// Логика взаимодействия для AccoutingSupplyPageA.xaml
    /// </summary>
    public partial class AccoutingSupplyPageA : Page
    {
        public AccoutingSupplyPageA()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            dataView.ItemsSource = ConnectClass.db.Supply.ToList();
            cmbWarehouse.ItemsSource = ConnectClass.db.Warehouse.Select(item => item.Title).ToList();
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

        private void txbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            dataView.ItemsSource = ConnectClass.db.Supply.Where(item => item.NameProduct.Contains(txbSearch.Text) || item.NameProvider.Contains(txbSearch.Text)).ToList();

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddSupplyPage());
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Supply editSupply = (Supply)dataView.SelectedItem;
            if (editSupply != null)
            {
                NavigationService.Navigate(new EditSupplyPageA(editSupply));
            }

            else
            {
                MessageBox.Show("Вы не выбрали ни одного элемента!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Supply deleteSupply = (Supply)dataView.SelectedItem;
            if (deleteSupply != null)
            {
                if (MessageBox.Show("Вы уверены, что хотите удалить данную поставку?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {

                    ConnectClass.db.Supply.Remove(deleteSupply);
                    ConnectClass.db.SaveChanges();
                    Page_Loaded(null, null);
                    MessageBox.Show("Вы успешно удалили данные о поставке!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

                }
            }

            else
            {
                MessageBox.Show("Вы не выбрали ни одного элемента!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
   
        }

        private void cmbWarehouse_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {

                Page_Loaded(null, null);
                dataView.ItemsSource = ConnectClass.db.Supply.Where(item => item.Warehouse.Title.Contains(cmbWarehouse.Text)).ToList();

            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, ex.Source, MessageBoxButton.OK, MessageBoxImage.Error);
                    
            }
        }

        void Sort(int id = -1)
        {

            var data = ConnectClass.db.Supply.ToList();

            if (id != -1)
            {
                data = data.Where(x => x.ID == id).ToList();
            }

            dataView.ItemsSource = data;

        }
    }
}
