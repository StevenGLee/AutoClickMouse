﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using System.Net;
using System.Net.Sockets;

namespace AutoClickMouse
{
    public partial class AutoClickMouseLeftButton : Form
    {
        [DllImport("User32")]
        public extern static void mouse_event(int dwFlags, int dx, int dy, int dwData, IntPtr dwExtraInfo);

        [DllImport("User32")]
        public extern static void SetCursorPos(int x, int y);

        [DllImport("User32")]
        public extern static bool GetCursorPos(out POINT p);

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;
        }

        //要定义热键的窗口的句柄
        //定义热键ID（不能与其它ID重复）int id, 
        //标识热键是否在按Alt、Ctrl、Shift、Windows等键时才会生效KeyModifiers fsModifiers,                 Keys vk                     //定义热键的内容
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr wnd, int id, MODKEY mode, Keys vk);

        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr wnd, int id);

        [Flags()]
        public enum MODKEY
        {
            None = 0,
            ALT = 0x0001,
            CTRL = 0x0002,
            SHIFT = 0x0004,
            WIN = 0x0008,
        }

        private NotifyIcon notifyIcon = null;

        public enum MouseEventFlags
        {
            Move = 0x0001,
            LeftDown = 0x0002,
            LeftUp = 0x0004,
            RightDown = 0x0008,
            RightUp = 0x0010,
            MiddleDown = 0x0020,
            MiddleUp = 0x0040,
            Wheel = 0x0800,
            Absolute = 0x8000
        }

        private void AutoClick(int x, int y)
        {
            POINT p = new POINT();
            GetCursorPos(out p);
            try
            {
                SetCursorPos(x, y);
                mouse_event((int)(MouseEventFlags.LeftDown | MouseEventFlags.Absolute), 0, 0, 0, IntPtr.Zero);
                mouse_event((int)(MouseEventFlags.LeftUp | MouseEventFlags.Absolute), 0, 0, 0, IntPtr.Zero);
            }
            finally
            {
                SetCursorPos(p.X, p.Y);
            }
        }
        //构造函数
        public AutoClickMouseLeftButton()
        {
            InitializeComponent();
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            LB_Numbers.Text = ClickCount.ToString();
            //调用初始化托盘显示函数
            InitialTray();
            RegisterHotKey(this.Handle, 10, MODKEY.None, Keys.F9);
            RegisterHotKey(this.Handle, 11, MODKEY.None, Keys.F10);
        }
        //存放着当前鼠标的位置坐标
        Point CursorPosition = new Point(0, 0);

        //存放着鼠标左键点击次数
        int ClickCount = 0;
        //主线控制程对象
        Thread controlThread;
        //线程主要处理的函数

        public static TimeSpan GetNtpTimeOffset(string ntpServer = "ntp.ntsc.ac.cn")
        {
            // NTP请求数据包
            byte[] ntpData = new byte[48];
            Array.Clear(ntpData, 0, ntpData.Length);
            ntpData[0] = 0x1B; // 设置NTP请求头（客户端模式，版本号3）

            // 创建UDP客户端
            for(int trials = 0; trials < 20; trials++)
            {
                using (UdpClient client = new UdpClient())
                {
                    try
                    {
                        // 记录发送请求的时间
                        DateTime T1 = DateTime.UtcNow;

                        // 发送请求到NTP服务器
                        client.Connect(ntpServer, 123); // NTP端口是123
                        client.Send(ntpData, ntpData.Length);
                        client.Client.ReceiveTimeout = 1000;

                        // 创建IPEndPoint对象来接收服务器地址和端口
                        IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, 0);

                        // 记录接收响应的时间
                        byte[] response = client.Receive(ref remoteEP);
                        DateTime T4 = DateTime.UtcNow;
                        client.Close();
                        // 从响应中提取T2和T3
                        DateTime T2 = new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds((UInt32)((response[32] << 24) | (response[33] << 16) | (response[34] << 8) | response[35])).AddMilliseconds((UInt32)((response[36] << 24) | (response[37] << 16) | (response[38] << 8) | response[39]) * 2e-7);
                        DateTime T3 = new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds((UInt32)((response[40] << 24) | (response[41] << 16) | (response[42] << 8) | response[43])).AddMilliseconds((UInt32)((response[44] << 24) | (response[45] << 16) | (response[46] << 8) | response[47]) * 2e-7);

                        // 构建精确的UTC时间
                        return (T4 - T1) - (T3 - T2);
                    }
                    catch (Exception ex)
                    {
                        if (client.Client != null)
                            client.Close();
                        Console.WriteLine($"获取NTP时间失败: {ex.Message}");
                        continue;
                    }
                }
            }
            MessageBox.Show("无法同步时钟，请检查网络链接。开始时间将跟随系统时间！");
            return TimeSpan.Zero;
        }
        private void ThreadRunMethod()
        {
            startTime.Value = DateTime.Now + TimeSpan.FromSeconds(10);
            if (check_EnableStartTime.Checked) 
            {
                var TimeFix = GetNtpTimeOffset();
                var start = startTime.Value;
                while (DateTime.Now + TimeFix < start)
                {
                    startTime.Value = DateTime.Now + TimeFix;
                    if ((DateTime.Now + TimeFix).Millisecond > 10)
                        Thread.Sleep(1000 - DateTime.Now.Millisecond);
                    else
                        Thread.Sleep(1000);
                }
            }
            CursorPosition = Cursor.Position;
            AutoClick(CursorPosition.X, CursorPosition.Y);
            int clicks = 1;
            while (!check_EnableClickTimes.Checked || clickTimes.Value > clicks)
            {
                Thread.Sleep((int)(clickInterval.Value * 1000));
                //this.BT_Start.PerformClick();
                CursorPosition = Cursor.Position;
                AutoClick(CursorPosition.X, CursorPosition.Y);
                clicks += 1;
            }

            BT_Start.Enabled = true;
            BT_Stop.Enabled = false;

            check_EnableClickTimes.Enabled = true;
            check_EnableStartTime.Enabled = true;
            clickTimes.Enabled = true;
            clickInterval.Enabled = true;
            startTime.Enabled = true;
        }

        private void BT_TestClick_Click(object sender, EventArgs e)
        {
            ClickCount++;
            LB_Numbers.Text = ClickCount.ToString();
        }

        private void BT_Start_Click(object sender, EventArgs e)
        {
            try
            {
                controlThread = new Thread(new ThreadStart(ThreadRunMethod));
                controlThread.Start();
            }
            catch (Exception)
            {
                Application.DoEvents();
            }
            BT_Stop.Enabled = true;
            BT_Start.Enabled = false;
            check_EnableClickTimes.Enabled = false;
            check_EnableStartTime.Enabled = false;
            clickTimes.Enabled = false;
            clickInterval.Enabled = false;
            startTime.Enabled = false;
        }

        private void BT_Stop_Click(object sender, EventArgs e)
        {
            try
            {
                if (controlThread != null)
                    controlThread.Abort();
            }
            catch (Exception)
            {
                Application.DoEvents();
            }
            BT_Start.Enabled = true;
            BT_Stop.Enabled = false;
            check_EnableClickTimes.Enabled = true;
            check_EnableStartTime.Enabled = true;
            clickTimes.Enabled = true;
            clickInterval.Enabled = true;
            startTime.Enabled = true;
        }

        private void AutoClickMouseLeftButton_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            //通过这里可以看出，这里的关闭其实不是真正意义上的“关闭”，而是将窗体隐藏，实现一个“伪关闭”  
            this.Hide();
        }

        private void InitialTray()
        {
            //隐藏主窗体  
            this.Hide();

            //实例化一个NotifyIcon对象  
            notifyIcon = new NotifyIcon();
            //托盘图标气泡显示的内容  
            notifyIcon.BalloonTipText = "正在后台运行";
            //托盘图标显示的内容  
            notifyIcon.Text = "鼠标自动点击器";
            //注意：下面的路径可以是绝对路径、相对路径。但是需要注意的是：文件必须是一个.ico格式  
            //notifyIcon.Icon = new System.Drawing.Icon("F:/renjiashuo/program/AutoClickMouse/AutoClickMouse/mouse.ico");
            ComponentResourceManager resources = new ComponentResourceManager(typeof(AutoClickMouseLeftButton));
            notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            //true表示在托盘区可见，false表示在托盘区不可见  
            notifyIcon.Visible = true;
            //气泡显示的时间（单位是毫秒）  
            notifyIcon.ShowBalloonTip(5000);
            notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(notifyIcon_MouseClick);

            ////设置二级菜单  
            //MenuItem setting1 = new MenuItem("二级菜单1");  
            //MenuItem setting2 = new MenuItem("二级菜单2");  
            //MenuItem setting = new MenuItem("一级菜单", new MenuItem[]{setting1,setting2});  

            //帮助选项，这里只是“有名无实”在菜单上只是显示，单击没有效果，可以参照下面的“退出菜单”实现单击事件  
            //MenuItem help = new MenuItem("帮助");

            //关于选项  
            MenuItem about = new MenuItem("关于");
            about.Click += new EventHandler(new_about);

            //退出菜单项  
            MenuItem exit = new MenuItem("退出");
            exit.Click += new EventHandler(exit_Click);

            ////关联托盘控件  
            //注释的这一行与下一行的区别就是参数不同，setting这个参数是为了实现二级菜单  
            //MenuItem[] childen = new MenuItem[] { setting, help, about, exit };  
            //MenuItem[] childen = new MenuItem[] { help, about, exit };
            MenuItem[] childen = new MenuItem[] { about, exit };
            notifyIcon.ContextMenu = new ContextMenu(childen);

            //窗体关闭时触发  
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AutoClickMouseLeftButton_FormClosing);
        }

        private void new_about(object sender, EventArgs e)
        {
            AboutBox aboutbox = new AboutBox();
            aboutbox.ShowDialog();
        }

        /// <summary>  
        /// 鼠标单击  
        /// </summary>  
        /// <param name="sender"></param>  
        /// <param name="e"></param>  
        private void notifyIcon_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //鼠标左键单击  
            if (e.Button == MouseButtons.Left)
            {
                //如果窗体是可见的，那么鼠标左击托盘区图标后，窗体为不可见  
                if (this.Visible == true)
                {
                    this.Visible = false;
                }
                else
                {
                    this.Visible = true;
                    this.Activate();
                }
            }
        }

        /// <summary>  
        /// 退出选项  
        /// </summary>  
        /// <param name="sender"></param>  
        /// <param name="e"></param>  
        private void exit_Click(object sender, EventArgs e)
        {
            //退出程序  
            System.Environment.Exit(0);
        }

        //快捷键
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0312)
            {
                switch (m.WParam.ToInt32())
                {
                    case 10:
                        this.BT_Start_Click(null, null);
                        break;
                    case 11:
                        this.BT_Stop_Click(null, null);
                        break;
                    default:
                        break;
                }
                return;
            }
            base.WndProc(ref m);
        }
    }


}
