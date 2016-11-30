namespace Library
{
    partial class FormSelect
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
            this.buttonListBooks = new System.Windows.Forms.Button();
            this.buttonListDepart = new System.Windows.Forms.Button();
            this.buttonListOutBooks = new System.Windows.Forms.Button();
            this.buttonListReaders = new System.Windows.Forms.Button();
            this.labelPersonal = new System.Windows.Forms.Label();
            this.labelExit = new System.Windows.Forms.Label();
            this.labelSearch = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonListBooks
            // 
            this.buttonListBooks.Location = new System.Drawing.Point(76, 23);
            this.buttonListBooks.Name = "buttonListBooks";
            this.buttonListBooks.Size = new System.Drawing.Size(146, 23);
            this.buttonListBooks.TabIndex = 3;
            this.buttonListBooks.Text = "Список книг";
            this.buttonListBooks.UseVisualStyleBackColor = true;
            this.buttonListBooks.Click += new System.EventHandler(this.buttonListBooks_Click);
            // 
            // buttonListDepart
            // 
            this.buttonListDepart.Location = new System.Drawing.Point(76, 54);
            this.buttonListDepart.Name = "buttonListDepart";
            this.buttonListDepart.Size = new System.Drawing.Size(146, 23);
            this.buttonListDepart.TabIndex = 4;
            this.buttonListDepart.Text = "Список отделов";
            this.buttonListDepart.UseVisualStyleBackColor = true;
            this.buttonListDepart.Click += new System.EventHandler(this.buttonListDepart_Click);
            // 
            // buttonListOutBooks
            // 
            this.buttonListOutBooks.Location = new System.Drawing.Point(76, 83);
            this.buttonListOutBooks.Name = "buttonListOutBooks";
            this.buttonListOutBooks.Size = new System.Drawing.Size(146, 23);
            this.buttonListOutBooks.TabIndex = 5;
            this.buttonListOutBooks.Text = "Список выданных книг";
            this.buttonListOutBooks.UseVisualStyleBackColor = true;
            this.buttonListOutBooks.Click += new System.EventHandler(this.buttonListOutBooks_Click);
            // 
            // buttonListReaders
            // 
            this.buttonListReaders.Location = new System.Drawing.Point(76, 113);
            this.buttonListReaders.Name = "buttonListReaders";
            this.buttonListReaders.Size = new System.Drawing.Size(146, 23);
            this.buttonListReaders.TabIndex = 6;
            this.buttonListReaders.Text = "Список читателей";
            this.buttonListReaders.UseVisualStyleBackColor = true;
            this.buttonListReaders.Click += new System.EventHandler(this.buttonListReaders_Click);
            // 
            // labelPersonal
            // 
            this.labelPersonal.AutoSize = true;
            this.labelPersonal.Location = new System.Drawing.Point(246, 24);
            this.labelPersonal.Name = "labelPersonal";
            this.labelPersonal.Size = new System.Drawing.Size(90, 13);
            this.labelPersonal.TabIndex = 7;
            this.labelPersonal.Text = "Личный кабинет";
            this.labelPersonal.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelExit
            // 
            this.labelExit.AutoSize = true;
            this.labelExit.Location = new System.Drawing.Point(297, 123);
            this.labelExit.Name = "labelExit";
            this.labelExit.Size = new System.Drawing.Size(39, 13);
            this.labelExit.TabIndex = 8;
            this.labelExit.Text = "Выход";
            this.labelExit.Click += new System.EventHandler(this.labelExit_Click);
            // 
            // labelSearch
            // 
            this.labelSearch.AutoSize = true;
            this.labelSearch.Location = new System.Drawing.Point(297, 9);
            this.labelSearch.Name = "labelSearch";
            this.labelSearch.Size = new System.Drawing.Size(39, 13);
            this.labelSearch.TabIndex = 9;
            this.labelSearch.Text = "Поиск";
            this.labelSearch.Click += new System.EventHandler(this.labelSearch_Click);
            // 
            // FormSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(348, 154);
            this.Controls.Add(this.labelSearch);
            this.Controls.Add(this.labelExit);
            this.Controls.Add(this.labelPersonal);
            this.Controls.Add(this.buttonListReaders);
            this.Controls.Add(this.buttonListOutBooks);
            this.Controls.Add(this.buttonListDepart);
            this.Controls.Add(this.buttonListBooks);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добро пожаловать в систему";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonListBooks;
        private System.Windows.Forms.Button buttonListDepart;
        private System.Windows.Forms.Button buttonListOutBooks;
        private System.Windows.Forms.Button buttonListReaders;
        private System.Windows.Forms.Label labelPersonal;
        private System.Windows.Forms.Label labelExit;
        private System.Windows.Forms.Label labelSearch;
    }
}