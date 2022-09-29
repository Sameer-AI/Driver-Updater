using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Driver_Updater
{
    internal class OsDataStore
    {
        public string Computer_Name { get; set; }
        public string User_Name { get; set; }
        public string Organisation { get; set; }
        public string OS_Name { get; set; }
        public string OS_Version { get; set; }
        public string Product_Id { get; set; }
        public int Architeture { get; set; }
    }
}
