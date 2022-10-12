using System;
using System.Collections.Generic;
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
    /// Interaction logic for DriverListFrameToast.xaml
    /// </summary>
    public partial class DriverListFrameToast : UserControl
    {
        public string FriendlyNameProp { get; set; }

        public DriverListFrameToast()
        {
            InitializeComponent();
            
        }
        public DriverListFrameToast(string obj,string cat)
        {
            InitializeComponent();
            FriendlyName.Content = obj;
            setCategoryButtonIcon(cat);
        }

        public void setCategoryButtonIcon(string obj)
        {
            var brush = new ImageBrush();
            string category = obj;
            Console.WriteLine(category);

            switch (category)
            {
                case "AUDIOENDPOINT":

                    brush.ImageSource = new BitmapImage(new Uri("Resources/AUDIOENDPOINT.png", UriKind.Relative));
                    category_logo.Fill = brush;
                    break;

                case "BATTERY":
                    brush.ImageSource = new BitmapImage(new Uri("Resources/BATTERY.png", UriKind.Relative));
                    category_logo.Fill = brush;
                    break;

                case "BLUETOOTH":

                    brush.ImageSource = new BitmapImage(new Uri("Resources/BLUETOOTH.png", UriKind.Relative));
                    category_logo.Fill = brush;
                    break;

                case "CAMERA":
                    brush.ImageSource = new BitmapImage(new Uri("Resources/CAMERA.png", UriKind.Relative));
                    category_logo.Fill = brush;
                    break;

                case "COMPUTER":

                    brush.ImageSource = new BitmapImage(new Uri("Resources/COMPUTER.png", UriKind.Relative));
                    category_logo.Fill = brush;
                    break;

                case "DISKDRIVE":
                    brush.ImageSource = new BitmapImage(new Uri("Resources/DISKDRIVE.png", UriKind.Relative));
                    category_logo.Fill = brush;
                    break;

                case "DELLINSTRUMENTATION":

                    brush.ImageSource = new BitmapImage(new Uri("Resources/DELLINSTRUMENTATION.png", UriKind.Relative));
                    category_logo.Fill = brush;
                    break;

                case "DISPLAY":
                    brush.ImageSource = new BitmapImage(new Uri("Resources/DISPLAY.png", UriKind.Relative));
                    category_logo.Fill = brush;
                    break;

                case "FIRMWARE":

                    brush.ImageSource = new BitmapImage(new Uri("Resources/FIRMWARE.png", UriKind.Relative));
                    category_logo.Fill = brush;
                    break;

                case "HIDCLASS":
                    brush.ImageSource = new BitmapImage(new Uri("Resources/HIDCLASS.png", UriKind.Relative));
                    category_logo.Fill = brush;
                    break;

                case "KEYBOARD":

                    brush.ImageSource = new BitmapImage(new Uri("Resources/KEYBOARD.png", UriKind.Relative));
                    category_logo.Fill = brush;
                    break;

                case "MEDIA":
                    brush.ImageSource = new BitmapImage(new Uri("Resources/MEDIA.png", UriKind.Relative));
                    category_logo.Fill = brush;
                    break;

                case "MONITOR":

                    brush.ImageSource = new BitmapImage(new Uri("Resources/MONITOR.png", UriKind.Relative));
                    category_logo.Fill = brush;
                    break;

                case "MOUSE":
                    brush.ImageSource = new BitmapImage(new Uri("Resources/MOUSE.png", UriKind.Relative));
                    category_logo.Fill = brush;
                    break;

                case "MTD":

                    brush.ImageSource = new BitmapImage(new Uri("Resources/MTD.png", UriKind.Relative));
                    category_logo.Fill = brush;
                    break;

                case "NET":
                    brush.ImageSource = new BitmapImage(new Uri("Resources/NET.png", UriKind.Relative));
                    category_logo.Fill = brush;
                    break;

                case "PORTS":

                    brush.ImageSource = new BitmapImage(new Uri("Resources/PORTS.png", UriKind.Relative));
                    category_logo.Fill = brush;
                    break;

                case "PRINTQUEUE":
                    brush.ImageSource = new BitmapImage(new Uri("Resources/PRINTQUEUE.png", UriKind.Relative));
                    category_logo.Fill = brush;
                    break;

                case "PROCESSOR":

                    brush.ImageSource = new BitmapImage(new Uri("Resources/PROCESSOR.png", UriKind.Relative));
                    category_logo.Fill = brush;
                    break;

                case "SCSIADAPTER":
                    brush.ImageSource = new BitmapImage(new Uri("Resources/SCSIADAPTER.png", UriKind.Relative));
                    category_logo.Fill = brush;
                    break;

                case "SECURITDEVICES":

                    brush.ImageSource = new BitmapImage(new Uri("Resources/SECURITYDEVICES.png", UriKind.Relative));
                    category_logo.Fill = brush;
                    break;

                case "SOFTWAREDEVICE":
                    brush.ImageSource = new BitmapImage(new Uri("Resources/SOFTWAREDEVICE.png", UriKind.Relative));
                    category_logo.Fill = brush;
                    break;

                case "SYSTEM":

                    brush.ImageSource = new BitmapImage(new Uri("Resources/SYSTEM.png", UriKind.Relative));
                    category_logo.Fill = brush;
                    break;

                case "UCM":
                    brush.ImageSource = new BitmapImage(new Uri("Resources/UCM.png", UriKind.Relative));
                    category_logo.Fill = brush;
                    break;

                case "USB":

                    brush.ImageSource = new BitmapImage(new Uri("Resources/USB.png", UriKind.Relative));
                    category_logo.Fill = brush;
                    break;

                default:
                    brush.ImageSource = new BitmapImage(new Uri("Resources/PROCESSOR.png", UriKind.Relative));
                    category_logo.Fill = brush;
                    break;


            }

        }
    }
}
