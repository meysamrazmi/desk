using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _808DesktopApp.Classes
{
    public class Version
    {
        public int id { get; set; }
        public string vid { get; set; }
        public string description { get; set; }
        public string force_update { get; set; }
        public string update_link { get; set; }
        //"id": "27",
        //"vid": "1.2.2",
        //"description": "<p>توضیحات تست</p>",
        //"force_update": "1",
        //"update_link": "https://example.com"
    }

    public class AllVersion
    {
        public List<Version> versions { get; set; }
    }
}
