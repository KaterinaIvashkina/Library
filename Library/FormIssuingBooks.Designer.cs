namespace Library
{
    partial class FormIssuingBooks
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
            this.dataGridIssuingBooks = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridIssuingBooks)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridIssuingBooks
            // 
            this.dataGridIssuingBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridIssuingBooks.Location = new System.Drawing.Point(12, 12);
            this.dataGridIssuingBooks.Name = "dataGridIssuingBooks";
            this.dataGridIssuingBooks.Size = new System.Drawing.Size(416, 238);
            this.dataGridIssuingBooks.TabIndex = 0;
            // 
            // FormIssuingBooks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 319);
            this.Controls.Add(this.dataGridIssuingBooks);
            this.Name = "FormIssuingBooks";
            this.Text = "FormIssuingBooks";
            this.Load += new System.EventHandler(this.FormIssuingBooks_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridIssuingBooks)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridIssuingBooks;
    }
}