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
            this.bindingSourceBooks = new System.Windows.Forms.BindingSource(this.components);
            this.splitContainerDepBooks = new System.Windows.Forms.SplitContainer();
            this.checkedListBoxDB = new System.Windows.Forms.CheckedListBox();
            this.dataGridBooks = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.buttonBooking = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonIssuing = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceBooks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerDepBooks)).BeginInit();
            this.splitContainerDepBooks.Panel1.SuspendLayout();
            this.splitContainerDepBooks.Panel2.SuspendLayout();
            this.splitContainerDepBooks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridBooks)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerDepBooks
            // 
            this.splitContainerDepBooks.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerDepBooks.Location = new System.Drawing.Point(12, 29);
            this.splitContainerDepBooks.Name = "splitContainerDepBooks";
            // 
            // splitContainerDepBooks.Panel1
            // 
            this.splitContainerDepBooks.Panel1.Controls.Add(this.buttonAdd);
            this.splitContainerDepBooks.Panel1.Controls.Add(this.buttonDelete);
            this.splitContainerDepBooks.Panel1.Controls.Add(this.checkedListBoxDB);
            this.splitContainerDepBooks.Panel1.Controls.Add(this.buttonIssuing);
            this.splitContainerDepBooks.Panel1.Controls.Add(this.buttonBooking);
            this.splitContainerDepBooks.Panel1.Controls.Add(this.buttonSave);
            // 
            // splitContainerDepBooks.Panel2
            // 
            this.splitContainerDepBooks.Panel2.Controls.Add(this.dataGridBooks);
            this.splitContainerDepBooks.Panel2MinSize = 400;
            this.splitContainerDepBooks.Size = new System.Drawing.Size(904, 490);
            this.splitContainerDepBooks.SplitterDistance = 199;
            this.splitContainerDepBooks.TabIndex = 1;
            // 
            // checkedListBoxDB
            // 
            this.checkedListBoxDB.CheckOnClick = true;
            this.checkedListBoxDB.FormattingEnabled = true;
            this.checkedListBoxDB.Location = new System.Drawing.Point(0, 0);
            this.checkedListBoxDB.Name = "checkedListBoxDB";
            this.checkedListBoxDB.Size = new System.Drawing.Size(199, 169);
            this.checkedListBoxDB.TabIndex = 0;
            this.checkedListBoxDB.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxDB_ItemCheck);
            this.checkedListBoxDB.SelectedIndexChanged += new System.EventHandler(this.checkedListBoxDB_SelectedIndexChanged);
            // 
            // dataGridBooks
            // 
            this.dataGridBooks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridBooks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridBooks.Location = new System.Drawing.Point(0, 0);
            this.dataGridBooks.Name = "dataGridBooks";
            this.dataGridBooks.Size = new System.Drawing.Size(701, 490);
            this.dataGridBooks.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 522);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(933, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatus
            // 
            this.toolStripStatus.Name = "toolStripStatus";
            this.toolStripStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // buttonBooking
            // 
            this.buttonBooking.Location = new System.Drawing.Point(28, 262);
            this.buttonBooking.Name = "buttonBooking";
            this.buttonBooking.Size = new System.Drawing.Size(134, 23);
            this.buttonBooking.TabIndex = 3;
            this.buttonBooking.Text = "Забронировать";
            this.buttonBooking.UseVisualStyleBackColor = true;
            this.buttonBooking.Click += new System.EventHandler(this.buttonBooking_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(28, 204);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(134, 23);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "Сохранить изменения";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonIssuing
            // 
            this.buttonIssuing.Location = new System.Drawing.Point(28, 291);
            this.buttonIssuing.Name = "buttonIssuing";
            this.buttonIssuing.Size = new System.Drawing.Size(134, 23);
            this.buttonIssuing.TabIndex = 5;
            this.buttonIssuing.Text = "Выдать читателю";
            this.buttonIssuing.UseVisualStyleBackColor = true;
            this.buttonIssuing.Click += new System.EventHandler(this.buttonIssuing_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(28, 233);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(134, 23);
            this.buttonDelete.TabIndex = 7;
            this.buttonDelete.Text = "Удалить";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(28, 175);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(134, 23);
            this.buttonAdd.TabIndex = 8;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            // 
            // FormBooks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 544);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.splitContainerDepBooks);
            this.Name = "FormBooks";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Книжный фонд";
            this.Load += new System.EventHandler(this.FormBooks_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceBooks)).EndInit();
            this.splitContainerDepBooks.Panel1.ResumeLayout(false);
            this.splitContainerDepBooks.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerDepBooks)).EndInit();
            this.splitContainerDepBooks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridBooks)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerDepBooks;
        private System.Windows.Forms.BindingSource bindingSourceBooks;
        private System.Windows.Forms.CheckedListBox checkedListBoxDB;
        private System.Windows.Forms.DataGridView dataGridBooks;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatus;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button buttonBooking;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonIssuing;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonAdd;
    }
}