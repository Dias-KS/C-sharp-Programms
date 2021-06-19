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
    /// Логика взаимодействия для AddUserPage.xaml
    /// </summary>
    public partial class AddUserPage : Page
    {
        public AddUserPage()
        {
            InitializeComponent();
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

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (ConnectClass.db.SignIn.Count(x => x.FirstName == txbFirstName.Text && x.LastName == txbLastName.Text) > 0)
            {
                MessageBox.Show("Пользователь с такими данными уже есть!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            else
            {
                try
                {
                    if (cmbRole.Text == "A")
                    {

                        SignIn newAdmin = new SignIn()
                        {
                            FirstName = txbFirstName.Text,
                            LastName = txbLastName.Text,
                            Password = pswPassword.Password,
                            RoleID = "A"
                        };

                        ConnectClass.db.SignIn.Add(newAdmin);
                        ConnectClass.db.SaveChanges();

                        MessageBox.Show("Пользователь успешно добавлен!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

                    }

                    if (cmbRole.Text == "U")
                    {
                        SignIn newUser = new SignIn()
                        {

                            FirstName = txbFirstName.Text,
                            LastName = txbLastName.Text,
                            Password = pswPassword.Password,
                            RoleID = "U"

                        };

                        ConnectClass.db.SignIn.Add(newUser);
                        ConnectClass.db.SaveChanges();

                        MessageBox.Show("Пользователь успешно добавлен!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.Source, MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }

        }


        private void btnClean_Click(object sender, RoutedEventArgs e)
        {
            txbFirstName.Text = "";
            txbLastName.Text = "";
            pswPassword.Password = "";
            cmbRole.Text = null;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            cmbRole.ItemsSource = ConnectClass.db.Role.Select(item => item.IDRole).ToList();
        }

        private void pswPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (txbFirstName.Text != "" & txbLastName.Text != "" & pswPassword.Password != "" & cmbRole.SelectedItem != null)
            {
                btnAdd.IsEnabled = true;
            }

            else
            {
                btnAdd.IsEnabled = false;
            }
        }


        private void cmbRole_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (txbFirstName.Text != "" & txbLastName.Text != "" & pswPassword.Password != "" & cmbRole.SelectedItem != null)
            {
                btnAdd.IsEnabled = true;
            }

            else
            {
                btnAdd.IsEnabled = false;
            }
        }
    }
}
