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
        int page = 1;
        string type;
        string order;
        int maxPage;
        string defStr = "Нет";

        public ProductForm()
        {
            order = type = defStr;
            maxPage = ProductDataWork.GetMaxPages(type);
            InitializeComponent();
            CmbTypeInit();
            CmbOrderByInit();
            GridFill();
            rbtnUp.Checked = true;
        }

        private void CmbTypeInit()
        {
            try
            {
                cmbType.Items.AddRange(ProductDataWork.GetTypes());
                cmbType.SelectedItem = type;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CmbOrderByInit()
        {
            try
            {
                cmbOrderBy.Items.AddRange(new string[] { "Нет", "Наименование_продукции", "Минимальная_стоимость_для_агента", "Номер_цеха_для_производства" });
                //cmbOrderBy.Items.AddRange(ProductDataWork.GetColumnsForSort());
                cmbOrderBy.SelectedItem = order;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GridFill()
        {
            try
            {
                Console.WriteLine();
                Console.WriteLine(type);
                Console.WriteLine(order);
                dgProduct.DataSource = ProductDataWork.GetProductByPage(type, page, order, rbtnUp.Checked? true: false, defStr).Tables[0];
                PageLabel.Text = page.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void cmbOrderBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            order = cmbOrderBy.SelectedItem.ToString();
            GridFill();
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            type = cmbType.SelectedItem.ToString();
            PageButtonsDelete();
            maxPage = ProductDataWork.GetMaxPages(type);
            PageButtonsInit();
            GridFill();
        }

        private void btnPreviousPage_Click(object sender, EventArgs e)
        {
            if (page > 1)
                page--;
            if (PageButtonMinValue() > 1)
                PageButtonsShift(false);
            GridFill();
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            if (page < maxPage)
                page++;
            if (PageButtonMaxValue()  < maxPage)
                PageButtonsShift(true);
            GridFill();
        }

        private void PageButtonsInit()
        {
            page = 1;
            int max = maxPage >= 3 ? 3 : maxPage;
            for (int i = max; i > 0; i--)
            {
                if (i <= maxPage)
                {
                    Button button = new Button();
                    button.Name = "pageBtn" + i.ToString();
                    button.Top = btnNextPage.Top;
                    button.Size = btnNextPage.Size;
                    button.Text = i.ToString();
                    button.Left = btnNextPage.Left - 27 * (max + 1 - i);
                    button.Tag = "PageButton";
                    btnPreviousPage.Left = button.Left - 27;
                    button.Click += new EventHandler(PageButtonClick);
                    this.Controls.Add(button);
                }
            }
        }

        private void PageButtonsShift(bool up)
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Button) //Check the type
                {
                    Button btn = ctrl as Button;
                    if (btn.Tag == "PageButton")
                    {
                        btn.Text = up ?
                            (Int32.Parse(btn.Text) + 1).ToString() :
                            (Int32.Parse(btn.Text) - 1).ToString();
                    }
                }
            }
        }

        private void PageButtonsDelete()
        {
            for (int i = 1; i <= maxPage; i++)
            {
                Button btn = this.Controls.Find(("pageBtn" + i.ToString()), true).FirstOrDefault() as Button;
                if (btn != null)
                {
                    if (btn.Tag == "PageButton")
                    {
                        Controls.Remove(btn);
                    }
                }
            }
        }

        private int PageButtonMaxValue()
        {
            int max = 0;
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Button) //Check the type
                {
                    Button btn = ctrl as Button;
                    if (btn.Tag == "PageButton")
                    {
                        if (Int32.Parse(btn.Text) > max)
                            max = Int32.Parse(btn.Text);
                    }
                }
            }
            return max;
        }

        private int PageButtonMinValue()
        {
            int min = maxPage;
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Button) //Check the type
                {
                    Button btn = ctrl as Button;
                    if (btn.Tag == "PageButton")
                    {
                        if (Int32.Parse(btn.Text) < min)
                            min = Int32.Parse(btn.Text);
                    }
                }
            }
            return min;
        }

        private void PageButtonClick(object sender, EventArgs e)
        {
            Button button = sender as Button;
            page = Int32.Parse(button.Text);
            GridFill();
        }

        private void rbtnUp_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnUp.Checked)
                rbtnDesc.Checked = false;
            else
                rbtnDesc.Checked = true;
            GridFill();
        }

        private void rbtnDesc_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnDesc.Checked)
                rbtnUp.Checked = false;
            else
                rbtnUp.Checked = true;
            GridFill();
        }
    }
}
