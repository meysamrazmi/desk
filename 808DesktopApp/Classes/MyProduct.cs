using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _808DesktopApp.Classes
{
    public class MyProduct
    {
        public MyProduct()
        {
            college = new List<Product>();
            product_kit = new List<Product>();
            product = new List<Product>();
        }
        public List<Product> product { get; set; }
        public List<Product> college { get; set; }
        public List<Product> product_kit { get; set; }
    }
}
