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
    /// Логика взаимодействия для AdminViewPage.xaml
    /// </summary>
    public partial class AdminViewPage : Page
    {
        public AdminViewPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            dataView.ItemsSource = connectClass.db.Companies.ToList();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminAddPage());
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                
                Company editCompany = (Company)dataView.SelectedItem;
                if (editCompany!= null)
                {
                    NavigationService.Navigate(new AdminEditPage(editCompany));
                }

                else
                {
                    throw new Exception("Вы не выбрали ни одного элемента!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Company removeCompany = (Company)dataView.SelectedItem;

                if(MessageBox.Show("Вы действительно хотите удалить выбранный элемент?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes) { 
                    if(removeCompany != null)
                    {
                       
                        connectClass.db.Companies.Remove(removeCompany);
                        connectClass.db.SaveChanges();
                        Page_Loaded(null, null);
                    
                    }

                    else
                    {
                       throw new Exception("Вы не выбрали элемент!");
                        
                    }

                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void txbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            dataView.ItemsSource = connectClass.db.Companies.Where(item => item.NameCompany.Contains(txbSearch.Text)).ToList();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Вы уверены что хотите закрыть программу?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {

                Application.Current.Shutdown();

            }
        }

        private void btnGetInfo_Click(object sender, RoutedEventArgs e)
        {
            Company selectedItem = (Company)dataView.SelectedItem;
            if(selectedItem != null)
            {

                NavigationService.Navigate(new AdminGetInfoPage());

            }
        }
    }
}
