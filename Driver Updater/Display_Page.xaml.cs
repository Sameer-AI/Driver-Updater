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
    /// Interaction logic for Display_Page.xaml
    /// </summary>
    public partial class Display_Page : Page
    {

        List<VideoDriverDataStore> VideoDrivers = new List<VideoDriverDataStore>();
        public Display_Page()
        {
            InitializeComponent();
            getData();
            setData();

        }

        public void getData()
        {
            ManagementObjectSearcher objectSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_VideoController");

            ManagementObjectCollection objCollection = objectSearcher.Get();

            foreach(ManagementObject obj in objCollection)
            {
                
                VideoDrivers.Add(new VideoDriverDataStore
                {
                    Name = obj["Name"].ToString(),
                    VideoProcessor=obj["VideoProcessor"].ToString(),
                    Manufacturer=obj["AdapterCompatibility"].ToString(),
                    VideoArchitecture=obj["VideoArchitecture"].ToString(),
                    DACType=obj["AdapterDACType"].ToString(),
                    MemorySize=obj["AdapterRAM"].ToString(),  
                    MemoryType=obj["VideoMemoryType"].ToString(),
                    VideoMode = obj["VideoModeDescription"].ToString(),
                    CurrentRefreshRate=obj["CurrentRefreshrate"].ToString(),
                    DriverVersion=obj["DriverVersion"].ToString(),
                    DriverDate=obj["DriverDate"].ToString()
                
                });
                     
            
            
            }
        }
        public void setData()
        {
            this.label.Text = VideoDrivers[0].VideoadapterLabel;
            this.label1.Text = VideoDrivers[0].NameLabel;
            this.label2.Text = VideoDrivers[0].VideoProcessorLabel;
            this.label3.Text = VideoDrivers[0].ManufacturerLabel;
            this.label4.Text = VideoDrivers[0].VideoArchitectureLabel;
            this.label5.Text = VideoDrivers[0].DACTypeLabel;
            this.label6.Text = VideoDrivers[0].MemorySizeLabel;
            this.value7.Text = VideoDrivers[0].MemoryTypeLabel;
            this.label8.Text = VideoDrivers[0].VideoModeLabel;
            this.label9.Text = VideoDrivers[0].CurrentRefreshRateLabel;
            this.label10.Text = VideoDrivers[0].DriverVersionLabel;
            this.label11.Text = VideoDrivers[0].DriverDateLabel;


            
            this.value1.Text = VideoDrivers[0].Name;
            this.value2.Text = VideoDrivers[0].VideoProcessor;
            this.value3.Text = VideoDrivers[0].Manufacturer;
            this.value4.Text = VideoDrivers[0].VideoArchitecture;
            this.value5.Text = VideoDrivers[0].DACType;
            this.value6.Text = VideoDrivers[0].MemorySize;
            this.value7.Text = VideoDrivers[0].MemoryType;
            this.value8.Text = VideoDrivers[0].VideoMode;
            this.value9.Text = VideoDrivers[0].CurrentRefreshRate;
            this.value10.Text = VideoDrivers[0].DriverVersion;
            this.value11.Text = VideoDrivers[0].DriverDate;

        }
    }
}
