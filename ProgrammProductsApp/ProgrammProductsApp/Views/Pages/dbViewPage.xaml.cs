using ProgrammProductsApp.Classes;
using ProgrammProductsApp.Models;
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

namespace ProgrammProductsApp.Views.Pages
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
            dbView.ItemsSource = dbConnectClass.db.Product.ToList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new dbAddPage());    
        }

        private void btnGetInfo_Click(object sender, RoutedEventArgs e)
        {
            
           
            Product selectedItem = (Product)dbView.SelectedItem;
            if(selectedItem != null)
            {
                NavigationService.Navigate(new dbGetInfoPage(selectedItem));
            }

            else
            {
                MessageBox.Show("Вы не выбрали ни одного элемента!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            dbView.ItemsSource = dbConnectClass.db.Product.Where(item => item.NameProduct.Contains(txtSearch.Text)).ToList();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Product editProduct = (Product)dbView.SelectedItem;
            if (editProduct != null)
            {
                NavigationService.Navigate(new dbEditPage(editProduct));
            }

            else
            {
                MessageBox.Show("Вы не выбрали ни одного элемента!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var removeProduct = (Product)dbView.SelectedItem;
            if (removeProduct != null)
            {
                if(MessageBox.Show("Вы уверены, что хотите удалить выбранный элемент?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question)==MessageBoxResult.Yes)
                {
                    dbConnectClass.db.Product.Remove(removeProduct);
                    dbConnectClass.db.SaveChanges();
                    Page_Loaded(null, null);
               
                
                }
            }

            else
            {
                MessageBox.Show("Вы не выбрали ни одного элемента!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

          
          //  MessageBox.Show("Прикладная область с наибольшим количеством номенклатуры: \n\n"  + "\n\nКоличество номенклатуры: " + a.ToString(), "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);


        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            dbView.ItemsSource = dbConnectClass.db.Product.ToList();
        }

       

        private void chk2_Checked(object sender, RoutedEventArgs e)
        {
            
        }

        private void chk2_Unchecked(object sender, RoutedEventArgs e)
        {
            dbView.ItemsSource = dbConnectClass.db.Product.ToList();
        }

        private void chk3_Checked(object sender, RoutedEventArgs e)
        {
            var d = dbView.ItemsSource = dbConnectClass.db.Product.Where(item => item.TypeProduct.Title == "ОС").OrderByDescending(item => item.QuantityDownoload).ToList();
        }

        private void chk3_Unchecked(object sender, RoutedEventArgs e)
        {
            dbView.ItemsSource = dbConnectClass.db.Product.ToList();
        }
    }
}
