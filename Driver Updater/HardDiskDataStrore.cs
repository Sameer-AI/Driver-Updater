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

        


        public String Name
        {
            get;
            set;
        }

        public String Capacity
        {
            get;
            set;
        }

        public String InterfacteType
        {
            get;
            set;
        }

        public String Partition
        {
            get;
            set;
        }

        public String TotalCylinder
        {
            get;
            set;
        }

        public String TotalHeads
        {
            get;
            set;
        }

        public String TotalSectors
        {
            get;
            set;
        }

        public String TotalTracks
        {
            get;
            set;
        }

        public String TracksPerCylinders
        {
            get;
            set;
        }

        public String BytesPerSector
        {
            get;
            set;
        }

        public String SectorsPerTrack
        {
            get;
            set;
        }







    }
}
