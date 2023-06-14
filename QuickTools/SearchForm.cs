using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Concurrent;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace QuickTools
{
    public partial class SearchForm : Form
    {
        //阻塞集合
        private BlockingCollection<FileInfo> _queue;
        private String keyWord = string.Empty;
        private String searchPath = string.Empty;
        private int searchThreadCount = 0;

        public SearchForm()
        {
            InitializeComponent();

            //允许是多线程操作RichTextBox控件
            RichTextBox.CheckForIllegalCrossThreadCalls = false;
        }

        private void BtChoose_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择文件路径";
            DialogResult result = dialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }
            this.tbDir.Text = dialog.SelectedPath.Trim();
        }

        private void BtConfirm_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(this.tbDir.Text))
            {
                MessageBox.Show("目录不能为空,请输入");
                return;
            }
            if (string.IsNullOrEmpty(this.tbKeyWord.Text))
            {
                MessageBox.Show("关键字不能为空,请输入");
                return;
            }
            if (string.IsNullOrEmpty(this.tbSearchNum.Text))
            {
                MessageBox.Show("搜索线程数不能为空,请输入");
                return;
            }

            if (!Directory.Exists(this.tbDir.Text))
            {
                MessageBox.Show("目录不存在,请检查后重新输入");
                return;
            }

            if (!int.TryParse(this.tbSearchNum.Text, out searchThreadCount))
            {
                MessageBox.Show("搜索线程数不为整数,请检查后重新输入");
                return;
            }

            keyWord = this.tbKeyWord.Text;
            searchPath = this.tbDir.Text;

            //清空RichTextBox显示
            this.richTextBox.Clear();
            _queue = new BlockingCollection<FileInfo>(new ConcurrentQueue<FileInfo>());

            //创建文件写入线程
            Thread thread1 = new Thread(new ParameterizedThreadStart(enumerate0));
            thread1.Start(new DirectoryInfo(searchPath));

            //根据线程数量创建读取线程
            for(int i = 0;i< searchThreadCount;i++)
            {
                Thread thread = new Thread(new ThreadStart(search));
                thread.Start();
            }
            
        }

        private void BtExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void enumerate(object directory)
        {
            FileInfo[] fileInfos = ((DirectoryInfo)directory).GetFiles();
            foreach(FileInfo fileInfo in fileInfos)
            {
                _queue.Add(fileInfo);
                //this.richTextBox.AppendText(fileInfo.FullName+"\n");
                //Console.WriteLine(fileInfo.FullName + "\n");
            }
            DirectoryInfo[] directoryInfos = ((DirectoryInfo)directory).GetDirectories();
            foreach (DirectoryInfo directoryInfo in directoryInfos)
            {
                enumerate(directoryInfo);
            }
        }

        //生产者所有文件写入阻塞队列并在最后增加一个结束标识
        public void enumerate0(object directory)
        {
            enumerate(directory);
            _queue.CompleteAdding();
        }

        //消费者将文件取出阻塞集合
        //每个消费者都一直循环阻塞集合，直到遇到结束标识后退出
        public void search()
        {
            while (!_queue.IsCompleted)
            {
                FileInfo file = _queue.Take();
                int i = 0;
                switch (file.Extension.ToString())
                {
                    case ".dox":
                    case ".docx": 
                        object fileName = file.FullName;
                        object MissingValue = Type.Missing;
                        Microsoft.Office.Interop.Word.Application wp = new Microsoft.Office.Interop.Word.ApplicationClass();

                        Microsoft.Office.Interop.Word.Document wd = wp.Documents.Open(ref fileName, ref MissingValue,
                                                                                      ref MissingValue, ref MissingValue,
                                                                                      ref MissingValue, ref MissingValue,
                                                                                      ref MissingValue, ref MissingValue,
                                                                                      ref MissingValue, ref MissingValue,
                                                                                      ref MissingValue, ref MissingValue,
                                                                                      ref MissingValue, ref MissingValue,
                                                                                      ref MissingValue, ref MissingValue);

                        Microsoft.Office.Interop.Word.Find wfnd;
                        if (wd.Paragraphs != null && wd.Paragraphs.Count > 0)
                        {
                            int iCount = wd.Paragraphs.Count;
                            for (i = 1; i <= iCount; i++)
                            {
                                wfnd = wd.Paragraphs[i].Range.Find;
                                wfnd.ClearFormatting();
                                wfnd.Text = keyWord;
                                if (wfnd.Execute(ref MissingValue, ref MissingValue,
                                    ref MissingValue, ref MissingValue,
                                    ref MissingValue, ref MissingValue,
                                    ref MissingValue, ref MissingValue,
                                    ref MissingValue, ref MissingValue,
                                    ref MissingValue, ref MissingValue,
                                    ref MissingValue, ref MissingValue,
                                    ref MissingValue))
                                {
                                    this.richTextBox.AppendText(file.FullName + "文档中包含指定的关键字！\n\n");
                                    break;
                                }
                            }
                        }
                        break;

                    default:
                        string[] lines = File.ReadAllLines(file.FullName);
                        foreach (string line in lines)
                        {
                            i++;
                            if (line.Contains(keyWord))
                            {
                                this.richTextBox.AppendText(file.FullName + "_" + i + "行:" + line + "\n\n");
                            }
                        }
                        break;
                }

               

            }
            
        }
    }  
}
