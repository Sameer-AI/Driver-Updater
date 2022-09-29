using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Driver_Updater
{
    internal class ProcessorDataStore
    {
        public string CPU_NAME { get; set; }
        public string NO_LOGICAL_PROCESSORS { get; set; }
        public string MANUFACTURER { get; set; }
        public int CURRENT_CLOCK_SPEED { get; set; }
        public int MAX_CLOCK_SPEED { get; set; }
        public float VOLTAGE { get; set; }
        public int EXTERNAL_CLOCK { get; set; }
        public string SERIAL_NUMBER { get; set; }   
        public string CPU_ID { get; set; }
        public string SOCKET_DESIGNATION { get; set; }  
        public int L2_CACHE { get; set; }
        public int L3_CACHE { get; set; }
        public string MODEL { get; set; }
        public string PMANUFACTURER { get; set; }
        public string PSERIAL_NUMBER { get; set; }
        public string BIOS_NAME { get; set;}
        public string BIOS_VENDOR { get; set;}
        public string SMBIOS_VERSION { get; set; }
        public bool PCI_SUPPORT { get; set; }
        public bool BIOS_UPGRADABLE { get; set; }   
        public bool BIOS_SHADOWING { get; set; }
        public bool BOOT_FROM_DISK { get; set; }
        public bool SELECTABLE_SUPPORTED { get; set; }  
        public bool EDD_SUPPORT { get; set; }
        public bool ACPI_SUPPORT { get; set; }
        public bool USB_LAGACY_SUPPORT { get; set; }
    }
}
