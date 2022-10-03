using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Driver_Updater
{
    public class MemoryDeviceDataStore
    {
        // Static Menu Values

        public string physicalMemoryLabel = "Physical Memory";
        string _memoryBankLabel = "Memory Bank";
        string _descriptionLabel= "Description";
        string _deviceLocatorLabel = "Device Locator";
        string _capacityLabel = "Capicity";
        string _speedLabel = "Speed Label";
        string _manufacturerLabel = "Manufacturer";
        string _dataWidthLabel = "Data Width";
        string _memoryTypeLabel = "Memroy Type";
        string _formFactorLabel = "Form Factor";



        public string PhysicalMemoryLabel
        {
            get
            {
                return physicalMemoryLabel;

            }


        }
        public string MemoryBankLabel
        {
            get
            {
                return _memoryBankLabel;

            }
           

        }
        public string DescriptionLabel
        {
            get
            {
                return _descriptionLabel;

            }
            
        }
        public string DeviceLocatorLabel
        {
            get
            {
                return _deviceLocatorLabel;
            }
            

        }
        public string CapacityLabel
        {
            get
            {
                return _capacityLabel;
            }
            
        }
        public string SpeedLabel
        {
            get
            {
                return _speedLabel;
            }
            
        }
        public string ManufacturerLabel
        {
            get
            {
                return _manufacturerLabel;
            }
            
        }
        public string DataWidthLabel
        {
            get
            {
                return _dataWidthLabel;
            }
            
        }
        public string MemoryTypeLabel
        {
            get
            {
                return _memoryTypeLabel;
            }
            
        }
        public string FormFactorLabel
        {
            get
            {
                return _formFactorLabel;
            }
            
        }

    

        public string MemoryBank
        {
            get;

            set;
            

        }
        public string Description
        {
            get;

            set;
            
        }
        public string DeviceLocator
        {
            get;

            set;
            

        }
        public float Capacity
        {
            get;

            set;
            
        }
        public int Speed
        {
            get;

            set;
           
        }
        public string Manufacturer
        {
            get;

            set;
            
        }
        public int DataWidth
        {
            get;

            set;
            
        }
        public int MemoryType
        {
            get;

            set;
              
        }
        public int FormFactor
        {
            get;

            set;
              
        }
        public float TOTAL_MEMORY { get; set; }

    }
}
