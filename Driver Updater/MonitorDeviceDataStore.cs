using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Driver_Updater
{
    class MonitorDeviceDataStore
    {
        public string MonitorLabel { get;  }
        public string NameLabel { get;  }
        public string ScreenheightLabel { get; }
        public string ScreenWidthLabel { get;  }
        public string StatusLabel { get;  }

        
        public string Name { get; set; }
        public string Screenheight { get; set; }
        public string ScreenWidth { get; set; }
        public string Status { get; set; }


    }
}
