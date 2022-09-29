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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Driver_Updater
{
    /// <summary>
    /// Interaction logic for Operating_System.xaml
    /// </summary>
    public partial class OperatingSystem : Page
    {   
        DriverUpdaterDataStoreEntities db =new DriverUpdaterDataStoreEntities();

        public OperatingSystem()
        {
            InitializeComponent();
            setData();
        }
            public void setData()
        {
            var docs = from d in db.OS
                       select new
                       {
                           COMPUTER_NAME=d.COMPUTER_NAME,
                           USER_NAME=d.USER_NAME,
                           ORGANISATION= d.ORAGNISATION,
                           OS_NAME=d.OS_NAME,
                           OS_VERSION=d.OS_VERSION,
                           PRODUCT_ID=d.PRODUCT_ID,
                           Architecture=d.ARCHITECTURE
                       };
            foreach (var item in docs)
            {
                CompName.Text = item.COMPUTER_NAME;
                UserName.Text = item.USER_NAME;
                Organization.Text = item.ORGANISATION;
                OSName.Text = item.OS_NAME;
                OSVersion.Text = item.OS_VERSION;
                ProductID.Text = item.PRODUCT_ID;
                Architecture.Text = item.Architecture.ToString();

            }
        
        }

    }
}
