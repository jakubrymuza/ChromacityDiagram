namespace GK_proj3
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.PointsCountNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.PointsCountLabel = new System.Windows.Forms.Label();
            this.SpectrumPictureBox = new System.Windows.Forms.PictureBox();
            this.BackgroundCheckBox = new System.Windows.Forms.CheckBox();
            this.DiagramPictureBox = new System.Windows.Forms.PictureBox();
            this.sRGBRadioButton = new System.Windows.Forms.RadioButton();
            this.WideGamutRadioButton = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PointsCountNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpectrumPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DiagramPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.PointsCountNumericUpDown);
            this.splitContainer1.Panel1.Controls.Add(this.PointsCountLabel);
            this.splitContainer1.Panel1.Controls.Add(this.SpectrumPictureBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.WideGamutRadioButton);
            this.splitContainer1.Panel2.Controls.Add(this.sRGBRadioButton);
            this.splitContainer1.Panel2.Controls.Add(this.BackgroundCheckBox);
            this.splitContainer1.Panel2.Controls.Add(this.DiagramPictureBox);
            this.splitContainer1.Size = new System.Drawing.Size(1406, 935);
            this.splitContainer1.SplitterDistance = 670;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.Text = "splitContainer1";
            // 
            // PointsCountNumericUpDown
            // 
            this.PointsCountNumericUpDown.Location = new System.Drawing.Point(176, 18);
            this.PointsCountNumericUpDown.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PointsCountNumericUpDown.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.PointsCountNumericUpDown.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.PointsCountNumericUpDown.Name = "PointsCountNumericUpDown";
            this.PointsCountNumericUpDown.Size = new System.Drawing.Size(71, 31);
            this.PointsCountNumericUpDown.TabIndex = 2;
            this.PointsCountNumericUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.PointsCountNumericUpDown.ValueChanged += new System.EventHandler(this.PointsCountNumericUpDown_ValueChanged);
            // 
            // PointsCountLabel
            // 
            this.PointsCountLabel.AutoSize = true;
            this.PointsCountLabel.Location = new System.Drawing.Point(19, 22);
            this.PointsCountLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PointsCountLabel.Name = "PointsCountLabel";
            this.PointsCountLabel.Size = new System.Drawing.Size(158, 25);
            this.PointsCountLabel.TabIndex = 1;
            this.PointsCountLabel.Text = "Number of points:";
            // 
            // SpectrumPictureBox
            // 
            this.SpectrumPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SpectrumPictureBox.Location = new System.Drawing.Point(4, 88);
            this.SpectrumPictureBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SpectrumPictureBox.Name = "SpectrumPictureBox";
            this.SpectrumPictureBox.Size = new System.Drawing.Size(661, 842);
            this.SpectrumPictureBox.TabIndex = 0;
            this.SpectrumPictureBox.TabStop = false;
            this.SpectrumPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.SpectrumPictureBox_Paint);
            this.SpectrumPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SpectrumPictureBox_MouseDown);
            // 
            // BackgroundCheckBox
            // 
            this.BackgroundCheckBox.AutoSize = true;
            this.BackgroundCheckBox.Checked = true;
            this.BackgroundCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.BackgroundCheckBox.Location = new System.Drawing.Point(6, 22);
            this.BackgroundCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BackgroundCheckBox.Name = "BackgroundCheckBox";
            this.BackgroundCheckBox.Size = new System.Drawing.Size(180, 29);
            this.BackgroundCheckBox.TabIndex = 1;
            this.BackgroundCheckBox.Text = "Draw background";
            this.BackgroundCheckBox.UseVisualStyleBackColor = true;
            this.BackgroundCheckBox.CheckedChanged += new System.EventHandler(this.BackgroundCheckBox_CheckedChanged);
            // 
            // DiagramPictureBox
            // 
            this.DiagramPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DiagramPictureBox.Location = new System.Drawing.Point(4, 88);
            this.DiagramPictureBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DiagramPictureBox.Name = "DiagramPictureBox";
            this.DiagramPictureBox.Size = new System.Drawing.Size(708, 842);
            this.DiagramPictureBox.TabIndex = 0;
            this.DiagramPictureBox.TabStop = false;
            this.DiagramPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.DiagramPictureBox_Paint);
            // 
            // sRGBRadioButton
            // 
            this.sRGBRadioButton.AutoSize = true;
            this.sRGBRadioButton.Checked = true;
            this.sRGBRadioButton.Location = new System.Drawing.Point(223, 22);
            this.sRGBRadioButton.Name = "sRGBRadioButton";
            this.sRGBRadioButton.Size = new System.Drawing.Size(78, 29);
            this.sRGBRadioButton.TabIndex = 2;
            this.sRGBRadioButton.TabStop = true;
            this.sRGBRadioButton.Text = "sRGB";
            this.sRGBRadioButton.UseVisualStyleBackColor = true;
            this.sRGBRadioButton.CheckedChanged += new System.EventHandler(this.sRGBRadioButton_CheckedChanged);
            // 
            // WideGamutRadioButton
            // 
            this.WideGamutRadioButton.AutoSize = true;
            this.WideGamutRadioButton.Location = new System.Drawing.Point(332, 22);
            this.WideGamutRadioButton.Name = "WideGamutRadioButton";
            this.WideGamutRadioButton.Size = new System.Drawing.Size(136, 29);
            this.WideGamutRadioButton.TabIndex = 3;
            this.WideGamutRadioButton.Text = "Wide Gamut";
            this.WideGamutRadioButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1406, 935);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GK_proj3";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PointsCountNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpectrumPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DiagramPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.NumericUpDown PointsCountNumericUpDown;
        private System.Windows.Forms.Label PointsCountLabel;
        private System.Windows.Forms.PictureBox SpectrumPictureBox;
        private System.Windows.Forms.PictureBox DiagramPictureBox;
        private System.Windows.Forms.CheckBox BackgroundCheckBox;
        private System.Windows.Forms.RadioButton WideGamutRadioButton;
        private System.Windows.Forms.RadioButton sRGBRadioButton;
    }
}

