using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _808DesktopApp.Classes
{
    public class Product
    {
        public int nid { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public string picture { get; set; }
        public string local_picture { get; set; }
        public int order_time { get; set; }
        public int price { get; set; }
        public List<File> files { get; set; }





        //"nid": 20732,
        //    "title": "تست برای قفل",
        //    "author": "علی بنایی",
        //    "picture": null,
        //    "order_time": 1546955974,
        //    "price": 0,
        //    "files": [
        //        {
        //            "url": "https://civil808.com/sites/default/files/locked_files/63db15ce.bin",
        //            "filesize": 265840,
        //            "title": "test-IMG_6608.mp4",
        //            "name": "IMG_6608.mp4",
        //            "new_name": "63db15ce",
        //            "password": "2J6MAM"
        //        },
        //        {
        //            "url": "https://civil808.com/sites/default/files/locked_files/e915d964.bin",
        //            "filesize": 3316768,
        //            "title": "test-video_2018-06-07_10-25-14.mp4",
        //            "name": "video_2018-06-07_10-25-14.mp4",
        //            "new_name": "e915d964",
        //            "password": "C2J0K5"
        //        }
        //    ]
    }
}
