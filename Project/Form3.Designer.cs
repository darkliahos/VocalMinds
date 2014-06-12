namespace VM_Main
{
    partial class StoryForm
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
            this.lblone = new System.Windows.Forms.Label();
            this.lbltwo = new System.Windows.Forms.Label();
            this.btnnext = new System.Windows.Forms.Button();
            this.btnfinish = new System.Windows.Forms.Button();
            this.btnlisten1 = new System.Windows.Forms.Button();
            this.listbutton2 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblone
            // 
            this.lblone.AutoSize = true;
            this.lblone.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblone.Location = new System.Drawing.Point(12, 672);
            this.lblone.Name = "lblone";
            this.lblone.Size = new System.Drawing.Size(228, 20);
            this.lblone.TabIndex = 1;
            this.lblone.Text = "Goldie and the three Aliens";
            // 
            // lbltwo
            // 
            this.lbltwo.AutoSize = true;
            this.lbltwo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltwo.Location = new System.Drawing.Point(648, 672);
            this.lbltwo.Name = "lbltwo";
            this.lbltwo.Size = new System.Drawing.Size(232, 20);
            this.lbltwo.TabIndex = 1;
            this.lbltwo.Text = "Goldie and the Three Aliens";
            // 
            // btnnext
            // 
            this.btnnext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnnext.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnnext.Location = new System.Drawing.Point(750, 5);
            this.btnnext.Name = "btnnext";
            this.btnnext.Size = new System.Drawing.Size(82, 38);
            this.btnnext.TabIndex = 2;
            this.btnnext.Text = "&Next";
            this.btnnext.UseVisualStyleBackColor = true;
            this.btnnext.Click += new System.EventHandler(this.btnnext_Click);
            // 
            // btnfinish
            // 
            this.btnfinish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnfinish.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnfinish.Location = new System.Drawing.Point(855, 5);
            this.btnfinish.Name = "btnfinish";
            this.btnfinish.Size = new System.Drawing.Size(94, 38);
            this.btnfinish.TabIndex = 3;
            this.btnfinish.Text = "&Finish";
            this.btnfinish.UseVisualStyleBackColor = true;
            this.btnfinish.Click += new System.EventHandler(this.btnfinish_Click);
            // 
            // btnlisten1
            // 
            this.btnlisten1.Location = new System.Drawing.Point(577, 839);
            this.btnlisten1.Name = "btnlisten1";
            this.btnlisten1.Size = new System.Drawing.Size(39, 30);
            this.btnlisten1.TabIndex = 8;
            this.btnlisten1.Text = "Play";
            this.btnlisten1.UseVisualStyleBackColor = true;
            // 
            // listbutton2
            // 
            this.listbutton2.Location = new System.Drawing.Point(1213, 839);
            this.listbutton2.Name = "listbutton2";
            this.listbutton2.Size = new System.Drawing.Size(39, 30);
            this.listbutton2.TabIndex = 5;
            this.listbutton2.Text = "Play";
            this.listbutton2.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.ErrorImage = global::VM_Main.Properties.Resources.title;
            this.pictureBox2.Image = global::VM_Main.Properties.Resources.title;
            this.pictureBox2.Location = new System.Drawing.Point(652, 49);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(600, 600);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::VM_Main.Properties.Resources.title;
            this.pictureBox1.Location = new System.Drawing.Point(16, 49);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(600, 600);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1264, 908);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.listbutton2);
            this.Controls.Add(this.btnlisten1);
            this.Controls.Add(this.btnfinish);
            this.Controls.Add(this.btnnext);
            this.Controls.Add(this.lbltwo);
            this.Controls.Add(this.lblone);
            this.Controls.Add(this.pictureBox2);
            this.Name = "Story";
            this.Text = "Story";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblone;
        private System.Windows.Forms.Label lbltwo;
        private System.Windows.Forms.Button btnnext;
        private System.Windows.Forms.Button btnfinish;
        private System.Windows.Forms.Button btnlisten1;
        private System.Windows.Forms.Button listbutton2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}