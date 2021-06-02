using GuardApp.Classes;
using GuardApp.Model;
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

namespace GuardApp.Views.Pages.Admin
{
    /// <summary>
    /// Логика взаимодействия для EditAdminPage.xaml
    /// </summary>
    public partial class EditAdminPage : Page
    {


        public EditAdminPage()
        {
            InitializeComponent();
        }

        private GuardInfoPesonal selectedItem;

       

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены что хотите закрыть программу?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        public EditAdminPage(GuardInfoPesonal selectedItem)
        {
            InitializeComponent();
            this.selectedItem = selectedItem;

            txbAdress.Text = selectedItem.Object.Adress;
            txbDivision.Text = selectedItem.Podrazdelenie.NameDivision;
            txbFirstName.Text = selectedItem.FirstName;
            txbLastName.Text = selectedItem.SurName;
            txbLicenseTypes.Text = Convert.ToString(selectedItem.License.LicenseType);
            txbModel.Text = selectedItem.GuardInfoGun.Model;
            txbObjectName.Text = selectedItem.Object.ObjectName;
            txbPhoneNumbers.Text = selectedItem.PhoneNumber;
            txbRegAdres.Text = selectedItem.RegAdress;
            txbShiftNumber.Text = Convert.ToString(selectedItem.Schedule.ShiftNumber);
            txbTypeGun.Text = selectedItem.GuardInfoGun.TypeGun;
            dtDateEnd.SelectedDate = selectedItem.Object.EndDate;
            dtDateShift.SelectedDate = selectedItem.Schedule.Date;
            dtDateStart.SelectedDate = selectedItem.Object.Date;
            txbLicenseBriefInfo.Text = selectedItem.License.LicenseBriefInfo;
            

        }

        

        private void btnCleane_Click(object sender, RoutedEventArgs e)
        {
            txbAdress.Text = "";
            txbDivision.Text = "";
            txbFirstName.Text = "";
            txbLastName.Text = "";
            txbLicenseTypes.Text = "";
            txbObjectName.Text = "";
            txbPhoneNumbers.Text = "";
            txbRegAdres.Text = "";
            txbShiftNumber.Text = "";
            txbTypeGun.Text = "";
            txbModel.Text = "";

            dtDateStart.SelectedDate = null;
            dtDateEnd.SelectedDate = null;
            dtDateShift.SelectedDate = null;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {



            try
            {

                var editInfo = ConnectClass.db.GuardInfoPesonal.FirstOrDefault(item => item.IDGuard == selectedItem.IDGuard);

                editInfo.FirstName = txbFirstName.Text;
                editInfo.SurName = txbLastName.Text;
                editInfo.PhoneNumber = txbPhoneNumbers.Text;
                editInfo.RegAdress = txbRegAdres.Text;
                editInfo.GuardInfoGun.TypeGun = txbTypeGun.Text;
                editInfo.GuardInfoGun.Model = txbModel.Text;
                editInfo.Schedule.Date = dtDateShift.SelectedDate;
                editInfo.Schedule.ShiftNumber = Convert.ToInt32(txbShiftNumber.Text);
                editInfo.Podrazdelenie.NameDivision = txbDivision.Text;
                editInfo.License.LicenseType = Convert.ToInt32(txbLicenseTypes.Text);
                editInfo.Object.ObjectName = txbObjectName.Text;
                editInfo.Object.Date = dtDateStart.SelectedDate;
                editInfo.Object.EndDate = dtDateEnd.SelectedDate;
                editInfo.Object.Adress = txbAdress.Text;
                editInfo.License.LicenseBriefInfo = txbLicenseBriefInfo.Text;

                ConnectClass.db.SaveChanges();
                MessageBox.Show("Вы успешно изменили данные!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
