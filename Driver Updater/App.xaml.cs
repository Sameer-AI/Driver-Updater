using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Forms = System.Windows.Forms;
namespace Driver_Updater
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
       protected override void OnStartup(StartupEventArgs e)
        {
            Forms.NotifyIcon notifyicon = new Forms.NotifyIcon();
            notifyicon.Icon = new System.Drawing.Icon("icon.ico");
            notifyicon.Visible = true;
        }
    }


}
  