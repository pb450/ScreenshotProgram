namespace ScreenshotProgram
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            button1 = new Button();
            notifyIcon1 = new NotifyIcon(components);
            groupBox1 = new GroupBox();
            label11 = new Label();
            r_fixed = new RadioButton();
            r_window = new RadioButton();
            r_fragment = new RadioButton();
            r_full = new RadioButton();
            button2 = new Button();
            groupBox2 = new GroupBox();
            label9 = new Label();
            button3 = new Button();
            tx_keybind = new TextBox();
            label1 = new Label();
            c_keybind = new CheckBox();
            groupBox3 = new GroupBox();
            label18 = new Label();
            button8 = new Button();
            label17 = new Label();
            cx_for = new ComboBox();
            n_for = new NumericUpDown();
            cx_every = new ComboBox();
            n_every = new NumericUpDown();
            label2 = new Label();
            c_delay = new CheckBox();
            n_delay = new NumericUpDown();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            groupBox4 = new GroupBox();
            button7 = new Button();
            label16 = new Label();
            label15 = new Label();
            label14 = new Label();
            label13 = new Label();
            label12 = new Label();
            label10 = new Label();
            tabPage2 = new TabPage();
            button6 = new Button();
            c_notify = new CheckBox();
            button5 = new Button();
            c_noti = new CheckBox();
            label8 = new Label();
            cx_save_enabled = new CheckBox();
            c_div = new CheckBox();
            c_floc = new CheckBox();
            c_clip = new CheckBox();
            comboBox3 = new ComboBox();
            label7 = new Label();
            c_editor = new CheckBox();
            label6 = new Label();
            label5 = new Label();
            textBox3 = new TextBox();
            label4 = new Label();
            button4 = new Button();
            textBox2 = new TextBox();
            label3 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            timer_fast = new System.Windows.Forms.Timer(components);
            folderBrowserDialog1 = new FolderBrowserDialog();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)n_for).BeginInit();
            ((System.ComponentModel.ISupportInitialize)n_every).BeginInit();
            ((System.ComponentModel.ISupportInitialize)n_delay).BeginInit();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            groupBox4.SuspendLayout();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(118, 12);
            button1.Name = "button1";
            button1.Size = new Size(110, 29);
            button1.TabIndex = 0;
            button1.Text = "W tle";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // notifyIcon1
            // 
            notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Text = "Awsome Screenshot Program (Tray)";
            notifyIcon1.Visible = true;
            notifyIcon1.MouseDoubleClick += notifyIcon1_MouseDoubleClick;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(r_fixed);
            groupBox1.Controls.Add(r_window);
            groupBox1.Controls.Add(r_fragment);
            groupBox1.Controls.Add(r_full);
            groupBox1.Location = new Point(6, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(301, 169);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Default mode:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(26, 113);
            label11.Name = "label11";
            label11.Size = new Size(16, 20);
            label11.TabIndex = 6;
            label11.Text = "?";
            // 
            // r_fixed
            // 
            r_fixed.AutoSize = true;
            r_fixed.Location = new Point(6, 86);
            r_fixed.Name = "r_fixed";
            r_fixed.Size = new Size(130, 24);
            r_fixed.TabIndex = 3;
            r_fixed.TabStop = true;
            r_fixed.Text = "Fixed fragment";
            r_fixed.UseVisualStyleBackColor = true;
            r_fixed.CheckedChanged += r_fixed_CheckedChanged;
            // 
            // r_window
            // 
            r_window.AutoSize = true;
            r_window.Location = new Point(6, 139);
            r_window.Name = "r_window";
            r_window.Size = new Size(85, 24);
            r_window.TabIndex = 2;
            r_window.TabStop = true;
            r_window.Text = "Window";
            r_window.UseVisualStyleBackColor = true;
            // 
            // r_fragment
            // 
            r_fragment.AutoSize = true;
            r_fragment.Location = new Point(6, 56);
            r_fragment.Name = "r_fragment";
            r_fragment.Size = new Size(93, 24);
            r_fragment.TabIndex = 2;
            r_fragment.TabStop = true;
            r_fragment.Text = "Fragment";
            r_fragment.UseVisualStyleBackColor = true;
            // 
            // r_full
            // 
            r_full.AutoSize = true;
            r_full.Location = new Point(6, 26);
            r_full.Name = "r_full";
            r_full.Size = new Size(99, 24);
            r_full.TabIndex = 2;
            r_full.TabStop = true;
            r_full.Text = "Full screen";
            r_full.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(18, 12);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 2;
            button2.Text = "Capture";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(button3);
            groupBox2.Controls.Add(tx_keybind);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(c_keybind);
            groupBox2.Location = new Point(325, 6);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(289, 151);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Key binds";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label9.ForeColor = Color.Brown;
            label9.Location = new Point(115, 106);
            label9.Name = "label9";
            label9.Size = new Size(107, 31);
            label9.TabIndex = 4;
            label9.Text = "Listening";
            // 
            // button3
            // 
            button3.Location = new Point(15, 109);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 3;
            button3.Text = "Set";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // tx_keybind
            // 
            tx_keybind.Enabled = false;
            tx_keybind.Location = new Point(15, 76);
            tx_keybind.Name = "tx_keybind";
            tx_keybind.Size = new Size(268, 27);
            tx_keybind.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 53);
            label1.Name = "label1";
            label1.Size = new Size(61, 20);
            label1.TabIndex = 1;
            label1.Text = "Default:";
            // 
            // c_keybind
            // 
            c_keybind.AutoSize = true;
            c_keybind.Location = new Point(15, 26);
            c_keybind.Name = "c_keybind";
            c_keybind.Size = new Size(72, 24);
            c_keybind.TabIndex = 0;
            c_keybind.Text = "Active";
            c_keybind.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label18);
            groupBox3.Controls.Add(button8);
            groupBox3.Controls.Add(label17);
            groupBox3.Controls.Add(cx_for);
            groupBox3.Controls.Add(n_for);
            groupBox3.Controls.Add(cx_every);
            groupBox3.Controls.Add(n_every);
            groupBox3.Controls.Add(label2);
            groupBox3.Controls.Add(c_delay);
            groupBox3.Controls.Add(n_delay);
            groupBox3.Location = new Point(6, 181);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(301, 261);
            groupBox3.TabIndex = 4;
            groupBox3.TabStop = false;
            groupBox3.Text = "Timer";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(6, 192);
            label18.Name = "label18";
            label18.Size = new Size(31, 20);
            label18.TabIndex = 6;
            label18.Text = "for:";
            // 
            // button8
            // 
            button8.Location = new Point(199, 109);
            button8.Name = "button8";
            button8.Size = new Size(94, 29);
            button8.TabIndex = 6;
            button8.Text = "Start";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(6, 90);
            label17.Name = "label17";
            label17.Size = new Size(91, 20);
            label17.TabIndex = 6;
            label17.Text = "Autopcature";
            // 
            // cx_for
            // 
            cx_for.FormattingEnabled = true;
            cx_for.Items.AddRange(new object[] { "seconds", "minutes", "hours", "days" });
            cx_for.Location = new Point(142, 215);
            cx_for.Name = "cx_for";
            cx_for.Size = new Size(151, 28);
            cx_for.TabIndex = 5;
            // 
            // n_for
            // 
            n_for.Location = new Point(6, 215);
            n_for.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            n_for.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            n_for.Name = "n_for";
            n_for.Size = new Size(130, 27);
            n_for.TabIndex = 5;
            n_for.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // cx_every
            // 
            cx_every.FormattingEnabled = true;
            cx_every.Items.AddRange(new object[] { "seconds", "minutes", "hours", "days" });
            cx_every.Location = new Point(142, 152);
            cx_every.Name = "cx_every";
            cx_every.Size = new Size(151, 28);
            cx_every.TabIndex = 5;
            // 
            // n_every
            // 
            n_every.Location = new Point(6, 152);
            n_every.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            n_every.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            n_every.Name = "n_every";
            n_every.Size = new Size(130, 27);
            n_every.TabIndex = 5;
            n_every.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 129);
            label2.Name = "label2";
            label2.Size = new Size(47, 20);
            label2.TabIndex = 5;
            label2.Text = "Every:";
            // 
            // c_delay
            // 
            c_delay.AutoSize = true;
            c_delay.Location = new Point(6, 26);
            c_delay.Name = "c_delay";
            c_delay.Size = new Size(164, 24);
            c_delay.TabIndex = 5;
            c_delay.Text = "Delay (miliseconds):";
            c_delay.UseVisualStyleBackColor = true;
            // 
            // n_delay
            // 
            n_delay.Location = new Point(6, 50);
            n_delay.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            n_delay.Name = "n_delay";
            n_delay.Size = new Size(147, 27);
            n_delay.TabIndex = 5;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(18, 47);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(718, 481);
            tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(groupBox4);
            tabPage1.Controls.Add(groupBox2);
            tabPage1.Controls.Add(groupBox3);
            tabPage1.Controls.Add(groupBox1);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(710, 448);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Ustawienia";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(button7);
            groupBox4.Controls.Add(label16);
            groupBox4.Controls.Add(label15);
            groupBox4.Controls.Add(label14);
            groupBox4.Controls.Add(label13);
            groupBox4.Controls.Add(label12);
            groupBox4.Controls.Add(label10);
            groupBox4.Location = new Point(325, 181);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(289, 251);
            groupBox4.TabIndex = 5;
            groupBox4.TabStop = false;
            groupBox4.Text = "Active autocapture";
            // 
            // button7
            // 
            button7.Location = new Point(6, 201);
            button7.Name = "button7";
            button7.Size = new Size(277, 29);
            button7.TabIndex = 6;
            button7.Text = "Cancel";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(6, 154);
            label16.Name = "label16";
            label16.Size = new Size(82, 20);
            label16.TabIndex = 5;
            label16.Text = "in: 00:00:00";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(6, 133);
            label15.Name = "label15";
            label15.Size = new Size(58, 20);
            label15.TabIndex = 4;
            label15.Text = "label15";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(6, 113);
            label14.Name = "label14";
            label14.Size = new Size(160, 20);
            label14.TabIndex = 3;
            label14.Text = "Last screenshot before:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(6, 77);
            label13.Name = "label13";
            label13.Size = new Size(58, 20);
            label13.TabIndex = 2;
            label13.Text = "label13";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(6, 57);
            label12.Name = "label12";
            label12.Size = new Size(133, 20);
            label12.TabIndex = 1;
            label12.Text = "Next screenshot in:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(6, 23);
            label10.Name = "label10";
            label10.Size = new Size(152, 20);
            label10.TabIndex = 0;
            label10.Text = "Autocapture is active!";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(button6);
            tabPage2.Controls.Add(c_notify);
            tabPage2.Controls.Add(button5);
            tabPage2.Controls.Add(c_noti);
            tabPage2.Controls.Add(label8);
            tabPage2.Controls.Add(cx_save_enabled);
            tabPage2.Controls.Add(c_div);
            tabPage2.Controls.Add(c_floc);
            tabPage2.Controls.Add(c_clip);
            tabPage2.Controls.Add(comboBox3);
            tabPage2.Controls.Add(label7);
            tabPage2.Controls.Add(c_editor);
            tabPage2.Controls.Add(label6);
            tabPage2.Controls.Add(label5);
            tabPage2.Controls.Add(textBox3);
            tabPage2.Controls.Add(label4);
            tabPage2.Controls.Add(button4);
            tabPage2.Controls.Add(textBox2);
            tabPage2.Controls.Add(label3);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(710, 448);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Zapisywanie";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Location = new Point(6, 206);
            button6.Name = "button6";
            button6.Size = new Size(120, 29);
            button6.TabIndex = 20;
            button6.Text = "Reset index";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // c_notify
            // 
            c_notify.AutoSize = true;
            c_notify.Location = new Point(167, 389);
            c_notify.Name = "c_notify";
            c_notify.Size = new Size(154, 24);
            c_notify.TabIndex = 19;
            c_notify.Text = "Notification sound";
            c_notify.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(615, 124);
            button5.Name = "button5";
            button5.Size = new Size(30, 30);
            button5.TabIndex = 18;
            button5.Text = "?";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // c_noti
            // 
            c_noti.AutoSize = true;
            c_noti.Location = new Point(14, 331);
            c_noti.Name = "c_noti";
            c_noti.Size = new Size(147, 24);
            c_noti.TabIndex = 16;
            c_noti.Text = "Show notification";
            c_noti.UseVisualStyleBackColor = true;
            c_noti.CheckedChanged += c_noti_CheckedChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 183);
            label8.Name = "label8";
            label8.Size = new Size(121, 20);
            label8.TabIndex = 14;
            label8.Text = "Sample file path:";
            // 
            // cx_save_enabled
            // 
            cx_save_enabled.AutoSize = true;
            cx_save_enabled.Location = new Point(6, 21);
            cx_save_enabled.Name = "cx_save_enabled";
            cx_save_enabled.Size = new Size(120, 24);
            cx_save_enabled.TabIndex = 13;
            cx_save_enabled.Text = "Save enabled";
            cx_save_enabled.UseVisualStyleBackColor = true;
            // 
            // c_div
            // 
            c_div.AutoSize = true;
            c_div.Location = new Point(167, 359);
            c_div.Name = "c_div";
            c_div.Size = new Size(252, 24);
            c_div.TabIndex = 12;
            c_div.Text = "Open file in default image viewer";
            c_div.UseVisualStyleBackColor = true;
            // 
            // c_floc
            // 
            c_floc.AutoSize = true;
            c_floc.Location = new Point(167, 331);
            c_floc.Name = "c_floc";
            c_floc.Size = new Size(150, 24);
            c_floc.TabIndex = 11;
            c_floc.Text = "Open file location";
            c_floc.UseVisualStyleBackColor = true;
            // 
            // c_clip
            // 
            c_clip.AutoSize = true;
            c_clip.Location = new Point(15, 389);
            c_clip.Name = "c_clip";
            c_clip.Size = new Size(151, 24);
            c_clip.TabIndex = 10;
            c_clip.Text = "Copy to clipboard";
            c_clip.UseVisualStyleBackColor = true;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Items.AddRange(new object[] { "JPG", "PNG", "BMP", "GIF", "WEBP" });
            comboBox3.Location = new Point(6, 277);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(151, 28);
            comboBox3.TabIndex = 9;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 254);
            label7.Name = "label7";
            label7.Size = new Size(126, 20);
            label7.TabIndex = 8;
            label7.Text = "Prefered file type:";
            // 
            // c_editor
            // 
            c_editor.AutoSize = true;
            c_editor.Location = new Point(15, 359);
            c_editor.Name = "c_editor";
            c_editor.Size = new Size(127, 24);
            c_editor.TabIndex = 7;
            c_editor.Text = "Open in editor";
            c_editor.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(15, 308);
            label6.Name = "label6";
            label6.Size = new Size(119, 20);
            label6.TabIndex = 6;
            label6.Text = "After screenshot:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 163);
            label5.Name = "label5";
            label5.Size = new Size(128, 20);
            label5.TabIndex = 5;
            label5.Text = "Sample file name:";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(6, 124);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(603, 27);
            textBox3.TabIndex = 4;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 101);
            label4.Name = "label4";
            label4.Size = new Size(76, 20);
            label4.TabIndex = 3;
            label4.Text = "File name:";
            // 
            // button4
            // 
            button4.Location = new Point(598, 69);
            button4.Name = "button4";
            button4.Size = new Size(94, 29);
            button4.TabIndex = 2;
            button4.Text = "Select";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(3, 71);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(586, 27);
            textBox2.TabIndex = 1;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 48);
            label3.Name = "label3";
            label3.Size = new Size(145, 20);
            label3.TabIndex = 0;
            label3.Text = "Save folder location:";
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // timer_fast
            // 
            timer_fast.Enabled = true;
            timer_fast.Interval = 50;
            timer_fast.Tick += timer_fast_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(766, 538);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(tabControl1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Name = "Form1";
            Text = "Awsome Screenshot Program";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)n_for).EndInit();
            ((System.ComponentModel.ISupportInitialize)n_every).EndInit();
            ((System.ComponentModel.ISupportInitialize)n_delay).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private NotifyIcon notifyIcon1;
        private GroupBox groupBox1;
        private RadioButton r_window;
        private RadioButton r_fragment;
        private RadioButton r_full;
        private Button button2;
        private RadioButton r_fixed;
        private GroupBox groupBox2;
        private TextBox tx_keybind;
        private Label label1;
        private CheckBox c_keybind;
        private Button button3;
        private GroupBox groupBox3;
        private ComboBox cx_for;
        private NumericUpDown n_for;
        private ComboBox cx_every;
        private NumericUpDown n_every;
        private Label label2;
        private CheckBox c_delay;
        private NumericUpDown n_delay;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Button button4;
        private TextBox textBox2;
        private Label label3;
        private ComboBox comboBox3;
        private Label label7;
        private CheckBox c_editor;
        private Label label6;
        private Label label5;
        private TextBox textBox3;
        private Label label4;
        private CheckBox c_div;
        private CheckBox c_floc;
        private CheckBox c_clip;
        private CheckBox cx_save_enabled;
        private System.Windows.Forms.Timer timer1;
        private Label label8;
        private Label label9;
        private System.Windows.Forms.Timer timer_fast;
        private FolderBrowserDialog folderBrowserDialog1;
        private CheckBox c_noti;
        private Label label11;
        private Button button5;
        private CheckBox c_notify;
        private Button button6;
        private GroupBox groupBox4;
        private Label label16;
        private Label label15;
        private Label label14;
        private Label label13;
        private Label label12;
        private Label label10;
        private Button button8;
        private Label label17;
        private Button button7;
        private Label label18;
    }
}
