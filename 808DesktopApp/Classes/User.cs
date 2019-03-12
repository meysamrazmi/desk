using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _808DesktopApp.Classes
{
    public class User
    {
        public int uid { get; set; }
        public string name { get; set; }
        public string mail { get; set; }
        public string created { get; set; }
        public string login { get; set; }
        public string picture { get; set; }
        public string local_picture { get; set; }
        public string password { get; set; }
        public bool privatemsg_disabled { get; set; }

        //"uid":262,
		//"name":"test",
		//"mail":"xxx@x.com",
		//"created":1401528280,
		//"login":1542281847,
		//"picture":"https://civil808.com/sites/default/files/styles/200x200/public/field/image/user_262_0.jpg?itok=9RjL4vX1",
		//"roles":{"2":"\u06a9\u0627\u0631\u0628\u0631 \u0634\u0646\u0627\u062e\u062a\u0647 \u0634\u062f\u0647"},
		//"privatemsg_disabled":false

    }
}
