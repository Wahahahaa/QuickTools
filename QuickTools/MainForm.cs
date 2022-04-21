using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickTools
{
    public partial class MainForm : Form
    {
        private int CutHotkey;  //截图快捷键
        private int SearchHotkey; //搜索快捷键

        public delegate void HotkeyEventHandler(int HotKeyID);

        private List<Bitmap> historyCutPictures = new List<Bitmap>(); //历史截图图片
        private bool isAlreadyOpenCutForm = false; //是否已经打开截屏页面

        public class Hotkey : System.Windows.Forms.IMessageFilter
        {
            Hashtable keyIDs = new Hashtable();
            IntPtr hWnd;
            public event HotkeyEventHandler OnHotkey;
            public enum KeyFlags
            {
                MOD_ALT = 0x1,
                MOD_CONTROL = 0x2,
                MOD_SHIFT = 0x4,
                MOD_WIN = 0x8
            }

            [DllImport("user32.dll")]
            public static extern UInt32 RegisterHotKey(IntPtr hWnd, UInt32 id, UInt32 fsModifiers, UInt32 vk);

            [DllImport("user32.dll")]
            public static extern UInt32 UnregisterHotKey(IntPtr hWnd, UInt32 id);

            [DllImport("kernel32.dll")]
            public static extern UInt32 GlobalAddAtom(String lpString);

            [DllImport("kernel32.dll")]
            public static extern UInt32 GlobalDeleteAtom(UInt32 nAtom);

            public Hotkey(IntPtr hWnd)
            {
                this.hWnd = hWnd;
                Application.AddMessageFilter(this);
            }

            public int RegisterHotkey(Keys Key, KeyFlags keyflags)
            {
                UInt32 hotkeyid = GlobalAddAtom(System.Guid.NewGuid().ToString());
                RegisterHotKey((IntPtr)hWnd, hotkeyid, (UInt32)keyflags, (UInt32)Key);
                keyIDs.Add(hotkeyid, hotkeyid);
                return (int)hotkeyid;
            }

            public void UnregisterHotkeys()
            {
                Application.RemoveMessageFilter(this);
                foreach (UInt32 key in keyIDs.Values)
                {
                    UnregisterHotKey(hWnd, key);
                    GlobalDeleteAtom(key);
                }
            }

            public bool PreFilterMessage(ref System.Windows.Forms.Message m)
            {
                if (m.Msg == 0x312)
                {
                    if (OnHotkey != null)
                    {
                        foreach (UInt32 key in keyIDs.Values)
                        {
                            if ((UInt32)m.WParam == key)
                            {
                                OnHotkey((int)m.WParam);
                                return true;
                            }
                        }
                    }
                }
                return false;
            }
        }

        /*
         * 快捷键注册函数
         * 截图快捷键Alt+C
         * 搜索快捷键Alt+S
         */
        public void SetHotKey()
        {
            Hotkey hotkey;
            hotkey = new Hotkey(this.Handle);
            CutHotkey = hotkey.RegisterHotkey(System.Windows.Forms.Keys.C, Hotkey.KeyFlags.MOD_ALT);
            SearchHotkey = hotkey.RegisterHotkey(System.Windows.Forms.Keys.S, Hotkey.KeyFlags.MOD_ALT);
            hotkey.OnHotkey += new HotkeyEventHandler(OnHotkey);
        }

        /*
         * 快捷键处理函数
         */
        public void OnHotkey(int HotkeyID)
        {
            if (HotkeyID == CutHotkey)
            {
                CutScreenStripMenuItem_Click(null, null);
            }
            if (HotkeyID == SearchHotkey)
            {
                SearchStripMenuItem_Click(null, null);
            }
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //注册快捷键
            SetHotKey();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutScreenStripMenuItem_Click(object sender, EventArgs e)
        {
            //如果已经打开截屏界面，则不允许打开新的截屏页面
            if(isAlreadyOpenCutForm)
            {
                return;
            }

            isAlreadyOpenCutForm = true;

            CutForm form = new CutForm();
            form.ShowDialog();
            if (form.GetBitmap() != null)
            {
                historyCutPictures.Add(form.GetBitmap());
                CutPictureDisplayForm displayForm = new CutPictureDisplayForm(form.GetBitmap());
                displayForm.Show();
            }

            isAlreadyOpenCutForm = false;
        }

        private void CutHistory_Click(object sender, EventArgs e)
        {
            CutHistoryForm cutHistoryForm = new CutHistoryForm(historyCutPictures);
            cutHistoryForm.ShowDialog();
        }

        private void SearchStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchForm form = new SearchForm();
            form.ShowDialog();
        }


    }
}
