namespace Library
{
    partial class FormIssuingBookReader
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxReaders = new System.Windows.Forms.ComboBox();
            this.readerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mylibraryDataSet = new Library.mylibraryDataSet();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxDepartment = new System.Windows.Forms.ComboBox();
            this.departmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.readerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mylibraryDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.departmentBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(75, 154);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Выдать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 39);
            this.label1.TabIndex = 2;
            this.label1.Text = "Введите номер читательского билета\r\n      читателя и отдел библиотеки\r\n          " +
    "или выберите из списка";
            // 
            // comboBoxReaders
            // 
            this.comboBoxReaders.FormattingEnabled = true;
            this.comboBoxReaders.Location = new System.Drawing.Point(23, 75);
            this.comboBoxReaders.Name = "comboBoxReaders";
            this.comboBoxReaders.Size = new System.Drawing.Size(174, 21);
            this.comboBoxReaders.TabIndex = 3;
            this.comboBoxReaders.ValueMember = "name_reader";
            // 
            // readerBindingSource
            // 
            this.readerBindingSource.DataMember = "reader";
            this.readerBindingSource.DataSource = this.mylibraryDataSet;
            // 
            // mylibraryDataSet
            // 
            this.mylibraryDataSet.DataSetName = "mylibraryDataSet";
            this.mylibraryDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Номер читательского билета:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Отдел:";
            // 
            // comboBoxDepartment
            // 
            this.comboBoxDepartment.FormattingEnabled = true;
            this.comboBoxDepartment.Location = new System.Drawing.Point(23, 115);
            this.comboBoxDepartment.Name = "comboBoxDepartment";
            this.comboBoxDepartment.Size = new System.Drawing.Size(174, 21);
            this.comboBoxDepartment.TabIndex = 6;
            this.comboBoxDepartment.ValueMember = "id_department";
            // 
            // departmentBindingSource
            // 
            this.departmentBindingSource.DataMember = "department";
            this.departmentBindingSource.DataSource = this.mylibraryDataSet;
            // 
            // FormIssuingBookReader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(229, 189);
            this.Controls.Add(this.comboBoxDepartment);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxReaders);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "FormIssuingBookReader";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выдача книги";
            this.Load += new System.EventHandler(this.FormIssuingBookReader_Load);
            ((System.ComponentModel.ISupportInitialize)(this.readerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mylibraryDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.departmentBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxReaders;
        private System.Windows.Forms.BindingSource readerBindingSource;
        private mylibraryDataSet mylibraryDataSet;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxDepartment;
        private System.Windows.Forms.BindingSource departmentBindingSource;
    }
}