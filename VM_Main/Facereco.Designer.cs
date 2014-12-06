namespace VM_Main
{
    partial class Facerecognition
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
            this.label1 = new System.Windows.Forms.Label();
            this.BtnConfirm = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.FaceBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.FaceBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(158, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(388, 39);
            this.label1.TabIndex = 5;
            this.label1.Text = "Face Recognition Quiz";
            // 
            // BtnConfirm
            // 
            this.BtnConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.BtnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnConfirm.Location = new System.Drawing.Point(512, 554);
            this.BtnConfirm.Name = "BtnConfirm";
            this.BtnConfirm.Size = new System.Drawing.Size(137, 67);
            this.BtnConfirm.TabIndex = 8;
            this.BtnConfirm.Text = "&Answer";
            this.BtnConfirm.UseVisualStyleBackColor = false;
            this.BtnConfirm.Click += new System.EventHandler(this.BtnConfirmClick);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(207, 571);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(258, 44);
            this.textBox1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(67, 576);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 33);
            this.label2.TabIndex = 28;
            this.label2.Text = "Input:";
            // 
            // FaceBox
            // 
            this.FaceBox.Image = global::VM_Main.Properties.Resources.scaredface;
            this.FaceBox.Location = new System.Drawing.Point(43, 51);
            this.FaceBox.Name = "FaceBox";
            this.FaceBox.Size = new System.Drawing.Size(606, 497);
            this.FaceBox.TabIndex = 6;
            this.FaceBox.TabStop = false;
            // 
            // Facerecognition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(730, 631);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.BtnConfirm);
            this.Controls.Add(this.FaceBox);
            this.Controls.Add(this.label1);
            this.Name = "Facerecognition";
            this.ShowInTaskbar = false;
            this.Text = "Face Recognition";
            ((System.ComponentModel.ISupportInitialize)(this.FaceBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox FaceBox;
        private System.Windows.Forms.Button BtnConfirm;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;

    }
}