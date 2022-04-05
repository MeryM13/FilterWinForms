
namespace FilterWinForms.FORMS
{
    partial class ProductForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.btnPreviousPage = new System.Windows.Forms.Button();
            this.btnNextPage = new System.Windows.Forms.Button();
            this.cmbOrderBy = new System.Windows.Forms.ComboBox();
            this.rbtnUp = new System.Windows.Forms.RadioButton();
            this.rbtnDesc = new System.Windows.Forms.RadioButton();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.grbOrder = new System.Windows.Forms.GroupBox();
            this.grbFilter = new System.Windows.Forms.GroupBox();
            this.grbSearch = new System.Windows.Forms.GroupBox();
            this.btnPriceChange = new System.Windows.Forms.Button();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.layoutProducts = new System.Windows.Forms.FlowLayoutPanel();
            this.grbOrder.SuspendLayout();
            this.grbFilter.SuspendLayout();
            this.grbSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbType
            // 
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(6, 28);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(234, 30);
            this.cmbType.TabIndex = 2;
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);
            // 
            // btnPreviousPage
            // 
            this.btnPreviousPage.Location = new System.Drawing.Point(893, 581);
            this.btnPreviousPage.Name = "btnPreviousPage";
            this.btnPreviousPage.Size = new System.Drawing.Size(25, 25);
            this.btnPreviousPage.TabIndex = 4;
            this.btnPreviousPage.Text = "<";
            this.btnPreviousPage.UseVisualStyleBackColor = true;
            this.btnPreviousPage.Click += new System.EventHandler(this.btnPreviousPage_Click);
            // 
            // btnNextPage
            // 
            this.btnNextPage.Location = new System.Drawing.Point(924, 581);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(25, 25);
            this.btnNextPage.TabIndex = 5;
            this.btnNextPage.Text = ">";
            this.btnNextPage.UseVisualStyleBackColor = true;
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
            // 
            // cmbOrderBy
            // 
            this.cmbOrderBy.FormattingEnabled = true;
            this.cmbOrderBy.Location = new System.Drawing.Point(6, 29);
            this.cmbOrderBy.Name = "cmbOrderBy";
            this.cmbOrderBy.Size = new System.Drawing.Size(228, 30);
            this.cmbOrderBy.TabIndex = 7;
            this.cmbOrderBy.SelectedIndexChanged += new System.EventHandler(this.cmbOrderBy_SelectedIndexChanged);
            // 
            // rbtnUp
            // 
            this.rbtnUp.AutoSize = true;
            this.rbtnUp.Location = new System.Drawing.Point(6, 66);
            this.rbtnUp.Name = "rbtnUp";
            this.rbtnUp.Size = new System.Drawing.Size(141, 26);
            this.rbtnUp.TabIndex = 9;
            this.rbtnUp.TabStop = true;
            this.rbtnUp.Text = "по возрастанию";
            this.rbtnUp.UseVisualStyleBackColor = true;
            this.rbtnUp.CheckedChanged += new System.EventHandler(this.rbtnUp_CheckedChanged);
            // 
            // rbtnDesc
            // 
            this.rbtnDesc.AutoSize = true;
            this.rbtnDesc.Location = new System.Drawing.Point(6, 89);
            this.rbtnDesc.Name = "rbtnDesc";
            this.rbtnDesc.Size = new System.Drawing.Size(121, 26);
            this.rbtnDesc.TabIndex = 10;
            this.rbtnDesc.TabStop = true;
            this.rbtnDesc.Text = "по убыванию";
            this.rbtnDesc.UseVisualStyleBackColor = true;
            this.rbtnDesc.CheckedChanged += new System.EventHandler(this.rbtnDesc_CheckedChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(6, 28);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(316, 29);
            this.txtSearch.TabIndex = 11;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // grbOrder
            // 
            this.grbOrder.Controls.Add(this.cmbOrderBy);
            this.grbOrder.Controls.Add(this.rbtnUp);
            this.grbOrder.Controls.Add(this.rbtnDesc);
            this.grbOrder.Location = new System.Drawing.Point(457, 7);
            this.grbOrder.Name = "grbOrder";
            this.grbOrder.Size = new System.Drawing.Size(240, 122);
            this.grbOrder.TabIndex = 13;
            this.grbOrder.TabStop = false;
            this.grbOrder.Text = "Сортировка";
            // 
            // grbFilter
            // 
            this.grbFilter.Controls.Add(this.cmbType);
            this.grbFilter.Location = new System.Drawing.Point(703, 7);
            this.grbFilter.Name = "grbFilter";
            this.grbFilter.Size = new System.Drawing.Size(246, 76);
            this.grbFilter.TabIndex = 14;
            this.grbFilter.TabStop = false;
            this.grbFilter.Text = "Фильтрация";
            // 
            // grbSearch
            // 
            this.grbSearch.Controls.Add(this.txtSearch);
            this.grbSearch.Location = new System.Drawing.Point(123, 7);
            this.grbSearch.Name = "grbSearch";
            this.grbSearch.Size = new System.Drawing.Size(328, 76);
            this.grbSearch.TabIndex = 15;
            this.grbSearch.TabStop = false;
            this.grbSearch.Text = "Введите значение для поиска";
            // 
            // btnPriceChange
            // 
            this.btnPriceChange.Enabled = false;
            this.btnPriceChange.Location = new System.Drawing.Point(123, 89);
            this.btnPriceChange.Name = "btnPriceChange";
            this.btnPriceChange.Size = new System.Drawing.Size(328, 33);
            this.btnPriceChange.TabIndex = 16;
            this.btnPriceChange.Text = "Изменить стоимость на ...";
            this.btnPriceChange.UseVisualStyleBackColor = true;
            this.btnPriceChange.Visible = false;
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Location = new System.Drawing.Point(703, 89);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(246, 32);
            this.btnAddProduct.TabIndex = 17;
            this.btnAddProduct.Text = "Добавить продукцию";
            this.btnAddProduct.UseVisualStyleBackColor = true;
            // 
            // layoutProducts
            // 
            this.layoutProducts.AutoScroll = true;
            this.layoutProducts.Location = new System.Drawing.Point(13, 134);
            this.layoutProducts.Name = "layoutProducts";
            this.layoutProducts.Size = new System.Drawing.Size(936, 441);
            this.layoutProducts.TabIndex = 18;
            // 
            // ProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 618);
            this.Controls.Add(this.layoutProducts);
            this.Controls.Add(this.btnAddProduct);
            this.Controls.Add(this.btnPriceChange);
            this.Controls.Add(this.grbSearch);
            this.Controls.Add(this.grbFilter);
            this.Controls.Add(this.grbOrder);
            this.Controls.Add(this.btnNextPage);
            this.Controls.Add(this.btnPreviousPage);
            this.Name = "ProductForm";
            this.Text = "Form1";
            this.Controls.SetChildIndex(this.btnPreviousPage, 0);
            this.Controls.SetChildIndex(this.btnNextPage, 0);
            this.Controls.SetChildIndex(this.grbOrder, 0);
            this.Controls.SetChildIndex(this.grbFilter, 0);
            this.Controls.SetChildIndex(this.grbSearch, 0);
            this.Controls.SetChildIndex(this.btnPriceChange, 0);
            this.Controls.SetChildIndex(this.btnAddProduct, 0);
            this.Controls.SetChildIndex(this.layoutProducts, 0);
            this.grbOrder.ResumeLayout(false);
            this.grbOrder.PerformLayout();
            this.grbFilter.ResumeLayout(false);
            this.grbSearch.ResumeLayout(false);
            this.grbSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Button btnPreviousPage;
        private System.Windows.Forms.Button btnNextPage;
        private System.Windows.Forms.ComboBox cmbOrderBy;
        private System.Windows.Forms.RadioButton rbtnUp;
        private System.Windows.Forms.RadioButton rbtnDesc;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.GroupBox grbOrder;
        private System.Windows.Forms.GroupBox grbFilter;
        private System.Windows.Forms.GroupBox grbSearch;
        private System.Windows.Forms.Button btnPriceChange;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.FlowLayoutPanel layoutProducts;
    }
}

