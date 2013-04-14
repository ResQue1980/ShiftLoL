using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Media;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using Timer = System.Windows.Forms.Timer;

namespace ShiftLoL
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            new MainClass();
            Application.EnableVisualStyles();
            Application.Run();
        }
    }

    public class MainClass
    {
        Container container = new Container();
        private NotifyIcon notify;
        private IntPtr lastWindow = IntPtr.Zero;
        private Timer timer;
        private SoundPlayer sound = new SoundPlayer();

        private SettingsForm settingsForm = new SettingsForm();
        public SettingsFile settingsFile = new SettingsFile();

        private KeyboardHook globalHotkey;

        readonly AssemblyName assemblyName = Assembly.GetExecutingAssembly().GetName();
        readonly AssemblyTitleAttribute assemblyTitle = (AssemblyTitleAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false)[0];

        public MainClass()
        {
            ReloadSettings();
            settingsForm.parent = this;
        }

        public void ReloadSettings()
        {
            bool firstTime;
            InitXml(out firstTime);
            InitNotify(firstTime);
            InitTimer();

            sound.SoundLocation = settingsFile.Settings.SoundPath;

            try
            {
                globalHotkey.Dispose();
            }
            catch
            {
                //Unregister key
            }
            finally
            {
                globalHotkey = new KeyboardHook();
            }

            if (settingsFile.Settings.GlobalHotkey.Length > 0)
            {
                try
                {
                    Tuple<Keys, ModifierKeys> keysTuple = KeysHelper.ConvertFromString(settingsFile.Settings.GlobalHotkey);
                    globalHotkey.RegisterHotKey(keysTuple.Item2, keysTuple.Item1);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, assemblyTitle.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    globalHotkey.KeyPressed += delegate { notify.ContextMenu.MenuItems[2].PerformClick(); };
                }
            }
        }

        void InitXml(out bool firstTime)
        {
            firstTime = false;
            if (!settingsFile.Exists)
            {
                MessageBox.Show(String.Format("'{0}' is missing.\nTool will create a new one.", settingsFile.Path), assemblyTitle.Title);
                settingsFile.Rewrite();
                firstTime = true;
            }
            settingsFile.Read();
        }

        void InitNotify(bool firstTime)
        {
            if (notify != null) notify.Dispose();
            notify = new NotifyIcon(container)
                         {
                             Visible = true,
                             Text = "ShiftLoL",
                             Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath)
                         };
            notify.DoubleClick += NotifyDoubleClick;

            MenuItem[] menuItems = new MenuItem[]
                                       {
                                           new MenuItem("Enable Timer", EnableTimer),
                                           new MenuItem("Disable Timer", DisableTimer),
                                           new MenuItem("Manual Shift", TimerTick),
                                           new MenuItem("-"),
                                           new MenuItem("Modify Settings", delegate { settingsForm.Show(); }), 
                                           new MenuItem("Reload Settings", delegate { ReloadSettings(); }),
                                           new MenuItem("-"),
                                           new MenuItem("About", (object o, EventArgs e) =>
                                                                     {
                                                                         MessageBox.Show(
                                                                             assemblyTitle.Title + @" version " +
                                                                             assemblyName.Version + "\n\n" + assemblyTitle.Title +
                                                                             " is a tool for shifting League of Legends window.\n\n" +
                                                                             assemblyTitle.Title +
                                                                             " is coded by Doğan Çelik.\nYou can visit my site at http://dogancelik.com/",
                                                                             @"About " + assemblyTitle.Title,
                                                                             MessageBoxButtons.OK,
                                                                             MessageBoxIcon.Information);
                                                                     }),
                                           new MenuItem("Exit", NotifyDoubleClick)
                                       };

            notify.ContextMenu = new ContextMenu(menuItems);
            notify.ContextMenu.MenuItems[0].Enabled = !settingsFile.Settings.TimerEnabled;
            notify.ContextMenu.MenuItems[1].Enabled = settingsFile.Settings.TimerEnabled;

            if (firstTime)
            {
                notify.BalloonTipIcon = ToolTipIcon.Info;
                notify.BalloonTipTitle = assemblyTitle.Title;
                notify.BalloonTipText = "Hi there!\n - Right click for menu\n - Double click to exit";
                notify.ShowBalloonTip(10000);    
            }
        }

        void InitTimer()
        {
            if (timer != null)
            {
                timer.Tick -= TimerTick;
                timer.Dispose();
            }

            timer = new Timer(container)
            {
                Interval = settingsFile.Settings.TimerInterval,
                Enabled = settingsFile.Settings.TimerEnabled
            };

            timer.Tick += TimerTick;
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
            if (notify.ContextMenu == null)
            {
                return;
            }

            if (sender == notify.ContextMenu.MenuItems[2])
                Scan(true);
            else
                Scan();
        }

        void Scan(bool manual = false)
        {
            IntPtr handle = WindowsAPI.FindWindow(null, @"League of Legends (TM) Client");
                 
            if ((IntPtr.Zero != handle && lastWindow != handle) || manual)
            {
                if (settingsFile.Settings.SoundEnabled && File.Exists(settingsFile.Settings.SoundPath) && !manual)
                {
                    try { sound.Play(); } catch (Exception) { WindowsAPI.Beep(1000, 250); }
                }
                if (settingsFile.Settings.WaitAfterDetect > 0)
                {
                    Thread.Sleep(settingsFile.Settings.WaitAfterDetect);
                }
                FullScreen(handle);
                lastWindow = handle;
            }
        }

        void FullScreen(IntPtr handle)
        {
            WindowsAPI.RECT rectClient, rectWindow;

            WindowsAPI.GetClientRect(handle, out rectClient);

            int rectClientWidth;
            int rectClientHeight;

            do
            {
                WindowsAPI.GetClientRect(handle, out rectClient);

                rectClientWidth = rectClient.right - rectClient.left;
                rectClientHeight = rectClient.bottom - rectClient.top;

                Thread.Sleep(settingsFile.Settings.TimerInterval);
            }
            while (rectClientWidth == 1);

            WindowsAPI.GetWindowRect(handle, out rectWindow);

            int rectWindowWidth = rectWindow.right - rectWindow.left;
            int rectWindowHeight = rectWindow.bottom - rectWindow.top;

            int borderTop = (rectWindow.bottom - rectWindow.top) - rectClient.bottom;
            int borderLeft = (rectWindow.right - rectWindow.left) - rectClient.right;

            Screen screen = Screen.FromHandle(handle);

            int reposLeft = 0, reposTop = 0;
            bool isFullScreen = screen.Bounds.Width == rectClientWidth && screen.Bounds.Height == rectClientHeight;

            if (!isFullScreen && (rectClientWidth <= screen.Bounds.Width || rectClientHeight <= screen.Bounds.Height))
            {
                int screenClientWidth = screen.WorkingArea.Width;
                int screenClientHeight = screen.WorkingArea.Height;

                switch (settingsFile.Settings.SmallWindowPosition)
                {
                    case 1:
                        break;
                    case 2:
                        reposLeft = (screenClientWidth - rectWindowWidth) / 2;
                        break;
                    case 3:
                        reposLeft = screenClientWidth - rectWindowWidth;
                        break;
                    case 4:
                        reposTop = (screenClientHeight - rectWindowHeight) / 2;
                        break;
                    case 5:
                        reposTop = (screenClientHeight - rectWindowHeight) / 2;
                        reposLeft = (screenClientWidth - rectWindowWidth) / 2;
                        break;
                    case 6:
                        reposTop = (screenClientHeight - rectWindowHeight) / 2;
                        reposLeft = screenClientWidth - rectWindowWidth;
                        break;
                    case 7:
                        reposTop = screenClientHeight - rectWindowHeight;
                        break;
                    case 8:
                        reposTop = screenClientHeight - rectWindowHeight;
                        reposLeft = (screenClientWidth - rectWindowWidth) / 2;
                        break;
                    case 9:
                        reposTop = screenClientHeight - rectWindowHeight;
                        reposLeft = screenClientWidth - rectWindowWidth;
                        break;
                }
            }

            bool borderExists = (WindowsAPI.GetWindowLong(handle, WindowsAPI.GWL_STYLE) & WindowsAPI.WS_BORDER) != 0;

            int finalLeft = screen.Bounds.Left + reposLeft + settingsFile.Settings.WindowMarginLeft;
            int finalTop = screen.Bounds.Top + reposTop + settingsFile.Settings.WindowMarginTop;
            int finalWidth = rectWindowWidth;
            int finalHeight = rectWindowHeight;

            if (borderExists)
            {
                int borderWidth = WindowsAPI.GetSystemMetrics(WindowsAPI.SM_CXSIZEFRAME);
                if (isFullScreen)
                {
                    finalLeft -= borderLeft + borderWidth;
                    finalTop -= borderTop;
                }
                else
                {
                    if (settingsFile.Settings.SmallWindowPosition >= 4)
                    {
                        finalTop -= borderWidth;
                    }

                }
                WindowsAPI.SetWindowPos(handle, IntPtr.Zero, finalLeft, finalTop, finalWidth, finalHeight, WindowsAPI.SWP_SHOWWINDOW);
                WindowsAPI.SetForegroundWindow(handle);
            }
            else
            {
                if (isFullScreen)
                {
                    WindowsAPI.ShowWindow(handle, WindowsAPI.SW_MAXIMIZE);
                }
                else
                {
                    finalLeft -= borderLeft;
                    finalTop -= borderTop;
                    WindowsAPI.SetWindowPos(handle, IntPtr.Zero, finalLeft, finalTop, finalWidth, finalHeight, 0);   
                }
            }
        }

        void NotifyDoubleClick(object sender, EventArgs e)
        {
            timer.Tick -= TimerTick;
            timer.Dispose();
            globalHotkey.Dispose();
            notify.Dispose();
            settingsForm.Dispose();
            Application.Exit();
        }
    }

    public class KeysHelper
    {
        public static Tuple<Keys, ModifierKeys> ConvertFromString(string keysString)
        {
            Keys mainKey = new Keys();
            ModifierKeys modKeys = new ModifierKeys();

            var keys = keysString.Split('+');
            foreach (string keyString in keys)
            {
                Keys key = (Keys)(new KeysConverter()).ConvertFromString(keyString);
                if (key == Keys.Alt || key == Keys.LWin || key == Keys.Shift || key == Keys.Control)
                {
                    switch (key)
                    {
                        case Keys.Alt: modKeys = modKeys | ModifierKeys.Alt; break;
                        case Keys.LWin: modKeys = modKeys | ModifierKeys.Win; break;
                        case Keys.Shift: modKeys = modKeys | ModifierKeys.Shift; break;
                        case Keys.Control: modKeys = modKeys | ModifierKeys.Control; break;
                    }
                }
                else
                {
                    mainKey = key;
                }
            }
            return new Tuple<Keys, ModifierKeys>(mainKey, (ModifierKeys)modKeys);
        }
    }

    public class WindowsAPI
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }

        [DllImport("user32.dll")]
        public static extern bool GetClientRect(IntPtr hWnd, out RECT lpRect);

        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        public const int SWP_SHOWWINDOW = 0x0040;

        [DllImport("user32.dll")]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, UInt32 uFlags);

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        public static extern IntPtr SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        public const int GWL_STYLE = -16;
        public const UInt32 WS_BORDER = 0x800000;

        [DllImport("user32.dll")]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        public const int SM_CXSIZEFRAME = 32;

        [DllImport("user32.dll")]
        public static extern int GetSystemMetrics(UInt32 smIndex);

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool Beep(uint dwFreq, uint dwDuration);

        [DllImport("user32.dll")]
        public static extern short VkKeyScan(char ch);

        public const int SW_MAXIMIZE = 3;

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
    }

    public class XmlHelper
    {
        public static void CreateElement(XmlWriter xmlWriter, string name, string value = "")
        {
            xmlWriter.WriteStartElement(name);
            if (!String.IsNullOrEmpty(value))
            {
                xmlWriter.WriteString(value);
            }
            xmlWriter.WriteEndElement();
        }

        public static int ParseInt32(string value)
        {
            int output = 0;
            if (Int32.TryParse(value, out output))
            {
                return output;
            }
            return 0;
        }
    }

    public class SettingsFile
    {
        public struct SettingsProps
        {
            public bool TimerEnabled { get; set; }
            public int TimerInterval { get; set; }
            public bool HotkeyEnabled { get; set; }
            public string GlobalHotkey { get; set; }
            public bool SoundEnabled { get; set; }
            public string SoundPath { get; set; }
            public int WaitAfterDetect { get; set; }
            public int WindowMarginLeft { get; set; }
            public int WindowMarginTop { get; set; }
            public int SmallWindowPosition { get; set; }
        }

        private const string FilePath = @"Settings.xml";
        public string Path { get { return FilePath; } }

        readonly XmlDocument _xmlDocument = new XmlDocument();
        readonly XmlWriterSettings _writerSettings = new XmlWriterSettings();

        public SettingsProps Settings;

        public SettingsFile()
        {
            _writerSettings.Indent = true;
            _writerSettings.IndentChars = "\t";

            Settings.GlobalHotkey = Settings.SoundPath = String.Empty;
            Settings.HotkeyEnabled = Settings.SoundEnabled = Settings.TimerEnabled = false;
            Settings.WaitAfterDetect = Settings.WindowMarginLeft = Settings.WindowMarginTop = 0;
            Settings.SmallWindowPosition = 5;
            Settings.TimerInterval = 5000;
        }

        public bool Exists
        {
            get { return File.Exists(FilePath); }
        }

        public void Rewrite()
        {
            XmlWriter xmlWriter = XmlWriter.Create(FilePath, _writerSettings);
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Settings");
            XmlHelper.CreateElement(xmlWriter, "TimerEnabled", "true");
            XmlHelper.CreateElement(xmlWriter, "TimerInterval", "1000");
            XmlHelper.CreateElement(xmlWriter, "HotkeyEnabled", "false");
            XmlHelper.CreateElement(xmlWriter, "GlobalHotkey", "Ctrl+Shift+Up");
            XmlHelper.CreateElement(xmlWriter, "SoundEnabled", "false");
            XmlHelper.CreateElement(xmlWriter, "SoundPath", "hit.wav");
            XmlHelper.CreateElement(xmlWriter, "WaitAfterDetect", "0");
            XmlHelper.CreateElement(xmlWriter, "WindowMarginLeft", "0");
            XmlHelper.CreateElement(xmlWriter, "WindowMarginTop", "0");
            XmlHelper.CreateElement(xmlWriter, "SmallWindowPosition", "5");
            xmlWriter.WriteEndElement();
            xmlWriter.Close();
        }

        public void Read()
        {
            _xmlDocument.Load(FilePath);
            XmlNode xmlSettings = _xmlDocument.GetElementsByTagName("Settings")[0];
            for (int i = 0; i < xmlSettings.ChildNodes.Count; i++)
            {
                switch (xmlSettings.ChildNodes[i].Name)
                {
                    case "TimerEnabled": Settings.TimerEnabled = Convert.ToBoolean(xmlSettings.ChildNodes[i].InnerText); break;
                    case "TimerInterval": Settings.TimerInterval = XmlHelper.ParseInt32(xmlSettings.ChildNodes[i].InnerText); break;
                    case "HotkeyEnabled": Settings.HotkeyEnabled = Convert.ToBoolean(xmlSettings.ChildNodes[i].InnerText); break;
                    case "GlobalHotkey": Settings.GlobalHotkey = xmlSettings.ChildNodes[i].InnerText; break;
                    case "SoundEnabled": Settings.SoundEnabled = Convert.ToBoolean(xmlSettings.ChildNodes[i].InnerText); break;
                    case "SoundPath": Settings.SoundPath = xmlSettings.ChildNodes[i].InnerText; break;
                    case "WaitAfterDetect": Settings.WaitAfterDetect = XmlHelper.ParseInt32(xmlSettings.ChildNodes[i].InnerText); break;
                    case "WindowMarginLeft": Settings.WindowMarginLeft = XmlHelper.ParseInt32(xmlSettings.ChildNodes[i].InnerText); break;
                    case "WindowMarginTop": Settings.WindowMarginTop = XmlHelper.ParseInt32(xmlSettings.ChildNodes[i].InnerText); break;
                    case "SmallWindowPosition": Settings.SmallWindowPosition = XmlHelper.ParseInt32(xmlSettings.ChildNodes[i].InnerText); break;
                }
            }
        }

        public void Save()
        {
            XmlNode xmlSettings = _xmlDocument.GetElementsByTagName("Settings")[0];
            for (int i = 0; i < xmlSettings.ChildNodes.Count; i++)
            {
                switch (xmlSettings.ChildNodes[i].Name)
                {
                    case "TimerEnabled": xmlSettings.ChildNodes[i].InnerText = Settings.TimerEnabled.ToString(); break;
                    case "TimerInterval": xmlSettings.ChildNodes[i].InnerText = Settings.TimerInterval.ToString(); break;
                    case "HotkeyEnabled": xmlSettings.ChildNodes[i].InnerText = Settings.HotkeyEnabled.ToString(); break;
                    case "GlobalHotkey": xmlSettings.ChildNodes[i].InnerText = Settings.GlobalHotkey; break;
                    case "SoundEnabled": xmlSettings.ChildNodes[i].InnerText = Settings.SoundEnabled.ToString(); break;
                    case "SoundPath": xmlSettings.ChildNodes[i].InnerText = Settings.SoundPath; break;
                    case "WaitAfterDetect": xmlSettings.ChildNodes[i].InnerText = Settings.WaitAfterDetect.ToString(); break;
                    case "WindowMarginLeft": xmlSettings.ChildNodes[i].InnerText = Settings.WindowMarginLeft.ToString(); break;
                    case "WindowMarginTop": xmlSettings.ChildNodes[i].InnerText = Settings.WindowMarginTop.ToString(); break;
                    case "SmallWindowPosition": xmlSettings.ChildNodes[i].InnerText = Settings.SmallWindowPosition.ToString(); break;
                }
            }
            _xmlDocument.Save(FilePath);
        }
    }

}
