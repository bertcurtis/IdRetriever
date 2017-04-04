using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsInput;

namespace DistIdProvider
{
    public partial class MainForm : Form
    {
        KeyboardHook hook = new KeyboardHook();

        public const string LiveFileName = "DistIdLive.csv";
        public const string TestFileName = "DistIdTest.csv";
        public string[] DistIdArray { get; set; }
        public int Index { get; set; }
        public MainForm()
        {
            InitializeComponent();
            Index = 0;
            // register the event that is fired after the key press.
            hook.KeyPressed += new EventHandler<KeyPressedEventArgs>(hook_KeyPressed);
            hook.DifferentKeyPressed += new EventHandler<KeyPressedEventArgs>(hook_DifferentKeyPressed);
            // register the control + alt + F12 combination as hot key.
            hook.RegisterHotKey(DistIdProvider.ModifierKeys.Control | DistIdProvider.ModifierKeys.Shift, Keys.L);
            hook.RegisterHotKey(DistIdProvider.ModifierKeys.Control | DistIdProvider.ModifierKeys.Shift, Keys.Right);
            label1.Text = GetDist(LiveFileName);
            label2.Text = (Index + 1).ToString();
            label3.Text = "/ " + (DistIdArray.Length).ToString();
        }
        public string GetDist(string liveOrTest)
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\AutomationTestSaves\\" + liveOrTest;
            DistIdArray = File.ReadAllLines(path);
            return DistIdArray[Index];
        }
        void hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            try
            {
                Clipboard.SetText(label1.Text);
                //InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_V);

                //SendKeys.SendWait("^{v}");

                //if (Clipboard.ContainsText())
                //{
                //    IntPtr theHandle = Win32.WindowFromPoint(Cursor.Position.X, Cursor.Position.Y);

                //    if (theHandle != null)
                //    {
                //        Win32.SendMessage(theHandle, Win32.WM_SETTEXT, IntPtr.Zero, Clipboard.GetText());
                //    }
                //}
            }
            catch
            {
                MessageBox.Show("Please have your cursor focus be in a valid text box");
            }
        }
        void hook_DifferentKeyPressed(object sender, KeyPressedEventArgs e)
        {
            SetValues(Index + 1);
            Clipboard.SetText(label1.Text);
        }
        private void SetValues(int whereInArray)
        {
            Index = whereInArray;
            label1.Text = DistIdArray[Index];
            label2.Text = (Index + 1).ToString();
        }

        private void nextInArray_Click(object sender, EventArgs e)
        {
            try
            {
                SetValues(Index - 1);
            }
            catch
            {
                MessageBox.Show("Can't go back any further!");
            }
        }

        private void backInArray_Click(object sender, EventArgs e)
        {
            SetValues(Index + 1);
        }

        private void lastInArray_Click(object sender, EventArgs e)
        {
            SetValues(DistIdArray.Length - 1);
        }

        private void firstInArray_Click(object sender, EventArgs e)
        {
            SetValues(0);
        }

        private void label1_DoubleClick(object sender, EventArgs e)
        {
            Clipboard.SetText(label1.Text);
            MessageBox.Show("DistId: " + label1.Text + " copied to the clipboard.");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Use keyboard shortcut CTRL-SHIFT-L while this app is running (it doesn't have to be in focus) to copy a test dist-" +
                "id to your clipboard. If you want a different dist-id, either change it on your app, or use the keyboard shortcut CTRL-SHIFT-RIGHT");
        }
    }
}
