using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FilterWinForms.UTILS;

namespace FilterWinForms.FORMS
{
    public partial class ProductForm : LibParent.ParentForm
    {
        public ProductForm()
        {
            InitializeComponent();
            CmbTypeInit();
            GridFill("Нет");
        }

        private void CmbTypeInit()
        {
            try
            {
                cmbType.Items.AddRange(ProductDataWork.GetTypes());
                cmbType.SelectedItem = "Нет";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GridFill(string Type)
        {
            try
            {
                if (Type == "Нет")
                {
                    dgProduct.DataSource = ProductDataWork.GetAll().Tables[0];
                }
                else
                {
                    dgProduct.DataSource = ProductDataWork.GetByType(Type).Tables[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridFill(cmbType.SelectedItem.ToString());
        }
    }
}
