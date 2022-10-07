using Driver_Updater.Models;
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
using System.Windows.Shapes;

namespace Driver_Updater
{
    /// <summary>
    /// Interaction logic for updatableDriverInfo.xaml
    /// </summary>
    public partial class updatableDriverInfo : Window
    {
        ScannedDriverDataStore drivers = new ScannedDriverDataStore();
        DriverUpdaterDataStoreEntities db = new DriverUpdaterDataStoreEntities();


        public updatableDriverInfo()
        {
            InitializeComponent();
        }

        public updatableDriverInfo(string obj)
        {
            InitializeComponent();
            setData(obj);

        }

        public void setData(string obj)
        {
            Console.WriteLine(obj);
            var docs = from d in db.DRIVER_DETAILS
                       where obj == d.FRIENDLY_NAME
                       select new
                       {
                           FriendlyName = d.FRIENDLY_NAME,
                           Category=d.CATEGORY,
                           DriverVersion=d.DRIVER_VIRSION,
                           Manufacturer=d.MANUFACTURER,
                           CurrentDate=d.CURRENT_DATE
                       };

            Console.WriteLine(docs);


            foreach(var item in docs)
            {
                DateTime ? driverDateParsed;
                string temp = String.IsNullOrEmpty(String.Concat(item.CurrentDate.Where(c => !Char.IsWhiteSpace(c)))) ? String.Empty : String.Concat(item.CurrentDate.Where(c => !Char.IsWhiteSpace(c)));

                try
                {
                    driverDateParsed = ManagementDateTimeConverter.ToDateTime(temp);
                }
                catch
                {
                    driverDateParsed = null;
                }
                FriendlyName.Text = item.FriendlyName;
                Category.Text = item.Category;
                Version.Text = item.DriverVersion;
                Date.Text = driverDateParsed.ToString();
                Publisher.Text = item.Manufacturer;

            }


        }



        private void unblurr(object sender, EventArgs e)
        {
            Application.Current.MainWindow.Effect = null;
        }
    }
}
