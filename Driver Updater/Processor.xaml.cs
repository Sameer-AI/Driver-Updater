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
    /// Interaction logic for Processor.xaml
    /// </summary>
    public partial class Processor : Page
    {
        DriverUpdaterDataStoreEntities db = new DriverUpdaterDataStoreEntities();
        public Processor()
        {
            InitializeComponent();
            setData();

        }

        private void  setData()
        {
            var docs = from d in db.PROCESSOR_AND_MOTHERBOARD
                       select new
                       {
                           CPU_NAME = d.CPU_NAME,
                           NO_LOGICAL_PROCESSORS = d.NO_LOGICAL_PROCESSORS,
                           MANUFACTURER = d.MANUFACTURER,
                           CURRENT_CLOCK_SPEED = d.CURRENT_CLOCK_SPEED,
                           MAX_CLOCK_SPEED = d.MAX_CLOCK_SPEED,
                           VOLTAGE = d.VOLTAGE,
                           EXTERNAL_CLOCK = d.EXTERNAL_CLOCK,
                           SERIAL_NUMBER = d.SERIAL_NUMBER,
                           CPU_ID = d.CPU_ID,
                           SOCKET_DESIGNATION = d.SOCKET_DESIGNATION,
                           L2_CACHE = d.L2_CACHE,
                           L3_CACHE = d.L3_CACHE,
                           MODEL = d.MODEL,
                           PMANUFACTURER = d.PMANUFACTURER,
                           PSERIAL_NUMBER = d.PSERIAL_NUMBER,
                           BIOS_NAME = d.BIOS_NAME,
                           BIOS_VENDOR = d.BIOS_VENDOR,
                           SMBIOS_VERSION = d.SMBIOS_VERSION,
                           PCI_SUPPORT = d.PCI_SUPPORT,
                           BIOS_UPGRADABLE = d.BIOS_UPGRADABLE,
                           BIOS_SHADOWING = d.BIOS_SHADOWING,
                           BOOT_FROM_DISK = d.BOOT_FROM_DISK,
                           SELECTABLE_SUPPORTED = d.SELECTABLE_SUPPORTED,
                           EDD_SUPPORT = d.EDD_SUPPORT,
                           ACPI_SUPPORT = d.ACPI_SUPPORT,
                           USB_LAGACY_SUPPORT = d.USB_LAGACY_SUPPORT
                       };           
            
            foreach(var item in docs)
            {
                // Processor Information
                CPUName.Text = item.CPU_NAME;
                NumberOfCores.Text = item.NO_LOGICAL_PROCESSORS;
                Manufacturer.Text = item.PMANUFACTURER;
                CurrentClockSpeed.Text = item.CURRENT_CLOCK_SPEED.ToString();
                MaxClockSpeed.Text = item.MAX_CLOCK_SPEED.ToString();
                CurrentVoltage.Text = item.VOLTAGE.ToString();
                ExternalClock.Text = item.EXTERNAL_CLOCK.ToString();
                SerialNumber.Text = item.PSERIAL_NUMBER;
                CPUID.Text = item.CPU_ID;
                SocketDesignation.Text = item.SOCKET_DESIGNATION;
                L2.Text = item.L2_CACHE.ToString();
                L3.Text = item.L3_CACHE.ToString();
                MotherBoardModel.Text = item.MODEL;
                MotherBoardManufacturer.Text = item.MANUFACTURER;
                MotherBoardSN.Text = item.SERIAL_NUMBER;
                BIOSName.Text = item.BIOS_NAME;
                BIOSVendor.Text = item.BIOS_VENDOR;
                SMBIOSVersion.Text = item.SMBIOS_VERSION;


            }

        }

    }
}
