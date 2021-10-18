namespace lab6
{
    partial class Lab6
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
            this.textBox = new System.Windows.Forms.RichTextBox();
            this.fontSizeTrackBar = new System.Windows.Forms.TrackBar();
            this.fontSizeLabel = new System.Windows.Forms.Label();
            this.fontLabel = new System.Windows.Forms.Label();
            this.checkBox = new System.Windows.Forms.CheckBox();
            this.clearButton = new System.Windows.Forms.Button();
            this.mboxButton = new System.Windows.Forms.Button();
            this.setLabelButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fontSizeTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(12, 12);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(249, 184);
            this.textBox.TabIndex = 0;
            this.textBox.Text = "";
            // 
            // fontSizeTrackBar
            // 
            this.fontSizeTrackBar.Location = new System.Drawing.Point(63, 202);
            this.fontSizeTrackBar.Name = "fontSizeTrackBar";
            this.fontSizeTrackBar.Size = new System.Drawing.Size(145, 45);
            this.fontSizeTrackBar.TabIndex = 1;
            this.fontSizeTrackBar.Scroll += new System.EventHandler(this.FontSizeTrackBar_Scroll);
            // 
            // fontSizeLabel
            // 
            this.fontSizeLabel.AutoSize = true;
            this.fontSizeLabel.Location = new System.Drawing.Point(243, 212);
            this.fontSizeLabel.Name = "fontSizeLabel";
            this.fontSizeLabel.Size = new System.Drawing.Size(18, 13);
            this.fontSizeLabel.TabIndex = 8;
            this.fontSizeLabel.Text = "px";
            // 
            // fontLabel
            // 
            this.fontLabel.AutoSize = true;
            this.fontLabel.Location = new System.Drawing.Point(12, 212);
            this.fontLabel.Name = "fontLabel";
            this.fontLabel.Size = new System.Drawing.Size(55, 13);
            this.fontLabel.TabIndex = 7;
            this.fontLabel.Text = "Font size: ";
            // 
            // checkBox
            // 
            this.checkBox.AutoSize = true;
            this.checkBox.Location = new System.Drawing.Point(296, 51);
            this.checkBox.Name = "checkBox";
            this.checkBox.Size = new System.Drawing.Size(78, 17);
            this.checkBox.TabIndex = 6;
            this.checkBox.Text = "default box";
            this.checkBox.UseVisualStyleBackColor = true;
            this.checkBox.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // clearButton
            // 
            this.clearButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.clearButton.Location = new System.Drawing.Point(12, 253);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(84, 26);
            this.clearButton.TabIndex = 1;
            this.clearButton.Text = "clear";
            this.clearButton.UseVisualStyleBackColor = false;
            this.clearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // mboxButton
            // 
            this.mboxButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.mboxButton.Location = new System.Drawing.Point(296, 12);
            this.mboxButton.Name = "mboxButton";
            this.mboxButton.Size = new System.Drawing.Size(111, 33);
            this.mboxButton.TabIndex = 3;
            this.mboxButton.Text = "show MessageBox";
            this.mboxButton.UseVisualStyleBackColor = false;
            this.mboxButton.Click += new System.EventHandler(this.MboxButton_Click);
            // 
            // setLabelButton
            // 
            this.setLabelButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.setLabelButton.Location = new System.Drawing.Point(12, 287);
            this.setLabelButton.Name = "setLabelButton";
            this.setLabelButton.Size = new System.Drawing.Size(84, 25);
            this.setLabelButton.TabIndex = 9;
            this.setLabelButton.Text = "set label";
            this.setLabelButton.UseVisualStyleBackColor = false;
            this.setLabelButton.Click += new System.EventHandler(this.SetLabelButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(102, 291);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "label";
            // 
            // Lab6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 344);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.setLabelButton);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.mboxButton);
            this.Controls.Add(this.checkBox);
            this.Controls.Add(this.fontLabel);
            this.Controls.Add(this.fontSizeLabel);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.fontSizeTrackBar);
            this.Name = "Lab6";
            this.Text = "Lab6";
            ((System.ComponentModel.ISupportInitialize)(this.fontSizeTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox textBox;
        private System.Windows.Forms.TrackBar fontSizeTrackBar;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.CheckBox checkBox;
        private System.Windows.Forms.Label fontSizeLabel;
        private System.Windows.Forms.Label fontLabel;
        private System.Windows.Forms.Button mboxButton;
        private System.Windows.Forms.Button setLabelButton;
        private System.Windows.Forms.Label label1;
    }
}


