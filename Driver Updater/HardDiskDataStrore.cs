using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Driver_Updater
{
    public class HardDiskDataStrore
    {
        private string _diskDriveLabel = "Disk Srives";
        private string _nameLabel = "Name";
        private string _capacityLabel = "Capacity";
        private string _interfaceTypeLabel = "Interface Type";
        private string _partitionLabel = "Partitions";
        private string _totalCylindersLabel = "Total Cylinders";
        private string _totalHeadsLabel = "Total Heads";
        private string _totalSectorsLabel = "Total Sectors";
        private string _totalTracksLabel = "Total Tracks";
        private string _tracksPerCylinderLabel = "Tracks per Cylinder";
        private string _bytesPerSectorLabel = "Bytes Per Sector";
        private string _sectorsPerTrackLabel = "Sectors Per Track";
   



        public String DiskDriveLabel { 
            get
                { return _diskDriveLabel; }
            }

        public String NameLabel
        {
            get
            { return _nameLabel; }
        }

        public String CapacityLabel
        {
            get
            { return _capacityLabel; }
        }

        public String InterfacteTypeLabel
        {
            get
            { return _interfaceTypeLabel; }
        }

        public String PartitionLabel
        {
            get
            { return _partitionLabel; }
        }

        public String TotalCylinderLabel
        {
            get
            { return _totalCylindersLabel; }
        }

        public String TotalHeadsLabel
        {
            get
            { return _totalHeadsLabel; }
        }

        public String TotalSectorsLabel
        {
            get
            { return _totalSectorsLabel; }
        }

        public String TotalTracksLabel
        {
            get
            { return _totalTracksLabel; }
        }

        public String TracksPerCylindersLabel
        {
            get
            { return _tracksPerCylinderLabel; }
        }

        public String BytesPerSectorLabel
        {
            get
            { return _bytesPerSectorLabel; }
        }

        public String SectorsPerTrackLabel
        {
            get
            { return _sectorsPerTrackLabel; }
        }

        


        public string Name
        {
            get;
            set;
        }

        public float Capacity
        {
            get;
            set;
        }

        public string InterfacteType
        {
            get;
            set;
        }

        public int Partition
        {
            get;
            set;
        }

        public int TotalCylinder
        {
            get;
            set;
        }

        public int TotalHeads
        {
            get;
            set;
        }

        public int TotalSectors
        {
            get;
            set;
        }

        public int TotalTracks
        {
            get;
            set;
        }

        public int TracksPerCylinders
        {
            get;
            set;
        }

        public int BytesPerSector
        {
            get;
            set;
        }

        public int SectorsPerTrack
        {
            get;
            set;
        }







    }
}
