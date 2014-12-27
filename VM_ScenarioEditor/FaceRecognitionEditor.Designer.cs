namespace VM_ScenarioEditor
{
    partial class FaceRecognitionEditor
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
            this.lblQTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblanswers = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txttitle = new System.Windows.Forms.TextBox();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.txtCopyrightNotice = new System.Windows.Forms.TextBox();
            this.lstAnswers = new System.Windows.Forms.ListBox();
            this.txtImageName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblQTitle
            // 
            this.lblQTitle.AutoSize = true;
            this.lblQTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQTitle.Location = new System.Drawing.Point(23, 9);
            this.lblQTitle.Name = "lblQTitle";
            this.lblQTitle.Size = new System.Drawing.Size(59, 25);
            this.lblQTitle.TabIndex = 0;
            this.lblQTitle.Text = "Title:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "ImageName";
            // 
            // lblanswers
            // 
            this.lblanswers.AutoSize = true;
            this.lblanswers.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblanswers.Location = new System.Drawing.Point(23, 97);
            this.lblanswers.Name = "lblanswers";
            this.lblanswers.Size = new System.Drawing.Size(100, 25);
            this.lblanswers.TabIndex = 2;
            this.lblanswers.Text = "Answers:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 246);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "Author:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(23, 281);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(177, 25);
            this.label4.TabIndex = 4;
            this.label4.Text = "Copyright Notice:";
            // 
            // txttitle
            // 
            this.txttitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttitle.Location = new System.Drawing.Point(206, 12);
            this.txttitle.Name = "txttitle";
            this.txttitle.Size = new System.Drawing.Size(193, 29);
            this.txttitle.TabIndex = 5;
            // 
            // txtAuthor
            // 
            this.txtAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAuthor.Location = new System.Drawing.Point(206, 246);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(193, 29);
            this.txtAuthor.TabIndex = 6;
            // 
            // txtCopyrightNotice
            // 
            this.txtCopyrightNotice.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCopyrightNotice.Location = new System.Drawing.Point(206, 281);
            this.txtCopyrightNotice.Name = "txtCopyrightNotice";
            this.txtCopyrightNotice.Size = new System.Drawing.Size(193, 29);
            this.txtCopyrightNotice.TabIndex = 7;
            // 
            // lstAnswers
            // 
            this.lstAnswers.FormattingEnabled = true;
            this.lstAnswers.Location = new System.Drawing.Point(206, 97);
            this.lstAnswers.Name = "lstAnswers";
            this.lstAnswers.Size = new System.Drawing.Size(172, 121);
            this.lstAnswers.TabIndex = 10;
            // 
            // txtImageName
            // 
            this.txtImageName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImageName.Location = new System.Drawing.Point(206, 47);
            this.txtImageName.Name = "txtImageName";
            this.txtImageName.Size = new System.Drawing.Size(193, 29);
            this.txtImageName.TabIndex = 11;
            // 
            // FaceRecognitionEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 369);
            this.Controls.Add(this.txtImageName);
            this.Controls.Add(this.lstAnswers);
            this.Controls.Add(this.txtCopyrightNotice);
            this.Controls.Add(this.txtAuthor);
            this.Controls.Add(this.txttitle);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblanswers);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblQTitle);
            this.Name = "FaceRecognitionEditor";
            this.Text = "FaceRecognitionEditor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblQTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblanswers;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txttitle;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.TextBox txtCopyrightNotice;
        private System.Windows.Forms.ListBox lstAnswers;
        private System.Windows.Forms.TextBox txtImageName;
    }
}