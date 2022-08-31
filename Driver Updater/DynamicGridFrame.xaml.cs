using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public DynamicGridFrame()
        {
            //this.label.Text = Label;

        
            InitializeComponent();
            label.Text = Label;
            //Console.WriteLine("reached here");
            Console.WriteLine(Label);
            label1.Text = Label1;
            label2.Text = Label2;
            label3.Text = Label3;
            label4.Text = Label4;
            label5.Text = Label5;
            label6.Text = Label6;

            label7.Text = Label7;
            label8.Text = Label8;
            label9.Text = Label9;

        }
        
       
         
        /*
        public DynamicGridFrame(string labelstr,string label1str,string label2str,string label3str,string label4str, string label5str,string label6str,string label7str, string label8str, string label9str)
        {
            InitializeComponent();
            
            Label= labelstr;
            Label1 = label1str;
            Label2 = label2str;
            Label3 = label3str;
            Label4 = label4str;
            Label5 = label5str;
            Label6 = label6str;
            Label7 = label7str;
            Label8 = label8str;
            Label9 = label9str;





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
        }*/
    }   

}
