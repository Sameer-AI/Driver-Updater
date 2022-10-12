using Driver_Updater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
namespace Driver_Updater
{
    /// <summary>
    /// Interaction logic for DriverResultListFrame.xaml
    /// </summary>
    public partial class DriverResultListFrame : UserControl
    {
        ScannedDriverDataStore tempObj = new ScannedDriverDataStore();
        DriverUpdaterDataStoreEntities db = new DriverUpdaterDataStoreEntities();
        
        public DriverResultListFrame()
        {
            InitializeComponent();
        }

        public DriverResultListFrame(ScannedDriverDataStore obj,List<DriverCheckBoxDataStore> chkbox ,int i, string id)
        {
            InitializeComponent();
            setCategoryButtonIcon(obj);
            checkBox_setter(obj,id);
            setData(obj);
            tempObj = obj;
            db_write(tempObj,chkbox,i);
            //db_read(tempObj);
            //loaderStart(workerObj);

        }

        /*
        private void loaderStart(BackgroundWorker worker)
        {

            //this thread worker is designed to operated only progress Bar

            //BackgroundWorker worker = new BackgroundWorker();
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            worker.WorkerReportsProgress = false;
            worker.DoWork += worker_DoWork;
            worker.RunWorkerAsync();

        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Console.WriteLine("thread completed");
        }*/



        public void db_read(List<ScannedDriverDataStore> obj)
        {
            /*var docs = from d in db.ScanResultCheckBoxValues
                       select new
                       {
                           Name=d.NAME,
                           Value=d.VALUE
                       };

            foreach( var item in docs)
            {
                Console.WriteLine(item.Name + ":" + item.Value);
            }*/
           
 

        }

        public void db_write(ScannedDriverDataStore obj, List<DriverCheckBoxDataStore> chkBox ,int i)
        {
            chkBox.Add(new DriverCheckBoxDataStore()
            {   ID=i,
                Name = CheckBox.Content.ToString(),
                Value = (bool)CheckBox.IsChecked
            }); ; ;
           /* if (db.ScanResultCheckBoxValues.Count() == 0)
            {
                Console.WriteLine(db.ScanResultCheckBoxValues.Count());

                ScanResultCheckBoxValue CheckBoxValue = new ScanResultCheckBoxValue()
                {
                    NAME = this.CheckBox.Content.ToString(),
                    VALUE = this.CheckBox.IsChecked

                };

                db.ScanResultCheckBoxValues.Add(CheckBoxValue);
                db.SaveChanges();

                

                //Console.WriteLine(CheckBoxValue.NAME + "db write") ;
               
            }

            else
            {
                ScanResultCheckBoxValue CheckBoxValue = new ScanResultCheckBoxValue()
                {
                    Id = db.ScanResultCheckBoxValues.Count() + 1,
                    NAME = this.CheckBox.Content.ToString(),
                    VALUE = this.CheckBox.IsChecked
                };
                //Console.WriteLine(CheckBoxValue.NAME + "db write else");
                db.ScanResultCheckBoxValues.Add(CheckBoxValue);
                db.SaveChanges();
            }*/

        }

        public void setData(ScannedDriverDataStore obj)
        {

            DateTime? driverDateParsed;
            string temp = String.IsNullOrEmpty(String.Concat(obj.CurrentDate.Where(c => !Char.IsWhiteSpace(c)))) ? String.Empty : String.Concat(obj.CurrentDate.Where(c => !Char.IsWhiteSpace(c)));

            try
            {
                driverDateParsed = ManagementDateTimeConverter.ToDateTime(temp);
            }
            catch
            {
                driverDateParsed = null;
            }



            try
            {

                //icon_content.Content = String.IsNullOrEmpty(String.Concat(obj.FriendlyName.Where(c => !Char.IsWhiteSpace(c)))) ? "n/a" : String.Concat(obj.FriendlyName.Where(c => !Char.IsWhiteSpace(c)));
                icon_content.Content = obj.FriendlyName;
                Friendly_Name_Content.Content = obj.FriendlyName;
                Update_now.Content = obj.FriendlyName;

            }
            catch
            {
                Console.WriteLine("empty");
            }

            Date.Text = String.Format("Current Date: {0}", driverDateParsed);


        }

