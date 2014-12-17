namespace VM_ScenarioEditor
{
    partial class FaceRecongitionScenarioEditorList
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
            this.btnNewScenario = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstScenarios
            // 
            this.lstScenarios.FormattingEnabled = true;
            this.lstScenarios.Location = new System.Drawing.Point(12, 46);
            this.lstScenarios.Name = "lstScenarios";
            this.lstScenarios.Size = new System.Drawing.Size(259, 394);
            this.lstScenarios.TabIndex = 0;
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(288, 46);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 1;
            this.btnSelect.Text = "Select";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnNewScenario
            // 
            this.btnNewScenario.Location = new System.Drawing.Point(288, 417);
            this.btnNewScenario.Name = "btnNewScenario";
            this.btnNewScenario.Size = new System.Drawing.Size(75, 23);
            this.btnNewScenario.TabIndex = 2;
            this.btnNewScenario.Text = "&New";
            this.btnNewScenario.UseVisualStyleBackColor = true;
            this.btnNewScenario.Click += new System.EventHandler(this.btnNewScenario_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(248, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Face Recognition Scenarios";
            // 
            // FaceRecongitionScenarioEditorList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 465);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnNewScenario);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.lstScenarios);
            this.Name = "FaceRecongitionScenarioEditorList";
            this.Text = "FaceRecongitionScenarioEditorList";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstScenarios;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnNewScenario;
        private System.Windows.Forms.Label label1;
    }
}