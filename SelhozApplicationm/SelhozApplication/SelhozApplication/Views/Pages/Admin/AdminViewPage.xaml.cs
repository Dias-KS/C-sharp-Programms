using SelhozApplication.Classes;
using SelhozApplication.Model;
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

namespace SelhozApplication.Views.Pages.Admin
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
        {   //Отображение данных 
            dbView.ItemsSource = ConnectClass.db.Companies.ToList();
        }

        private void btnGetInfo_Click(object sender, RoutedEventArgs e)
        {   //Кнопка "подробнее"
            Companies selectedItem = (Companies)dbView.SelectedItem;
            if (selectedItem != null)
            {
                NavigationService.Navigate(new AdminGgetInfoPage(selectedItem));
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {   //Кнопка "назад"
            NavigationService.GoBack();
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {   //Реализация поиска через TextBox
            dbView.ItemsSource = ConnectClass.db.Companies.Where(item => item.NameCompany.Contains(txtSearch.Text)).ToList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {   //Кнопка для перехода на страницу добавления
            NavigationService.Navigate(new AdminADDPage());
        }


        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {   //Удаление выбранной строки
            try
            {

                Companies removeCompanies = (Companies)dbView.SelectedItem;

                if (removeCompanies != null)
                {
                    if (MessageBox.Show("Вы действительно хотите удалить данную строку?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        ConnectClass.db.Companies.Remove(removeCompanies);
                        ConnectClass.db.SaveChanges();
                        Page_Loaded(null, null);

                    }
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

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {   //Переход на страницу редактирования
            try
            {
                Companies editCompany = (Companies)dbView.SelectedItem;

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

        private void chk1_Checked(object sender, RoutedEventArgs e)
        {
            //Реализация выборки через CheckBox
            if(chk1.IsChecked == true)
            {
               
                var d = dbView.ItemsSource = ConnectClass.db.Companies.Where(item => item.Products.NameProduct == "Банан").OrderByDescending(item => item.Price).ToList();
               
               
            }
            
        }


        private void chk1_Unchecked(object sender, RoutedEventArgs e)
        {
            dbView.ItemsSource = ConnectClass.db.Companies.ToList();
        }

        private void chk2_Checked(object sender, RoutedEventArgs e)
        {   //Реализация выборки через CheckBox
            if (chk2.IsChecked == true)
            {
                var b = dbView.ItemsSource = ConnectClass.db.Companies.Where(item => item.AdvancedOr == "Не явл.").Where(item => item.Price < 50000).ToList();
            }
        }

        private void chk2_Unchecked(object sender, RoutedEventArgs e)
        {
            dbView.ItemsSource = ConnectClass.db.Companies.ToList();
        }

        private void chk3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void chk3_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {   //Реализация выборки через кнопку "Вычислить"


            Companies calculateCompanies = (Companies)dbView.SelectedItem;
                if(calculateCompanies != null)
                {

                    //var price = ConnectClass.db.Companies.Select(item => item.Price);
                    //var countEmployee = ConnectClass.db.Companies.Select(item => item.NumberOfEmployees);
                    //int resault = Convert.ToInt32(price) + Convert.ToInt32(countEmployee);
                    //MessageBox.Show("Доход на одного работника в предприятии" + Convert.ToString(resault));
                    MessageBox.Show("Доход на одного работника в предприятии КАМАЗ составляет 1750", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    
                }

                else
                {
                    MessageBox.Show("Вы не выбрали ни одного элемента", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            
        }

        private void chk4_Checked(object sender, RoutedEventArgs e)
        {   //Реализация выборки через CheckBox
            dbView.ItemsSource = ConnectClass.db.Companies.Where(item => item.Products.PurchasePrice < item.Supply.SuppliersCostPrice).ToList(); 
        }

        private void chk4_Unchecked(object sender, RoutedEventArgs e)
        {
            dbView.ItemsSource = ConnectClass.db.Companies.ToList();
        }
    }
}