        public void checkBox_setter(ScannedDriverDataStore obj,string id)
        {
            this.CheckBox.Content = obj.FriendlyName+"."+id;
            //Console.WriteLine(CheckBox.Content);
        }



        public void setCategoryButtonIcon(ScannedDriverDataStore obj)
        {
            var brush = new ImageBrush();
            string category = obj.Category;
            
            switch (category)
            {
                case "AUDIOENDPOINT":
                    
                    brush.ImageSource = new BitmapImage(new Uri("Resources/AUDIOENDPOINT.png", UriKind.Relative));
                    icon_content.Background = brush;
                    break;

                case "BATTERY":
                    brush.ImageSource = new BitmapImage(new Uri("Resources/BATTERY.png", UriKind.Relative));
                    icon_content.Background = brush;
                    break;

                case "BLUETOOTH":

                    brush.ImageSource = new BitmapImage(new Uri("Resources/BLUETOOTH.png", UriKind.Relative));
                    icon_content.Background = brush;
                    break;

                case "CAMERA":
                    brush.ImageSource = new BitmapImage(new Uri("Resources/CAMERA.png", UriKind.Relative));
                    icon_content.Background = brush;
                    break;

                case "COMPUTER":

                    brush.ImageSource = new BitmapImage(new Uri("Resources/COMPUTER.png", UriKind.Relative));
                    icon_content.Background = brush;
                    break;

                case "DISKDRIVE":
                    brush.ImageSource = new BitmapImage(new Uri("Resources/DISKDRIVE.png", UriKind.Relative));
                    icon_content.Background = brush;
                    break;

                case "DELLINSTRUMENTATION":

                    brush.ImageSource = new BitmapImage(new Uri("Resources/DELLINSTRUMENTATION.png", UriKind.Relative));
                    icon_content.Background = brush;
                    break;

                case "DISPLAY":
                    brush.ImageSource = new BitmapImage(new Uri("Resources/DISPLAY.png", UriKind.Relative));
                    icon_content.Background = brush;
                    break;

                case "FIRMWARE":

                    brush.ImageSource = new BitmapImage(new Uri("Resources/FIRMWARE.png", UriKind.Relative));
                    icon_content.Background = brush;
                    break;

                case "HIDCLASS":
                    brush.ImageSource = new BitmapImage(new Uri("Resources/HIDCLASS.png", UriKind.Relative));
                    icon_content.Background = brush;
                    break;

                case "KEYBOARD":

                    brush.ImageSource = new BitmapImage(new Uri("Resources/KEYBOARD.png", UriKind.Relative));
                    icon_content.Background = brush;
                    break;

                case "MEDIA":
                    brush.ImageSource = new BitmapImage(new Uri("Resources/MEDIA.png", UriKind.Relative));
                    icon_content.Background = brush;
                    break;

                case "MONITOR":

                    brush.ImageSource = new BitmapImage(new Uri("Resources/MONITOR.png", UriKind.Relative));
                    icon_content.Background = brush;
                    break;

                case "MOUSE":
                    brush.ImageSource = new BitmapImage(new Uri("Resources/MOUSE.png", UriKind.Relative));
                    icon_content.Background = brush;
                    break;

                case "MTD":

                    brush.ImageSource = new BitmapImage(new Uri("Resources/MTD.png", UriKind.Relative));
                    icon_content.Background = brush;
                    break;

                case "NET":
                    brush.ImageSource = new BitmapImage(new Uri("Resources/NET.png", UriKind.Relative));
                    icon_content.Background = brush;
                    break;

                case "PORTS":

                    brush.ImageSource = new BitmapImage(new Uri("Resources/PORTS.png", UriKind.Relative));
                    icon_content.Background = brush;
                    break;

                case "PRINTQUEUE":
                    brush.ImageSource = new BitmapImage(new Uri("Resources/PRINTQUEUE.png", UriKind.Relative));
                    icon_content.Background = brush;
                    break;

                case "PROCESSOR":

                    brush.ImageSource = new BitmapImage(new Uri("Resources/PROCESSOR.png", UriKind.Relative));
                    icon_content.Background = brush;
                    break;

                case "SCSIADAPTER":
                    brush.ImageSource = new BitmapImage(new Uri("Resources/SCSIADAPTER.png", UriKind.Relative));
                    icon_content.Background = brush;
                    break;

                case "SECURITDEVICES":

                    brush.ImageSource = new BitmapImage(new Uri("Resources/SECURITYDEVICES.png", UriKind.Relative));
                    icon_content.Background = brush;
                    break;

                case "SOFTWAREDEVICE":
                    brush.ImageSource = new BitmapImage(new Uri("Resources/SOFTWAREDEVICE.png", UriKind.Relative));
                    icon_content.Background = brush;
                    break;

                case "SYSTEM":

                    brush.ImageSource = new BitmapImage(new Uri("Resources/SYSTEM.png", UriKind.Relative));
                    icon_content.Background = brush;
                    break;

                case "UCM":
                    brush.ImageSource = new BitmapImage(new Uri("Resources/UCM.png", UriKind.Relative));
                    icon_content.Background = brush;
                    break;

                case "USB":

                    brush.ImageSource = new BitmapImage(new Uri("Resources/USB.png", UriKind.Relative));
                    icon_content.Background = brush;
                    break;

                default:
                    brush.ImageSource = new BitmapImage(new Uri("Resources/PROCESSOR.png", UriKind.Relative));
                    icon_content.Background = brush;
                    break;



            }

            
        }

