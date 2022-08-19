using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
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
    /// Interaction logic for Overall_info.xaml
    /// </summary>
    public partial class Overall_info : Page
    {
        public Overall_info()
        {
            InitializeComponent();
            getOperatingSystemInfo();
            getProcessorInfo();
            getRamInfo();
            getGraphicCard();
            getDisplayInfo();
            getDrivesInfo();
            getHDSoundInfo();
            getMotherBoardInfo();



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
                    Processor.Text = processor_name.GetValue("ProcessorNameString").ToString();   //Display processor info.
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
        private void getGraphicCard()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DisplayConfiguration");

            string graphicsCard = string.Empty;
            foreach (ManagementObject mo in searcher.Get())
            {
                foreach (PropertyData property in mo.Properties)
                {
                    if (property.Name == "Description")
                    {
                        GraphicsCard.Text = property.Value.ToString();
                    }
                }
            }
        }
        private void getDisplayInfo()
        {
            string screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth.ToString();

            string screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight.ToString();

            Monitor.Text = screenWidth + " x " + screenHeight;
        }

        private void getDrivesInfo()
        {
            // Retrieve all drives the computer has
            DriveInfo[] drives = DriveInfo.GetDrives();
            double totalSize = 0;
            // Do something with those drives, like iterate through them and print their name
            foreach (DriveInfo drive in drives)
            {
                if (drive.IsReady)
                {
                    double freeSpacePerc = (drive.AvailableFreeSpace / (float)drive.TotalSize) * 100;


                    totalSize += drive.TotalSize;

                    double TotalDiskSpace = totalSize / 1073741824;
                    float roundedDiskSpace = (float)TotalDiskSpace;
                    DiskStorage.Text = roundedDiskSpace.ToString() + " GB";

                }
            }



        }

        private void getHDSoundInfo()
        {
            ManagementObjectSearcher objSearcher = new ManagementObjectSearcher(
          "SELECT * FROM Win32_SoundDevice");

            ManagementObjectCollection objCollection = objSearcher.Get();

            foreach (ManagementObject obj in objCollection)
            {


                Audio.Text = obj["Caption"].ToString();
                break;


                // foreach (PropertyData property in obj.Properties)
                // {
                //   Console.Out.WriteLine(String.Format("{0}:{1}", property.Name, property.Value));
                //  }
                // Win32_MotherboardDevice
            }

        }
        private void getMotherBoardInfo()
        {
            ManagementObjectSearcher objSearcher = new ManagementObjectSearcher(
"SELECT * FROM Win32_ComputerSystem");

            ManagementObjectCollection objCollection = objSearcher.Get();

            foreach (ManagementObject obj in objCollection)
            {


               Motherboard.Text=obj["Model"].ToString();
                break;

                // foreach (PropertyData property in obj.Properties)
                // {
                //   Console.Out.WriteLine(String.Format("{0}:{1}", property.Name, property.Value));
                //  }
                // 
            }

        }
    }
}