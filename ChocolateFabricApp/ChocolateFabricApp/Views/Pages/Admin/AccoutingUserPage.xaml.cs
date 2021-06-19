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
    /// Логика взаимодействия для AccoutingUserPage.xaml
    /// </summary>
    public partial class AccoutingUserPage : Page
    {
        public AccoutingUserPage()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Вы уверены, что хотите закрыть программу?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            dataView.ItemsSource = ConnectClass.db.SignIn.ToList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddUserPage());
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            SignIn deleteSignIn = (SignIn)dataView.SelectedItem;
            if (deleteSignIn != null)
            {
                if (MessageBox.Show("Вы уверены, что хотите удалить данного пользователя?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {

                    ConnectClass.db.SignIn.Remove(deleteSignIn);
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

        private void txbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            dataView.ItemsSource = ConnectClass.db.SignIn.Where(item => item.FirstName.Contains(txbSearch.Text) || item.LastName.Contains(txbSearch.Text) || item.Role.Title.Contains(txbSearch.Text)).ToList();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            SignIn editSignIn = (SignIn)dataView.SelectedItem;
            if(editSignIn != null)
            {
                NavigationService.Navigate(new EditUserPage(editSignIn));
            }

            else
            {
                MessageBox.Show("Вы не выбрали ни одного элемента!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
