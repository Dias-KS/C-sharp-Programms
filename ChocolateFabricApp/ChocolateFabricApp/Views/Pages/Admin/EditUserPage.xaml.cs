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
    /// Логика взаимодействия для EditUserPage.xaml
    /// </summary>
    public partial class EditUserPage : Page
    {
        public EditUserPage()
        {
            InitializeComponent();
        }

        private SignIn selectedItem;

        public EditUserPage(SignIn selectedItem)
        {
            InitializeComponent();

            this.selectedItem = selectedItem;

            txbFirstName.Text = selectedItem.FirstName;
            txbLastName.Text = selectedItem.LastName;
            pswPassword.Password = selectedItem.Password;
            cmbRole.SelectedItem = selectedItem.Role.IDRole;
        }
             


        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

            try
            {

                var editSignIn = ConnectClass.db.SignIn.FirstOrDefault(item => item.ID == selectedItem.ID);

                editSignIn.FirstName = txbFirstName.Text;
                editSignIn.LastName = txbLastName.Text;
                editSignIn.Password = pswPassword.Password;
                editSignIn.RoleID = cmbRole.Text;

                ConnectClass.db.SaveChanges();
                MessageBox.Show("Данные успешно изменены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void btnClean_Click(object sender, RoutedEventArgs e)
        {
            txbFirstName.Text = "";
            txbLastName.Text = "";
            pswPassword.Password = "";
            cmbRole.Text = null;
        }

        private void cmbRole_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (txbFirstName.Text != "" & txbLastName.Text != "" & pswPassword.Password != "" & cmbRole.SelectedItem != null)
            {
                btnEdit.IsEnabled = true;
            }

            else
            {
                btnEdit.IsEnabled = false;
            }
        }

        private void pswPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (txbFirstName.Text != "" & txbLastName.Text != "" & pswPassword.Password != "" & cmbRole.SelectedItem != null)
            {
                btnEdit.IsEnabled = true;
            }

            else
            {
                btnEdit.IsEnabled = false;
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите закрыть программу?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            cmbRole.ItemsSource = ConnectClass.db.Role.Select(item => item.IDRole).ToList();
        }
    }
}
