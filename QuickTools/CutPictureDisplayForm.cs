using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuickTools
{
    public partial class CutPictureDisplayForm : Form
    {
        private Boolean isDown = false;
        private Point DownPoint,MovePoint;
        private Bitmap bitmap;

        public CutPictureDisplayForm(Bitmap bitmap)
        {
            this.bitmap = bitmap;


            InitializeComponent();
            this.Size = new Size(bitmap.Width, bitmap.Height);
            //缩放
            this.Size = new Size((int)(bitmap.Width/ScreenInfo.ScaleX), (int)(bitmap.Height/ScreenInfo.ScaleX));
            this.pictureBox1.Image = bitmap;
            this.pictureBox1.MouseWheel += pictureBox1_MouseWheel;
        }

        private void TopMostMenuItem_Click(object sender, EventArgs e)
        {
            this.TopMost = true;
        }

        private void CancelTopMosttoolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.TopMost = false;
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //将图片复制粘贴版
            Clipboard.SetImage(bitmap);
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "png|*.png|bmp|*.bmp|jpg|*.jpg|gif|*.gif";
            if (saveFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                bitmap.Save(saveFileDialog.FileName);
            }
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.Close();
        }


        private void PictureBox1_MouseEnter(object sender, EventArgs e)
        {
            this.Opacity = 0.5;
        }

        private void PictureBox1_MouseLeave(object sender, EventArgs e)
        {
            this.Opacity = 1;
        }

        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDown = true;
                DownPoint = e.Location;
            }
        }

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDown)
            {
                MovePoint = e.Location;
                this.Location = new Point(this.Location.X + (MovePoint.X - DownPoint.X), this.Location.Y + (MovePoint.Y - DownPoint.Y));
            }
        }

        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (isDown)
            {
                isDown = false;
            }
        }


        private void pictureBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            int zoomStep = 10;
            if (e.Delta > 0)    //放大
            {
                this.Size = new Size(this.Size.Width + zoomStep, this.Size.Height + zoomStep);
            }
            if (e.Delta < 0)    //缩小
            {
                //防止一直缩成负值
                if (pictureBox1.Width < bitmap.Width / 10)
                    return;
                this.Size = new Size(this.Size.Width - zoomStep, this.Size.Height - zoomStep);
            }
        }
    }
}
