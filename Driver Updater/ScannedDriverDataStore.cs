using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Driver_Updater
{
   public class ScannedDriverDataStore
    {

        public string FriendlyName{ get; set; }
        public string Category { get; set; }   //DeviceClass
        public string FileContent { get; set; }
        public string Created_At { get; set; }
        public string Updated_At { get; set; }
        public string DriverVersion { get; set; }
        public string Manufacturer { get; set; }
        public string HardwareId { get; set; }
        public string DeviceId { get; set; }
        public string InfName { get; set; }
        public string CurrentDate { get; set; }




    }
}
