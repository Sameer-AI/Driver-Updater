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
        public OperatingSystem()
        {
            InitializeComponent();
            getCompName();
            getUserName();
            getOwnerName();
            getOSName();
            getOSVersion();
            getProductID();
            getSystemArchitecture();

        }

        private void getCompName()
        {

            ManagementObjectSearcher objSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystem");

            ManagementObjectCollection objCollection = objSearcher.Get();

            foreach (ManagementObject obj in objCollection)
            {


                CompName.Text = obj["Name"].ToString();
                


            }

        }
        private void getUserName()
        {

            ManagementObjectSearcher objSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystem");

            ManagementObjectCollection objCollection = objSearcher.Get();

            foreach (ManagementObject obj in objCollection)
            {


                UserName.Text = obj["UserName"].ToString();



            }

        }
        private void getOwnerName()
        {

            ManagementObjectSearcher objSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystem");

            ManagementObjectCollection objCollection = objSearcher.Get();

            foreach (ManagementObject obj in objCollection)
            {


                Organization.Text = obj["PrimaryOwnerName"].ToString();



            }

        }

        private void getOSName()
        {

            ManagementObjectSearcher objSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");

            ManagementObjectCollection objCollection = objSearcher.Get();

            foreach (ManagementObject obj in objCollection)
            {


                OSName.Text = obj["Caption"].ToString();



            }

        }

        private void getOSVersion()
        {

            ManagementObjectSearcher objSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");

            ManagementObjectCollection objCollection = objSearcher.Get();

            foreach (ManagementObject obj in objCollection)
            {


                OSVersion.Text = obj["Version"].ToString();



            }

        }

        private void getProductID()
        {

            ManagementObjectSearcher objSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");

            ManagementObjectCollection objCollection = objSearcher.Get();

            foreach (ManagementObject obj in objCollection)
            {


                ProductID.Text = obj["SerialNumber"].ToString();



            }

        }

        private void getSystemArchitecture()
        {

            ManagementObjectSearcher objSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");

            ManagementObjectCollection objCollection = objSearcher.Get();

            foreach (ManagementObject obj in objCollection)
            {


                Architecture.Text = obj["OSArchitecture"].ToString();



            }

        }
    }
}
