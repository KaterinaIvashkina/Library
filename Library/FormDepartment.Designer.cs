namespace Library
{
    partial class FormDepartment
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
            this.dataGridDepartment = new System.Windows.Forms.DataGridView();
            this.bindingSourceDepartment = new System.Windows.Forms.BindingSource(this.components);
            this.buttonSaveChange = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDepartment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDepartment)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridDepartment
            // 
            this.dataGridDepartment.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridDepartment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDepartment.Location = new System.Drawing.Point(12, 12);
            this.dataGridDepartment.Name = "dataGridDepartment";
            this.dataGridDepartment.Size = new System.Drawing.Size(555, 248);
            this.dataGridDepartment.TabIndex = 0;
            // 
            // buttonSaveChange
            // 
            this.buttonSaveChange.Location = new System.Drawing.Point(618, 34);
            this.buttonSaveChange.Name = "buttonSaveChange";
            this.buttonSaveChange.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveChange.TabIndex = 1;
            this.buttonSaveChange.Text = "Сохранить изменения";
            this.buttonSaveChange.UseVisualStyleBackColor = true;
            this.buttonSaveChange.Click += new System.EventHandler(this.buttonSaveChange_Click);
            // 
            // FormDepartment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 280);
            this.Controls.Add(this.buttonSaveChange);
            this.Controls.Add(this.dataGridDepartment);
            this.Name = "FormDepartment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormDepartment";
            this.Load += new System.EventHandler(this.FormDepartment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDepartment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDepartment)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridDepartment;
        private System.Windows.Forms.BindingSource bindingSourceDepartment;
        private System.Windows.Forms.Button buttonSaveChange;
    }
}