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
            this.components = new System.ComponentModel.Container();
            this.dataGridIssuingBooks = new System.Windows.Forms.DataGridView();
            //this.mylibraryDataSet = new Library.mylibraryDataSet();
            this.issuingbooksBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.idissuingDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idlibrarykardDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idlibrarycipherDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateissuingDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datereturnDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iddepartmentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridIssuingBooks)).BeginInit();
            //((System.ComponentModel.ISupportInitialize)(this.mylibraryDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.issuingbooksBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridIssuingBooks
            // 
            this.dataGridIssuingBooks.AutoGenerateColumns = false;
            this.dataGridIssuingBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridIssuingBooks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idissuingDataGridViewTextBoxColumn,
            this.idlibrarykardDataGridViewTextBoxColumn,
            this.idlibrarycipherDataGridViewTextBoxColumn,
            this.dateissuingDataGridViewTextBoxColumn,
            this.datereturnDataGridViewTextBoxColumn,
            this.iddepartmentDataGridViewTextBoxColumn});
            this.dataGridIssuingBooks.DataSource = this.issuingbooksBindingSource;
            this.dataGridIssuingBooks.Location = new System.Drawing.Point(12, 12);
            this.dataGridIssuingBooks.Name = "dataGridIssuingBooks";
            this.dataGridIssuingBooks.Size = new System.Drawing.Size(643, 269);
            this.dataGridIssuingBooks.TabIndex = 0;
            // 
            // mylibraryDataSet
            // 
            //this.mylibraryDataSet.DataSetName = "mylibraryDataSet";
            //this.mylibraryDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // issuingbooksBindingSource
            // 
            this.issuingbooksBindingSource.DataMember = "issuing_books";
            //this.issuingbooksBindingSource.DataSource = this.mylibraryDataSet;
            // 
            // idissuingDataGridViewTextBoxColumn
            // 
            this.idissuingDataGridViewTextBoxColumn.DataPropertyName = "id_issuing";
            this.idissuingDataGridViewTextBoxColumn.HeaderText = "id_issuing";
            this.idissuingDataGridViewTextBoxColumn.Name = "idissuingDataGridViewTextBoxColumn";
            // 
            // idlibrarykardDataGridViewTextBoxColumn
            // 
            this.idlibrarykardDataGridViewTextBoxColumn.DataPropertyName = "id_library_kard";
            this.idlibrarykardDataGridViewTextBoxColumn.HeaderText = "id_library_kard";
            this.idlibrarykardDataGridViewTextBoxColumn.Name = "idlibrarykardDataGridViewTextBoxColumn";
            // 
            // idlibrarycipherDataGridViewTextBoxColumn
            // 
            this.idlibrarycipherDataGridViewTextBoxColumn.DataPropertyName = "id_library_cipher";
            this.idlibrarycipherDataGridViewTextBoxColumn.HeaderText = "id_library_cipher";
            this.idlibrarycipherDataGridViewTextBoxColumn.Name = "idlibrarycipherDataGridViewTextBoxColumn";
            // 
            // dateissuingDataGridViewTextBoxColumn
            // 
            this.dateissuingDataGridViewTextBoxColumn.DataPropertyName = "date_issuing";
            this.dateissuingDataGridViewTextBoxColumn.HeaderText = "date_issuing";
            this.dateissuingDataGridViewTextBoxColumn.Name = "dateissuingDataGridViewTextBoxColumn";
            // 
            // datereturnDataGridViewTextBoxColumn
            // 
            this.datereturnDataGridViewTextBoxColumn.DataPropertyName = "date_return";
            this.datereturnDataGridViewTextBoxColumn.HeaderText = "date_return";
            this.datereturnDataGridViewTextBoxColumn.Name = "datereturnDataGridViewTextBoxColumn";
            // 
            // iddepartmentDataGridViewTextBoxColumn
            // 
            this.iddepartmentDataGridViewTextBoxColumn.DataPropertyName = "id_department";
            this.iddepartmentDataGridViewTextBoxColumn.HeaderText = "id_department";
            this.iddepartmentDataGridViewTextBoxColumn.Name = "iddepartmentDataGridViewTextBoxColumn";
            // 
            // FormIssuingBooks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 338);
            this.Controls.Add(this.dataGridIssuingBooks);
            this.Name = "FormIssuingBooks";
            this.Text = "FormIssuingBooks";
            this.Load += new System.EventHandler(this.FormIssuingBooks_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridIssuingBooks)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this.mylibraryDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.issuingbooksBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridIssuingBooks;
        private System.Windows.Forms.DataGridViewTextBoxColumn idissuingDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idlibrarykardDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idlibrarycipherDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateissuingDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn datereturnDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iddepartmentDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource issuingbooksBindingSource;
        //private mylibraryDataSet mylibraryDataSet;
    }
}