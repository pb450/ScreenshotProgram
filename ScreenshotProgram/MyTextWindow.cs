using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenshotProgram
{
    public partial class MyTextWindow : Form
    {
        public MyTextWindow()
        {
            InitializeComponent();
        }

        public string text;
        public string font;
        public List<int> font_app;

        private void MyTextWindow_Load(object sender, EventArgs e)
        {
            this.Shown += MyTextWindow_Shown;
        }

        private void MyTextWindow_Shown(object? sender, EventArgs e)
        {
            var fonts = new List<string>();
            foreach (var item in System.Drawing.FontFamily.Families)
            {
                fonts.Add(item.Name);
            }

            comboBox1.Items.AddRange(fonts.ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.text = textBox1.Text;
            //this.font = comboBox1.SelectedItem.ToString();
            var c = comboBox1.SelectedIndex;
            this.font_app = checkedListBox1.CheckedIndices.Cast<int>().ToList();

            if (string.IsNullOrEmpty(this.text))
            {
                MessageBox.Show("Brak wpisanego tekstu");
                return;
            }

            if (c == -1)
            {
                MessageBox.Show("Brak wybranej czcionki");
                return;
            }

            this.font = comboBox1.SelectedItem.ToString();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
