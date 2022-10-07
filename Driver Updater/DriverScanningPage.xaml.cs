using Driver_Updater.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading;
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
    /// Interaction logic for DriverScanningPage.xaml
    /// 
    /// Here we will start a background Worker To update the progressBar
    /// and scan all the drivers and save the details  
    /// </summary>
    public partial class DriverScanningPage : Page
    {
        List<ScannedDriverDataStore> Drivers = new List<ScannedDriverDataStore>();
        DriverUpdaterDataStoreEntities db = new DriverUpdaterDataStoreEntities();
        List<TextBlock> textBlocks = new List<TextBlock>();

        public DriverScanningPage()
        {
            InitializeComponent();

            driverScanner();
            loaderStart();
           


        }

        private void loaderStart()
        {
           
            //this thread worker is designed to operated only progress Bar

            BackgroundWorker worker = new BackgroundWorker();
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_DoWork;
            worker.ProgressChanged += worker_ProgressChanged;
            worker.RunWorkerAsync();

        }


        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // here we will update the progress bar and its text

            loader.Value = e.ProgressPercentage;
            loaderText.Text = (string)e.UserState;
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;
            worker.ReportProgress(0); // This calls the progressChanged event method

            for (int i=0 ; i < 100; i++)
            {
                Thread.Sleep(100);
                worker.ReportProgress(i, String.Format("{0}%", i));
            }

            worker.ReportProgress(100);
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            loader.Value = 0;
            loaderText.Text = "";

            NavigationService navService = NavigationService.GetNavigationService(this);
            DriverScanResultPage page2 = new DriverScanResultPage();
            navService.Navigate(page2);
            
        }


        private void driverScanner()
        {
            BackgroundWorker scanWorker = new BackgroundWorker();
            scanWorker.RunWorkerCompleted += scanWorker_RunworkerCompleted;
            scanWorker.WorkerReportsProgress = true;
            scanWorker.DoWork += scanWorker_DoWork;
            scanWorker.ProgressChanged += scanWorker_ProgressChenged;
            scanWorker.RunWorkerAsync();


        }

        private void scanWorker_ProgressChenged(object sender, ProgressChangedEventArgs e)
        {
            driverNames.Text = (string)e.UserState;
        }

        private void scanWorker_DoWork(object sender, DoWorkEventArgs e)

        {
            // Conditional control
            int i = 0;

            if (db.DRIVER_DETAILS.Count()==0)
            { 

            // here we will call the scan method
            ManagementObjectSearcher objSearcher2 = new ManagementObjectSearcher("select * from Win32_PnpSignedDriver");

            ManagementObjectCollection objCollection2 = objSearcher2.Get();

            //drverstore

            
                foreach (ManagementObject obj in objCollection2)

                {
                    var infName = string.IsNullOrEmpty(obj.GetPropertyValue("InfName")?.ToString()) ? string.Empty : obj.GetPropertyValue("InfName")?.ToString();
                    var hardwareId = string.IsNullOrEmpty(obj.GetPropertyValue("HardwareId")?.ToString()) ? string.Empty : obj.GetPropertyValue("HardwareId")?.ToString();
                    var deviceId = string.IsNullOrEmpty(obj.GetPropertyValue("DeviceId")?.ToString()) ? string.Empty : obj.GetPropertyValue("DeviceId")?.ToString();
                    var driverDate = string.IsNullOrEmpty(obj.GetPropertyValue("DriverDate")?.ToString()) ? string.Empty : obj.GetPropertyValue("DriverDate")?.ToString();
                    var driverVersion = string.IsNullOrEmpty(obj.GetPropertyValue("DriverVersion")?.ToString()) ? string.Empty : obj.GetPropertyValue("DriverVersion")?.ToString();
                    var deviceName = string.IsNullOrEmpty(obj.GetPropertyValue("FriendlyName")?.ToString()) ? obj.GetPropertyValue("Description")?.ToString() : obj.GetPropertyValue("FriendlyName")?.ToString();
                    var manufacturer = string.IsNullOrEmpty(obj.GetPropertyValue("Manufacturer")?.ToString()) ? string.Empty : obj.GetPropertyValue("Manufacturer")?.ToString();
                    var deviceClass = string.IsNullOrEmpty(obj.GetPropertyValue("DeviceClass")?.ToString()) ? string.Empty : obj.GetPropertyValue("DeviceClass")?.ToString();


                    Drivers.Add(new ScannedDriverDataStore
                    {
                        FriendlyName = deviceName,
                        Category = deviceClass,
                        CurrentDate = driverDate,
                        DriverVersion = driverVersion,
                        Manufacturer = manufacturer,
                        DeviceId = deviceId,
                        HardwareId = hardwareId,
                        InfName = infName
                    });

                    DRIVER_DETAILS driverBlock = new DRIVER_DETAILS()
                    {
                        ID = i + 1,
                        FRIENDLY_NAME = Drivers[i].FriendlyName,
                        CATEGORY = Drivers[i].Category,
                        CURRENT_DATE = Drivers[i].CurrentDate,
                        DRIVER_VIRSION = Drivers[i].DriverVersion,
                        MANUFACTURER = Drivers[i].Manufacturer,
                        DEVICE_ID = Drivers[i].DeviceId,
                        HARDWARE_ID = Drivers[i].HardwareId,
                        INF_NAME = Drivers[i].InfName

                    };
                    i++;

                    db.DRIVER_DETAILS.Add(driverBlock);
                    db.SaveChanges();
                }
                
                 
            }

            var docs = from d in db.DRIVER_DETAILS
                       select new
                       {
                           FRIENDLY_NAME = d.FRIENDLY_NAME,
                           CATEGORY = d.CATEGORY,
                           CURRENT_DATE = d.CURRENT_DATE,
                           DRIVER_VERSION = d.DRIVER_VIRSION,
                           MANUFACTURER = d.MANUFACTURER,
                           DEVICE_ID = d.DEVICE_ID,
                           HARDWARE_ID = d.HARDWARE_ID,
                           INF_NAME = d.INF_NAME,
                           FILE_CONTENT = d.FILE_CONTENT,
                           CREATED_AT = d.CREATED_AT,
                           UPDATED_AT = d.UPDATED_AT


                       };

            var scanWorker=sender as BackgroundWorker;

            int j = 0;
            foreach(var item in docs)
            {
                Thread.Sleep(80);
                scanWorker.ReportProgress(j,item.FRIENDLY_NAME);
                /*
                textBlocks.Add(new TextBlock());
                textBlocks[j].Text = item.FRIENDLY_NAME;
                this.DriverListSetter.Children.Add(textBlocks[j]);
                */
                j++;
            }

            scanWorker.ReportProgress(100,"Scan Complete");

        }

        private void scanWorker_RunworkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //here we will write the code for storing the collected information in the database
           
        }
    }
    
}
