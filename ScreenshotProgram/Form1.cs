using Microsoft.Toolkit.Uwp.Notifications;
using Newtonsoft.Json;
using ScreenshotProgram.Properties;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Input;

namespace ScreenshotProgram
{
    public partial class Form1 : Form
    {

        public ScreenshotProgramSettings activeSettings;
        private GlobalKeyboardHook _globalKeyboardHook;

        public Form1()
        {
            InitializeComponent();
            this.Shown += Form1_Shown;
            this.FormClosing += Form1_FormClosing;
            this.Load += Form1_Load;
            _globalKeyboardHook = new GlobalKeyboardHook();
            _globalKeyboardHook.KeyDown += GlobalKeyboardHook_KeyDown;
            ToastNotificationManagerCompat.OnActivated += ToastNotificationManagerCompat_OnActivated;
        }

        private void ToastNotificationManagerCompat_OnActivated(ToastNotificationActivatedEventArgsCompat e)
        {
            ToastArguments args = ToastArguments.Parse(e.Argument);
            string k;
            var v = args.TryGetValue("flnm", out k);

            if (v)
            {
                var info = new ProcessStartInfo();
                info.FileName = k;
                info.UseShellExecute = true;

                Process px = new Process();
                px.StartInfo = info;
                px.Start();
            }
        }

        private void Form1_FormClosing(object? sender, FormClosingEventArgs e)
        {
            var currPath = Path.GetDirectoryName(Application.ExecutablePath);
            var finalPath = Path.Combine(currPath, "settings.json");

            File.WriteAllText(finalPath, JsonConvert.SerializeObject(activeSettings));
        }

