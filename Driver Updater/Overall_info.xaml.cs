using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using Driver_Updater.Models;

namespace Driver_Updater
{
    /// <summary>
    /// Interaction logic for Overall_info.xaml
    /// </summary>
    public partial class Overall_info : Page
    {
        DriverUpdaterDataStoreEntities db = new DriverUpdaterDataStoreEntities();
        

        public Overall_info()
        {
            InitializeComponent();
            setData();
            


        }
        

        public void setData()
        {


            var docs = from d in db.InfoBlockOverAlls
                       select new
                       {
                           OS = d.OPERATING_SYSTEM,
                           CPU = d.PROCESSOR,
                           GRAPHICS_CARD = d.GRAPHICS_CARD,
                           MEMORY = d.MEMORY,
                           MONITOR = d.MONITOR,
                           DISK_STORAGE = d.DISK_STORAGE,
                           AUDIO = d.AUDIO,
                           MOTHERBOARD = d.MOTHERBOARD,
                           MOUSE = d.MOUSE,
                           KEYBOARD = d.KEYBOARD
                       };
                
             foreach(var item in docs)
            {
                OS.Text=item.OS;
                Processor.Text = item.CPU;
                GraphicsCard.Text = item.GRAPHICS_CARD;
                RAM.Text = item.MEMORY.ToString();
                Monitor.Text = item.MONITOR;
                DiskStorage.Text = item.DISK_STORAGE.ToString();
                Audio.Text = item.AUDIO;
                Motherboard.Text = item.MOTHERBOARD;


            }
        
        }

        }
}
