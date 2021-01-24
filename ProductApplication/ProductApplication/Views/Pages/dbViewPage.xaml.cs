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
    /// Логика взаимодействия для dbViewPage.xaml
    /// </summary>
    public partial class dbViewPage : Page
    {
        public dbViewPage()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new dbAddPage());
        }


        //Кнопкка "Дополнительно"
        private void btnGetInfo_Click(object sender, RoutedEventArgs e)
        {
            Product selectedItem = (Product)dbView.SelectedItem;
            if (selectedItem != null)
            {
                NavigationService.Navigate(new dbGetInfoPage(selectedItem));
            }

            else
            {
                MessageBox.Show("Вы не выбрали ни одного элемента!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        //Кнопка удаления
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var deleteItem = (Product)dbView.SelectedItem;
            if (deleteItem != null)
            {
                if (MessageBox.Show("Вы уверены, что хотите удалить выбранный элемент?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {

                    ConnectClass.db.Product.Remove(deleteItem);
                    ConnectClass.db.SaveChanges();
                    Page_Loaded(null, null);

                }
            }

            else
            {
                MessageBox.Show("Вы не выбрали ни одного элемента!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //Редактирование выбранного элемента
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Product editItem = (Product)dbView.SelectedItem;
            if (editItem != null)
            {
                NavigationService.Navigate(new dbEditPage(editItem));
            }
        }

        //Отображение в гриде
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            dbView.ItemsSource = ConnectClass.db.Product.ToList();
        }


        private void btnClean_Click(object sender, RoutedEventArgs e)
        {
            txtSearch.Text = "";
        }


        //Поиск  
        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            dbView.ItemsSource = ConnectClass.db.Product.Where(item => item.NameProduct.Contains(txtSearch.Text) || item.Company.NameCompany.Contains(txtSearch.Text)).ToList();
        }


        //Выборка 1
        private void chk1_Checked(object sender, RoutedEventArgs e)
        {

            var currentMaxQuantity = ConnectClass.db.Product.Where(item => item.Material.TypeMaterial == "Цветной металл").Max(item => item.Specification.QuantityMaterial);

            dbView.ItemsSource = ConnectClass.db.Product.Where(item => item.Specification.QuantityMaterial == currentMaxQuantity).ToList();

        }

        private void chk1_Unchecked(object sender, RoutedEventArgs e)
        {
            dbView.ItemsSource = ConnectClass.db.Product.ToList();
        }

       //Выборка 2
        private void chk2_Checked(object sender, RoutedEventArgs e)
        {

            DateTime date = new DateTime(2000, 10, 12);
            DateTime date2 = new DateTime(2000, 01, 01);


            dbView.ItemsSource = ConnectClass.db.Product.Where(item => item.Company.YearRelease != date && item.Company.YearRelease != date2).ToList();

        }

      
        private void chk2_Unchecked(object sender, RoutedEventArgs e)
        {
            dbView.ItemsSource = ConnectClass.db.Product.ToList();
        }
    }
}
