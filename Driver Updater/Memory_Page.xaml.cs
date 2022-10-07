using Driver_Updater.Models;
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


        public MemoryDeviceDataStore Device = new MemoryDeviceDataStore();

        public Memory_Page()
        {
            InitializeComponent();
            setData();
           


        }

        public void setData()
        { int i = 0;
            DriverUpdaterDataStoreEntities db = new DriverUpdaterDataStoreEntities();

            var docs = from d in db.MEMORY_DEVICE
                       select new 
                       {
                           TOTAL_MEMORY=d.TOTAL_MEMORY,
                           MEMORY_BANK=d.MEMORY_BANK,
                           DESCRIPTION=d.DESCRIPTION,
                           DEVICE_LOCATOR=d.DEVICE_LOCATOR,
                           CAPACITY=d.CAPACITY,
                           SPEED_LABEL=d.SPEED_LABEL,
                           MANUFACTURER=d.MANUFACTURER,
                           DATA_WIDTH=d.DATA_WIDTH,
                           MEMORY_TYPE=d.MEMORY_TYPE,
                           FORM_FACTOR=d.FORM_FACTOR
                       };

            foreach (var item in docs)
            {

                Device.TOTAL_MEMORY = (float)item.TOTAL_MEMORY;
                Device.MemoryBank = item.MEMORY_BANK;
                Device.Description = item.DESCRIPTION;
                Device.DeviceLocator = item.DEVICE_LOCATOR;
                Device.Capacity = (float)item.CAPACITY;
                Device.Speed = (int)item.SPEED_LABEL;
                Device.Manufacturer=item.MANUFACTURER;
                Device.DataWidth = (int)item.DATA_WIDTH;
                Device.MemoryType = (int)item.MEMORY_TYPE;
                Device.FormFactor = (int)item.FORM_FACTOR;

                Console.WriteLine(item.DESCRIPTION);






                Frames.Add(new DynamicGridFrame(Device));



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

