using Driver_Updater.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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

        public DriverResultListFrame(ScannedDriverDataStore obj)
        {
            InitializeComponent();
            setCategoryButtonIcon(obj);
            checkBox_setter(obj);
            setData(obj);
            tempObj = obj;
            loaderStart();

        }

        private void loaderStart()
        {

            //this thread worker is designed to operated only progress Bar

            BackgroundWorker worker = new BackgroundWorker();
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            worker.WorkerReportsProgress = false;
            worker.DoWork += worker_DoWork;
            worker.RunWorkerAsync();

        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            db_write(tempObj);
            db_read(tempObj);
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Console.WriteLine("thread completed");
        }



        private void db_read(ScannedDriverDataStore obj)
        {
            var docs = from d in db.ScanResultCheckBoxValues
                       select new
                       {
                           Name=d.NAME,
                           Value=d.VALUE
                       };

            foreach( var item in docs)
            {
                Console.WriteLine(item.Name + ":" + item.Value);
            }
        }

        private void db_write(ScannedDriverDataStore obj)
        {
            if (db.ScanResultCheckBoxValues.Count() == 0)
            {
                ScanResultCheckBoxValue CheckBoxValue = new ScanResultCheckBoxValue()
                {
                    NAME=this.CheckBox.Content.ToString(),
                    VALUE=this.CheckBox.IsChecked
                };

                //Console.WriteLine(CheckBoxValue.NAME + "db write") ;
                db.ScanResultCheckBoxValues.Add(CheckBoxValue);
                db.SaveChanges();
            }

            else
            {
                ScanResultCheckBoxValue CheckBoxValue = new ScanResultCheckBoxValue()
                {   Id = db.ScanResultCheckBoxValues.Count() + 1,
                    NAME = this.CheckBox.Content.ToString(),
                    VALUE = this.CheckBox.IsChecked
                };
                //Console.WriteLine(CheckBoxValue.NAME + "db write else");
                db.ScanResultCheckBoxValues.Add(CheckBoxValue);
                db.SaveChanges();
            }

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

        public void checkBox_setter(ScannedDriverDataStore obj)
        {
            this.CheckBox.Content = obj.FriendlyName;
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
        {
            Console.WriteLine(this.CheckBox.Content + " is checked");
        }

        private void Unchecked(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(this.CheckBox.Content + " is unchecked");
        }
    }
 }

