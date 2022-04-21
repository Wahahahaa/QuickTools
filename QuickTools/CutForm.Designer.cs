namespace QuickTools
{
    partial class CutForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // CutForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(253, 95);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CutForm";
            this.Opacity = 0.5D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CutForm";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CutForm_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CutForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CutForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CutForm_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
    }
}