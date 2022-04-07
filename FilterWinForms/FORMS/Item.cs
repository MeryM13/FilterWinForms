using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FilterWinForms.CLASSES;
using FilterWinForms.UTILS;

namespace FilterWinForms.FORMS
{
    public partial class Item : UserControl
    {
        public Item()
        {
            InitializeComponent();
        }

        public Item(ProductClass product)
        {
            InitializeComponent();
            lblType.Text = product.Type;
            lblName.Text = product.Name;
            lblPrice.Text = product.Price.ToString();
            lblID.Text = product.SKU;
            foreach (var material in DataWork.GetMaterialsList(product))
            {
                lblMaterials.Text += " " + material.Name + ",";
            }
            if (product.PicturePath != "нет")
            {
                string photo = product.PicturePath.Substring(1);
                Image image = Image.FromFile($"{AppDomain.CurrentDomain.BaseDirectory}IMAGES\\{photo}");
                Img.Image = image;
            }
            else
            {
                Image image = Image.FromFile($"{AppDomain.CurrentDomain.BaseDirectory}IMAGES\\picture.png");
                Img.Image = image;
            }
        }
    }
}
