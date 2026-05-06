using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Epiano
{
    public partial class frmBeepPlayer : Form
    {
        public frmBeepPlayer()
        {
            InitializeComponent();
        }

        [DllImport("kernel32.dll")]
        public static extern bool Beep(int frequency, int duration);
        int[] freq = { 523, 587, 659, 698, 784, 880, 988, 1046 };

        private void button1_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.Enabled = false;
            Beep(freq[btn.TabIndex], 300);
            btn.Enabled = true;
        }

        private void InitializeButton()
        {
            // 讓btn1~btn8共用同一個事件處理函式
            btn2.Click += btn1_Click;
            btn3.Click += btn1_Click;
            btn4.Click += btn1_Click;
            btn5.Click += btn1_Click;
            btn6.Click += btn1_Click;
            btn7.Click += btn1_Click;
            btn8.Click += btn1_Click;
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.Enabled = false;
            Beep(freq[btn.TabIndex], 300);
            btn.Enabled = true;
        }
        int initWidth = 0;
        int initHeight = 0;
        Dictionary<string, Rectangle> initControl = new Dictionary<string, Rectangle>();

        private void frmBeepPlayer_Load(object sender, EventArgs e)
        {
            InitializeButton(); // 記得在這裡呼叫，按鈕才會共用事件

            this.initWidth = this.palMain.Width;
            this.initHeight = this.palMain.Height;
            foreach (Control ctl in this.palMain.Controls)
            {
                this.initControl.Add(ctl.Name, new Rectangle(ctl.Left, ctl.Top,
                ctl.Width, ctl.Height));
            }
        }

        private void frmBeepPlayer_SizeChanged(object sender, EventArgs e)
        {
            // 1. 防呆檢查：如果初始寬度或高度為 0 (代表 Load 尚未完成)，或字典根本沒資料，就直接跳出
            if (this.initWidth <= 0 || this.initHeight <= 0 || this.initControl.Count == 0)
            {
                return;
            }

            double width = this.palMain.Width;
            double height = this.palMain.Height;
            double iRatioWith = width / this.initWidth;
            double iRatioHeight = height / this.initHeight;

            foreach (Control ctl in this.palMain.Controls)
            {
                // 2. 安全性檢查：確保控制項的名字真的存在於字典中
                if (initControl.ContainsKey(ctl.Name))
                {
                    ctl.Left = (int)(initControl[ctl.Name].Left * iRatioWith);
                    ctl.Top = (int)(initControl[ctl.Name].Top * iRatioHeight);
                    ctl.Width = (int)(initControl[ctl.Name].Width * iRatioWith);
                    ctl.Height = (int)(initControl[ctl.Name].Height * iRatioHeight);
                }
            }
        }
    }
}
