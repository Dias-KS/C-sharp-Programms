using Geograf.Classes;
using Geograf.Context;
using Geograf.Model;
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

namespace Geograf.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddDataPage.xaml
    /// </summary>
    public partial class AddDataPage : Page
    {
        public AddDataPage()
        {
            InitializeComponent();
            LoadDataFromDB.LoadLanguageInCombo(cmbLanguage);
            LoadDataFromDB.LoadNationalityInCombo(cmbNationality);
            LoadDataFromDB.LoadPopulationInCombo(cmbPopulation);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Country country = new Country();
                Ethnic ethnic = new Ethnic();
                country.Title = txbName.Text;
                country.Region = txbRegion.Text;
                country.Capital = txbCaptail.Text;
                country.Economy = cmbEcomomic.Text;
                country.Square = txbSquare.Text;
                var currentPopulation = dbContext.db.Populations.FirstOrDefault(item => item.Count.ToString() == cmbPopulation.Text);
                country.IDPopulation = currentPopulation.ID;
                var currentNationality = dbContext.db.Natinolities.FirstOrDefault(item => item.Ttile == cmbNationality.Text);
                ethnic.IDNationality = currentNationality.ID;
                var currentLanguage = dbContext.db.Languages.FirstOrDefault(item => item.Title == cmbLanguage.Text);
                ethnic.IDLanguage = currentLanguage.ID;
                country.IDEthnic = ethnic.ID;
                ethnic.TotalNumber = int.Parse(txbCount.Text);
                dbContext.db.Ethnics.Add(ethnic);
                dbContext.db.Countries.Add(country);
                dbContext.db.SaveChanges();
                MessageBox.Show("Добавлено!");
                NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
