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
    /// Логика взаимодействия для ADDPage.xaml
    /// </summary>
    public partial class ADDPage : Page
    {
        public ADDPage()
        {
            InitializeComponent();
        }

            OpenFileDialog file = new OpenFileDialog();
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            file.Filter = "Image (*.jpg; *.png; *jpeg;) | *.jpg; *.png; *.jpeg;";
            if (file.ShowDialog() == true)
            {
                PictureBox.Source = new BitmapImage(new Uri(file.FileName));
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
            try
            {

                Computer newComputer = new Computer();

                newComputer.CPU = txbCPU.Text;
                newComputer.GPU = txbGPU.Text;
                newComputer.RAM = txbRAM.Text;
                newComputer.MotherBoard = txbMotherBoard.Text;
                newComputer.HDD = txbHDD.Text;
                newComputer.Keyboard = txbKeyboard.Text;
                newComputer.Mouse = txbMouse.Text;
                newComputer.Headphones = txbHeadphones.Text;

                {
                    //MemoryStream stream = new MemoryStream();
                    //JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                    //encoder.Frames.Add(BitmapFrame.Create((BitmapImage)PictureBox.Source));
                    //encoder.Save(stream);
                    //newComputer.Image = stream.ToArray();   
                }

                newComputer.Image = file.FileName;

                ConnectClass.db.Computer.Add(newComputer);
                ConnectClass.db.SaveChanges();
                MessageBox.Show("Данные успешно сохранены!", "Уведомление!", MessageBoxButton.OK, MessageBoxImage.Information);

            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
