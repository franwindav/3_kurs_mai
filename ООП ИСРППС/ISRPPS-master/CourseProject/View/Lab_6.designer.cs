namespace CourseProject
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
            this.textBox.Location = new System.Drawing.Point(204, 109);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(249, 127);
            this.textBox.TabIndex = 0;
            this.textBox.Text = "";
            // 
            // fontSizeTrackBar
            // 
            this.fontSizeTrackBar.Location = new System.Drawing.Point(224, 347);
            this.fontSizeTrackBar.Name = "fontSizeTrackBar";
            this.fontSizeTrackBar.Size = new System.Drawing.Size(145, 45);
            this.fontSizeTrackBar.TabIndex = 1;
            this.fontSizeTrackBar.Scroll += new System.EventHandler(this.FontSizeTrackBar_Scroll);
            // 
            // fontSizeLabel
            // 
            this.fontSizeLabel.AutoSize = true;
            this.fontSizeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fontSizeLabel.Location = new System.Drawing.Point(366, 350);
            this.fontSizeLabel.Name = "fontSizeLabel";
            this.fontSizeLabel.Size = new System.Drawing.Size(20, 15);
            this.fontSizeLabel.TabIndex = 8;
            this.fontSizeLabel.Text = "px";
            this.fontSizeLabel.Click += new System.EventHandler(this.fontSizeLabel_Click);
            // 
            // fontLabel
            // 
            this.fontLabel.AutoSize = true;
            this.fontLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fontLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fontLabel.Location = new System.Drawing.Point(125, 347);
            this.fontLabel.Name = "fontLabel";
            this.fontLabel.Size = new System.Drawing.Size(93, 20);
            this.fontLabel.TabIndex = 7;
            this.fontLabel.Text = "Font size: ";
            this.fontLabel.Click += new System.EventHandler(this.fontLabel_Click);
            // 
            // checkBox
            // 
            this.checkBox.AutoSize = true;
            this.checkBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBox.Location = new System.Drawing.Point(375, 242);
            this.checkBox.Name = "checkBox";
            this.checkBox.Size = new System.Drawing.Size(81, 17);
            this.checkBox.TabIndex = 6;
            this.checkBox.Text = "Default Box";
            this.checkBox.UseVisualStyleBackColor = true;
            this.checkBox.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // clearButton
            // 
            this.clearButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.clearButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearButton.Location = new System.Drawing.Point(204, 54);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(84, 26);
            this.clearButton.TabIndex = 1;
            this.clearButton.Text = "clear";
            this.clearButton.UseVisualStyleBackColor = false;
            this.clearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // mboxButton
            // 
            this.mboxButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.mboxButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mboxButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mboxButton.Location = new System.Drawing.Point(270, 265);
            this.mboxButton.Name = "mboxButton";
            this.mboxButton.Size = new System.Drawing.Size(111, 33);
            this.mboxButton.TabIndex = 3;
            this.mboxButton.Text = "Show";
            this.mboxButton.UseVisualStyleBackColor = false;
            this.mboxButton.Click += new System.EventHandler(this.MboxButton_Click);
            // 
            // setLabelButton
            // 
            this.setLabelButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.setLabelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.setLabelButton.Location = new System.Drawing.Point(369, 55);
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
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(266, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 22);
            this.label1.TabIndex = 10;
            this.label1.Text = "Default Label";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Lab6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(700, 433);
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
            this.Load += new System.EventHandler(this.Lab6_Load);
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


