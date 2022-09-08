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
using System.Management;

namespace Driver_Updater
{
    /// <summary>
    /// Interaction logic for Drives_Page.xaml
    /// </summary>
    public partial class Drives_Page : Page
    {
        public HardDiskDataStrore HardDiskData = new HardDiskDataStrore();

        public Drives_Page()
        {

            InitializeComponent();
            getData();
            setData();
        }
        
        public void getData()
        {
            ManagementObjectSearcher objSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
            ManagementObjectCollection objCollections = objSearcher.Get();
            foreach (ManagementObject obj in objCollections)
            {

                HardDiskData.Name = obj["Caption"].ToString();
                HardDiskData.Capacity = obj["Size"].ToString();
                HardDiskData.InterfacteType = obj["InterfaceType"].ToString();
                HardDiskData.Partition = obj["Partitions"].ToString();
                HardDiskData.TotalCylinder = obj["TotalCylinders"].ToString();
                HardDiskData.TotalHeads = obj["TotalHeads"].ToString();
                HardDiskData.TotalSectors = obj["TotalSectors"].ToString();
                HardDiskData.TotalTracks = obj["TotalTracks"].ToString();
                HardDiskData.BytesPerSector = obj["BytesPerSector"].ToString();
                HardDiskData.SectorsPerTrack = obj["SectorsPerTrack"].ToString();
                HardDiskData.TracksPerCylinders = obj["TracksPerCylinder"].ToString();
                
            }
        }
    
        void setData()
        {
            this.label.Text = HardDiskData.DiskDriveLabel;
            this.label1.Text = HardDiskData.NameLabel;
            this.label2.Text = HardDiskData.CapacityLabel;
            this.label3.Text = HardDiskData.InterfacteTypeLabel;
            this.label4.Text = HardDiskData.PartitionLabel;
            this.label5.Text = HardDiskData.TotalCylinderLabel;
            this.label6.Text = HardDiskData.TotalHeadsLabel;
            this.label7.Text = HardDiskData.TotalSectorsLabel;
            this.label8.Text = HardDiskData.TotalTracksLabel;
            this.label9.Text = HardDiskData.TracksPerCylindersLabel;
            this.label10.Text = HardDiskData.BytesPerSectorLabel;
            this.label11.Text = HardDiskData.SectorsPerTrackLabel;

            
            this.value1.Text = HardDiskData.Name;
            this.value2.Text = HardDiskData.Capacity;
            this.value3.Text = HardDiskData.InterfacteType;
            this.value4.Text = HardDiskData.Partition;
            this.value5.Text = HardDiskData.TotalCylinder;
            this.value6.Text = HardDiskData.TotalHeads;
            this.value7.Text = HardDiskData.TotalSectors;
            this.value8.Text = HardDiskData.TotalTracks;
            this.value9.Text = HardDiskData.TracksPerCylinders;
            this.value10.Text = HardDiskData.BytesPerSector;
            this.value11.Text = HardDiskData.SectorsPerTrack;



        }



    }

}
