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


            if(selectedItem.Picture != "")
            {

                PictureBox.Source = new BitmapImage(new Uri(selectedItem.Picture));

            }

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

            var editAir = ConnectClass.db.Airplane.FirstOrDefault(item => item.ID == selectedItem.ID);

            editAir.NumberAirplane = txtNumberAirplane.Text;
            editAir.SpeedOfFlight = txtSpeedOfFlight.Text;
            editAir.NumberOfSeats =  Convert.ToInt32(txtNumberOfSeats.Text);

            editAir.Route.NumberRoute = txtNumberRoute.Text;
            editAir.Route.Distance = txtDistance.Text;
            editAir.Route.PointOfDeparture = txtPointOfDeparture.Text;
            editAir.Route.PointOfDestination = txtPointOfDestination.Text;

            editAir.Route.RouteInfo.DateTimeArrival = Convert.ToDateTime(dtDateTimeArrival.SelectedDate);
            editAir.Route.RouteInfo.DateTimeDeparture = Convert.ToDateTime(dtDateTimeDeparture.SelectedDate);

            editAir.TypeAirplane.Title = cmbTypeAirplane.Text;

            editAir.Picture = file.FileName;

            ConnectClass.db.SaveChanges();
            MessageBox.Show("Вы успешно изменили данные!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

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

        OpenFileDialog file = new OpenFileDialog();

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {

            file.Filter = "Image(*.jpg; *.jpeg; *.png; | *.jpg; *.jpeg; *.png;)";

            if(file.ShowDialog() == true)
            {
                PictureBox.Source = new BitmapImage(new Uri(file.FileName));
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