        private void Info_browser(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Effect = new BlurEffect();
          
            var keyword = (e.Source as Button).Content.ToString();
            string pk = keyword;
            Console.WriteLine(pk);
            updatableDriverInfo window = new updatableDriverInfo(pk);

            window.Owner = Application.Current.MainWindow;
            window.ShowDialog();
        }


        private void Info_browser_two(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Effect = new BlurEffect();

            var keyword = (e.Source as Button).Content.ToString();
            string pk = keyword;
            Console.WriteLine(pk);
            Up_to_date_driver_Info window = new Up_to_date_driver_Info(pk);

            window.Owner = Application.Current.MainWindow;
            window.ShowDialog();
        }

        private void Info_brower_three(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Effect = new BlurEffect();

            var keyword = (e.Source as Button).Content.ToString();
            string pk = keyword;
            Console.WriteLine(pk);
            Up_to_date_driver_Info window = new Up_to_date_driver_Info(pk);

            window.Owner = Application.Current.MainWindow;
            window.ShowDialog();
        }

        private void Checked(object sender, RoutedEventArgs e)
        {   int chkBoxId = Convert.ToInt32(splitter());
            
            var result = db.ScanResultCheckBoxValues.SingleOrDefault(b => b.Id == chkBoxId);
            if (result != null)
            {
                result.VALUE = true;
                db.SaveChanges();
            }



        }

        public string splitter()
        {
            string splitted_contentId;
            string[] strArr = CheckBox.Content.ToString().Split('.');
            splitted_contentId = strArr[1];
           
            return splitted_contentId;
        }

        private void Unchecked(object sender, RoutedEventArgs e)
        {
            
            int chkBoxId = Convert.ToInt32(splitter());
           
            var result = db.ScanResultCheckBoxValues.SingleOrDefault(b => b.Id == chkBoxId);
            if (result != null)
            {
                result.VALUE = false;
                db.SaveChanges();
            }

            
        }
    }
 }

