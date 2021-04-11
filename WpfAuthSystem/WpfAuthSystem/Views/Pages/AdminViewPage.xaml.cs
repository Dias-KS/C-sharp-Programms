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
using WpfAuthSystem.Context;
using WpfAuthSystem.Models;

namespace WpfAuthSystem.Views.Pages
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

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void btnADD_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminADDPage());
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               ConnectCompany editCompany = (ConnectCompany)dataView.SelectedItem;
                if (editCompany != null)
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

        private void btnBack_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            dataView.ItemsSource = dbContext.db.ConnectCompanies.ToList();
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                    

                ConnectCompany removeCompany = (ConnectCompany)dataView.SelectedItem;
                if (MessageBox.Show("Вы действительно хотите удалить выбранный элемент?", "Действие", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (removeCompany != null)
                    {
                        dbContext.db.ConnectCompanies.Remove(removeCompany);
                        dbContext.db.SaveChanges();
                        Page_Loaded(null, null);


                    }

                    else
                    {
                        MessageBox.Show("Вы ничего не выбрали!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            dataView.ItemsSource = dbContext.db.ConnectCompanies.Where(item => item.Company.NameCompany.Contains(txtSearch.Text)).ToList();
        }
    }
}