        private async void GlobalKeyboardHook_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == activeSettings.keybind.key && !listening_to_hotkey && activeSettings.keybind.active)
            {
                if (a != null)
                {
                    return;
                }

                if (activeSettings.timer.delay_active && activeSettings.timer.delay > 0)
                {
                    await DelaySC(activeSettings.timer.delay);
                } else
                {
                    StartScreenshot();
                }
                
            }
        }

        private void Form1_Shown(object? sender, EventArgs e)
        {

        }

        string ICON_PATH = "";
        string SOUND_PATH = "";

        void SetupFiles()
        {
            var p = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "files");

            if (!Directory.Exists(p))
            {
                Directory.CreateDirectory(p);
            }

            ICON_PATH = Path.Combine(p, "ic.png");
            if (!File.Exists(ICON_PATH))
            {
                Properties.Resources.icam.Save(ICON_PATH, System.Drawing.Imaging.ImageFormat.Png);
            }

            SOUND_PATH = Path.Combine(p, "cs.mp3");
            if (!File.Exists(SOUND_PATH))
            {
                var bytes = Properties.Resources.cs;
                File.WriteAllBytes(SOUND_PATH, bytes);
            }
        }

        void LoadSettings(ScreenshotProgramSettings s)
        {
            activeSettings = s;

            switch (s.mode)
            {
                case SHMode.FullScreen:
                    r_full.Checked = true;
                    break;
                case SHMode.Fragment:
                    r_fragment.Checked = true;
                    break;
                case SHMode.FixedFragment:
                    r_fixed.Checked = true;
                    break;
                case SHMode.Window:
                    r_window.Checked = true;
                    break;
                default:
                    break;
            }

            c_delay.Checked = s.timer.delay_active;
            n_delay.Value = s.timer.delay;

            //c_acpt.Checked = s.timer.autoctp_active;
            n_every.Value = s.timer.every;
            cx_every.SelectedIndex = s.timer.every_unit;

            n_for.Value = s.timer.for_time;
            cx_for.SelectedIndex = s.timer.for_time_unit;

            c_keybind.Checked = s.keybind.active;
            tx_keybind.Text = s.keybind.key;

            cx_save_enabled.Checked = s.saveSettings.save_enabled;
            textBox2.Text = s.saveSettings.path;
            textBox3.Text = s.saveSettings.filename;
            comboBox3.SelectedIndex = s.saveSettings.pref_save_form;

            c_div.Checked = s.saveSettings.file_op;
            c_floc.Checked = s.saveSettings.file_loc;
            c_clip.Checked = s.saveSettings.after_clip;
            c_editor.Checked = s.saveSettings.after_editor;

            c_noti.Checked = s.saveSettings.annoucement.notification;
            c_notify.Checked = s.saveSettings.annoucement.sound;

            c_delay.Checked = s.timer.delay_active;
            n_delay.Value = s.timer.delay;
        }

        public ScreenshotProgramSettings GetSettings()
        {
            ScreenshotProgramSettings s = new ScreenshotProgramSettings();

            if (r_full.Checked)
                s.mode = SHMode.FullScreen;
            else if (r_fragment.Checked)
                s.mode = SHMode.Fragment;
            else if (r_fixed.Checked)
                s.mode = SHMode.FixedFragment;
            else if (r_window.Checked)
                s.mode = SHMode.Window;

            s.timer.delay_active = c_delay.Checked;
            s.timer.delay = (int)n_delay.Value;

            //s.timer.autoctp_active = c_acpt.Checked;
            s.timer.every = (int)n_every.Value;
            s.timer.every_unit = cx_every.SelectedIndex;

            s.timer.for_time = (int)n_for.Value;
            s.timer.for_time_unit = cx_for.SelectedIndex;

            s.keybind.active = c_keybind.Checked;
            s.keybind.key = tx_keybind.Text;

            s.saveSettings.save_enabled = cx_save_enabled.Checked;
            s.saveSettings.path = textBox2.Text;
            s.saveSettings.filename = textBox3.Text;
            s.saveSettings.pref_save_form = comboBox3.SelectedIndex;

            s.saveSettings.file_op = c_div.Checked;
            s.saveSettings.file_loc = c_floc.Checked;
            s.saveSettings.after_clip = c_clip.Checked;
            s.saveSettings.after_editor = c_editor.Checked;

            s.saveSettings.annoucement.notification = c_noti.Checked;
            s.saveSettings.annoucement.sound = c_notify.Checked;

            s.FixedFragmentRect = activeSettings.FixedFragmentRect;
            s.saveSettings.index = activeSettings.saveSettings.index;

            s.timer.delay_active = c_delay.Checked;
            s.timer.delay = (int)n_delay.Value;

            return s;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listening_to_hotkey) { return; }
            this.Hide();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (a != null)
            {
                return;
            }

            if (activeSettings.timer.delay_active && activeSettings.timer.delay > 0)
            {
                await DelaySC(activeSettings.timer.delay);
            }
            else
            {
                StartScreenshot();
            }
        }

        public (int, int) GetSizeForHero(int height, int width, int maxSize)
        {
            int newWidth, newHeight;

            if (width > height)
            {
                newWidth = maxSize;
                newHeight = (int)(height * ((float)maxSize / width));
            }
            else
            {
                newHeight = maxSize;
                newWidth = (int)(width * ((float)maxSize / height));
            }

            return (newHeight, newWidth);
        }

        void ShowToast(bool saveEn, string path, Bitmap img)
        {
            var _p = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "temp.jpg");
            var size = GetSizeForHero(img.Height, img.Width, 500);


            using (Bitmap bmp = new Bitmap(img, size.Item2, size.Item1))
            {
                bmp.Save(_p, System.Drawing.Imaging.ImageFormat.Jpeg);
            }


            var url = $"file:///{_p}";
            var tb = new ToastContentBuilder().AddText("Screenshot taken!").AddHeroImage(new Uri(url, UriKind.Absolute));
            //tb = tb.AddAppLogoOverride()
            //this.resources
            var fn = Path.GetFileName(path);
            tb = tb.AddAppLogoOverride(new Uri($"file:///{ICON_PATH}", UriKind.Absolute));

            if (activeSettings.saveSettings.annoucement.sound)
                tb = tb.AddAudio(new Uri($"file:///{SOUND_PATH}", UriKind.Absolute));

            if (saveEn)
            {
                Debug.WriteLine(path);
                tb = tb.AddText($"File name: {fn}");
                tb = tb.AddArgument("flnm", path);
            }

            tb = tb.SetToastDuration(ToastDuration.Short);
            tb.Show();
        }

        async Task DelaySC(int ms)
        {
            await Task.Delay(ms);

            StartScreenshot();
        }

        public void StartScreenshot()
        {
            //this.WindowState = FormWindowState.Minimized;
            if (listening_to_hotkey)
            {
                return;
            }

            this.Opacity = 0;
            var img = GetScreenshot();
            this.Opacity = 1;
            //this.WindowState = FormWindowState.Normal;

            if (img == null)
            {
                MessageBox.Show("Error during screenshot!");
                return;
            }

            var sl = activeSettings.saveSettings.path;
            var fn = FormatFileName(activeSettings.saveSettings.filename, false) + getSelectedExtensions();
            var ps = Path.Combine(sl, fn);
            var type = getFormatEnum();

            if (activeSettings.saveSettings.save_enabled)
            {
                img.Save(ps, type);
            }

            if (activeSettings.saveSettings.annoucement.notification)
            {
                ShowToast(activeSettings.saveSettings.save_enabled, ps, img);
            }

            if (activeSettings.saveSettings.after_editor)
            {
                EditorForm ef = new EditorForm(img);
                ef.Show();
            }

            if (activeSettings.saveSettings.after_clip)
            {
                Clipboard.SetImage(img);
            }

            if (activeSettings.saveSettings.file_loc && activeSettings.saveSettings.save_enabled)
            {
                var info = new ProcessStartInfo();
                info.FileName = "explorer";
                info.Arguments = string.Format("/e, /select, \"{0}\"", ps);

                Process px = new Process();
                px.StartInfo = info;
                px.Start();
            }

            if (activeSettings.saveSettings.file_op && activeSettings.saveSettings.save_enabled)
            {
                var info = new ProcessStartInfo();
                info.FileName = ps;
                info.UseShellExecute = true;

                Process px = new Process();
                px.StartInfo = info;
                px.Start();
            }
        }

        public Bitmap GetScreenshot()
        {
            Debug.WriteLine(this.WindowState);
            if (activeSettings.mode == SHMode.Fragment)
            {
                ScreenshotWindow sw = new ScreenshotWindow();
                var v = sw.ShowDialog();
                if (v == DialogResult.OK)
                {
                    return sw.result;
                }

            }
            else if (activeSettings.mode == SHMode.FullScreen)
            {
                var rect = Screen.PrimaryScreen.Bounds;
                Bitmap bitmap = new Bitmap(rect.Width, rect.Height);
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(rect.Location, Point.Empty, rect.Size);
                }
                return bitmap;
            }
            else if (activeSettings.mode == SHMode.FixedFragment)
            {
                var rect = activeSettings.FixedFragmentRect;
                if (rect != Rectangle.Empty)
                {
                    Bitmap bitmap = new Bitmap(rect.Width, rect.Height);
                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        g.CopyFromScreen(rect.Location, Point.Empty, rect.Size);
                    }
                    return bitmap;
                }
            }
            else if (activeSettings.mode == SHMode.Window)
            {
                WindowSelectionScreenshot wfs = new WindowSelectionScreenshot();
                var res = wfs.ShowDialog();

                if (res == DialogResult.OK)
                {
                    var rect = wfs.result;

                    Bitmap bitmap = new Bitmap(rect.Width, rect.Height);
                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        g.CopyFromScreen(rect.Location, Point.Empty, rect.Size);
                    }
                    return bitmap;
                }
            }

            return null;
        }

        public Bitmap GetTempImg()
        {
            Random rnd = new Random();
            Bitmap bmp = new Bitmap(100, 100);
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    var c = rnd.NextDouble() < 0.5 ? Color.Pink : Color.Red;
                    var h = rnd.NextDouble() < 0.2 ? Color.RebeccaPurple : c;
                    bmp.SetPixel(i, j, rnd.NextDouble() < 0.5 ? h : Color.Navy);
                }
            }

            return bmp;
        }

        public Bitmap? StartCapture()
        {
            this.Hide();
            ScreenshotWindow sw = new ScreenshotWindow();
            var res = sw.ShowDialog();

            if (res == DialogResult.OK)
            {
                var rm = sw.result;

                return rm;
            }

            this.Show();

            return null;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            activeSettings = GetSettings();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            UpdateNames();
        }

        void UpdateNames()
        {
            Debug.WriteLine(textBox3.Text);
            if (!string.IsNullOrEmpty(textBox3.Text))
            {
                var replace = textBox3.Text;
                var fn = FormatFileName(replace);
                label5.Text = "Sample file name: " + fn;
                label8.Text = "Sample file path: " + activeSettings.saveSettings.path + "\\" + fn + getSelectedExtensions();
            }
        }

        public string getSelectedExtensions()
        {
            switch (comboBox3.SelectedIndex)
            {
                case 0:
                    return ".jpg";
                case 1:
                    return ".png";
                case 2:
                    return ".bmp";
                case 3:
                    return ".gif";
                case 4:
                    return ".webp";
                default:
                    return ".jpg";
            }
        }

        public System.Drawing.Imaging.ImageFormat getFormatEnum()
        {
            switch (comboBox3.SelectedIndex)
            {
                case 0:
                    return System.Drawing.Imaging.ImageFormat.Jpeg;
                case 1:
                    return System.Drawing.Imaging.ImageFormat.Png;
                case 2:
                    return System.Drawing.Imaging.ImageFormat.Bmp;
                case 3:
                    return System.Drawing.Imaging.ImageFormat.Gif;
                case 4:
                    return System.Drawing.Imaging.ImageFormat.Webp;
                default:
                    return System.Drawing.Imaging.ImageFormat.Jpeg;
            }
        }

        public string FormatFileName(string fn, bool sample = true)
        {
            var dn = DateTime.Now;

            var vals = new Dictionary<string, string>();
            //vals.Add("{d}", dn.ToString("yyyy-MM-dd"));
            //vals.Add("{t}", dn.ToString("HH-mm-ss"));

            vals.Add("{y}", dn.ToString("yyyy"));
            vals.Add("{M}", dn.ToString("MM"));
            vals.Add("{d}", dn.ToString("dd"));
            vals.Add("{h}", dn.ToString("HH"));
            vals.Add("{m}", dn.ToString("mm"));
            vals.Add("{s}", dn.ToString("ss"));

            if (!sample)
            {
                activeSettings.saveSettings.index++;
            }

            vals.Add("{i}", activeSettings.saveSettings.index.ToString());
            vals.Add("{u}", Environment.UserName);

            foreach (var item in vals)
            {
                fn = Regex.Replace(fn, item.Key, item.Value);
            }

            return fn;
        }

        public bool listening_to_hotkey = false;

        private void button3_Click(object sender, EventArgs e)
        {
            listening_to_hotkey = !listening_to_hotkey;
        }

        private void Form1_KeyUp(object? sender, KeyEventArgs e)
        {
            if (listening_to_hotkey)
            {
                activeSettings.keybind.key = e.KeyData.ToString();
                tx_keybind.Text = activeSettings.keybind.key;
                listening_to_hotkey = false;
            }
        }

        private void timer_fast_Tick(object sender, EventArgs e)
        {
            label9.Visible = listening_to_hotkey;
            textBox2.BackColor = Directory.Exists(activeSettings.saveSettings.path) ? Color.White : Color.DarkRed;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                activeSettings.saveSettings.path = folderBrowserDialog1.SelectedPath;
                textBox2.Text = activeSettings.saveSettings.path;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var currPath = Path.GetDirectoryName(Application.ExecutablePath);
            var finalPath = Path.Combine(currPath, "settings.json");

            if (File.Exists(finalPath))
            {
                var txt = File.ReadAllText(finalPath);
                LoadSettings(JsonConvert.DeserializeObject<ScreenshotProgramSettings>(txt));
            }
            else
            {
                LoadSettings(new ScreenshotProgramSettings());
            }

            this.KeyUp += Form1_KeyUp;
            timer_fast.Tick += HandleAutocapture;
            groupBox4.Visible = false;

            SetupFiles();
        }

        private void HandleAutocapture(object? sender, EventArgs e)
        {
            HandleAutocapture();
        }

        private void r_fixed_CheckedChanged(object sender, EventArgs e)
        {
            if (r_fixed.Checked)
            {
                this.Hide();
                ScreenshotWindow sw = new ScreenshotWindow();
                var res = sw.ShowDialog();

                if (res == DialogResult.OK)
                {
                    var rm = sw.rectangle;
                    activeSettings.FixedFragmentRect = rm;

                    label11.Text = $"X:{rm.X}, Y: {rm.Y}, Height: {rm.Height}, Width: {rm.Width}";
                }

                this.Show();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            UpdateNames();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var msg = "Filename template help:\r\n" + "{y} - Year in four-digit format.\r\n" +
                  "{M} - Month in two-digit format.\r\n" +
                  "{d} - Day of the month in two-digit format.\r\n" +
                  "{h} - Hour in 24-hour format, two digits.\r\n" +
                  "{m} - Minutes in two-digit format.\r\n" +
                  "{s} - Seconds in two-digit format.\r\n" +
                  "{i} - Current index\r\n" + "{u} - Current username";
            MessageBox.Show(msg);
        }

        private void c_noti_CheckedChanged(object sender, EventArgs e)
        {
            c_notify.Enabled = c_noti.Checked;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            activeSettings.saveSettings.index = 0;
            UpdateNames();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (a != null)
            {
                return;
            }

            var isFS = activeSettings.mode == SHMode.FullScreen;
            var isFX = activeSettings.mode == SHMode.FixedFragment;

            if (!(isFS || isFX))
            {
                MessageBox.Show("Autocapture is possible only in full screen of fixed fragment mode");
                return;
            }

            groupBox4.Visible = true;

            Autocapture ax = new Autocapture();
            ax.SetEndDate((int)n_for.Value, cx_for.SelectedIndex);
            ax.SetStep((int)n_every.Value, cx_every.SelectedIndex);

            Debug.WriteLine(cx_for.SelectedIndex);

            a = ax;

            Debug.WriteLine(JsonConvert.SerializeObject(a));
        }

        Autocapture a;
        void HandleAutocapture()
        {
            if (a != null)
            {
                var dt = DateTime.Now;

                label13.Text = (DateTime.Now - a.last.AddMilliseconds(a.step.TotalMilliseconds)).ToString(@"hh\:mm\:ss");
                label15.Text = a.end.ToString("dd-MM-yyyy HH:mm:ss");

                var sks = (a.end - DateTime.Now);
                var df = (int)Math.Floor(sks.TotalMilliseconds / a.step.TotalMilliseconds);

                label16.Text = "in: " + sks.ToString(@"hh\:mm\:ss") + $" ({df} screens left)";

                if ((dt - a.last).TotalMilliseconds > a.step.TotalMilliseconds)
                {
                    StartScreenshot();
                    a.last = DateTime.Now;
                }

                if (dt > a.end)
                {
                    a = null;
                    groupBox4.Visible = false;
                    Debug.WriteLine("null a");
                }
            }
        }

        public string FormatTimeSpan(TimeSpan timeSpan)
        {
            return string.Format("{0:D2}:{1:D2}:{2:D2}",
                                 (int)timeSpan.TotalHours,
                                 timeSpan.Minutes,
                                 timeSpan.Seconds);
        }

        public class Autocapture
        {
            public DateTime end;
            public DateTime last;

            public TimeSpan step;

            public Autocapture()
            {
                last = DateTime.Now;
            }

            public void SetEndDate(int amount, int t)
            {
                end = DateTime.Now;

                switch (t)
                {
                    case 0:
                        end = end.AddSeconds(amount);
                        break;
                    case 1:
                        end = end.AddMinutes(amount);
                        break;
                    case 2:
                        end = end.AddHours(amount);
                        break;
                    case 3:
                        end = end.AddDays(amount);
                        break;
                }
            }

            public void SetStep(int amount, int t)
            {
                step = TimeSpan.Zero;

                switch (t)
                {
                    case 0:
                        step = TimeSpan.FromSeconds(amount);
                        break;
                    case 1:
                        step = TimeSpan.FromMinutes(amount);
                        break;
                    case 2:
                        step = TimeSpan.FromHours(amount);
                        break;
                    case 3:
                        step = TimeSpan.FromDays(amount);
                        break;
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (a != null)
            {
                a = null;
                groupBox4.Visible = false;
            }
        }
    }
}
