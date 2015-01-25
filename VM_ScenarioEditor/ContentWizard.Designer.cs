namespace VM_ScenarioEditor
{
    partial class ContentWizard
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
            this.lstContent = new System.Windows.Forms.ListBox();
            this.lstContentTypes = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstContent
            // 
            this.lstContent.FormattingEnabled = true;
            this.lstContent.Location = new System.Drawing.Point(280, 40);
            this.lstContent.Name = "lstContent";
            this.lstContent.Size = new System.Drawing.Size(278, 407);
            this.lstContent.TabIndex = 1;
            // 
            // lstContentTypes
            // 
            this.lstContentTypes.FormattingEnabled = true;
            this.lstContentTypes.Location = new System.Drawing.Point(4, 41);
            this.lstContentTypes.Name = "lstContentTypes";
            this.lstContentTypes.Size = new System.Drawing.Size(273, 407);
            this.lstContentTypes.TabIndex = 2;
            this.lstContentTypes.SelectedValueChanged += new System.EventHandler(this.lstContentTypes_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Content Type:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(280, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Contents";
            // 
            // ContentWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 460);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstContentTypes);
            this.Controls.Add(this.lstContent);
            this.Name = "ContentWizard";
            this.Text = "ContentWizard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstContent;
        private System.Windows.Forms.ListBox lstContentTypes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}