using AiroportApplication.Classes;
using AiroportApplication.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для AddPage.xaml
    /// </summary>
    public partial class AddPage : Page
    {
        public AddPage()
        {
            InitializeComponent();
            cmbTypeAirplane.ItemsSource = ConnectClass.db.TypeAirplane.Select(item => item.Title).ToList();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
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

        private void cmbTypeAirplane_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

            try
            {

                Airplane newAirplane = new Airplane();
                Route newRoute = new Route();
                RouteInfo newRouteInfo = new RouteInfo();

                newAirplane.NumberAirplane = txtNumberAirplane.Text;
                newAirplane.NumberOfSeats = Convert.ToInt32(txtNumberOfSeats.Text);
                newAirplane.SpeedOfFlight = txtSpeedOfFlight.Text;

                newRoute.NumberRoute = txtNumberRoute.Text;
                newRoute.Distance = txtDistance.Text;
                newRoute.PointOfDeparture = txtPointOfDeparture.Text;
                newRoute.PointOfDestination = txtPointOfDestination.Text;

                newRouteInfo.DateTimeDeparture = Convert.ToDateTime(dtDateTimeDeparture.SelectedDate);
                newRouteInfo.DateTimeArrival = Convert.ToDateTime(dtDateTimeArrival.SelectedDate);
                newRouteInfo.CountSaleTicket = Convert.ToInt32(txtCountSaleTicket.Text);

                var currentTypeAirplane = ConnectClass.db.TypeAirplane.FirstOrDefault(item => item.Title == cmbTypeAirplane.Text);
                newAirplane.IDTypeAirplane = currentTypeAirplane.ID;

                {

                    MemoryStream stream = new MemoryStream();
                    JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create((BitmapImage)PictureBox.Source));
                    encoder.Save(stream);
                    newAirplane.Picture = stream.ToArray();

                }

                ConnectClass.db.Airplane.Add(newAirplane);
                ConnectClass.db.Route.Add(newRoute);
                ConnectClass.db.RouteInfo.Add(newRouteInfo);
                ConnectClass.db.SaveChanges();
                MessageBox.Show("Данные успешно сохранены!", "Уведомление!", MessageBoxButton.OK, MessageBoxImage.Information);

            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
            }
 
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Image (*.jpg; *.png; *.jpeg;) | *.jpg; *.png; *.jpeg;";
            if (file.ShowDialog() == true)
            {
                BitmapImage bitmap = new BitmapImage(new Uri(file.FileName));
                PictureBox.Source = bitmap;
            }
        }
    }
}
