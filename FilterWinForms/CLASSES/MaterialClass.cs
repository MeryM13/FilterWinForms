using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilterWinForms.CLASSES
{
    class MaterialClass
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int InPack { get; set; }
        public string Measure { get; set; }
        public int Quantity { get; set; }
        public int MinQuantity { get; set; }
        public decimal Price { get; set; }
    }
}
