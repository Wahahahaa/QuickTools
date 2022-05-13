using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace QuickTools
{
    public partial class CutForm : Form
    {
        private Point start, end, temp;
        private bool mouseDown = false, havePainted = false;
        private Size size = new Size(0, 0);
        private bool isStartCut = true;
        private Bitmap bitmap;
        

        public CutForm()
        {
            InitializeComponent();

        }

        private void CutForm_Load(object sender, EventArgs e)
        {
            Rectangle rect = System.Windows.Forms.SystemInformation.VirtualScreen;
            int w = rect.Width, h = rect.Height;
            if (this.Width != w || this.Height != h)
            {
                this.Width = w;
                this.Height = h;
                this.MaximumSize = this.MinimumSize = new System.Drawing.Size(w, h);
                this.Location = new Point(0, 0);
            }
        }

        public Bitmap GetBitmap()
        {
            return bitmap;
        }

        private void CutForm_MouseDown(object sender, MouseEventArgs e)
        {
            //右键退出
            if(e.Button == MouseButtons.Right)
            {
                isStartCut = false;
                return;
            }

            if (isStartCut)
            { 
                start = e.Location;
                //缩放
                start.X = (int)(start.X * ScreenInfo.ScaleX);
                start.Y = (int)(start.Y * ScreenInfo.ScaleX);
                mouseDown = true;
            }
        }

        private void CutForm_MouseMove(object sender, MouseEventArgs e)
        {
            
            if (isStartCut && mouseDown)
            {


                end = e.Location;
                //缩放
                end.X = (int)(end.X * ScreenInfo.ScaleX);
                end.Y = (int)(end.Y * ScreenInfo.ScaleX);
                size.Width = Math.Abs(end.X  - start.X);
                size.Height = Math.Abs(end.Y - start.Y);
                temp.X = Math.Min(start.X,end.X);
                temp.Y = Math.Min(start.Y, end.Y);
                if (size.Width != 0 && size.Height != 0)
                {
                    panel1.Location = new Point(Math.Min(start.X,end.X), Math.Min(start.Y,end.Y));
                    panel1.Size = new Size(size.Width, size.Height);
                    havePainted = true;
                }
            }
        }

        private void CutForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (isStartCut)
            {
                if (size.Width != 0 && size.Height != 0)
                {
                    havePainted = false;
                    bitmap = new Bitmap(size.Width, size.Height);
                    Graphics g = Graphics.FromImage(bitmap);
                    g.CopyFromScreen(temp, new Point(0, 0), bitmap.Size);
                }
                this.Opacity = 0.0;
                Thread.Sleep(200);
                mouseDown = false;
            }
            this.Close();
        }

        /*
         * 按键事件函数
         * ESC：退出
         */
        private void CutForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)
            {
                this.Close();
            }
        }

    }
}
