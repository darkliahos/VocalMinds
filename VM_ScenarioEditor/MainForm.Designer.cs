namespace VM_ScenarioEditor
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newScenarioFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scenariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contentImporterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.faceRecognitionScenariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.scenariosToolStripMenuItem,
            this.contentImporterToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1326, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newScenarioFileToolStripMenuItem,
            this.saveAllToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newScenarioFileToolStripMenuItem
            // 
            this.newScenarioFileToolStripMenuItem.Name = "newScenarioFileToolStripMenuItem";
            this.newScenarioFileToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.newScenarioFileToolStripMenuItem.Text = "&New Scenario File";
            // 
            // saveAllToolStripMenuItem
            // 
            this.saveAllToolStripMenuItem.Name = "saveAllToolStripMenuItem";
            this.saveAllToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.saveAllToolStripMenuItem.Text = "Save All";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            // 
            // scenariosToolStripMenuItem
            // 
            this.scenariosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.faceRecognitionScenariosToolStripMenuItem});
            this.scenariosToolStripMenuItem.Name = "scenariosToolStripMenuItem";
            this.scenariosToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.scenariosToolStripMenuItem.Text = "Scenarios";
            // 
            // contentImporterToolStripMenuItem
            // 
            this.contentImporterToolStripMenuItem.Name = "contentImporterToolStripMenuItem";
            this.contentImporterToolStripMenuItem.Size = new System.Drawing.Size(111, 20);
            this.contentImporterToolStripMenuItem.Text = "Content Importer";
            // 
            // faceRecognitionScenariosToolStripMenuItem
            // 
            this.faceRecognitionScenariosToolStripMenuItem.Name = "faceRecognitionScenariosToolStripMenuItem";
            this.faceRecognitionScenariosToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.faceRecognitionScenariosToolStripMenuItem.Text = "Face Recognition Scenarios";
            this.faceRecognitionScenariosToolStripMenuItem.Click += new System.EventHandler(this.faceRecognitionScenariosToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1326, 762);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Scenario Editor";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newScenarioFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scenariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contentImporterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem faceRecognitionScenariosToolStripMenuItem;
    }
}

