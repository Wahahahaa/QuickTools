namespace QuickTools
{
    partial class SearchForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btExit = new System.Windows.Forms.Button();
            this.btConfirm = new System.Windows.Forms.Button();
            this.btChoose = new System.Windows.Forms.Button();
            this.tbSearchNum = new System.Windows.Forms.TextBox();
            this.tbKeyWord = new System.Windows.Forms.TextBox();
            this.tbDir = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btExit);
            this.splitContainer1.Panel1.Controls.Add(this.btConfirm);
            this.splitContainer1.Panel1.Controls.Add(this.btChoose);
            this.splitContainer1.Panel1.Controls.Add(this.tbSearchNum);
            this.splitContainer1.Panel1.Controls.Add(this.tbKeyWord);
            this.splitContainer1.Panel1.Controls.Add(this.tbDir);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.richTextBox);
            this.splitContainer1.Size = new System.Drawing.Size(329, 514);
            this.splitContainer1.SplitterDistance = 172;
            this.splitContainer1.TabIndex = 0;
            // 
            // btExit
            // 
            this.btExit.Location = new System.Drawing.Point(243, 80);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(75, 23);
            this.btExit.TabIndex = 2;
            this.btExit.Text = "退出";
            this.btExit.UseVisualStyleBackColor = true;
            this.btExit.Click += new System.EventHandler(this.BtExit_Click);
            // 
            // btConfirm
            // 
            this.btConfirm.Location = new System.Drawing.Point(243, 41);
            this.btConfirm.Name = "btConfirm";
            this.btConfirm.Size = new System.Drawing.Size(75, 23);
            this.btConfirm.TabIndex = 2;
            this.btConfirm.Text = "确认";
            this.btConfirm.UseVisualStyleBackColor = true;
            this.btConfirm.Click += new System.EventHandler(this.BtConfirm_Click);
            // 
            // btChoose
            // 
            this.btChoose.Location = new System.Drawing.Point(243, 4);
            this.btChoose.Name = "btChoose";
            this.btChoose.Size = new System.Drawing.Size(75, 23);
            this.btChoose.TabIndex = 2;
            this.btChoose.Text = "选择目录";
            this.btChoose.UseVisualStyleBackColor = true;
            this.btChoose.Click += new System.EventHandler(this.BtChoose_Click);
            // 
            // tbSearchNum
            // 
            this.tbSearchNum.Location = new System.Drawing.Point(110, 82);
            this.tbSearchNum.Name = "tbSearchNum";
            this.tbSearchNum.Size = new System.Drawing.Size(100, 21);
            this.tbSearchNum.TabIndex = 1;
            this.tbSearchNum.Text = "1";
            // 
            // tbKeyWord
            // 
            this.tbKeyWord.Location = new System.Drawing.Point(110, 43);
            this.tbKeyWord.Name = "tbKeyWord";
            this.tbKeyWord.Size = new System.Drawing.Size(100, 21);
            this.tbKeyWord.TabIndex = 1;
            // 
            // tbDir
            // 
            this.tbDir.Location = new System.Drawing.Point(110, 6);
            this.tbDir.Name = "tbDir";
            this.tbDir.Size = new System.Drawing.Size(100, 21);
            this.tbDir.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "搜索线程数";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "关键词";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "目录";
            // 
            // richTextBox
            // 
            this.richTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox.Location = new System.Drawing.Point(0, 0);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(329, 338);
            this.richTextBox.TabIndex = 1;
            this.richTextBox.Text = "";
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 514);
            this.Controls.Add(this.splitContainer1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SearchForm";
            this.Text = "SearchForm";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btExit;
        private System.Windows.Forms.Button btConfirm;
        private System.Windows.Forms.Button btChoose;
        private System.Windows.Forms.TextBox tbSearchNum;
        private System.Windows.Forms.TextBox tbKeyWord;
        private System.Windows.Forms.TextBox tbDir;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox;
    }
}