using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShiftLoL
{
    public partial class SettingsForm : Form
    {
        public MainClass parent;

        public SettingsForm()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            checkTimer.Checked = parent.settingsFile.Settings.TimerEnabled;
            textTimer.Value = parent.settingsFile.Settings.TimerInterval;

            checkHotkey.Checked = parent.settingsFile.Settings.HotkeyEnabled;
            textHotkey.Text = parent.settingsFile.Settings.GlobalHotkey;

            checkSound.Checked = parent.settingsFile.Settings.SoundEnabled;
            textSound.Text = parent.settingsFile.Settings.SoundPath;

            textWaitAfter.Value = parent.settingsFile.Settings.WaitAfterDetect;
            textMarginLeft.Value = parent.settingsFile.Settings.WindowMarginLeft;
            textMarginTop.Value = parent.settingsFile.Settings.WindowMarginTop;

            smallWindowPanel.Controls.OfType<RadioButton>().Single(t => t.Name == "smallWindowRadio" + parent.settingsFile.Settings.SmallWindowPosition.ToString()).Checked = true;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            parent.settingsFile.Settings.TimerEnabled = checkTimer.Checked;
            parent.settingsFile.Settings.TimerInterval = (int) textTimer.Value;

            parent.settingsFile.Settings.HotkeyEnabled = checkHotkey.Checked;
            parent.settingsFile.Settings.GlobalHotkey = textHotkey.Text;

            parent.settingsFile.Settings.SoundEnabled = checkSound.Checked;
            parent.settingsFile.Settings.SoundPath = textSound.Text;

            parent.settingsFile.Settings.WaitAfterDetect = (int) textWaitAfter.Value;
            parent.settingsFile.Settings.WindowMarginLeft = (int) textMarginLeft.Value;
            parent.settingsFile.Settings.WindowMarginTop = (int) textMarginTop.Value;

            var radioName = smallWindowPanel.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Name;
            parent.settingsFile.Settings.SmallWindowPosition = XmlHelper.ParseInt32(radioName.Substring(radioName.Length - 1, 1));

            parent.settingsFile.Save();
            parent.ReloadSettings();
            Hide();
        }

        private void textHotkey_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Back)
            {
                Keys modifierKeys = e.Modifiers;
                Keys pressedKey = e.KeyData ^ modifierKeys;

                if (modifierKeys != Keys.None && pressedKey != Keys.None)
                {
                    var converter = new KeysConverter();
                    textHotkey.Text = converter.ConvertToString(e.KeyData);
                }
            }
            else
            {
                e.Handled = false;
                e.SuppressKeyPress = true;
                textHotkey.Text = "";
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            try
            {
                File.Delete(parent.settingsFile.Path);
            }
            finally
            {
                parent.ReloadSettings();
            }
            SettingsForm_Load(sender, e);
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }
    }
}
