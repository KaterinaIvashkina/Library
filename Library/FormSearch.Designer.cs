namespace Library
{
    partial class FormSearch
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
            this.textBoxQuery = new System.Windows.Forms.TextBox();
            this.buttonFind = new System.Windows.Forms.Button();
            this.dataGridViewSearch = new System.Windows.Forms.DataGridView();
            this.radioButtonBook = new System.Windows.Forms.RadioButton();
            this.radioButtonReader = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxQuery
            // 
            this.textBoxQuery.Location = new System.Drawing.Point(12, 39);
            this.textBoxQuery.Multiline = true;
            this.textBoxQuery.Name = "textBoxQuery";
            this.textBoxQuery.Size = new System.Drawing.Size(533, 23);
            this.textBoxQuery.TabIndex = 0;
            // 
            // buttonFind
            // 
            this.buttonFind.Location = new System.Drawing.Point(551, 39);
            this.buttonFind.Name = "buttonFind";
            this.buttonFind.Size = new System.Drawing.Size(75, 23);
            this.buttonFind.TabIndex = 1;
            this.buttonFind.Text = "Поиск";
            this.buttonFind.UseVisualStyleBackColor = true;
            this.buttonFind.Click += new System.EventHandler(this.buttonFind_Click);
            // 
            // dataGridViewSearch
            // 
            this.dataGridViewSearch.AllowUserToAddRows = false;
            this.dataGridViewSearch.AllowUserToDeleteRows = false;
            this.dataGridViewSearch.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSearch.Location = new System.Drawing.Point(12, 68);
            this.dataGridViewSearch.Name = "dataGridViewSearch";
            this.dataGridViewSearch.ReadOnly = true;
            this.dataGridViewSearch.Size = new System.Drawing.Size(614, 308);
            this.dataGridViewSearch.TabIndex = 2;
            // 
            // radioButtonBook
            // 
            this.radioButtonBook.AutoSize = true;
            this.radioButtonBook.Checked = true;
            this.radioButtonBook.Location = new System.Drawing.Point(12, 12);
            this.radioButtonBook.Name = "radioButtonBook";
            this.radioButtonBook.Size = new System.Drawing.Size(141, 17);
            this.radioButtonBook.TabIndex = 3;
            this.radioButtonBook.TabStop = true;
            this.radioButtonBook.Text = "Искать по списку книг";
            this.radioButtonBook.UseVisualStyleBackColor = true;
            // 
            // radioButtonReader
            // 
            this.radioButtonReader.AutoSize = true;
            this.radioButtonReader.Location = new System.Drawing.Point(159, 12);
            this.radioButtonReader.Name = "radioButtonReader";
            this.radioButtonReader.Size = new System.Drawing.Size(169, 17);
            this.radioButtonReader.TabIndex = 4;
            this.radioButtonReader.TabStop = true;
            this.radioButtonReader.Text = "Искать по списку читателей";
            this.radioButtonReader.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "label1";
            // 
            // FormSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 389);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radioButtonReader);
            this.Controls.Add(this.radioButtonBook);
            this.Controls.Add(this.dataGridViewSearch);
            this.Controls.Add(this.buttonFind);
            this.Controls.Add(this.textBoxQuery);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormSearch";
            this.Load += new System.EventHandler(this.FormSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSearch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxQuery;
        private System.Windows.Forms.Button buttonFind;
        private System.Windows.Forms.DataGridView dataGridViewSearch;
        private System.Windows.Forms.RadioButton radioButtonBook;
        private System.Windows.Forms.RadioButton radioButtonReader;
        private System.Windows.Forms.Label label1;
    }
}