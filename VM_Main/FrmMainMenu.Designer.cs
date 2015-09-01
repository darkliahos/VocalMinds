namespace VM_Main
{
    partial class FrmMainMenu
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
            this.btnscrg = new System.Windows.Forms.Button();
            this.btnstartface = new System.Windows.Forms.Button();
            this.btnvoicetones = new System.Windows.Forms.Button();
            this.btnScenarioEditor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnscrg
            // 
            this.btnscrg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnscrg.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnscrg.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnscrg.Image = global::VM_Main.Properties.Resources.socialgamebutton;
            this.btnscrg.Location = new System.Drawing.Point(31, 55);
            this.btnscrg.Name = "btnscrg";
            this.btnscrg.Size = new System.Drawing.Size(632, 249);
            this.btnscrg.TabIndex = 1;
            this.btnscrg.UseVisualStyleBackColor = false;
            this.btnscrg.Click += new System.EventHandler(this.btnscrg_Click);
            // 
            // btnstartface
            // 
            this.btnstartface.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnstartface.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnstartface.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnstartface.Image = global::VM_Main.Properties.Resources.guessexpressiongamebutton;
            this.btnstartface.Location = new System.Drawing.Point(27, 331);
            this.btnstartface.Name = "btnstartface";
            this.btnstartface.Size = new System.Drawing.Size(636, 226);
            this.btnstartface.TabIndex = 2;
            this.btnstartface.UseVisualStyleBackColor = false;
            this.btnstartface.Click += new System.EventHandler(this.btnstartface_Click);
            // 
            // btnvoicetones
            // 
            this.btnvoicetones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnvoicetones.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnvoicetones.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnvoicetones.Image = global::VM_Main.Properties.Resources.guessthatvoice;
            this.btnvoicetones.Location = new System.Drawing.Point(683, 57);
            this.btnvoicetones.Name = "btnvoicetones";
            this.btnvoicetones.Size = new System.Drawing.Size(635, 245);
            this.btnvoicetones.TabIndex = 3;
            this.btnvoicetones.UseVisualStyleBackColor = false;
            this.btnvoicetones.Click += new System.EventHandler(this.btnvoicetones_Click);
            // 
            // btnScenarioEditor
            // 
            this.btnScenarioEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnScenarioEditor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnScenarioEditor.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScenarioEditor.Image = global::VM_Main.Properties.Resources._8iEjdppyT;
            this.btnScenarioEditor.Location = new System.Drawing.Point(683, 331);
            this.btnScenarioEditor.Name = "btnScenarioEditor";
            this.btnScenarioEditor.Size = new System.Drawing.Size(636, 226);
            this.btnScenarioEditor.TabIndex = 4;
            this.btnScenarioEditor.UseVisualStyleBackColor = false;
            this.btnScenarioEditor.Click += new System.EventHandler(this.btnScenarioEditor_Click);
            // 
            // FrmMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1326, 593);
            this.Controls.Add(this.btnScenarioEditor);
            this.Controls.Add(this.btnvoicetones);
            this.Controls.Add(this.btnstartface);
            this.Controls.Add(this.btnscrg);
            this.Name = "FrmMainMenu";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Vocal Mind V0.1A";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnscrg;
        private System.Windows.Forms.Button btnstartface;
        private System.Windows.Forms.Button btnvoicetones;
        private System.Windows.Forms.Button btnScenarioEditor;
    }
}

