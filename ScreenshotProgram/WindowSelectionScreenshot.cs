using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenshotProgram
{
    public partial class WindowSelectionScreenshot : Form
    {

        private System.Windows.Forms.Timer hoverTimer;
        private IntPtr currentWindow;
        private Pen highlightPen;
        public Rectangle result;
        private string currentWindowTitle;

        public WindowSelectionScreenshot()
        {
            InitializeComponent();
            this.Text = "Window Hover Highlighter";
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.Opacity = 0.5;
            this.BackColor = SystemColors.HotTrack;
            this.TopMost = true;
            this.DoubleBuffered = true;

            highlightPen = new Pen(Color.Red, 3);
            hoverTimer = new System.Windows.Forms.Timer { Interval = 100 };
            hoverTimer.Tick += HoverTimer_Tick;
            hoverTimer.Start();

            this.MouseUp += WindowSelectionScreenshot_MouseUp;

        }

        private void WindowSelectionScreenshot_MouseUp(object? sender, MouseEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        [DllImport("user32.dll")]
        private static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [DllImport("user32.dll")]
        private static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern bool IsIconic(IntPtr hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);



        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        private delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        private void HoverTimer_Tick(object sender, EventArgs e)
        {
            Point cursorPosition = Cursor.Position;
            currentWindow = IntPtr.Zero;

            EnumWindows((hWnd, lParam) =>
            {
                if (IsWindowVisible(hWnd) && hWnd != this.Handle && !IsIconic(hWnd))
                {
                    if (GetWindowRect(hWnd, out RECT rect) &&
                        cursorPosition.X >= rect.Left && cursorPosition.X <= rect.Right &&
                        cursorPosition.Y >= rect.Top && cursorPosition.Y <= rect.Bottom)
                    {
                        currentWindow = hWnd;

                        StringBuilder title = new StringBuilder(256);
                        GetWindowText(hWnd, title, title.Capacity);
                        currentWindowTitle = title.ToString();
                        return false; // Stop enumeration as we found the window
                    }
                }
                return true; // Continue enumeration
            }, IntPtr.Zero);

            this.Invalidate(); // Redraw the form
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var pn = new Pen(Brushes.Pink, 7);

            if (currentWindow != IntPtr.Zero && GetWindowRect(currentWindow, out RECT rect))
            {
                Rectangle windowRectangle = new Rectangle(
                    rect.Left,
                    rect.Top,
                    rect.Right - rect.Left,
                    rect.Bottom - rect.Top
                );

                result = windowRectangle;
                e.Graphics.DrawRectangle(pn, windowRectangle);

                if (!string.IsNullOrEmpty(currentWindowTitle))
                {
                    using (Font font = new Font("Arial", 12, FontStyle.Bold))
                    using (Brush brush = new SolidBrush(Color.Red))
                    {
                        e.Graphics.DrawString(currentWindowTitle, font, brush, rect.Left + 5, rect.Top + 25);
                    }
                }

            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            hoverTimer.Stop();
            hoverTimer.Dispose();
            highlightPen.Dispose();
            base.OnFormClosing(e);
        }


        private void WindowSelectionScreenshot_Load(object sender, EventArgs e)
        {

        }
    }
}
