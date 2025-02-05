namespace ScreenshotProgram
{
    partial class EditorForm
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
            pictureBox1 = new PictureBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            trackBar1 = new TrackBar();
            colorDialog1 = new ColorDialog();
            button9 = new Button();
            button10 = new Button();
            saveFileDialog1 = new SaveFileDialog();
            checkBox1 = new CheckBox();
            trackBar2 = new TrackBar();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(12, 79);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(776, 62);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // button1
            // 
            button1.BackgroundImage = Properties.Resources.highlight;
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            button1.Location = new Point(276, 12);
            button1.Name = "button1";
            button1.Size = new Size(60, 60);
            button1.TabIndex = 1;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackgroundImage = Properties.Resources.pencil;
            button2.BackgroundImageLayout = ImageLayout.Stretch;
            button2.Location = new Point(342, 12);
            button2.Name = "button2";
            button2.Size = new Size(60, 60);
            button2.TabIndex = 2;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackgroundImage = Properties.Resources.square1;
            button3.BackgroundImageLayout = ImageLayout.Stretch;
            button3.Location = new Point(430, 12);
            button3.Name = "button3";
            button3.Size = new Size(60, 60);
            button3.TabIndex = 3;
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.BackgroundImage = Properties.Resources.line1;
            button4.BackgroundImageLayout = ImageLayout.Stretch;
            button4.Location = new Point(496, 13);
            button4.Name = "button4";
            button4.Size = new Size(60, 60);
            button4.TabIndex = 4;
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.BackgroundImage = Properties.Resources.arrow_narrow_up1;
            button5.BackgroundImageLayout = ImageLayout.Stretch;
            button5.Location = new Point(562, 13);
            button5.Name = "button5";
            button5.Size = new Size(60, 60);
            button5.TabIndex = 5;
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.BackgroundImage = Properties.Resources.letter_case1;
            button6.BackgroundImageLayout = ImageLayout.Stretch;
            button6.Location = new Point(652, 12);
            button6.Name = "button6";
            button6.Size = new Size(60, 60);
            button6.TabIndex = 6;
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.BackgroundImage = Properties.Resources.mist_off1;
            button7.BackgroundImageLayout = ImageLayout.Stretch;
            button7.Location = new Point(718, 13);
            button7.Name = "button7";
            button7.Size = new Size(60, 60);
            button7.TabIndex = 7;
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button8
            // 
            button8.ForeColor = SystemColors.ControlText;
            button8.Location = new Point(12, 13);
            button8.Name = "button8";
            button8.Size = new Size(60, 60);
            button8.TabIndex = 8;
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(78, 17);
            trackBar1.Maximum = 20;
            trackBar1.Minimum = 1;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(192, 56);
            trackBar1.TabIndex = 9;
            trackBar1.Value = 8;
            // 
            // button9
            // 
            button9.BackgroundImage = Properties.Resources.device_floppy;
            button9.BackgroundImageLayout = ImageLayout.Stretch;
            button9.Location = new Point(815, 13);
            button9.Name = "button9";
            button9.Size = new Size(60, 60);
            button9.TabIndex = 10;
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // button10
            // 
            button10.BackgroundImage = Properties.Resources.copy;
            button10.BackgroundImageLayout = ImageLayout.Stretch;
            button10.Location = new Point(881, 13);
            button10.Name = "button10";
            button10.Size = new Size(60, 60);
            button10.TabIndex = 11;
            button10.UseVisualStyleBackColor = true;
            button10.Click += button10_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(90, 17);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(98, 24);
            checkBox1.TabIndex = 12;
            checkBox1.Text = "Note style";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.Visible = false;
            // 
            // trackBar2
            // 
            trackBar2.Location = new Point(947, 17);
            trackBar2.Maximum = 255;
            trackBar2.Minimum = 1;
            trackBar2.Name = "trackBar2";
            trackBar2.Size = new Size(287, 56);
            trackBar2.TabIndex = 13;
            trackBar2.Value = 80;
            trackBar2.Visible = false;
            trackBar2.ValueChanged += trackBar2_ValueChanged;
            // 
            // EditorForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1241, 450);
            Controls.Add(trackBar2);
            Controls.Add(checkBox1);
            Controls.Add(button10);
            Controls.Add(button9);
            Controls.Add(trackBar1);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            Name = "EditorForm";
            Text = "EditorForm";
            Load += EditorForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private TrackBar trackBar1;
        private ColorDialog colorDialog1;
        private Button button9;
        private Button button10;
        private SaveFileDialog saveFileDialog1;
        private CheckBox checkBox1;
        private TrackBar trackBar2;
    }
}