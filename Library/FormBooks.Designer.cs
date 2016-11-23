namespace Library
{
    partial class FormBooks
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridBooks = new System.Windows.Forms.DataGridView();
            this.bindingSourceBooks = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridBooks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceBooks)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridBooks
            // 
            this.dataGridBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridBooks.Location = new System.Drawing.Point(12, 12);
            this.dataGridBooks.Name = "dataGridBooks";
            this.dataGridBooks.Size = new System.Drawing.Size(647, 426);
            this.dataGridBooks.TabIndex = 0;
            // 
            // FormBooks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 488);
            this.Controls.Add(this.dataGridBooks);
            this.Name = "FormBooks";
            this.Text = "FormBooks";
            this.Load += new System.EventHandler(this.FormBooks_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridBooks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceBooks)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridBooks;
        private System.Windows.Forms.BindingSource bindingSourceBooks;
    }
}