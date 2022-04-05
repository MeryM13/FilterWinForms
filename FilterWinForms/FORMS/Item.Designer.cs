
namespace FilterWinForms.FORMS
{
    partial class Item
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.Img = new System.Windows.Forms.PictureBox();
            this.lblType = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.lblMaterials = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Img)).BeginInit();
            this.SuspendLayout();
            // 
            // Img
            // 
            this.Img.ImageLocation = "";
            this.Img.Location = new System.Drawing.Point(18, 24);
            this.Img.Margin = new System.Windows.Forms.Padding(6, 12, 6, 12);
            this.Img.Name = "Img";
            this.Img.Size = new System.Drawing.Size(126, 103);
            this.Img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Img.TabIndex = 0;
            this.Img.TabStop = false;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Gabriola", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblType.Location = new System.Drawing.Point(156, 13);
            this.lblType.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(156, 50);
            this.lblType.TabIndex = 1;
            this.lblType.Text = "Тип продукта";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(321, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 50);
            this.label1.TabIndex = 2;
            this.label1.Text = "|";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(358, 13);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(263, 50);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "Наименование продукта";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(729, 13);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(136, 50);
            this.lblPrice.TabIndex = 4;
            this.lblPrice.Text = "Стоимость";
            this.lblPrice.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Gabriola", 14F, System.Drawing.FontStyle.Bold);
            this.lblID.Location = new System.Drawing.Point(159, 54);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(77, 35);
            this.lblID.TabIndex = 5;
            this.lblID.Text = "Артикул";
            // 
            // lblMaterials
            // 
            this.lblMaterials.AutoSize = true;
            this.lblMaterials.Font = new System.Drawing.Font("Gabriola", 14F, System.Drawing.FontStyle.Bold);
            this.lblMaterials.Location = new System.Drawing.Point(159, 79);
            this.lblMaterials.Name = "lblMaterials";
            this.lblMaterials.Size = new System.Drawing.Size(102, 35);
            this.lblMaterials.TabIndex = 6;
            this.lblMaterials.Text = "Материалы:";
            // 
            // Item
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 50F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblMaterials);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.Img);
            this.Font = new System.Drawing.Font("Gabriola", 20F, System.Drawing.FontStyle.Bold);
            this.Margin = new System.Windows.Forms.Padding(6, 12, 6, 12);
            this.Name = "Item";
            this.Size = new System.Drawing.Size(879, 150);
            ((System.ComponentModel.ISupportInitialize)(this.Img)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Img;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblMaterials;
    }
}
