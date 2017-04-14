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

namespace DistIdProvider
{
    public partial class MainForm : Form
    {
        KeyboardHook hook = new KeyboardHook();
        DataLayer data = new DataLayer();
        SetData set = new SetData();
        public bool? LoyaltyFinalCheck { get; set; }
        public bool EnrolledInLoyaltyCheck { get; set; }
        public bool NotEnrolledInLoyaltyCheck { get; set; }

        public bool RankIdForCustomer { get; set; }
        public bool RankIdForDistributor { get; set; }


        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            data.Index = 0;
            // register the event that is fired after the key press.
            hook.KeyPressed += new EventHandler<KeyPressedEventArgs>(hook_KeyPressed);
            // register the control + shift + L etc. combination as hot key.
            hook.RegisterHotKey(DistIdProvider.ModifierKeys.Control | DistIdProvider.ModifierKeys.Shift, Keys.D5);
            //SetValues(0, data.GetDist(data.LiveFileName));
            data.WindowStay = false;
            //comboBox1.Items.AddRange(data.Countries);
            set.SetCountries(comboBox1, data);
            set.SetID("US", data);
            comboBox1.Text = "US";
            SetValues(0, data.DistIds[0]);
            comboBox1.Focus();
            this.WindowState = FormWindowState.Minimized;
        }

