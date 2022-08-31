using System;
using System.Collections.Generic;
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
    /// Interaction logic for Processor.xaml
    /// </summary>
    public partial class Processor : Page
    {
        public Processor()
        {
            InitializeComponent();
            getCPUName();
            getMotherboardInfo();
            getBIOSInfo();
        }

        private void getCPUName()
        {
            ManagementObjectSearcher objSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
            ManagementObjectCollection objCollection = objSearcher.Get();
            
            foreach(ManagementObject obj in objCollection)
            {
                // Processor Information
                CPUName.Text = obj["Name"].ToString();
                NumberOfCores.Text = obj["NumberOfCores"].ToString();
                Manufacturer.Text = obj["Manufacturer"].ToString();
                CurrentClockSpeed.Text = obj["CurrentClockSpeed"].ToString();
                MaxClockSpeed.Text = obj["MaxClockSpeed"].ToString();
                CurrentVoltage.Text = obj["CurrentVoltage"].ToString();
                ExternalClock.Text = obj["ExtClock"].ToString();
                SerialNumber.Text = obj["SerialNumber"].ToString();
                CPUID.Text = obj["DeviceID"].ToString();
                SocketDesignation.Text = obj["SocketDesignation"].ToString();
                L2.Text = obj["L2CacheSize"].ToString();
                L3.Text = obj["L3CacheSize"].ToString();

            }

        }
        private void getMotherboardInfo()
        {

                ManagementObjectSearcher objSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");
                ManagementObjectCollection objCollection = objSearcher.Get();

                foreach (ManagementObject obj in objCollection)
                {


                    MotherBoardModel.Text = obj["Product"].ToString();
                    MotherBoardManufacturer.Text = obj["Manufacturer"].ToString();
                    MotherBoardSN.Text = obj["SerialNumber"].ToString();
                    
                    
                    

                    // foreach (PropertyData property in obj.Properties)
                    // {
                    //   Console.Out.WriteLine(String.Format("{0}:{1}", property.Name, property.Value));
                    //  }
                    // 


            }

        }

        private void getBIOSInfo()
        {
            ManagementObjectSearcher objSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_BIOS");
            ManagementObjectCollection objCollection = objSearcher.Get();

            foreach(ManagementObject obj in objCollection)
            {
                BIOSName.Text = obj["Name"].ToString();
                BIOSVendor.Text = obj["Manufacturer"].ToString();
                SMBIOSVersion.Text = obj["SMBIOSBIOSVersion"].ToString();

                
                

                

            }




        }
    }
}
