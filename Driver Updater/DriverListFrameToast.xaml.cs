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
        public DriverListFrameToast(string obj)
        {
            InitializeComponent();
            FriendlyName.Content = obj;
        }
    }
}
