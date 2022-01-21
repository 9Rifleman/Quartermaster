namespace Quartermaster
{
    partial class formSave
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
            this.lblSaveQuery = new System.Windows.Forms.Label();
            this.btnYes = new System.Windows.Forms.Button();
            this.btnNo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblSaveQuery
            // 
            this.lblSaveQuery.Location = new System.Drawing.Point(17, 9);
            this.lblSaveQuery.Name = "lblSaveQuery";
            this.lblSaveQuery.Size = new System.Drawing.Size(290, 63);
            this.lblSaveQuery.TabIndex = 0;
            this.lblSaveQuery.Text = "Data file not found in the chosen folder. It will be created the next time you sa" +
    "ve. Click OK to confirm the path or Source... to choose a different one.";
            this.lblSaveQuery.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnYes
            // 
            this.btnYes.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnYes.Location = new System.Drawing.Point(72, 75);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(75, 23);
            this.btnYes.TabIndex = 1;
            this.btnYes.Text = "OK";
            this.btnYes.UseVisualStyleBackColor = true;
            // 
            // btnNo
            // 
            this.btnNo.DialogResult = System.Windows.Forms.DialogResult.TryAgain;
            this.btnNo.Location = new System.Drawing.Point(169, 75);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(75, 23);
            this.btnNo.TabIndex = 2;
            this.btnNo.Text = "Source...";
            this.btnNo.UseVisualStyleBackColor = true;
            // 
            // formSave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 111);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.btnYes);
            this.Controls.Add(this.lblSaveQuery);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "formSave";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "QMsource.csv not found";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private Label lblSaveQuery;
        private Button btnYes;
        private Button btnNo;
    }
}