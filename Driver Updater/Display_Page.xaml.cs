using Driver_Updater.Models;
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

        DriverUpdaterDataStoreEntities db = new DriverUpdaterDataStoreEntities();
        VideoDriverDataStore VideoDrivers = new VideoDriverDataStore();
        public Display_Page()
        {
            InitializeComponent();
           
            setData();

        }

        
        public void setData()
        {
            this.label.Text = VideoDrivers.VideoadapterLabel;
            this.label1.Text = VideoDrivers.NameLabel;
            this.label2.Text = VideoDrivers.VideoProcessorLabel;
            this.label3.Text = VideoDrivers.ManufacturerLabel;
            this.label4.Text = VideoDrivers.VideoArchitectureLabel;
            this.label5.Text = VideoDrivers.DACTypeLabel;
            this.label6.Text = VideoDrivers.MemorySizeLabel;
            this.value7.Text = VideoDrivers.MemoryTypeLabel;
            this.label8.Text = VideoDrivers.VideoModeLabel;
            this.label9.Text = VideoDrivers.CurrentRefreshRateLabel;
            this.label10.Text = VideoDrivers.DriverVersionLabel;
            this.label11.Text = VideoDrivers.DriverDateLabel;




            var docs = from d in db.DISPLAYs
                       select new
                       {
                           NAME=d.NAME,
                           VIDEO_PROCESSOR=d.VIDEO_PROCESSOR,
                           MANUFACTURER=d.MANUFACTURER,
                           VIDEO_ARCHITECTURE=d.VIDEO_ARCHITECTURE,
                           DAC_TYPE=d.DAC_TYPE,
                           MEMORY_SIZE=d.MEMORY_SIZE,
                           MEMORY_TYPE=d.MOUSE,
                           VIDEO_MODE=d.VIDEO_MODE,
                           CURRENT_REFRESH_RATE=d.CURRENT_REFRESH_RATE,
                           DRIVER_VERSION=d.DRIVER_VIRSION,
                           DRIVER_DATE=d.DRIVER_DATE
                          
                            };

            foreach(var item in docs)
            {
                this.value1.Text = item.NAME;
                this.value2.Text = item.VIDEO_PROCESSOR;
                this.value3.Text = item.MANUFACTURER;
                this.value4.Text = item.VIDEO_ARCHITECTURE.ToString();
                this.value5.Text = item.DAC_TYPE;
                this.value6.Text = item.MEMORY_SIZE.ToString();
                this.value7.Text = item.MEMORY_TYPE.ToString();
                this.value8.Text = item.VIDEO_MODE;
                this.value9.Text = item.CURRENT_REFRESH_RATE.ToString();
                this.value10.Text= item.DRIVER_VERSION;
                this.value11.Text= item.DRIVER_DATE;

            }



        }
    }
}
