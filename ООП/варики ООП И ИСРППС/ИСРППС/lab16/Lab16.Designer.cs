namespace lab16
{
    partial class Lab16
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.checkBoxRotate = new System.Windows.Forms.CheckBox();
            this.checkBoxFlip = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(143, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(282, 273);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 27);
            this.button1.TabIndex = 3;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.button2.Location = new System.Drawing.Point(12, 45);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(125, 26);
            this.button2.TabIndex = 4;
            this.button2.Text = "Load image";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.button3.Location = new System.Drawing.Point(12, 77);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(125, 26);
            this.button3.TabIndex = 5;
            this.button3.Text = "Copy to clipboard";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // checkBoxRotate
            // 
            this.checkBoxRotate.AutoSize = true;
            this.checkBoxRotate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.checkBoxRotate.Location = new System.Drawing.Point(12, 136);
            this.checkBoxRotate.Name = "checkBoxRotate";
            this.checkBoxRotate.Size = new System.Drawing.Size(89, 21);
            this.checkBoxRotate.TabIndex = 6;
            this.checkBoxRotate.Text = "Rotate 90";
            this.checkBoxRotate.UseVisualStyleBackColor = true;
            this.checkBoxRotate.Click += new System.EventHandler(this.CheckBoxRotate_CheckedChanged);
            // 
            // checkBoxFlip
            // 
            this.checkBoxFlip.AutoSize = true;
            this.checkBoxFlip.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.checkBoxFlip.Location = new System.Drawing.Point(12, 109);
            this.checkBoxFlip.Name = "checkBoxFlip";
            this.checkBoxFlip.Size = new System.Drawing.Size(53, 21);
            this.checkBoxFlip.TabIndex = 7;
            this.checkBoxFlip.Text = "Flip ";
            this.checkBoxFlip.UseVisualStyleBackColor = true;
            this.checkBoxFlip.CheckedChanged += new System.EventHandler(this.CheckBoxFlip_CheckedChanged);
            // 
            // Lab16
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 308);
            this.Controls.Add(this.checkBoxFlip);
            this.Controls.Add(this.checkBoxRotate);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Lab16";
            this.Text = "Lab16";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.CheckBox checkBoxRotate;
        private System.Windows.Forms.CheckBox checkBoxFlip;
    }
}