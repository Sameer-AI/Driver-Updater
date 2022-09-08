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
using System.Windows.Shapes;

namespace Driver_Updater
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        

        public Window1()
        {
            InitializeComponent();
            overallloader();
            
        }
        private void overallloader()
        {
            Overall_info page = new Overall_info();
            this.infoSwitch.Content = page;
        }

        private void unblurr(object sender, EventArgs e)
        {

            Application.Current.MainWindow.Effect = null;

        }

        private void overAllPage(object sender, RoutedEventArgs e)
        {
            Overall_info page = new Overall_info();
            this.infoSwitch.Content = page;
        }

        private void OperatingSystemPage(object sender, RoutedEventArgs e)
        {
            OperatingSystem page = new OperatingSystem();
            this.infoSwitch.Content = page;
        }

        private void ProcessorPage(object sender, RoutedEventArgs e)
        {
            Processor page = new Processor();
            this.infoSwitch.Content = page;
        }

        private void MemoryPage(object sender, RoutedEventArgs e)
        {
            Memory_Page page = new Memory_Page();
            this.infoSwitch.Content = page;

        }

        private void DisplayPage(object sender, RoutedEventArgs e)
        {
            Display_Page page = new Display_Page();
            this.infoSwitch.Content = page;
        }

        private void DrivesPage(object sender, RoutedEventArgs e)
        {
            Drives_Page page = new Drives_Page();
            this.infoSwitch.Content = page;
        }

       
    }
 }

