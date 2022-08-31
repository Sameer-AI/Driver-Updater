using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for Memory_Page.xaml
    /// </summary>
    public partial class Memory_Page : Page
    {

        public List<DynamicGridFrame> Frames = new List<DynamicGridFrame>();


        public ObservableCollection<MemoryDeviceDataStore> Devices = new ObservableCollection<MemoryDeviceDataStore>();

        public Memory_Page()
        {
            InitializeComponent();
            getData();
            setDataGrid();












        }

        public void getData()
        {

            ManagementObjectSearcher objSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMemory");

            ManagementObjectCollection objCollection = objSearcher.Get();

            foreach (ManagementObject obj in objCollection)
            {


                //foreach (PropertyData property in obj.Properties)
                //{
                //    Console.Out.WriteLine(String.Format("{0}:{1}", property.Name, property.Value));
                //}

                Devices.Add(new MemoryDeviceDataStore
                {
                    MemoryBank = obj["BankLabel"].ToString(),
                    Description = obj["Description"].ToString(),
                    DeviceLocator = obj["DeviceLocator"].ToString(),
                    Capacity = obj["Capacity"].ToString(),
                    Speed =String.Format("{0} Hz",obj["Speed"].ToString()) , //String.Format("Hello {0}", name)
                    Manufacturer = obj["Manufacturer"].ToString(),
                    DataWidth = obj["DataWidth"].ToString(),
                    MemoryType = obj["MemoryType"].ToString(),
                    FormFactor = obj["FormFactor"].ToString()
                });

               

            }

            
        }
        
        public void setDataGrid()
        {
           // here we first set the number of frames required based upon the number of devices
            foreach(MemoryDeviceDataStore singleDevice in Devices)
            {
               
                Frames.Add(new DynamicGridFrame
                {
                  Label=singleDevice.PhysicalMemoryLabel,
                  Label1=singleDevice.MemoryBankLabel,
                  Label2=singleDevice.DescriptionLabel,
                  Label3=singleDevice.DeviceLocatorLabel,
                  Label4=singleDevice.CapacityLabel,
                  Label5=singleDevice.Speed,
                  Label6=singleDevice.ManufacturerLabel,
                  Label7=singleDevice.DataWidthLabel,
                  Label8=singleDevice.MemoryTypeLabel,
                  Label9=singleDevice.FormFactorLabel
                  
                }
                );
            }

            foreach(DynamicGridFrame frame in Frames)
            {
                
                this.deviceshowstack.Children.Add(frame);
                
            }

            
        }
    }
}