        private void SetValues(int setIndex, string distIds, bool copyToClipboard = true)
        {
            data.Index = setIndex;
            label1.Text = distIds;
            label2.Text = (data.Index + 1).ToString();
            label3.Text = "/ " + data.DistIds.Count.ToString();
            if (copyToClipboard == true)
            {
                Clipboard.SetText(label1.Text);
            }
        }
        void hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Normal;
                this.Show();
                comboBox1.Focus();
                SetValues(data.Index, data.DistIds[data.Index]);

            }
            catch
            {
                MessageBox.Show("Please have your cursor focus be in a valid text box");
            }
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                if (data.WindowStay == false)
                {
                    this.WindowState = FormWindowState.Minimized;
                }
                else
                {
                    data.WindowStay = false;
                }
            }
        }
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                data.WindowStay = true;
            }
            if (e.KeyCode == Keys.F2)
            {
                random_Click(sender, e);
            }
            if (e.KeyCode == Keys.Right)
            {
                nextInArray_Click(sender, e);
                e.Handled = true;
            }
            if (e.KeyCode == Keys.Left)
            {
                backInArray_Click(sender, e);
                e.Handled = true;
            }
            if (e.Modifiers == Keys.Shift && e.KeyCode == Keys.Right )
            {
                lastInArray_Click(sender, e);
                e.Handled = true;
            }
            if (e.Modifiers == Keys.Shift && e.KeyCode == Keys.Left)
            {
                firstInArray_Click(sender, e);
                e.Handled = true;
            }
            
        }

        private void backInArray_Click(object sender, EventArgs e)
        {
            try
            {
                SetValues(data.Index - 1, data.DistIds[data.Index - 1]);
            }
            catch
            {
                MessageBox.Show("Can't go back any further!");
            }
        }

        private void nextInArray_Click(object sender, EventArgs e)
        {
            try
            {
                SetValues(data.Index + 1, data.DistIds[data.Index + 1]);
            }
            catch
            {
                MessageBox.Show("Can't go any further!");
            }
        }

        private void lastInArray_Click(object sender, EventArgs e)
        {
            SetValues(data.DistIds.Count - 1, data.DistIds[data.DistIds.Count - 1]);
        }

        private void firstInArray_Click(object sender, EventArgs e)
        {
            SetValues(0, data.DistIds[0]);
        }

        private void label1_DoubleClick(object sender, EventArgs e)
        {
            Clipboard.SetText(label1.Text);
            MessageBox.Show("DistId: " + label1.Text + " copied to the clipboard.");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("The following shortcuts can be used when the app is not in focus:" +
                "\r\n\r\n  -  CTRL + SHIFT + D5 will bring the app to focus and by default copy a US distid to your clipboard." +
                "\r\n\r\n  -  If you let go of SHIFT, the app will minimize again. If you wish to prevent this, just hit the 'F1' key." + 
                "\r\n\r\n  -  After typing CTRL + SHIFT + 5, while still holding CTRL + SHIFT, you can then press either the 'K' or the 'M' key to copy a Korean" + 
                " or a Mexican distid (or any country) to your clipboard. Letting go of SHIFT will minimize the app again unless you press 'F1' first." + 
                "\r\n\r\n  -  Pressing 'F2' at anytime will randomize the distributor ID list." +
                "\r\n\r\n  -  Pressing 'Shift' + 'Right Arrow' will take you to the end of the array. Same goes for the left arrow. However, if you are using quick mode" +
                " and do not let go of 'Control' it will not take you to the end, it will only you take you to the next id in the array.");
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Continuing will close this program and you'll have to re-open it in order to regain functionality. Minimizing it will hide it from your view" +
                " and you'll still have the sweet functionality.", "Are you sure?", MessageBoxButtons.YesNoCancel);
            if (dialogResult == DialogResult.Yes)
            {
                e.Cancel = true;
                this.WindowState = FormWindowState.Minimized;
            }
            else if(dialogResult == DialogResult.No)
            {
                hook.Dispose();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            data.Index = 0;
            set.SetID(comboBox.SelectedItem.ToString(), data, LoyaltyFinalCheck, SetRankIdFinal()); 
            if (data.DistIds.Count < 1)
            {
                MessageBox.Show("No test distids for this country");
            }
            else
            {
                SetValues(0, data.DistIds[0]);
            }
        }
        private void SetLoyaltyFinal()
        {
            if (EnrolledInLoyaltyCheck == true && NotEnrolledInLoyaltyCheck == false)
            {
                LoyaltyFinalCheck = false;
            }
            else if (NotEnrolledInLoyaltyCheck == true && EnrolledInLoyaltyCheck == false)
            {
                LoyaltyFinalCheck = true;
            }
            else if (EnrolledInLoyaltyCheck == true && NotEnrolledInLoyaltyCheck == true)
            {
                LoyaltyFinalCheck = null;
            }
            else
            {
                LoyaltyFinalCheck = null;
            }
        }

        private string SetRankIdFinal()
        {
            if (RankIdForCustomer == true && RankIdForDistributor == false)
            {
                return "1 and 1";
            }
            else if (RankIdForDistributor == true && RankIdForCustomer == false)
            {
                return "2 and 10";
            }
            else if (RankIdForCustomer == true && RankIdForDistributor == true)
            {
                return "1 and 10";
            }
            else
            {
                return "1 and 10";
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (EnrolledInLoyaltyCheck == false)
            {
                EnrolledInLoyaltyCheck = true;
            }
            else
            {
                EnrolledInLoyaltyCheck = false;
            }
            SetLoyaltyFinal();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (NotEnrolledInLoyaltyCheck == false)
            {
                NotEnrolledInLoyaltyCheck = true;
            }
            else
            {
                NotEnrolledInLoyaltyCheck = false;
            }
            SetLoyaltyFinal();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (RankIdForDistributor == false)
            {
                RankIdForDistributor = true;
            }
            else
            {
                RankIdForDistributor = false;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (RankIdForCustomer == false)
            {
                RankIdForCustomer = true;
            }
            else
            {
                RankIdForCustomer = false;
            }
        }

        private void apply_Click(object sender, EventArgs e)
        {
            SetLoyaltyFinal();
            set.SetID(comboBox1.SelectedItem.ToString(), data, LoyaltyFinalCheck, SetRankIdFinal());
            SetValues(0, data.DistIds[0]);
        }

        private void random_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            int randomNumber = rand.Next(0, data.DistIds.Count);
            SetValues(randomNumber, data.DistIds[randomNumber]);
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                notifyIcon.Visible = true;                
                this.ShowInTaskbar = false;
            }

            else if (FormWindowState.Normal == this.WindowState)
            {
                this.WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;
                notifyIcon.Visible = false;
            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)        
        {
            this.ShowInTaskbar = true;
            this.Show();
            this.WindowState = FormWindowState.Normal;
            comboBox1.Focus();
        }



    }
}
