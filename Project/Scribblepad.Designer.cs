namespace Project
{
    partial class Scribblepad
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
            this.btnred = new System.Windows.Forms.Button();
            this.btnblue = new System.Windows.Forms.Button();
            this.btngreen = new System.Windows.Forms.Button();
            this.btnyellow = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnred
            // 
            this.btnred.BackColor = System.Drawing.Color.Red;
            this.btnred.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnred.Font = new System.Drawing.Font("Pericles", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnred.Location = new System.Drawing.Point(30, 108);
            this.btnred.Name = "btnred";
            this.btnred.Size = new System.Drawing.Size(149, 56);
            this.btnred.TabIndex = 0;
            this.btnred.Text = "Red";
            this.btnred.UseVisualStyleBackColor = false;
            this.btnred.Click += new System.EventHandler(this.btnred_Click);
            // 
            // btnblue
            // 
            this.btnblue.BackColor = System.Drawing.Color.Navy;
            this.btnblue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnblue.Font = new System.Drawing.Font("Pericles", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnblue.ForeColor = System.Drawing.Color.White;
            this.btnblue.Location = new System.Drawing.Point(30, 194);
            this.btnblue.Name = "btnblue";
            this.btnblue.Size = new System.Drawing.Size(149, 56);
            this.btnblue.TabIndex = 1;
            this.btnblue.Text = "Blue";
            this.btnblue.UseVisualStyleBackColor = false;
            this.btnblue.Click += new System.EventHandler(this.btnblue_Click);
            // 
            // btngreen
            // 
            this.btngreen.BackColor = System.Drawing.Color.Lime;
            this.btngreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btngreen.Font = new System.Drawing.Font("Pericles", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btngreen.Location = new System.Drawing.Point(30, 358);
            this.btngreen.Name = "btngreen";
            this.btngreen.Size = new System.Drawing.Size(149, 56);
            this.btngreen.TabIndex = 2;
            this.btngreen.Text = "Green";
            this.btngreen.UseVisualStyleBackColor = false;
            this.btngreen.Click += new System.EventHandler(this.btngreen_Click);
            // 
            // btnyellow
            // 
            this.btnyellow.BackColor = System.Drawing.Color.Yellow;
            this.btnyellow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnyellow.Font = new System.Drawing.Font("Pericles", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnyellow.Location = new System.Drawing.Point(30, 276);
            this.btnyellow.Name = "btnyellow";
            this.btnyellow.Size = new System.Drawing.Size(149, 56);
            this.btnyellow.TabIndex = 3;
            this.btnyellow.Text = "Yellow";
            this.btnyellow.UseVisualStyleBackColor = false;
            this.btnyellow.Click += new System.EventHandler(this.btnyellow_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Pericles", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(30, 433);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(149, 56);
            this.button2.TabIndex = 4;
            this.button2.Text = "Eraser";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Black;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Pericles", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(30, 29);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(149, 56);
            this.button3.TabIndex = 5;
            this.button3.Text = "Black";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Tomato;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Pericles", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(30, 519);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(149, 56);
            this.button1.TabIndex = 6;
            this.button1.Text = "E&xit";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // Scribblepad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(957, 602);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnyellow);
            this.Controls.Add(this.btngreen);
            this.Controls.Add(this.btnblue);
            this.Controls.Add(this.btnred);
            this.Name = "Scribblepad";
            this.Text = "Scribblepad";
            this.Load += new System.EventHandler(this.Scribblepad_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnred;
        private System.Windows.Forms.Button btnblue;
        private System.Windows.Forms.Button btngreen;
        private System.Windows.Forms.Button btnyellow;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
    }
}