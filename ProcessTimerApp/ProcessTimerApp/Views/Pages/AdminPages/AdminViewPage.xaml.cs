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

namespace ProcessTimerApp.Views.Pages.AdminPages
{
    /// <summary>
    /// Логика взаимодействия для AdminViewPage.xaml
    /// </summary>
    public partial class AdminViewPage : Page
    {
        public AdminViewPage()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены что хотите закрыть программу?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {

                Application.Current.Shutdown();
            
            }

        }
    }
}
