using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Driver_Updater
{
    class VideoDriverDataStore
    {

        private string _videoAdapterLabel = "Video Adapter";
        private string _nameLabel = "Name";
        private string _videoProcessor = "Video Processor";
        private string _manufacturer = "Manufacturer";
        private string _videoArchitecture = "Video Architecture";
        private string _dacType = "DAC Type";
        private string _memorySize = "Memory Size";
        private string _memoryType = "Memory Type";
        private string _videoMode = "Video Mode";
        private string _currentRefreshRate = "Current Refresh Rate"; 
        private string _driverVersion = "Driver Version";
        private string _driverDate = "Driver Date";


        public string VideoadapterLabel {
            get
            {
                return _videoAdapterLabel;
            }
        }

        public string NameLabel{ 
            get 
            { 
                return _nameLabel; 
            } 
        }

        public string VideoProcessorLabel {
            get
            { 
                return _videoProcessor; 
            }
        }
        public string ManufacturerLabel {
            get 
            {
                return _manufacturer;

            }
        }
        public string VideoArchitectureLabel {
            get 
            {
                return _videoArchitecture;
            }
        }
        public string DACTypeLabel { 
            get
            {
                return _dacType;            
            }
        }

        public string MemorySizeLabel { 
            get
            {
                return _memorySize;
            }
                
                }

        public string MemoryTypeLabel {

            get 
            {
                return _memoryType;
            }
        }
        public string VideoModeLabel {
            get
            {
                return _videoMode;
            }
                
                }
        public string CurrentRefreshRateLabel {
            get 
            {
                return _currentRefreshRate;
            }
        }
        public string DriverVersionLabel { 
            get 
            {
                return _driverVersion;
            } 
        }
        public string DriverDateLabel {
            get
            {
                return _driverDate;
            }
        }
          

        public string Name { get; set; }
        public string VideoProcessor { get; set; }
        public string Manufacturer { get; set; }
        public int VideoArchitecture { get; set; }
        public string DACType { get; set; }
        public float MemorySize { get; set; }
        public int MemoryType { get; set; }
        public string VideoMode { get; set; }
        public int CurrentRefreshRate { get; set; }
        public string DriverVersion { get; set; }
        public string DriverDate { get; set; }
       

    }
}
   