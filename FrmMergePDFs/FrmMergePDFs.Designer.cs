namespace FrmMergePDFs
{
    partial class FrmMergePDFs
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbxPaths = new System.Windows.Forms.ListBox();
            this.btnAddPDF = new System.Windows.Forms.Button();
            this.btnMoveItemUp = new System.Windows.Forms.Button();
            this.btnMoveItemDown = new System.Windows.Forms.Button();
            this.btnMergePDFs = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnRemoveAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbxPaths
            // 
            this.lbxPaths.FormattingEnabled = true;
            this.lbxPaths.Location = new System.Drawing.Point(12, 12);
            this.lbxPaths.Name = "lbxPaths";
            this.lbxPaths.DisplayMember = "Name";
            this.lbxPaths.Size = new System.Drawing.Size(203, 420);
            this.lbxPaths.TabIndex = 0;
            this.lbxPaths.TabStop = false;
            this.lbxPaths.DoubleClick += new System.EventHandler(this.BtnAddPDF_Click);
            // 
            // btnAddPDF
            // 
            this.btnAddPDF.Location = new System.Drawing.Point(221, 12);
            this.btnAddPDF.Name = "btnAddPDF";
            this.btnAddPDF.Size = new System.Drawing.Size(75, 23);
            this.btnAddPDF.TabIndex = 0;
            this.btnAddPDF.Text = "Add PDF";
            this.btnAddPDF.UseVisualStyleBackColor = true;
            this.btnAddPDF.Click += new System.EventHandler(this.BtnAddPDF_Click);
            // 
            // btnMoveItemUp
            // 
            this.btnMoveItemUp.Location = new System.Drawing.Point(221, 60);
            this.btnMoveItemUp.Name = "btnMoveItemUp";
            this.btnMoveItemUp.Size = new System.Drawing.Size(75, 23);
            this.btnMoveItemUp.TabIndex = 1;
            this.btnMoveItemUp.Text = "UP";
            this.btnMoveItemUp.UseVisualStyleBackColor = true;
            this.btnMoveItemUp.Click += new System.EventHandler(this.BtnMoveItemUp_Click);
            // 
            // btnMoveItemDown
            // 
            this.btnMoveItemDown.Location = new System.Drawing.Point(221, 89);
            this.btnMoveItemDown.Name = "btnMoveItemDown";
            this.btnMoveItemDown.Size = new System.Drawing.Size(75, 23);
            this.btnMoveItemDown.TabIndex = 2;
            this.btnMoveItemDown.Text = "Down";
            this.btnMoveItemDown.UseVisualStyleBackColor = true;
            this.btnMoveItemDown.Click += new System.EventHandler(this.BtnMoveItemDown_Click);
            // 
            // btnMergePDFs
            // 
            this.btnMergePDFs.Location = new System.Drawing.Point(222, 408);
            this.btnMergePDFs.Name = "btnMergePDFs";
            this.btnMergePDFs.Size = new System.Drawing.Size(153, 23);
            this.btnMergePDFs.TabIndex = 3;
            this.btnMergePDFs.Text = "Merge PDF\'s";
            this.btnMergePDFs.UseVisualStyleBackColor = true;
            this.btnMergePDFs.Click += new System.EventHandler(this.BtnMergePDFs_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(12, 438);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 4;
            this.btnRemove.TabStop = false;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.BtnRemove_Click);
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.Location = new System.Drawing.Point(140, 438);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveAll.TabIndex = 5;
            this.btnRemoveAll.TabStop = false;
            this.btnRemoveAll.Text = "Remove all";
            this.btnRemoveAll.UseVisualStyleBackColor = true;
            this.btnRemoveAll.Click += new System.EventHandler(this.BtnRemoveAll_Click);
            // 
            // FrmMergePDFs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 470);
            this.Controls.Add(this.btnRemoveAll);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnMergePDFs);
            this.Controls.Add(this.btnMoveItemDown);
            this.Controls.Add(this.btnMoveItemUp);
            this.Controls.Add(this.btnAddPDF);
            this.Controls.Add(this.lbxPaths);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmMergePDFs";
            this.ShowIcon = false;
            this.Text = "Merge PDF\'s";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMergePDFs_FormClosing);
            this.Load += new System.EventHandler(this.FrmMergePDFs_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbxPaths;
        private System.Windows.Forms.Button btnAddPDF;
        private System.Windows.Forms.Button btnMoveItemUp;
        private System.Windows.Forms.Button btnMoveItemDown;
        private System.Windows.Forms.Button btnMergePDFs;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnRemoveAll;
    }
}

