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
using Object = GuardApp.Model.Object;

namespace GuardApp.Views.Pages.Admin
{
    /// <summary>
    /// Логика взаимодействия для AddAdminPage.xaml
    /// </summary>
    public partial class AddAdminPage : Page
    {
        public AddAdminPage()
        {
            InitializeComponent();
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
            txbLicenseBriefInfo.Text = "";

            dtDateStart.SelectedDate = null;
            dtDateEnd.SelectedDate = null;
            dtDateShift.SelectedDate = null;

        }

        private void btnADD_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                GuardInfoPesonal newGuard = new GuardInfoPesonal();
                GuardInfoGun newGuardGun = new GuardInfoGun();
                Podrazdelenie newPodrazdelenie = new Podrazdelenie();
                Schedule newSchedule = new Schedule();
                License newLicense = new License();
                Object newObject = new Object();

                newGuard.FirstName = txbFirstName.Text;
                newGuard.SurName = txbLastName.Text;
                newGuard.RegAdress = txbRegAdres.Text;
                newGuard.PhoneNumber = txbPhoneNumbers.Text;

                newGuardGun.Model = txbModel.Text;
                newGuardGun.TypeGun = txbTypeGun.Text;

                newLicense.LicenseType = Convert.ToInt32(txbLicenseTypes.Text);
                newLicense.LicenseBriefInfo = txbLicenseBriefInfo.Text;

                newPodrazdelenie.NameDivision = txbDivision.Text;

                newSchedule.Date = dtDateShift.SelectedDate;
                newSchedule.ShiftNumber = Convert.ToInt32(txbShiftNumber.Text);

                newObject.ObjectName = txbObjectName.Text;
                newObject.Date = dtDateStart.SelectedDate;
                newObject.EndDate = dtDateEnd.SelectedDate;
                newObject.Adress = txbAdress.Text;

                newGuard.IDDivision = newPodrazdelenie.IDDivision;
                newGuard.IDGuardGun = newGuardGun.GuardGunID;
                newGuard.IDLicense = newLicense.IDLicense;
                newGuard.IDObject = newObject.ObjectID;
                newGuard.IDSchedule = newSchedule.ID;

                ConnectClass.db.GuardInfoPesonal.Add(newGuard);
                ConnectClass.db.GuardInfoGun.Add(newGuardGun);
                ConnectClass.db.License.Add(newLicense);
                ConnectClass.db.Schedule.Add(newSchedule);
                ConnectClass.db.Object.Add(newObject);
                ConnectClass.db.Podrazdelenie.Add(newPodrazdelenie);    
                ConnectClass.db.SaveChanges();

                MessageBox.Show("Вы успешно добавили данные!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);


            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Source, ex.Message, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены что хотите закрыть программу?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
