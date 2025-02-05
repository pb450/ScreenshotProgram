using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenshotProgram
{
    public partial class ScreenshotWindow : Form
    {

        private Rectangle selectionRectangle;
        private Point startPoint;
        private bool isSelecting;

        public Bitmap waitImage;

        public Bitmap result;
        public Rectangle rectangle;

        public ScreenshotWindow()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = Color.Black;
            this.Opacity = 0.5;
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = true;

            var bs = new Rectangle(0, 0, this.Width, this.Height);
            waitImage = CaptureSelection(new Rectangle(0, 0, this.Width, this.Height));
        }

        private void ScreenshotWindow_Load(object sender, EventArgs e)
        {
            this.MouseDown += this.ScreenshotForm_MouseDown;
            this.MouseMove += this.ScreenshotForm_MouseMove;
            this.MouseUp += this.ScreenshotForm_MouseUp;
            this.Paint += this.ScreenshotForm_Paint;
            //this.Load += this.ScreenshotForm_Load;
            this.KeyDown += ScreenshotWindow_KeyDown;
            Cursor = Cursors.Cross;
        }

        private void ScreenshotWindow_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void ScreenshotForm_MouseDown(object sender, MouseEventArgs e)
        {
            startPoint = e.Location;
            isSelecting = true;
        }

        Point tempMousePos = Point.Empty;

        private void ScreenshotForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (isSelecting)
            {
                selectionRectangle = new Rectangle(
                    Math.Min(startPoint.X, e.X),
                    Math.Min(startPoint.Y, e.Y),
                    Math.Abs(startPoint.X - e.X),
                    Math.Abs(startPoint.Y - e.Y)
                );
                this.Invalidate();
            }
            else
            {
                tempMousePos = e.Location;
                this.Invalidate();
            }
        }

        private void ScreenshotForm_MouseUp(object sender, MouseEventArgs e)
        {
            isSelecting = false;
            this.Hide();
            var screenshot = CaptureSelection(selectionRectangle);
            SaveScreenshot(screenshot);
            SaveRect(selectionRectangle);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void SaveRect(Rectangle selectionRectangle)
        {
            rectangle = selectionRectangle;
        }

        private void ScreenshotForm_Paint(object sender, PaintEventArgs e)
        {
            if (selectionRectangle != Rectangle.Empty)
            {
                using (Pen pen = new Pen(Color.White, 2))
                {
                   // e.Graphics.DrawImage(waitImage, new Point(0, 0));
                   var sizeStr = selectionRectangle.Height + "x" + selectionRectangle.Width;
                   var textSize = TextRenderer.MeasureText(sizeStr, DefaultFont);
                   var margin = 10;
                   e.Graphics.FillRectangle(Brushes.Navy, selectionRectangle.X, selectionRectangle.Y, textSize.Width + 2*margin, textSize.Height + 2*margin);
                   e.Graphics.DrawString(sizeStr, DefaultFont, Brushes.White, new Point(selectionRectangle.X + margin, selectionRectangle.Y + margin));
                   e.Graphics.DrawRectangle(pen, selectionRectangle);
                }
            } else
            {
                if (tempMousePos == Point.Empty)
                {
                    return;
                }

                var pen = new Pen(Color.White, 7);
                var screenSize = Screen.PrimaryScreen.Bounds;
                e.Graphics.DrawLine(pen, new Point(0, tempMousePos.Y), new Point(screenSize.Width, tempMousePos.Y));
                e.Graphics.DrawLine(pen, new Point(tempMousePos.X, 0), new Point(tempMousePos.X, screenSize.Height));
            }
        }

        private Bitmap CaptureSelection(Rectangle rect)
        {
            Bitmap bitmap = new Bitmap(rect.Width, rect.Height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.CopyFromScreen(rect.Location, Point.Empty, rect.Size);
            }
            return bitmap;
        }

        private void SaveScreenshot(Bitmap bitmap)
        {
            result = bitmap;
            //string filePath = $"screenshot_{DateTime.Now:yyyyMMdd_HHmmss}.png";
            //bitmap.Save(filePath, ImageFormat.Png);
            //MessageBox.Show($"Screenshot saved: {filePath}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
