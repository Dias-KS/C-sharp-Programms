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
using WPFdbProject.Classes;

namespace WPFdbProject.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для dbPage.xaml
    /// </summary>
    public partial class dbPage : Page
    {
        public dbPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DataGridRegistration.ItemsSource = connectClass.db.CourseRegistration.ToList();
        }
    }
}
