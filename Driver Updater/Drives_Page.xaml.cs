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
using Driver_Updater.Models;

namespace Driver_Updater
{
    /// <summary>
    /// Interaction logic for Drives_Page.xaml
    /// </summary>
    public partial class Drives_Page : Page
    {
        public HardDiskDataStrore HardDiskData = new HardDiskDataStrore();
        DriverUpdaterDataStoreEntities db = new DriverUpdaterDataStoreEntities();

        public Drives_Page()
        {

            InitializeComponent();
            
            setData();
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

            var docs = from d in db.DRIVES
                       select new
                       {
                           Name=d.NAME,
                           Capacity=d.CAPACITY,
                           InterfaceType=d.INTERFACE_TYPE,
                           Partition=d.PARTITIONS,
                           TotalCylinder=d.TOTAL_CYLINDERS,
                           TotalHeads=d.TOTAL_HEADS,    
                           TotalSectors=d.TOTAL_SECTORS,
                           TotalTracks=d.TOTAL_TRACKS,
                           TracksPerCylinders=d.TRACKS_PER_CYLINDERS,
                           BytesPerSector=d.BYTES_PER_SECTOR,
                           SectorsPerTracks=d.SECTORS_PER_TRACK
                       };
            
            foreach(var item in docs)
            {
                this.value1.Text = item.Name;
                this.value2.Text = item.Capacity.ToString();
                this.value3.Text = item.InterfaceType;
                this.value4.Text = item.Partition.ToString();
                this.value5.Text = item.TotalCylinder.ToString();
                this.value6.Text = item.TotalHeads.ToString();
                this.value7.Text = item.TotalSectors.ToString();
                this.value8.Text = item.TotalTracks.ToString();
                this.value9.Text = item.TracksPerCylinders.ToString();
                this.value10.Text = item.BytesPerSector.ToString();
                this.value11.Text = item.SectorsPerTracks.ToString();

            }




        }



    }

}
