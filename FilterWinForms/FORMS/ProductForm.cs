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
        string searchStr;
        string defStr = "Все типы";

        public ProductForm()
        {
            type = defStr;
            order = "Отсутствует";
            maxPage = ProductDataWork.GetMaxPages(type, defStr, searchStr);
            InitializeComponent();
            CmbTypeInit();
            CmbOrderByInit();
            ProductsFill();
            rbtnUp.Checked = true;
        }

        private void CmbTypeInit()
        {
            try
            {
                foreach (string item in ProductDataWork.GetTypes(defStr))
                    cmbType.Items.Add(item);
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
                cmbOrderBy.Items.Add(order);
                cmbOrderBy.Items.Add("Наименование_продукции");
                cmbOrderBy.Items.Add("Номер_цеха_для_производства");
                cmbOrderBy.Items.Add("Минимальная_стоимость_для_агента");
                cmbOrderBy.SelectedItem = order;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ProductsFill()
        {
            try
            {
                DataTable productTable = ProductDataWork.GetProductByPage(type, page, order, rbtnUp.Checked? true: false, defStr, searchStr).Tables[0];
                foreach (DataRow row in productTable.Rows)
                {
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void cmbOrderBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            order = cmbOrderBy.SelectedItem.ToString();
            ProductsFill();
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            type = cmbType.SelectedItem.ToString();
            PageButtonsDelete();
            maxPage = ProductDataWork.GetMaxPages(type, defStr, searchStr);
            PageButtonsInit();
            ProductsFill();
        }

        private void btnPreviousPage_Click(object sender, EventArgs e)
        {
            if (page > 1)
                page--;
            if (PageButtonMinValue() > 1)
                PageButtonsShift(false);
            ProductsFill();
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            if (page < maxPage)
                page++;
            if (PageButtonMaxValue()  < maxPage)
                PageButtonsShift(true);
            ProductsFill();
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
            ProductsFill();
        }

        private void rbtnUp_CheckedChanged(object sender, EventArgs e)
        {
            ProductsFill();
        }

        private void rbtnDesc_CheckedChanged(object sender, EventArgs e)
        {
            ProductsFill();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            searchStr = txtSearch.Text;
            PageButtonsDelete();
            maxPage = ProductDataWork.GetMaxPages(type, defStr, searchStr);
            PageButtonsInit();
            ProductsFill();
        }
    }
}
