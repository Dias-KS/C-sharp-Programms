using Geograf.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Geograf.Classes
{
    public static class LoadDataFromDB
    {
        public static void LoadLanguageInCombo(ComboBox comboBox)
        {
            var query = dbContext.db.Languages.Select(item => new 
            {
                title = item.Title
            });
            var collectionSelectedItem = from selectedItem in query select selectedItem.title;
            comboBox.ItemsSource = collectionSelectedItem.ToList();
        }
        public static void LoadNationalityInCombo(ComboBox comboBox)
        {
            var query = dbContext.db.Natinolities.Select(item => new
            {
                title = item.Ttile
            });
            var collectionSelectedItem = from selectedItem in query select selectedItem.title;
            comboBox.ItemsSource = collectionSelectedItem.ToList();
        }
        public static void LoadPopulationInCombo(ComboBox comboBox)
        {
            var query = dbContext.db.Populations.Select(item => new
            {
                title = item.Count
            });
            var collectionSelectedItem = from selectedItem in query select selectedItem.title;
            comboBox.ItemsSource = collectionSelectedItem.ToList();
        }
    }
}
