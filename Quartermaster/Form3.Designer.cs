namespace Quartermaster
{
    partial class FormRename
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
            this.boxRename = new System.Windows.Forms.TextBox();
            this.btnRename = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // boxRename
            // 
            this.boxRename.Location = new System.Drawing.Point(3, 4);
            this.boxRename.Name = "boxRename";
            this.boxRename.Size = new System.Drawing.Size(266, 23);
            this.boxRename.TabIndex = 0;
            // 
            // btnRename
            // 
            this.btnRename.CausesValidation = false;
            this.btnRename.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnRename.Location = new System.Drawing.Point(275, 4);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(75, 23);
            this.btnRename.TabIndex = 1;
            this.btnRename.Text = "OK";
            this.btnRename.UseVisualStyleBackColor = true;
            this.btnRename.Click += new System.EventHandler(this.btnRename_Click);
            // 
            // FormRename
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(358, 32);
            this.Controls.Add(this.btnRename);
            this.Controls.Add(this.boxRename);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormRename";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Enter a new name for this item";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button btnRename;
        public TextBox boxRename;
    }
}