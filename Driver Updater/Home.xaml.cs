using Microsoft.Win32;
using System;
using System.Management;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Effects;
using System.Windows.Navigation;

namespace Driver_Updater
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>  
    public partial class Home : Page
    {
        public Home()
        {
            InitializeComponent();
            PcInfoMethod();/*This method is used for gathering basic os and hardware specs 
                            * we can further modify these mthod to sut are needs
                            * for now we are only looking at 3 value but rest can also be used
                            */
            popWindowOpen();
            popWindow2Open();

        }
        private void PcInfoMethod()
        {
            getOperatingSystemInfo();
            getProcessorInfo();
            getRamInfo();

        }
        private void getOperatingSystemInfo()
        {
            ManagementObjectSearcher mos = new ManagementObjectSearcher("select * from Win32_OperatingSystem");
            foreach (ManagementObject managementObject in mos.Get())
            {

                if (managementObject["Caption"] != null)
                {
                    OS.Text = managementObject["Caption"].ToString();   //Display operating system caption
                }

            }
        }
        private void getProcessorInfo()
        {
            RegistryKey processor_name = Registry.LocalMachine.OpenSubKey(@"Hardware\Description\System\CentralProcessor\0", RegistryKeyPermissionCheck.ReadSubTree);   //This registry entry contains entry for processor info.

            if (processor_name != null)
            {
                if (processor_name.GetValue("ProcessorNameString") != null)
                {
                    CPU.Text = processor_name.GetValue("ProcessorNameString").ToString();   //Display processor info.
                }

            }

        }
        private void getRamInfo()
        {
            ManagementObjectSearcher Search = new ManagementObjectSearcher("select * from Win32_ComputerSystem");
            foreach (ManagementObject managementObject in Search.Get())
            {
                double RamBytes = (Convert.ToDouble(managementObject["TotalPhysicalMemory"]));
                RAM.Text = (Convert.ToDecimal(RamBytes / 1073741824)).ToString();


            }
        }



        private void moreWindowOpen(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Effect = new BlurEffect();
            //MainWindowGrid.Effect = new BlurEffect();

            Window1 window = new Window1();
            
            window.Owner = Application.Current.MainWindow;
            window.ShowDialog();

            

 
            
        }
        private void popWindowOpen()
        {
            
           Popup1 window = new Popup1();
            window.Top = 680;
            window.Left = 1230;

            
            window.Show();


        }
        private void popWindow2Open()
        {

            PopUp2 window = new PopUp2();
            window.Top = 380;
            window.Left = 1230;


            window.Show();


        }

        private void startScan(object sender, RoutedEventArgs e)
        {
            NavigationService navService = NavigationService.GetNavigationService(this);
            DriverScanningPage page = new DriverScanningPage();
            navService.Navigate(page);


            
        }
    }
}
     