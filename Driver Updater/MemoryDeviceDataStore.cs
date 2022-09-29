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


        
        string _memoryBank ;
        string _description;
        string _deviceLocator ;
        string _capacity;
        string _speed ;
        string _manufacturer ;
        string _dataWidth;
        string _memoryType;
        string _formFactor;


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
            get
            {
                return _memoryBank;

            }
            set
            {
                _memoryBank = value;
            }

        }

        public string Description
        {
            get
            {
                return _description;

            }
            set
            {
                _description = value;
            }
        }
        public string DeviceLocator
        {
            get
            {
                return _deviceLocator;
            }
            set
            {
                _deviceLocator = value;
            }

        }
        public string Capacity
        {
            get
            {
                return _capacity;
            }
            set
            {
                _capacity = value;
            }   
        }
        public string Speed
        {
            get
            {
                return _speed;
            }
            set
            {
                _speed = value;
            }   
        }
        public string Manufacturer
        {
            get
            {
                return _manufacturer;
            }
            set
            {
                _manufacturer = value;
            }   
        }
        public string DataWidth
        {
            get
            {
                return _dataWidth;
            }
            set
            {
                _dataWidth = value;
            }
        }
        public string MemoryType
        {
            get
            {
                return _memoryType;
            }
            set
            {
                _memoryType = value;
            }   
        }
        public string FormFactor
        {
            get
            {
                return _formFactor;
            }
            set
            {
                _formFactor = value;
            }   
        }

    }
}
