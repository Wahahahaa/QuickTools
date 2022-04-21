using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
                //再画一遍，去除上次的边框线
                if (size.Width != 0 && size.Height != 0 && havePainted)
                {
                    ControlPaint.DrawReversibleFrame(new Rectangle(temp, size), Color.Transparent, FrameStyle.Dashed);
                }


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
                    ControlPaint.DrawReversibleFrame(new Rectangle(temp, size), Color.Transparent, FrameStyle.Dashed);
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
                    ControlPaint.DrawReversibleFrame(new Rectangle(temp, size), Color.Transparent, FrameStyle.Dashed);
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
