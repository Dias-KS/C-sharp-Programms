using AiroportApplication.Classes;
using AiroportApplication.Models;
using Microsoft.Win32;
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
    /// Логика взаимодействия для EditPage.xaml
    /// </summary>
    public partial class EditPage : Page
    {

        private Airplane selectedItem;


        public EditPage()
        {

            InitializeComponent();
            
        }

        public EditPage(Airplane selectedItem)
        {

            InitializeComponent();
            this.selectedItem = selectedItem;

            txtCountSaleTicket.Text = Convert.ToString(selectedItem.Route.RouteInfo.CountSaleTicket);
            txtDistance.Text = selectedItem.Route.Distance;
            txtNumberAirplane.Text = selectedItem.NumberAirplane;
            txtNumberOfSeats.Text = Convert.ToString(selectedItem.NumberOfSeats);
            txtNumberRoute.Text = selectedItem.Route.NumberRoute;
            txtPointOfDeparture.Text = selectedItem.Route.PointOfDeparture;
            txtPointOfDestination.Text = selectedItem.Route.PointOfDestination;
            txtSpeedOfFlight.Text = selectedItem.SpeedOfFlight;
            dtDateTimeArrival.SelectedDate = selectedItem.Route.RouteInfo.DateTimeArrival;
            dtDateTimeDeparture.SelectedDate = selectedItem.Route.RouteInfo.DateTimeDeparture;

            cmbTypeAirplane.SelectedItem = selectedItem.TypeAirplane.Title;

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {

            txtCountSaleTicket.Text = "";
            dtDateTimeArrival.Text = null;
            dtDateTimeDeparture.Text = null;
            txtDistance.Text = "";
            txtNumberAirplane.Text = "";
            txtNumberOfSeats.Text = "";
            txtNumberRoute.Text = "";
            txtPointOfDeparture.Text = "";
            txtSpeedOfFlight.Text = "";
            txtPointOfDestination.Text = "";
            cmbTypeAirplane.SelectedItem = null;

        }

        private void btnBack_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Image (*.png; *.jpg; *.jpeg;) | *.png; *.jpg; *.jpeg";

            if(file.ShowDialog() == true)
            {
                BitmapImage bitmap = new BitmapImage(new Uri(file.FileName));
                PictureBox.Source = bitmap;
            }

        }

        private void cmbTypeAirplane_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            cmbTypeAirplane.ItemsSource = ConnectClass.db.TypeAirplane.Select(item => item.Title).ToList();
        }
    }
}
