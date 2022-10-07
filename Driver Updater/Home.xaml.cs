using Driver_Updater.Models;
using Microsoft.Win32;
using System;
using System.IO;
using System.Management;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Effects;
using System.Windows.Navigation;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Driver_Updater
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>  
    public partial class Home : Page
    {
        OverAllInfoDataStore overAllPageInfo = new OverAllInfoDataStore();
        OsDataStore osInfoBlock = new OsDataStore();
        ProcessorDataStore processorInfoBlock = new ProcessorDataStore();

        public ObservableCollection<MemoryDeviceDataStore> memoryInfoBlock = new ObservableCollection<MemoryDeviceDataStore>();

        VideoDriverDataStore videoDriverInfoBlock = new VideoDriverDataStore();
        HardDiskDataStrore driveInfoBlock = new HardDiskDataStrore();

        public Home()
        {
            InitializeComponent();
            dbDataStoreMethodsThread();
            /*This method is used for gathering basic os and hardware specs 
                            * we can further modify these mthod to sut are needs
                            * for now we are only looking at 3 value but rest can also be used
                            */
            popWindowOpen();
            popWindow2Open();
            scanAndSaveDataToDb();




        }

        private void dbDataStoreMethodsThread()
        {
            BackgroundWorker dbDataStoreWorker = new BackgroundWorker();
            dbDataStoreWorker.WorkerReportsProgress = false;
            dbDataStoreWorker.DoWork += dbDataStore_DoWork;
            dbDataStoreWorker.RunWorkerAsync();

             
        }



        private void dbDataStore_DoWork(object sender, DoWorkEventArgs e)
        {
            PcInfoMethod();
        }

       

        private void PcInfoMethod()

        {   
            // these methods are used for Over All Iniformation Page
            getOperatingSystemInfo();
            getProcessorInfo();
            getRamInfo();
            getGraphicCard();
            getDisplayInfo();
            getDrivesInfo();
            getHDSoundInfo();
            getMotherBoardInfo();

            //these methods are used for Oerating System

            getCompName();
            getUserName();
            getOwnerName();
            getOSName();
            getOSVersion();
            getProductID();
            getSystemArchitecture();

            //these methods are used for Processor and MotherBoard
            getCPUName();
            getMotherboardInfo();
            getBIOSInfo();

            //these methods are used for Memory Device
            getMemoryDeviceData();

            //these methods are used for Display
            getDisplayData();

            //these method are used for Drives
            getDriveData();


        }

        private void moreWindowOpen(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Effect = new BlurEffect();
            

            Window1 window = new Window1();

            window.Owner = Application.Current.MainWindow;
            window.ShowDialog();


        }

        private void popWindowOpen()
        {

            Popup1 window = new Popup1();
            window.Top = 680;
            window.Left = 1230;


            window.Show();


        }

        private void popWindow2Open()
        {

            PopUp2 window = new PopUp2();
            window.Top = 380;
            window.Left = 1230;


            window.Show();


        }

        private void startScan(object sender, RoutedEventArgs e)
        {
            NavigationService navService = NavigationService.GetNavigationService(this);
            DriverScanningPage page = new DriverScanningPage();
            navService.Navigate(page);



        }


        private void scanAndSaveDataToDb()
        {
            DriverUpdaterDataStoreEntities db = new DriverUpdaterDataStoreEntities();
            

            //This section is for Over All page

            if (db.InfoBlockOverAlls.Count() == 0)
            {
                InfoBlockOverAll overAllBlock = new InfoBlockOverAll()
                {
                    OPERATING_SYSTEM = overAllPageInfo.OS,
                    PROCESSOR = overAllPageInfo.Processor,
                    GRAPHICS_CARD = overAllPageInfo.GraphicCard,
                    MEMORY = overAllPageInfo.Memory,
                    MONITOR = overAllPageInfo.Monitor,
                    DISK_STORAGE = overAllPageInfo.DiskStorage,
                    AUDIO = overAllPageInfo.Audio,
                    MOTHERBOARD = overAllPageInfo.MotherBoard,
                    MOUSE = overAllPageInfo.Mouse,
                    KEYBOARD = overAllPageInfo.Keyboard


                };

                Console.WriteLine("NEW overAll STRING ROW HAS BEEN INSERTED");
                db.InfoBlockOverAlls.Add(overAllBlock);
                db.SaveChanges();
            }

            //This section is for Os page

            if (db.OS.Count() == 0)
            {
               OS osBlock = new OS()
                {
                    COMPUTER_NAME=osInfoBlock.Computer_Name,
                    USER_NAME=osInfoBlock.User_Name,
                    ORAGNISATION=osInfoBlock.Organisation,
                    OS_NAME=osInfoBlock.OS_Name,
                    OS_VERSION=osInfoBlock.OS_Version,
                    PRODUCT_ID=osInfoBlock.Product_Id,
                    ARCHITECTURE=osInfoBlock.Architeture



                };

                Console.WriteLine("NEW OS STRING ROW HAS BEEN INSERTED");
                db.OS.Add(osBlock);
                db.SaveChanges();
            }

            //This section is for Processor page

            if (db.PROCESSOR_AND_MOTHERBOARD.Count() == 0)
            {
                PROCESSOR_AND_MOTHERBOARD processorBlock = new PROCESSOR_AND_MOTHERBOARD()
                {
                    CPU_NAME=processorInfoBlock.CPU_NAME,
                    NO_LOGICAL_PROCESSORS=processorInfoBlock.NO_LOGICAL_PROCESSORS,
                    MANUFACTURER=processorInfoBlock.MANUFACTURER,
                    CURRENT_CLOCK_SPEED=processorInfoBlock.CURRENT_CLOCK_SPEED,
                    MAX_CLOCK_SPEED=processorInfoBlock.MAX_CLOCK_SPEED,
                    VOLTAGE=processorInfoBlock.VOLTAGE,
                    EXTERNAL_CLOCK=processorInfoBlock.EXTERNAL_CLOCK,
                    SERIAL_NUMBER=processorInfoBlock.SERIAL_NUMBER,
                    CPU_ID=processorInfoBlock.CPU_ID,
                    SOCKET_DESIGNATION=processorInfoBlock.SOCKET_DESIGNATION,
                    L2_CACHE=processorInfoBlock.L2_CACHE,
                    L3_CACHE=processorInfoBlock.L3_CACHE,
                    MODEL=processorInfoBlock.MODEL,
                    PMANUFACTURER=processorInfoBlock.PMANUFACTURER,
                    PSERIAL_NUMBER=processorInfoBlock.PSERIAL_NUMBER,
                    BIOS_NAME=processorInfoBlock.BIOS_NAME,
                    BIOS_VENDOR=processorInfoBlock.BIOS_VENDOR,
                    SMBIOS_VERSION=processorInfoBlock.SMBIOS_VERSION,
                    PCI_SUPPORT=processorInfoBlock.PCI_SUPPORT,
                    BIOS_UPGRADABLE=processorInfoBlock.BIOS_UPGRADABLE,
                    BIOS_SHADOWING=processorInfoBlock.BIOS_SHADOWING,
                    BOOT_FROM_DISK=processorInfoBlock.BOOT_FROM_DISK,
                    SELECTABLE_SUPPORTED=processorInfoBlock.SELECTABLE_SUPPORTED,
                    EDD_SUPPORT=processorInfoBlock.EDD_SUPPORT,
                    ACPI_SUPPORT=processorInfoBlock.ACPI_SUPPORT,
                    USB_LAGACY_SUPPORT=processorInfoBlock.USB_LAGACY_SUPPORT

                };

                Console.WriteLine("NEW OS STRING ROW HAS BEEN INSERTED");
                db.PROCESSOR_AND_MOTHERBOARD.Add(processorBlock);
                db.SaveChanges();
            }

            //This section is for Memory Device page

            if (db.MEMORY_DEVICE.Count() == 0)
            { int i = 0;
                foreach (MemoryDeviceDataStore Device in memoryInfoBlock)
                {

                    MEMORY_DEVICE memoryDeviceBlock = new MEMORY_DEVICE()
                    { ID = i + 1,
                     TOTAL_MEMORY=Device.TOTAL_MEMORY,
                     MEMORY_BANK=Device.MemoryBank,
                     DESCRIPTION=Device.Description,
                     DEVICE_LOCATOR=Device.DeviceLocator,
                     CAPACITY=Device.Capacity,
                     SPEED_LABEL=Device.Speed,
                     MANUFACTURER=Device.Manufacturer,
                     DATA_WIDTH=Device.DataWidth,
                     MEMORY_TYPE=Device.MemoryType,
                     FORM_FACTOR=Device.FormFactor

                    };

                    Console.WriteLine("NEW Memory Device STRING ROW HAS BEEN INSERTED");
                    db.MEMORY_DEVICE.Add(memoryDeviceBlock);
                    db.SaveChanges();
                    i++;
                }
            }

            // THis section is for Display
            
            if (db.DISPLAYs.Count() == 0)
            {
                DISPLAY displayBlock = new DISPLAY()
                {
                    NAME= videoDriverInfoBlock.Name,
                    VIDEO_PROCESSOR=videoDriverInfoBlock.VideoProcessor,
                    MANUFACTURER=videoDriverInfoBlock.Manufacturer,
                    VIDEO_ARCHITECTURE=videoDriverInfoBlock.VideoArchitecture,
                    DAC_TYPE=videoDriverInfoBlock.DACType,
                    MEMORY_SIZE=videoDriverInfoBlock.MemorySize,
                    MOUSE=videoDriverInfoBlock.MemoryType,
                    VIDEO_MODE=videoDriverInfoBlock.VideoMode,
                    CURRENT_REFRESH_RATE=videoDriverInfoBlock.CurrentRefreshRate,
                    DRIVER_VIRSION=videoDriverInfoBlock.DriverVersion,
                    DRIVER_DATE=videoDriverInfoBlock.DriverDate,

                }; 

                    Console.WriteLine("NEW Display Device STRING ROW HAS BEEN INSERTED");
                    db.DISPLAYs.Add(displayBlock);
                    db.SaveChanges();

             
            }


            // THis section is for DRIVES   

            if (db.DRIVES.Count() == 0)
            {
                DRIVE driveBlock = new DRIVE()
                {
                    NAME = driveInfoBlock.Name,
                    CAPACITY= driveInfoBlock.Capacity,
                    INTERFACE_TYPE= driveInfoBlock.InterfacteType,
                    PARTITIONS= driveInfoBlock.Partition,
                    TOTAL_CYLINDERS= driveInfoBlock.TotalCylinder,
                    TOTAL_HEADS= driveInfoBlock.TotalHeads,
                    TOTAL_SECTORS= driveInfoBlock.TotalSectors,
                    TOTAL_TRACKS= driveInfoBlock.TotalTracks,
                    TRACKS_PER_CYLINDERS= driveInfoBlock.TracksPerCylinders,
                    BYTES_PER_SECTOR= driveInfoBlock.BytesPerSector,
                    SECTORS_PER_TRACK= driveInfoBlock.SectorsPerTrack,

                };

                Console.WriteLine("NEW Drives STRING ROW HAS BEEN INSERTED");
                db.DRIVES.Add(driveBlock);
                db.SaveChanges();


            }

        }

        // These methods are for OverAll Page

        private void getOperatingSystemInfo()
        {
            ManagementObjectSearcher mos = new ManagementObjectSearcher("select * from Win32_OperatingSystem");
            foreach (ManagementObject managementObject in mos.Get())
            {

                if (managementObject["Caption"] != null)
                {
                    overAllPageInfo.OS = managementObject["Caption"].ToString();   //Display operating system caption
                }

            }
        }

        private void getProcessorInfo()
        {
            RegistryKey processor_name = Registry.LocalMachine.OpenSubKey(@"Hardware\Description\System\CentralProcessor\0", RegistryKeyPermissionCheck.ReadSubTree);   //This registry entry contains entry for processor info.

            if (processor_name != null)
            {
                if (processor_name.GetValue("ProcessorNameString") != null)
                {
                    overAllPageInfo.Processor = processor_name.GetValue("ProcessorNameString").ToString();   //Display processor info.
                }

            }

        }

        private void getRamInfo()
        {
            ManagementObjectSearcher Search = new ManagementObjectSearcher("select * from Win32_ComputerSystem");
            foreach (ManagementObject managementObject in Search.Get())
            {
                double RamBytes = (Convert.ToDouble(managementObject["TotalPhysicalMemory"]));
                overAllPageInfo.Memory = ((float)Convert.ToDecimal(RamBytes / 1073741824));


            }
        }

        private void getGraphicCard()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DisplayConfiguration");

            string graphicsCard = string.Empty;
            foreach (ManagementObject mo in searcher.Get())
            {
                foreach (PropertyData property in mo.Properties)
                {
                    if (property.Name == "Description")
                    {
                        overAllPageInfo.GraphicCard = property.Value.ToString();
                    }
                }
            }
        }

        private void getDisplayInfo()
        {
            string screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth.ToString();

            string screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight.ToString();

            overAllPageInfo.Monitor = screenWidth + " x " + screenHeight;
        }

        private void getDrivesInfo()
        {
            // Retrieve all drives the computer has
            DriveInfo[] drives = DriveInfo.GetDrives();
            double totalSize = 0;
            // Do something with those drives, like iterate through them and print their name
            foreach (DriveInfo drive in drives)
            {
                if (drive.IsReady)
                {
                    double freeSpacePerc = (drive.AvailableFreeSpace / (float)drive.TotalSize) * 100;


                    totalSize += drive.TotalSize;

                    double TotalDiskSpace = totalSize / 1073741824;
                    float roundedDiskSpace = (float)TotalDiskSpace;
                    overAllPageInfo.DiskStorage = roundedDiskSpace;

                }
            }



        }

        private void getHDSoundInfo()
        {
            ManagementObjectSearcher objSearcher = new ManagementObjectSearcher(
          "SELECT * FROM Win32_SoundDevice");

            ManagementObjectCollection objCollection = objSearcher.Get();

            foreach (ManagementObject obj in objCollection)
            {


                overAllPageInfo.Audio = obj["Caption"].ToString();
                break;

            }

        }

        private void getMotherBoardInfo()
        {
            ManagementObjectSearcher objSearcher = new ManagementObjectSearcher(
"SELECT * FROM Win32_ComputerSystem");

            ManagementObjectCollection objCollection = objSearcher.Get();

            foreach (ManagementObject obj in objCollection)
            {


                overAllPageInfo.MotherBoard = obj["Model"].ToString();
                break;


            }

        }

        // These methods are for Operating System Page

        private void getCompName()
        {

            ManagementObjectSearcher objSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystem");

            ManagementObjectCollection objCollection = objSearcher.Get();

            foreach (ManagementObject obj in objCollection)
            {


                osInfoBlock.Computer_Name = obj["Name"].ToString();



            }

        }

        private void getUserName()
        {

            ManagementObjectSearcher objSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystem");

            ManagementObjectCollection objCollection = objSearcher.Get();

            foreach (ManagementObject obj in objCollection)
            {


                osInfoBlock.User_Name = obj["UserName"].ToString();



            }

        }

        private void getOwnerName()
        {

            ManagementObjectSearcher objSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystem");

            ManagementObjectCollection objCollection = objSearcher.Get();

            foreach (ManagementObject obj in objCollection)
            {


                osInfoBlock.Organisation = obj["PrimaryOwnerName"].ToString();



            }

        }

        private void getOSName()
        {

            ManagementObjectSearcher objSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");

            ManagementObjectCollection objCollection = objSearcher.Get();

            foreach (ManagementObject obj in objCollection)
            {


                osInfoBlock.OS_Name = obj["Caption"].ToString();



            }

        }

        private void getOSVersion()
        {

            ManagementObjectSearcher objSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");

            ManagementObjectCollection objCollection = objSearcher.Get();

            foreach (ManagementObject obj in objCollection)
            {


                osInfoBlock.OS_Version = obj["Version"].ToString();



            }

        }

        private void getProductID()
        {

            ManagementObjectSearcher objSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");

            ManagementObjectCollection objCollection = objSearcher.Get();

            foreach (ManagementObject obj in objCollection)
            {


                osInfoBlock.Product_Id = obj["SerialNumber"].ToString();



            }

        }

        private void getSystemArchitecture()
        {

            ManagementObjectSearcher objSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");

            ManagementObjectCollection objCollection = objSearcher.Get();

            foreach (ManagementObject obj in objCollection)
            {

                int temp;
                //temp = Convert.ToInt16(obj["OSArchitecture"]);
                //osInfoBlock.Architeture = temp;
                
                string resultString = Regex.Match(obj["OSArchitecture"].ToString(), @"\d+").Value;
                Console.WriteLine(resultString);
                temp=Int32.Parse(resultString);
                osInfoBlock.Architeture = temp;
            
            }

        }

        // These mewthods are for Processor page

        private void getCPUName()
        {
            ManagementObjectSearcher objSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
            ManagementObjectCollection objCollection = objSearcher.Get();

            foreach (ManagementObject obj in objCollection)
            {
                // Processor Information
                processorInfoBlock.CPU_NAME= obj["Name"].ToString();
                processorInfoBlock.NO_LOGICAL_PROCESSORS = obj["NumberOfCores"].ToString();
                processorInfoBlock.PMANUFACTURER = obj["Manufacturer"].ToString();
                processorInfoBlock.CURRENT_CLOCK_SPEED = Convert.ToInt32(obj["CurrentClockSpeed"]);
                processorInfoBlock.MAX_CLOCK_SPEED = Convert.ToInt32(obj["MaxClockSpeed"]);
                processorInfoBlock.VOLTAGE = Convert.ToInt32(obj["CurrentVoltage"]);
                processorInfoBlock.EXTERNAL_CLOCK = Convert.ToInt32(obj["ExtClock"]);
                processorInfoBlock.PSERIAL_NUMBER = obj["SerialNumber"].ToString();
                processorInfoBlock.CPU_ID = obj["DeviceID"].ToString();
                processorInfoBlock.SOCKET_DESIGNATION = obj["SocketDesignation"].ToString();
                processorInfoBlock.L2_CACHE = Convert.ToInt32(obj["L2CacheSize"]);
                processorInfoBlock.L3_CACHE = Convert.ToInt32(obj["L3CacheSize"]);

            }

        }

        private void getMotherboardInfo()
        {

            ManagementObjectSearcher objSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");
            ManagementObjectCollection objCollection = objSearcher.Get();

            foreach (ManagementObject obj in objCollection)
            {


                processorInfoBlock.MODEL = obj["Product"].ToString();
                processorInfoBlock.MANUFACTURER = obj["Manufacturer"].ToString();
                processorInfoBlock.SERIAL_NUMBER = obj["SerialNumber"].ToString();


            }

        }

        private void getBIOSInfo()
        {
            ManagementObjectSearcher objSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_BIOS");
            ManagementObjectCollection objCollection = objSearcher.Get();

            foreach (ManagementObject obj in objCollection)
            {
                processorInfoBlock.BIOS_NAME = obj["Name"].ToString();
                processorInfoBlock.BIOS_VENDOR = obj["Manufacturer"].ToString();
                processorInfoBlock.SMBIOS_VERSION = obj["SMBIOSBIOSVersion"].ToString();

            }




        }


        // This method is for Memory Devices

        public void getMemoryDeviceData()
        { 
            
            
            int i = 0;
            float totalMemory = 0;

            ManagementObjectSearcher objSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMemory");

            ManagementObjectCollection objCollection = objSearcher.Get();

            foreach (ManagementObject obj in objCollection)
            {
                totalMemory += float.Parse(obj["Capacity"].ToString());

                memoryInfoBlock.Add(new MemoryDeviceDataStore
                {
                    MemoryBank = obj["BankLabel"].ToString(),
                    Description = obj["Description"].ToString(),
                    DeviceLocator = obj["DeviceLocator"].ToString(),
                    Capacity = float.Parse(obj["Capacity"].ToString()),
                    Speed = Convert.ToInt32(obj["Speed"].ToString()), //String.Format("Hello {0}", name)
                    Manufacturer = obj["Manufacturer"].ToString(),
                    DataWidth = Convert.ToInt32(obj["DataWidth"].ToString()),
                    MemoryType = Convert.ToInt32(obj["MemoryType"].ToString()),
                    FormFactor = Convert.ToInt32(obj["FormFactor"].ToString()),
                    TOTAL_MEMORY= totalMemory
                });


//               

            }

           


        }

        // This method is for Display Page

        public void getDisplayData()
        {
            ManagementObjectSearcher objectSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_VideoController");

            ManagementObjectCollection objCollection = objectSearcher.Get();

            foreach (ManagementObject obj in objCollection)
            {

                videoDriverInfoBlock.Name = obj["Name"].ToString();
                videoDriverInfoBlock.VideoProcessor = obj["VideoProcessor"].ToString();
                videoDriverInfoBlock.Manufacturer = obj["AdapterCompatibility"].ToString();
                videoDriverInfoBlock.VideoArchitecture = Convert.ToInt32(obj["VideoArchitecture"].ToString());
                videoDriverInfoBlock.DACType = obj["AdapterDACType"].ToString();
                videoDriverInfoBlock.MemorySize = float.Parse(obj["AdapterRAM"].ToString());
                videoDriverInfoBlock.MemoryType = Convert.ToInt32(obj["VideoMemoryType"].ToString());
                videoDriverInfoBlock.VideoMode = obj["VideoModeDescription"].ToString();
                videoDriverInfoBlock.CurrentRefreshRate = Convert.ToInt32(obj["CurrentRefreshrate"].ToString());
                videoDriverInfoBlock.DriverVersion = obj["DriverVersion"].ToString();
                videoDriverInfoBlock.DriverDate = obj["DriverDate"].ToString();


            }
        }

        // This method is for Drive Page

        public void getDriveData()
        {
            ManagementObjectSearcher objSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
            ManagementObjectCollection objCollections = objSearcher.Get();
            foreach (ManagementObject obj in objCollections)
            {

                driveInfoBlock.Name = obj["Caption"].ToString();
                driveInfoBlock.Capacity = float.Parse(obj["Size"].ToString());
                driveInfoBlock.InterfacteType = obj["InterfaceType"].ToString();
                driveInfoBlock.Partition = Convert.ToInt32(obj["Partitions"].ToString());
                driveInfoBlock.TotalCylinder = Convert.ToInt32(obj["TotalCylinders"].ToString());
                driveInfoBlock.TotalHeads = Convert.ToInt32(obj["TotalHeads"].ToString());
                driveInfoBlock.TotalSectors = Convert.ToInt32(obj["TotalSectors"].ToString());
                driveInfoBlock.TotalTracks = Convert.ToInt32(obj["TotalTracks"].ToString());
                driveInfoBlock.BytesPerSector = Convert.ToInt32(obj["BytesPerSector"].ToString());
                driveInfoBlock.SectorsPerTrack = Convert.ToInt32(obj["SectorsPerTrack"].ToString());
                driveInfoBlock.TracksPerCylinders = Convert.ToInt32(obj["TracksPerCylinder"].ToString());

            }
        }

    }
}
     