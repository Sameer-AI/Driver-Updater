using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
    /// Interaction logic for DynamicGridFrame.xaml
    /// </summary>
    public partial class DynamicGridFrame : UserControl

    {
        public string Label { get; set; }
        public string Label1 { get; set; }
        public string Label2 { get; set; }
        public string Label3 { get; set; }
        public string Label4 { get; set; }
        public string Label5 { get; set; }
        public string Label6 { get; set; }
        public string Label7 { get; set; }
        public string Label8 { get; set; }
        public string Label9 { get; set; }
        
        public string Value1 { get; set; }
        public string Value2 { get; set; }
        public string Value3 { get; set; }
        public string Value4 { get; set; }
        public string Value5 { get; set; }
        public string Value6 { get; set; }
        public string Value7 { get; set; }
        public string Value8 { get; set; }
        public string Value9 { get; set; }
        public ObservableCollection<MemoryDeviceDataStore> Devices = new ObservableCollection<MemoryDeviceDataStore>();

        public DynamicGridFrame(MemoryDeviceDataStore tempObj)
        {

            
            InitializeComponent();
            getData(tempObj);
            this.label.Text = Label;
            this.label1.Text = Label1;
            this.label2.Text = Label2;
            this.label3.Text = Label3;
            this.label4.Text = Label4;
            this.label5.Text = Label5;
            this.label6.Text = Label6;
            this.label7.Text = Label7;
            this.label8.Text = Label8;
            this.label9.Text = Label9;

            
            this.value1.Text = Value1;
            this.value2.Text = Value2;
            this.value3.Text = Value3;
            this.value4.Text = Value4;
            this.value5.Text = Value5;
            this.value6.Text = Value6;
            this.value7.Text = Value7;
            this.value8.Text = Value8;
            this.value9.Text = Value9;



        }

        public void getData(MemoryDeviceDataStore tempObj)
        {
            
            Label = tempObj.PhysicalMemoryLabel;
            Label1 = tempObj.MemoryBankLabel;
            Label2 = tempObj.DescriptionLabel;
            Label3 = tempObj.DeviceLocatorLabel;
            Label4 = tempObj.CapacityLabel;
            Label5 = tempObj.SpeedLabel;
            Label6 = tempObj.ManufacturerLabel;
            Label7 = tempObj.DataWidthLabel;
            Label8 = tempObj.MemoryTypeLabel;
            Label9 = tempObj.FormFactorLabel;

            Value1 = tempObj.MemoryBank;
            Value2 = tempObj.Description;
            Value3 = tempObj.DeviceLocator;
            Value4 = tempObj.Capacity.ToString();
            Value5 = tempObj.Speed.ToString();
            Value6 = tempObj.Manufacturer;
            Value7 = tempObj.DataWidth.ToString();
            Value8 = tempObj.MemoryType.ToString();
            Value9 = tempObj.FormFactor.ToString();

        }


    }



}   



