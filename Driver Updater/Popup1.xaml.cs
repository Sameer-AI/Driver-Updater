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
using System.Windows.Shapes;

namespace Driver_Updater
{
    /// <summary>
    /// Interaction logic for Popup1.xaml
    /// </summary>
    public partial class Popup1 : Window
    {
        public Popup1()
        {
            InitializeComponent();
        }

        private void open_window(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow == null)
            {
                MainWindow window = new MainWindow();
                window.Show();

            }
            else
            {
                Application.Current.MainWindow.Activate();

            }

        }
        private void close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
