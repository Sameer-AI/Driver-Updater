using Driver_Updater.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace Driver_Updater
{
    /// <summary>
    /// Interaction logic for PopUp2.xaml
    /// </summary>
    public partial class PopUp2 : Window
    {
        DriverUpdaterDataStoreEntities db = new DriverUpdaterDataStoreEntities();
        ObservableCollection<DriverListFrameToast> Frames = new ObservableCollection<DriverListFrameToast>();

        public PopUp2()
        {
            InitializeComponent();
            setData();

        }
        public void setData()
        {
            int i = 0;
            var docs = from d in db.DRIVER_DETAILS
                       select new
                       {
                           FRIENDLY_NAME = d.FRIENDLY_NAME
                       };

            foreach (var item in docs)
            {
                Frames.Add(new DriverListFrameToast(item.FRIENDLY_NAME));
                this.FrameSetter.Children.Add(Frames[i]);
                i++;
            }


        }

    }   
}
