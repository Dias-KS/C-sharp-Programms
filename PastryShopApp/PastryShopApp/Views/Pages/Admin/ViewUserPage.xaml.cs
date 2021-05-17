using PastryShopApp.Classes;
using PastryShopApp.Model;
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

namespace PastryShopApp.Views.Pages.Admin
{
    /// <summary>
    /// Логика взаимодействия для ViewUserPage.xaml
    /// </summary>
    public partial class ViewUserPage : Page
    {
        public ViewUserPage()
        {
            InitializeComponent();
        }

        

        private void listViewData_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            listViewData.ItemsSource = ConnectClass.db.SignIn.ToList();
        }

        private void txbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
          listViewData.ItemsSource = ConnectClass.db.SignIn.Where(item => item.FirstName.Contains(txbSearch.Text) || item.LastName.Contains(txbSearch.Text)).ToArray();
        }
        private void btnClean_Click(object sender, RoutedEventArgs e)
        {
            txbSearch.Text = "";
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = (SignIn)listViewData.SelectedItem;

            if(selectedItem != null)
            {
                NavigationService.Navigate(new EditUserPage(selectedItem));
            }

            else
            {
                MessageBox.Show("Вы не выбрали ни одного элемента!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            SignIn removeSignIn = (SignIn)listViewData.SelectedItem;
            if(removeSignIn != null)
            {
                if(MessageBox.Show("Вы уверены, что хотите удалить данного пользователя?" ,"Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {

                    ConnectClass.db.SignIn.Remove(removeSignIn);
                    ConnectClass.db.SaveChanges();
                    Page_Loaded(null, null);
                    MessageBox.Show("Вы успешно удалили пользователя!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

                }
            }

            else
            {
                MessageBox.Show("Вы не выбрали ни одного элемента!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

//