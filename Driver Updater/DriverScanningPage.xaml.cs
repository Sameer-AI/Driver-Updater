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
    /// Interaction logic for DriverScanningPage.xaml
    /// </summary>
    public partial class DriverScanningPage : Page
    {
        public DriverScanningPage()
        {
            InitializeComponent();

            progressBarValueChanger();
            pageChanger();
        }

        private void progressBarValueChanger()
        { for (int i=0 ; i<=100 ; i++)
            {

                this.loader.Value = i;
            
            }
            
        }

        private void pageChanger()
        {
            

            NavigationService navService = NavigationService.GetNavigationService(this);
            DriverScanResultPage page2 = new DriverScanResultPage();
            

            ;

        }


    }
}
