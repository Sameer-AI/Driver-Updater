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
           


        }

        public void getData()
        {
            int i = 0;
            long totalMemory = 0;

            ManagementObjectSearcher objSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMemory");

            ManagementObjectCollection objCollection = objSearcher.Get();

            foreach (ManagementObject obj in objCollection)
            {


                Devices.Add(new MemoryDeviceDataStore
                {
                MemoryBank = obj["BankLabel"].ToString(),
                Description = obj["Description"].ToString(),
                DeviceLocator = obj["DeviceLocator"].ToString(),
                Capacity = obj["Capacity"].ToString(),
                Speed = String.Format("{0} Hz", obj["Speed"].ToString()), //String.Format("Hello {0}", name)
                Manufacturer = obj["Manufacturer"].ToString(),
                DataWidth = obj["DataWidth"].ToString(),
                MemoryType = obj["MemoryType"].ToString(),
                FormFactor = obj["FormFactor"].ToString()

                });

                totalMemory += long.Parse(obj["Capacity"].ToString());

                this.TotalMem.Text =String.Format("{0} GB", totalMemory.ToString());
                Frames.Add(new DynamicGridFrame(Devices[i]));



                this.deviceshowstack.Children.Add(Frames[i]);
                i++;


            }

            
        }
        /*
       public void setDataGrid()
       {
          // here we first set the number of frames required based upon the number of devices
           foreach(MemoryDeviceDataStore singleDevice in Devices)
           {

               Frames.Add(new DynamicGridFrame());

               Frames[i].Label = "hshshshhshs";
               Frames[i].Label1 = singleDevice.MemoryBankLabel;
               Frames[i].Label2 = singleDevice.DescriptionLabel;
               Frames[i].Label3 = singleDevice.DeviceLocatorLabel;
               Frames[i].Label4 = singleDevice.CapacityLabel;
               Frames[i].Label5 = singleDevice.Speed;
               Frames[i].Label6 = singleDevice.ManufacturerLabel;
               Frames[i].Label7 = singleDevice.DataWidthLabel;
               Frames[i].Label8 = singleDevice.MemoryTypeLabel;
               Frames[i].Label9 = singleDevice.FormFactorLabel;

               Console.WriteLine(singleDevice.Manufacturer);


           }


           foreach(DynamicGridFrame frame in Frames)
           {
                 frame.Label = "hshshshhshs",
                 frame.Label1 = singleDevice.MemoryBankLabel,
                 frame.Label2 = singleDevice.DescriptionLabel,
                 frame.Label3 = singleDevice.DeviceLocatorLabel,
                 frame.Label4 = singleDevice.CapacityLabel,
                 frame.Label5 = singleDevice.Speed,
                 frame.Label6 = singleDevice.ManufacturerLabel,
                 frame.Label7 = singleDevice.DataWidthLabel,
                 frame.Label8 = singleDevice.MemoryTypeLabel,
                 frame.Label9 = singleDevice.FormFactorLabel


               this.deviceshowstack.Children.Add(frame);
               Console.WriteLine("lol");

           }*/


    }
}

