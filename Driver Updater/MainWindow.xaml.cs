using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
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


namespace Driver_Updater
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            
            InitializeComponent();
            homeWindowloader();

            

            

        }
       
       private void homeWindowloader()
        {
            Home page = new Home();
            this.switchingWindow.Content = page;
        }


        private void boostWindowClick(object sender, RoutedEventArgs e)
        {
            Page1 page = new Page1();
            this.switchingWindow.Content = page;
        }

        private void systemConfigWindow(object sender, RoutedEventArgs e)
        {
            Page2 page = new Page2();
            this.switchingWindow.Content = page;
        }

        private void actionCenterWindow(object sender, RoutedEventArgs e)
        {
            Page3 page = new Page3();
            this.switchingWindow.Content = page;
        }

        private void settingWindow(object sender, RoutedEventArgs e)
        {
            Page4 page = new Page4();
            this.switchingWindow.Content = page;
        }

        private void homeWindow(object sender, RoutedEventArgs e)
        {
            Home page = new Home();
            this.switchingWindow.Content = page;
        }
    }
}
