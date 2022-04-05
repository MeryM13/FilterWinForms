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
            lblMaterials.Text += MaterialsDataWork.GetMaterialsList(product);
            if (!(string.IsNullOrEmpty(product.PicturePath)))
            {
                Img.ImageLocation = @"FilterWinForms\IMAGES\" + product.PicturePath;
            }
            else
            {
                Img.ImageLocation = @"FilterWinForms\IMAGES\picture.png";
            }
        }
    }
}
