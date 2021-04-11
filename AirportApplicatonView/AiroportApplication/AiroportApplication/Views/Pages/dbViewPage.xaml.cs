using AiroportApplication.Classes;
using AiroportApplication.Models;
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

namespace AiroportApplication.Views.Pages
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

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {

            NavigationService.GoBack();

        }

        private void listViewData_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            var selectedItemList = (Airplane)listViewData.SelectedItem;

            if (selectedItemList != null)
                NavigationService.Navigate(new EditPage(selectedItemList));

            else
                MessageBox.Show("Выберите элемент!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {

            if (MessageBox.Show("Вы уверены, что хотите закрыть программу?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

            NavigationService.Navigate(new AddPage());

        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                Airplane removeAirplane = (Airplane)listViewData.SelectedItem;
                if (removeAirplane != null)
                {

                    if (MessageBox.Show("Вы уверены, что хотите удалить данный элемент?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        ConnectClass.db.Airplane.Remove(removeAirplane);
                        ConnectClass.db.SaveChanges();
                        Page_Loaded(null, null);
                    }

                    else
                    {
                        MessageBox.Show("Вы не выбрали ни одного элемента!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            listViewData.ItemsSource = ConnectClass.db.Airplane.ToList();

            //cmbSort1.Items.Add("255");
            //cmbSort1.Items.Add("232");
            //cmbSort1.Items.Add("121");

            cmbSort1.ItemsSource = ConnectClass.db.Airplane.ToList();
            cmbSort1.DisplayMemberPath = "NumberOfSeats";

        }


        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            listViewData.ItemsSource = ConnectClass.db.Airplane.Where(item => item.NumberAirplane.Contains(txtSearch.Text)).ToList();
        }

        private void cmbSort1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {

                var Current = cmbSort1.SelectedItem as Airplane;

                Sort(Current.ID);

            }

            catch (Exception)
            {

            }

        }

        void Sort(int id = -1)
        {

            var data = ConnectClass.db.Airplane.ToList();

            if (id != -1)
            {
                data = data.Where(x => x.ID == id).ToList();
            }

            listViewData.ItemsSource = data;

        }

    }
}
