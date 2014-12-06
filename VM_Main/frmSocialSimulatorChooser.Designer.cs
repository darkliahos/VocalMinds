namespace VM_Main
{
    partial class FrmSocialSimulatorChooser
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
            this.lstScenarios = new System.Windows.Forms.ListBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstScenarios
            // 
            this.lstScenarios.FormattingEnabled = true;
            this.lstScenarios.Location = new System.Drawing.Point(13, 13);
            this.lstScenarios.Name = "lstScenarios";
            this.lstScenarios.Size = new System.Drawing.Size(293, 381);
            this.lstScenarios.TabIndex = 0;
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(134, 400);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 1;
            this.btnSelect.Text = "Select";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // FrmSocialSimulatorChooser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(318, 432);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.lstScenarios);
            this.Name = "FrmSocialSimulatorChooser";
            this.Text = "Choose your Scenario...";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstScenarios;
        private System.Windows.Forms.Button btnSelect;
    }
}