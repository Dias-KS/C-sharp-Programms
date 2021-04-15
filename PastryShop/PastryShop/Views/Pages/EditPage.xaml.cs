using Microsoft.Win32;
using PastryShop.Classes;
using PastryShop.Models;
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

namespace PastryShop.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для EditPage.xaml
    /// </summary>
    public partial class EditPage : Page
    {

        private Computer selectedItem;

        public EditPage()
        {
            InitializeComponent();
            Loaded += EditPage_Loaded;
        }

        private void EditPage_Loaded(object sender, RoutedEventArgs e)
        {
           
        }

        public EditPage(Computer selectedItem)
        {
            InitializeComponent();
            this.selectedItem = selectedItem;

            txbCPU.Text = selectedItem.CPU;
            txbGPU.Text = selectedItem.GPU;
            txbHDD.Text = selectedItem.HDD;
            txbHeadphones.Text = selectedItem.Headphones;
            txbKeyboard.Text = selectedItem.Keyboard;
            txbMotherBoard.Text = selectedItem.MotherBoard;
            txbMouse.Text = selectedItem.Mouse;
            txbRAM.Text = selectedItem.RAM;

            PictureBox.Source = new BitmapImage(new Uri(selectedItem.Image));

        }


        OpenFileDialog newOpenFile = new OpenFileDialog();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            newOpenFile.Filter = "Image(*.jpg; *.png; *.jpeg | *.jpg; *.png; *.jpeg)";

            if (newOpenFile.ShowDialog() == true)
            {
                PictureBox.Source = new BitmapImage(new Uri(newOpenFile.FileName));
            }
        }

        private void btnClean_Click(object sender, RoutedEventArgs e)
        {
            txbCPU.Text = "";
            txbGPU.Text = "";
            txbHDD.Text = "";
            txbHeadphones.Text = "";
            txbKeyboard.Text = "";
            txbMotherBoard.Text = "";
            txbMouse.Text = "";
            txbRAM.Text = "";
            
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var editComputer = ConnectClass.db.Computer.FirstOrDefault(item => item.ID == selectedItem.ID);

            editComputer.CPU = txbCPU.Text;
            editComputer.GPU = txbGPU.Text;
            editComputer.HDD = txbHDD.Text;
            editComputer.Headphones = txbHeadphones.Text;
            editComputer.Keyboard = txbKeyboard.Text;
            editComputer.MotherBoard = txbMotherBoard.Text;
            editComputer.Mouse = txbMouse.Text;
            editComputer.RAM = txbRAM.Text;

            editComputer.Image = newOpenFile.FileName;

            ConnectClass.db.SaveChanges();
            MessageBox.Show("Данные успешно изменены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
