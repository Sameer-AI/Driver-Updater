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
    /// Interaction logic for DriverResultListFrame.xaml
    /// </summary>
    public partial class DriverResultListFrame : UserControl
    {
        public DriverResultListFrame()
        {
            InitializeComponent();
        }

        public DriverResultListFrame(ScannedDriverDataStore obj)
        {
            InitializeComponent();
            
            DateTime? driverDateParsed = ManagementDateTimeConverter.ToDateTime(obj.CurrentDate);
            Console.WriteLine(driverDateParsed);
            Friendly_Name.Text = obj.FriendlyName;
            Date.Text = String.Format("Current Date:{0}", obj.CurrentDate);


        }
    }
}
