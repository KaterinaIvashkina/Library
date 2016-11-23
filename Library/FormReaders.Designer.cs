namespace Library
{
    partial class FormReaders
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
            this.dataGridReaders = new System.Windows.Forms.DataGridView();
            this.bindingSourceReaders = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridReaders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceReaders)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridReaders
            // 
            this.dataGridReaders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridReaders.Location = new System.Drawing.Point(12, 12);
            this.dataGridReaders.Name = "dataGridReaders";
            this.dataGridReaders.Size = new System.Drawing.Size(466, 283);
            this.dataGridReaders.TabIndex = 0;
            // 
            // FormReaders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 322);
            this.Controls.Add(this.dataGridReaders);
            this.Name = "FormReaders";
            this.Text = "FormReaders";
            this.Load += new System.EventHandler(this.FormReaders_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridReaders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceReaders)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridReaders;
        private System.Windows.Forms.BindingSource bindingSourceReaders;
    }
}