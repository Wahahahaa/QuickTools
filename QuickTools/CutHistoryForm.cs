using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickTools
{
    public partial class CutHistoryForm : Form
    {
        private List<Bitmap> bitmaps = new List<Bitmap>();

        public CutHistoryForm(List<Bitmap> bitmaps)
        {
            this.bitmaps = bitmaps;
            InitializeComponent();

        }

        private void CutHistoryForm_Load(object sender, EventArgs e)
        {
            int i = 0;
            foreach (Bitmap bitmap in bitmaps)
            {
                PictureBox pictureBox = new PictureBox();
                pictureBox.Size = new System.Drawing.Size(200, 100);
                pictureBox.Location = new System.Drawing.Point(10, 10 + (110) * i);
                pictureBox.Image = bitmap;
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox.MouseClick += pictureBox_MouseClick;
                this.Controls.Add(pictureBox);
                i++;
            }

        }

        private void pictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                CutPictureDisplayForm cutPictureDisplayForm = new CutPictureDisplayForm(new Bitmap(((PictureBox)sender).Image));
                cutPictureDisplayForm.Show();
            }
        }
    }
}
