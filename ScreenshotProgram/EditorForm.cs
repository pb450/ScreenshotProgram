using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ScreenshotProgram
{
    public partial class EditorForm : Form
    {

        Bitmap bmp;
        bool mousePressed;

        Bitmap drawn;
        Graphics gfx;

        Bitmap temp;
        Graphics temp_gfx;

        Bitmap highliter_layer;
        Graphics highliter_gfx;

        Color color = Color.Red;

        Brush half_transparent_brush
        {
            get
            {
                return new SolidBrush(Color.FromArgb(100, color.R, color.G, color.B));
            }
        }

        Brush brush
        {
            get
            {
                return new SolidBrush(color);
            }
        }

        Pen pen
        {
            get { return new Pen(color, trackBar1.Value); }
        }

        int __a
        {
            get { return (int)trackBar2.Value; }
        }



        public DrawingMode mode;

        public EditorForm(Bitmap bmp)
        {
            InitializeComponent();

            this.bmp = bmp;
            this.DoubleBuffered = true;

            drawn = bmp;
            gfx = Graphics.FromImage(drawn);

            temp = new Bitmap(drawn.Width, drawn.Height);
            temp_gfx = Graphics.FromImage(temp);

            highliter_layer = new Bitmap(drawn.Width, drawn.Height);
            highliter_gfx = Graphics.FromImage(highliter_layer);

            saveFileDialog1.Filter = Filter();

            this.Shown += EditorForm_Shown;
            this.MouseWheel += EditorForm_MouseWheel;

            pictureBox1.MouseDown += PictureBox1_MouseDown;
            pictureBox1.MouseUp += PictureBox1_MouseUp;
            pictureBox1.MouseMove += PictureBox1_MouseMove;
            pictureBox1.Paint += PictureBox1_Paint;
        }

        private void EditorForm_MouseWheel(object? sender, MouseEventArgs e)
        {
            if (mode == DrawingMode.Text && dt != null)
            {
                if (e.Delta > 0f)
                {
                    dt.size += 1;
                    dt.size = dt.size > 100 ? 100 : dt.size;
                }
                else
                {
                    dt.size -= 1;
                    dt.size = dt.size < 1 ? 1 : dt.size;
                }
            }
        }

        private void EditorForm_Load(object sender, EventArgs e)
        {
            colorDialog1.AllowFullOpen = true;
        }

        private void PictureBox1_Paint(object? sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(drawn, new Rectangle(0, 0, drawn.Width, drawn.Height));
            e.Graphics.DrawImage(temp, new Rectangle(0, 0, temp.Width, temp.Height));


            ColorMatrix cm = new ColorMatrix();
            cm.Matrix33 = __a / 255f;
            using (ImageAttributes ia = new ImageAttributes())
            {
                ia.SetColorMatrix(cm, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                e.Graphics.DrawImage(highliter_layer, new Rectangle(0, 0, highliter_layer.Width, highliter_layer.Height), 0, 0, highliter_layer.Width, highliter_layer.Height, GraphicsUnit.Pixel, ia);
            }

        }

        public float dist(Point point1, Point point2)
        {
            var u = Math.Pow(point1.X - point2.X, 2) + Math.Pow(point1.Y - point2.Y, 2);
            return (float)Math.Sqrt(u);
        }

        Point point;
        DrawText dt;

        Point lastPos = Point.Empty;

        private void PictureBox1_MouseMove(object? sender, MouseEventArgs e)
        {
            if (mousePressed)
            {
                temp_gfx.Clear(Color.Transparent);

                if (lastPos == Point.Empty)
                {
                    lastPos = e.Location;
                }

                if (mode == DrawingMode.Highlight)
                {
                    //highliter_gfx.FillEllipse(half_transparent_brush, e.X - v/2, e.Y - v/2, v * 2, v * 2);
                    Pen px = pen;
                    px.StartCap = LineCap.Round;
                    px.EndCap = LineCap.Round;

                    highliter_gfx.DrawLine(px, lastPos, e.Location);
                    lastPos = e.Location;
                }

                if (mode == DrawingMode.Pencil)
                {
                    //gfx.FillEllipse(brush, e.X, e.Y, 15, 15);

                    Pen px = pen;
                    px.StartCap = LineCap.Round;
                    px.EndCap = LineCap.Round;

                    gfx.DrawLine(px, lastPos, e.Location);
                    lastPos = e.Location;
                }

                if (mode == DrawingMode.Rect)
                {
                    DrawRect(temp_gfx, point, e.Location);
                }

                if (mode == DrawingMode.Line)
                {
                    temp_gfx.DrawLine(pen, point, e.Location);
                }

                if (mode == DrawingMode.Arrow)
                {
                    DrawArrow(temp_gfx, point, e.Location);
                }

                if (mode == DrawingMode.Censor)
                {
                    var p1 = point;
                    var p2 = e.Location;

                    var width = Math.Abs(p1.X - p2.X);
                    var height = Math.Abs(p1.Y - p2.Y);
                    var x = Math.Min(p2.X, p1.X);
                    var y = Math.Min(p2.Y, p1.Y);

                    Pen p = new Pen(Color.Black, 6);
                    temp_gfx.DrawRectangle(p, x, y, width, height);
                }

                pictureBox1.Invalidate();
            }

            if (dt != null && mode == DrawingMode.Text)
            {
                temp_gfx.Clear(Color.Transparent);
                DrawNote(temp_gfx, e.Location, dt);

                pictureBox1.Invalidate();
            }
        }

        void DrawNote(Graphics gx, Point r, DrawText dx, bool db = false)
        {
            if (db)
            {
                Debug.WriteLine(gx.ToString());
                Debug.WriteLine(r.ToString());
                Debug.WriteLine(dx.text);
                Debug.WriteLine(dx.font);
            }

            var style = GetFont(dt.font_app);
            var ft = new Font(dt.font, dt.size, style);
            var ms = TextRenderer.MeasureText(dt.text, ft);

            if (checkBox1.Checked)
            {
                gx.FillRectangle(Brushes.Beige, r.X, r.Y, ms.Width + 2 * 20, ms.Height + 2 * 20);
                gx.DrawString(dt.text, ft, Brushes.Black, r.X + 20, r.Y + 20);
            }
            else
            {
                gx.DrawString(dt.text, ft, brush, r.X, r.Y);
            }
        }

        FontStyle GetFont(List<int> s)
        {
            FontStyle style = FontStyle.Regular;
            foreach (var item in s)
            {
                style |= (FontStyle)Math.Pow(2, item);
            }

            return style;
        }

        void DrawArrow(Graphics temp_gfx, Point p1, Point p2)
        {
            var pn = new Pen(color, trackBar1.Value);
            pn.CustomEndCap = new AdjustableArrowCap(trackBar1.Value / 2, trackBar1.Value / 2);
            temp_gfx.DrawLine(pn, p1, p2);
        }

        void DrawRect(Graphics graphics, Point p1, Point p2)
        {
            var width = Math.Abs(p1.X - p2.X);
            var height = Math.Abs(p1.Y - p2.Y);
            var x = Math.Min(p2.X, p1.X);
            var y = Math.Min(p2.Y, p1.Y);

            graphics.DrawRectangle(pen, x, y, width, height);
        }

        private void PictureBox1_MouseUp(object? sender, MouseEventArgs e)
        {
            if (mode == DrawingMode.Rect)
            {
                DrawRect(gfx, point, e.Location);
            }

            if (mode == DrawingMode.Line)
            {
                gfx.DrawLine(pen, point, e.Location);
            }

            if (mode == DrawingMode.Arrow)
            {
                DrawArrow(gfx, point, e.Location);
            }

            if (mode == DrawingMode.Censor)
            {
                var p1 = point;
                var p2 = e.Location;

                var width = Math.Abs(p1.X - p2.X);
                var height = Math.Abs(p1.Y - p2.Y);
                var x = Math.Min(p2.X, p1.X);
                var y = Math.Min(p2.Y, p1.Y);
                var rect = new Rectangle(x, y, width, height);

                var pix = Pixelate(drawn, rect, 5);
                gfx.DrawImage(pix, 0, 0);
            }

            if (mode == DrawingMode.Text)
            {
                Debug.WriteLine("DrawingModeText Mouse Up");
                DrawNote(gfx, e.Location, dt, true);

                trackBar1.Visible = true;
                checkBox1.Visible = false;

                mode = DrawingMode.None;
                dt = null;
            }

            temp_gfx.Clear(Color.Transparent);

            pictureBox1.Invalidate();
            //pictureBox1.Update();
            pictureBox1.Refresh();

            lastPos = Point.Empty;

            mousePressed = false;
        }

        private Bitmap Pixelate(Bitmap image, Rectangle rectangle, int pixelateSize)
        {
            Bitmap pixelated = new System.Drawing.Bitmap(image.Width, image.Height);

            // make an exact copy of the bitmap provided
            using (Graphics graphics = System.Drawing.Graphics.FromImage(pixelated))
                graphics.DrawImage(image, new System.Drawing.Rectangle(0, 0, image.Width, image.Height),
                    new Rectangle(0, 0, image.Width, image.Height), GraphicsUnit.Pixel);

            // look at every pixel in the rectangle while making sure we're within the image bounds
            for (Int32 xx = rectangle.X; xx < rectangle.X + rectangle.Width && xx < image.Width; xx += pixelateSize)
            {
                for (Int32 yy = rectangle.Y; yy < rectangle.Y + rectangle.Height && yy < image.Height; yy += pixelateSize)
                {
                    Int32 offsetX = pixelateSize / 2;
                    Int32 offsetY = pixelateSize / 2;

                    // make sure that the offset is within the boundry of the image
                    while (xx + offsetX >= image.Width) offsetX--;
                    while (yy + offsetY >= image.Height) offsetY--;

                    // get the pixel color in the center of the soon to be pixelated area
                    Color pixel = pixelated.GetPixel(xx + offsetX, yy + offsetY);

                    // for each pixel in the pixelate size, set it to the center color
                    for (Int32 x = xx; x < xx + pixelateSize && x < image.Width; x++)
                        for (Int32 y = yy; y < yy + pixelateSize && y < image.Height; y++)
                            pixelated.SetPixel(x, y, pixel);
                }
            }

            return pixelated;
        }

        private void PictureBox1_MouseDown(object? sender, MouseEventArgs e)
        {
            point = e.Location;
            mousePressed = true;
        }

        private void EditorForm_Shown(object? sender, EventArgs e)
        {
            pictureBox1.Image = drawn;

            pictureBox1.Width = bmp.Width;
            pictureBox1.Height = bmp.Height;

            var c1 = bmp.Width + pictureBox1.Left * 2;
            var c2 = bmp.Height + pictureBox1.Left * 8;

            Size s = new Size()
            {
                Width = c1 < 1259 ? 1259 : c1,
                Height = c2 < 497 ? 497 : c2
            };

            this.ClientSize = s;

            button8.BackColor = color;

            foreach (var item in Controls.OfType<System.Windows.Forms.Button>())
            {
                if (item != button1)
                {
                    item.Click += (x, y) =>
                    {
                        trackBar2.Visible = false;
                    };

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mode = DrawingMode.Highlight;
            trackBar2.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mode = DrawingMode.Pencil;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            mode = DrawingMode.Rect;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var cd = colorDialog1.ShowDialog();

            if (cd == DialogResult.OK)
            {
                color = colorDialog1.Color;
                button8.BackColor = color;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            mode = DrawingMode.Line;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            mode = DrawingMode.Arrow;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            mode = DrawingMode.Censor;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MyTextWindow mw = new MyTextWindow();
            var res = mw.ShowDialog();

            if (res == DialogResult.OK)
            {
                mode = DrawingMode.Text;

                var pickedText = mw.text;
                var font = mw.font;
                var font_app = mw.font_app;

                dt = new DrawText(pickedText, font, font_app);

                trackBar1.Visible = false;
                checkBox1.Visible = true;
            }
        }

        public class DrawText
        {
            public string text;
            public string font;
            public List<int> font_app;
            public int size;

            public DrawText(string txt, string ft, List<int> fa)
            {
                this.text = txt;
                this.font = ft;
                this.font_app = fa;
                this.size = 48;
            }
        }

        public enum DrawingMode
        {
            None,
            Highlight,
            Pencil,
            Rect,
            Line,
            Arrow,
            Censor,
            Text
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var res = saveFileDialog1.ShowDialog();

            if (res == DialogResult.OK)
            {
                var fn = saveFileDialog1.FileName;
                var ext = Path.GetExtension(fn);
                var type = getFormatEnum(ext.Replace(".", ""));
                //drawn.Save(fn, type);
                getImageForSave().Save(fn, type);
            }
        }

        Bitmap getImageForSave()
        {
            Bitmap bmp = new Bitmap(drawn.Width, drawn.Height);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.DrawImage(drawn, Point.Empty);
                //g.DrawImage(highliter_layer, Point.Empty);

                ColorMatrix cm = new ColorMatrix();
                cm.Matrix33 = __a / 255f;
                using (ImageAttributes ia = new ImageAttributes())
                {
                    ia.SetColorMatrix(cm, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                    g.DrawImage(highliter_layer, new Rectangle(0, 0, highliter_layer.Width, highliter_layer.Height), 0, 0, highliter_layer.Width, highliter_layer.Height, GraphicsUnit.Pixel, ia);
                }
            }

            return bmp;
        }

        public System.Drawing.Imaging.ImageFormat getFormatEnum(string ext)
        {
            switch (ext)
            {
                case "jpeg":
                    return System.Drawing.Imaging.ImageFormat.Jpeg;
                case "png":
                    return System.Drawing.Imaging.ImageFormat.Png;
                case "bmp":
                    return System.Drawing.Imaging.ImageFormat.Bmp;
                case "gif":
                    return System.Drawing.Imaging.ImageFormat.Gif;
                case "webp":
                    return System.Drawing.Imaging.ImageFormat.Webp;
                default:
                    return System.Drawing.Imaging.ImageFormat.Jpeg;
            }
        }

        string Filter()
        {
            var ext = new string[] { "png", "jpg", "bmp", "jpeg", "gif", "webp" };

            var fn = "";

            foreach (var ext2 in ext)
            {
                fn += $"Plik {ext2.ToUpper()}|*.{ext2}|";
            };

            return fn.TrimEnd('|');
        }


        private void button10_Click(object sender, EventArgs e)
        {
            var i = getImageForSave();
            Clipboard.SetImage(i);
        }

        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
            //pictureBox1.Update();
            pictureBox1.Refresh();
        }
    }
}
