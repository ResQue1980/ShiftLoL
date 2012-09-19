using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Media;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ShiftLoL
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            new MainClass();
            Application.Run();
        }
    }

    public class MainClass
    {
        #region PInvokes
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }

        [DllImport("user32.dll")]
        static extern bool GetClientRect(IntPtr hWnd, out RECT lpRect);

        [DllImport("user32.dll")]
        static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [DllImport("user32.dll")]
        static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, UInt32 uFlags);

        [DllImport("user32.dll")]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        const int GWL_STYLE = -16;
        const UInt32 WS_BORDER = 0x800000;
        [DllImport("user32.dll")]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        const int SM_CXSIZEFRAME = 32;
        [DllImport("user32.dll")]
        static extern int GetSystemMetrics(UInt32 smIndex);

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool Beep(uint dwFreq, uint dwDuration);
        #endregion

        Container container = new Container();
        private NotifyIcon notify;
        private IntPtr lastWindow = IntPtr.Zero;
        private Timer timer;
        private SoundPlayer sound = new SoundPlayer("hit.wav");

        public MainClass()
        {
            notify = new NotifyIcon(container)
            {
                Visible = true,
                Text = "ShiftLoL",
                Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath)
            };

            notify.DoubleClick += new EventHandler(NotifyDoubleClick);

            AssemblyName assemblyName = Assembly.GetExecutingAssembly().GetName();
            AssemblyTitleAttribute assemblyTitle = (AssemblyTitleAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false)[0];

            MenuItem[] menuItems = new MenuItem[]
                                       {
                                            new MenuItem("Enable Timer", EnableTimer),
                                            new MenuItem("Disable Timer", DisableTimer),
                                            new MenuItem("Manual Shift", TimerTick),
                                            new MenuItem("-"),
                                            new MenuItem("About", (object o, EventArgs e) =>
                                                                      {
                                                                          MessageBox.Show(assemblyTitle.Title + @" version " + assemblyName.Version + "\n\n" + assemblyTitle.Title + " is a tool for shifting League of Legends window.\n\n" + assemblyTitle.Title + " is coded by Doğan Çelik.\nYou can visit my site at http://www.dogancelik.com/",
                                                                                          @"About "+ assemblyTitle.Title,
                                                                                          MessageBoxButtons.OK,
                                                                                          MessageBoxIcon.Information);
                                                                      }),
                                            new MenuItem("Exit", NotifyDoubleClick)
                                       };
            notify.ContextMenu = new ContextMenu(menuItems);
            notify.ContextMenu.MenuItems[0].Enabled = false;

            timer = new Timer(container)
                        {
                            Interval = 5000,
                            Enabled = true
                        };

            timer.Tick += new EventHandler(TimerTick);

        }

        void EnableTimer(object o, EventArgs e)
        {
            timer.Enabled = true;
            notify.ContextMenu.MenuItems[0].Enabled = false;
            notify.ContextMenu.MenuItems[1].Enabled = true;
        }

        void DisableTimer(object o, EventArgs e)
        {
            timer.Enabled = false;
            notify.ContextMenu.MenuItems[0].Enabled = true;
            notify.ContextMenu.MenuItems[1].Enabled = false;
        }

        void TimerTick(object sender, EventArgs e)
        {
            if (sender == notify.ContextMenu.MenuItems[2])
                Scan(true);
            else
                Scan();
        }

        void Scan(bool manual = false)
        {
            IntPtr handle = FindWindow(null, @"League of Legends (TM) Client");
                 
            if ((IntPtr.Zero != handle && lastWindow != handle) || manual)
            {
                FullScreen(handle);
                try { sound.Play(); } catch (Exception) { Beep(1000, 250); }
                lastWindow = handle;
            }
        }

        void FullScreen(IntPtr handle)
        {
            RECT rectClient, rectWindow;

            GetClientRect(handle, out rectClient);
            GetWindowRect(handle, out rectWindow);

            int borderTop = (rectWindow.bottom - rectWindow.top) - rectClient.bottom;
            int borderLeft = (rectWindow.right - rectWindow.left) - rectClient.right;

            Screen screen = Screen.FromHandle(handle);
            Rectangle rectScreen = screen.Bounds;

            if ((GetWindowLong(handle, GWL_STYLE) & WS_BORDER) != 0)
            {
                int borderWidth = GetSystemMetrics(SM_CXSIZEFRAME);
                SetWindowPos(handle, IntPtr.Zero, -borderLeft + screen.Bounds.Left + borderWidth - 1, -borderTop + screen.Bounds.Top + borderWidth - 1, rectScreen.Width + borderLeft, rectScreen.Height + borderTop, 0);
            }
            else
            {
                SetWindowPos(handle, IntPtr.Zero, -borderLeft + screen.Bounds.Left, -borderTop + screen.Bounds.Top, rectScreen.Width + borderLeft, rectScreen.Height + borderTop, 0);
            }
        }

        void NotifyDoubleClick(object sender, EventArgs e)
        {
            notify.Dispose();
            Application.Exit();
        }
    }

}
