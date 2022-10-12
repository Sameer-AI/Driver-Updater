using Driver_Updater.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
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
    /// Interaction logic for DriverScanResultPage.xaml
    /// </summary>
    public partial class DriverScanResultPage : Page
    {
        ObservableCollection<DriverResultListFrame> Frames = new ObservableCollection<DriverResultListFrame>();
        DriverUpdaterDataStoreEntities db = new DriverUpdaterDataStoreEntities();
        ScannedDriverDataStore driverInfoBlock = new ScannedDriverDataStore();
        public List<DriverCheckBoxDataStore> chkBox = new List<DriverCheckBoxDataStore>();
        

        public DriverScanResultPage()
        {
            InitializeComponent();

            get();
        }



        public void get()
        { int i = 0;
            var docs = from d in db.DRIVER_DETAILS
                       select new
                       {
                           FRIENDLY_NAME = d.FRIENDLY_NAME,
                           CATEGORY = d.CATEGORY,
                           CURRENT_DATE = d.CURRENT_DATE,
                           DRIVER_VERSION=d.DRIVER_VIRSION,
                           MANUFACTURER=d.MANUFACTURER,
                           DEVICE_ID=d.DEVICE_ID,
                           HARDWARE_ID=d.HARDWARE_ID,
                           INF_NAME=d.INF_NAME,
                           FILE_CONTENT=d.FILE_CONTENT,
                           CREATED_AT=d.CREATED_AT,
                           UPDATED_AT=d.UPDATED_AT


                       };
            foreach(var item in docs)
            {
                driverInfoBlock.FriendlyName = item.FRIENDLY_NAME;
                driverInfoBlock.Category = item.CATEGORY;
                driverInfoBlock.DriverVersion = item.DRIVER_VERSION;
                driverInfoBlock.Manufacturer = item.MANUFACTURER;
                driverInfoBlock.DeviceId = item.DEVICE_ID;
                driverInfoBlock.HardwareId = item.HARDWARE_ID;
                driverInfoBlock.InfName= item.INF_NAME;
                driverInfoBlock.CurrentDate = item.CURRENT_DATE;
                driverInfoBlock.FileContent = String.IsNullOrEmpty(item.FILE_CONTENT?.ToString()) ? String.Empty : item.FILE_CONTENT?.ToString();
                driverInfoBlock.Created_At = String.IsNullOrEmpty(item.CREATED_AT?.ToString()) ? String.Empty : item.CREATED_AT?.ToString();
                driverInfoBlock.Updated_At = String.IsNullOrEmpty(item.UPDATED_AT?.ToString()) ? String.Empty: item.UPDATED_AT?.ToString();

                if (driverInfoBlock.FriendlyName != null)
                {  
                    Frames.Add(new DriverResultListFrame(driverInfoBlock,chkBox,i,i.ToString()));
                    this.frameSetter.Children.Add(Frames[i]);
                    i++;

                }
                

            }
            
            if (db.ScanResultCheckBoxValues.Count() == 0)
            {
                foreach (var item in chkBox)
                {
                    ScanResultCheckBoxValue chkboxObj = new ScanResultCheckBoxValue()
                    {
                        Id = item.ID,
                        NAME = item.Name,
                        VALUE = item.Value
                    };

                    db.ScanResultCheckBoxValues.Add(chkboxObj);
                    db.SaveChanges();

                   
                }


            }

            else
            {   foreach(var item in db.ScanResultCheckBoxValues)
                {
                    db.ScanResultCheckBoxValues.Remove(item);
                }

                foreach (var item in chkBox)
                {
                    ScanResultCheckBoxValue chkboxObj = new ScanResultCheckBoxValue()
                    {
                        Id = item.ID,
                        NAME = item.Name,
                        VALUE = item.Value
                    };

                    db.ScanResultCheckBoxValues.Add(chkboxObj);
                    db.SaveChanges();                    
                }
            }
        }

        public void set()
        {

        }

        private void upgradeAll(object sender, RoutedEventArgs e)
        {
            var docs = from d in db.ScanResultCheckBoxValues
                       select new
                       {
                           id = d.Id,
                           name = d.NAME,
                           val = d.VALUE
                       };

            foreach (var item in docs)
            {
                Console.WriteLine(item.id + " : " + item.name + ":" + item.val);
            }
        }
    }
}
