using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilterWinForms.CLASSES
{
    public class ProductClass
    {
        public string Name { get; set; }
        public string SKU { get; set; }
        public decimal MinPrice { get; set; }
        public string Type { get; set; }
        public int Workshop { get; set; }
        public string PicturePath { get; set; }
        public decimal Price { get; set; }
    }
}
