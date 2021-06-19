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
    /// Логика взаимодействия для AccoutingProductionPageA.xaml
    /// </summary>
    public partial class AccoutingProductionPageA : Page
    {
        public AccoutingProductionPageA()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void txbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            dataView.ItemsSource = ConnectClass.db.FinishedProducts.Where(item => item.Name.Contains(txbSearch.Text)).ToList();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите закрыть программу?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddProductionPageAxaml());
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            FinishedProducts editProduction = (FinishedProducts)dataView.SelectedItem;
            if (editProduction != null)
            {
                NavigationService.Navigate(new EditProductionPageA(editProduction));
            }

            else
            {
                MessageBox.Show("Вы не выбрали ни одного элемента!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            FinishedProducts deleteProduction = (FinishedProducts)dataView.SelectedItem;
            if (deleteProduction != null)
            {
                if (MessageBox.Show("Вы уверены, что хотите удалить данную продукцию?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {

                    ConnectClass.db.FinishedProducts.Remove(deleteProduction);
                    ConnectClass.db.SaveChanges();
                    Page_Loaded(null, null);
                    MessageBox.Show("Вы успешно удалили продукцию!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

                }

            }

            else
            {
                MessageBox.Show("Вы не выбрали ни одного элемента!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            dataView.ItemsSource = ConnectClass.db.FinishedProducts.ToList();
            cmbDepartment.ItemsSource = ConnectClass.db.DepartmentProd.Select(item => item.Title).ToList();
        }

        private void cmbDepartment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {

                Page_Loaded(null, null);
                dataView.ItemsSource = ConnectClass.db.FinishedProducts.Where(item => item.DepartmentProd.Title.Contains(cmbDepartment.Text)).ToList();

            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, ex.Source, MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
    }

}
