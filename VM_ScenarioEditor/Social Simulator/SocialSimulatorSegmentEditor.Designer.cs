namespace VM_ScenarioEditor
{
    partial class SocialSimulatorSegmentEditor
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
            this.btnSelectContentWizard = new System.Windows.Forms.Button();
            this.txtAnswerSingle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtVideoName = new System.Windows.Forms.TextBox();
            this.lstAnswers = new System.Windows.Forms.ListBox();
            this.txtPlayOrder = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblanswers = new System.Windows.Forms.Label();
            this.lblVideoPath = new System.Windows.Forms.Label();
            this.lblQTitle = new System.Windows.Forms.Label();
            this.btnAddAnswers = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboResponseType = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.cboNextSegment = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSelectContentWizard
            // 
            this.btnSelectContentWizard.Location = new System.Drawing.Point(397, 68);
            this.btnSelectContentWizard.Name = "btnSelectContentWizard";
            this.btnSelectContentWizard.Size = new System.Drawing.Size(75, 23);
            this.btnSelectContentWizard.TabIndex = 48;
            this.btnSelectContentWizard.Text = "Select";
            this.btnSelectContentWizard.UseVisualStyleBackColor = true;
            this.btnSelectContentWizard.Click += new System.EventHandler(this.btnSelectContentWizard_Click);
            // 
            // txtAnswerSingle
            // 
            this.txtAnswerSingle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAnswerSingle.Location = new System.Drawing.Point(103, 19);
            this.txtAnswerSingle.Name = "txtAnswerSingle";
            this.txtAnswerSingle.Size = new System.Drawing.Size(132, 29);
            this.txtAnswerSingle.TabIndex = 45;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 25);
            this.label2.TabIndex = 44;
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(316, 457);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 43;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtVideoName
            // 
            this.txtVideoName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVideoName.Location = new System.Drawing.Point(195, 64);
            this.txtVideoName.Name = "txtVideoName";
            this.txtVideoName.ReadOnly = true;
            this.txtVideoName.Size = new System.Drawing.Size(196, 29);
            this.txtVideoName.TabIndex = 42;
            // 
            // lstAnswers
            // 
            this.lstAnswers.FormattingEnabled = true;
            this.lstAnswers.Location = new System.Drawing.Point(195, 114);
            this.lstAnswers.Name = "lstAnswers";
            this.lstAnswers.Size = new System.Drawing.Size(172, 121);
            this.lstAnswers.TabIndex = 41;
            // 
            // txtPlayOrder
            // 
            this.txtPlayOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPlayOrder.Location = new System.Drawing.Point(195, 410);
            this.txtPlayOrder.Name = "txtPlayOrder";
            this.txtPlayOrder.Size = new System.Drawing.Size(193, 29);
            this.txtPlayOrder.TabIndex = 39;
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(195, 29);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(196, 29);
            this.txtDescription.TabIndex = 38;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 410);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 25);
            this.label3.TabIndex = 36;
            this.label3.Text = "PlayOrder:";
            // 
            // lblanswers
            // 
            this.lblanswers.AutoSize = true;
            this.lblanswers.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblanswers.Location = new System.Drawing.Point(12, 114);
            this.lblanswers.Name = "lblanswers";
            this.lblanswers.Size = new System.Drawing.Size(100, 25);
            this.lblanswers.TabIndex = 35;
            this.lblanswers.Text = "Answers:";
            // 
            // lblVideoPath
            // 
            this.lblVideoPath.AutoSize = true;
            this.lblVideoPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVideoPath.Location = new System.Drawing.Point(12, 64);
            this.lblVideoPath.Name = "lblVideoPath";
            this.lblVideoPath.Size = new System.Drawing.Size(123, 25);
            this.lblVideoPath.TabIndex = 34;
            this.lblVideoPath.Text = "Video Path:";
            // 
            // lblQTitle
            // 
            this.lblQTitle.AutoSize = true;
            this.lblQTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQTitle.Location = new System.Drawing.Point(12, 26);
            this.lblQTitle.Name = "lblQTitle";
            this.lblQTitle.Size = new System.Drawing.Size(126, 25);
            this.lblQTitle.TabIndex = 33;
            this.lblQTitle.Text = "Description:";
            // 
            // btnAddAnswers
            // 
            this.btnAddAnswers.Location = new System.Drawing.Point(338, 65);
            this.btnAddAnswers.Name = "btnAddAnswers";
            this.btnAddAnswers.Size = new System.Drawing.Size(75, 23);
            this.btnAddAnswers.TabIndex = 46;
            this.btnAddAnswers.Text = "Add";
            this.btnAddAnswers.UseVisualStyleBackColor = true;
            this.btnAddAnswers.Click += new System.EventHandler(this.btnAddAnswers_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(397, 212);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 47;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 25);
            this.label1.TabIndex = 49;
            this.label1.Text = "Answer:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(254, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 25);
            this.label4.TabIndex = 50;
            this.label4.Text = "Type:";
            // 
            // cboResponseType
            // 
            this.cboResponseType.FormattingEnabled = true;
            this.cboResponseType.Items.AddRange(new object[] {
            "Positive",
            "Negative"});
            this.cboResponseType.Location = new System.Drawing.Point(315, 21);
            this.cboResponseType.Name = "cboResponseType";
            this.cboResponseType.Size = new System.Drawing.Size(107, 21);
            this.cboResponseType.TabIndex = 51;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.cboNextSegment);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtAnswerSingle);
            this.groupBox1.Controls.Add(this.cboResponseType);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnAddAnswers);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 241);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(524, 134);
            this.groupBox1.TabIndex = 52;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Answer Editor";
            this.groupBox1.UseCompatibleTextRendering = true;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(433, 65);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 54;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // cboNextSegment
            // 
            this.cboNextSegment.FormattingEnabled = true;
            this.cboNextSegment.Location = new System.Drawing.Point(172, 67);
            this.cboNextSegment.Name = "cboNextSegment";
            this.cboNextSegment.Size = new System.Drawing.Size(121, 21);
            this.cboNextSegment.TabIndex = 53;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 25);
            this.label5.TabIndex = 52;
            this.label5.Text = "NextSegment:";
            // 
            // SocialSimulatorSegmentEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 522);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSelectContentWizard);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtVideoName);
            this.Controls.Add(this.lstAnswers);
            this.Controls.Add(this.txtPlayOrder);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblanswers);
            this.Controls.Add(this.lblVideoPath);
            this.Controls.Add(this.lblQTitle);
            this.Name = "SocialSimulatorSegmentEditor";
            this.Text = "SocialSimulatorSegementEditor";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSelectContentWizard;
        private System.Windows.Forms.TextBox txtAnswerSingle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtVideoName;
        private System.Windows.Forms.ListBox lstAnswers;
        private System.Windows.Forms.TextBox txtPlayOrder;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblanswers;
        private System.Windows.Forms.Label lblVideoPath;
        private System.Windows.Forms.Label lblQTitle;
        private System.Windows.Forms.Button btnAddAnswers;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboResponseType;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ComboBox cboNextSegment;
        private System.Windows.Forms.Label label5;
    }
}