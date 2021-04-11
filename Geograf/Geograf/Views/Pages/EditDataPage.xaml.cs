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
    /// Логика взаимодействия для EditDataPage.xaml
    /// </summary>
    public partial class EditDataPage : Page
    {
        private Country selectedItem;
        public EditDataPage()
        {
            InitializeComponent();

        }

        public EditDataPage(Country selectedItem)
        {
            InitializeComponent();
            this.selectedItem = selectedItem;
            txbName.Text = selectedItem.Title;
            txbRegion.Text = selectedItem.Region;
            txbCaptail.Text = selectedItem.Capital;
            txbSquare.Text = selectedItem.Square;
            cmbEcomomic.Text = selectedItem.Economy;
            txbCount.Text = selectedItem.Ethnic.TotalNumber.ToString();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Country country = dbContext.db.Countries.FirstOrDefault(item => item.ID == selectedItem.ID);
                Ethnic ethnic = dbContext.db.Ethnics.FirstOrDefault(item => item.ID == selectedItem.IDEthnic);
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
                dbContext.db.SaveChanges();
                MessageBox.Show("Сохранено!");
                NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDataFromDB.LoadLanguageInCombo(cmbLanguage);
            LoadDataFromDB.LoadNationalityInCombo(cmbNationality);
            LoadDataFromDB.LoadPopulationInCombo(cmbPopulation);
        }
    }
}
