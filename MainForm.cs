using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScumKiller
{
    public partial class MainForm : Form
    {
        private bool isFirstStartup;
        private bool enableScumKill;
        private int totalNumberOfKills;

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool IsWindowVisible(IntPtr hWnd);

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            isFirstStartup = !Properties.Settings.Default.isFirstStartup;
            enableScumKill = Properties.Settings.Default.enableScumKill;
            totalNumberOfKills = Properties.Settings.Default.totalNumberOfKills;

            if (isFirstStartup)
            {
                enableScumKill = !enableScumKill;
                Properties.Settings.Default.enableScumKill = enableScumKill;

                isFirstStartup = !isFirstStartup;
                Properties.Settings.Default.isFirstStartup = isFirstStartup;

                Properties.Settings.Default.Save();
            }

            enableScumKillCheckBox.Checked = enableScumKill;
            killCountLabel.Text = totalNumberOfKills.ToString();

            MessageBox.Show("test");
            timer1.Enabled = true;
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            Process[] sp = Process.GetProcessesByName("SCUM");
            bool isScumRunning = (sp.Length > 0);

            Process[] op = Process.GetProcessesByName("GameOverlayUI");
            bool isOverLayRunning = (op.Length > 0);

            if (isScumRunning && isOverLayRunning)
            {
                timer1.Enabled = false;      
                timer2.Enabled = true;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

            Process[] sp = Process.GetProcessesByName("SCUM");
            bool isScumRunning = (sp.Length > 0);

            Process[] op = Process.GetProcessesByName("GameOverlayUI");
            bool isOverLayRunning = (op.Length > 0);

            if (isScumRunning && !isOverLayRunning)
            {
                if (!IsWindowVisible(sp[0].MainWindowHandle))
                {
                    try
                    {
                        sp[0].Kill();
                        totalNumberOfKills += 1;
                        killCountLabel.Text = totalNumberOfKills.ToString();
                        Properties.Settings.Default.totalNumberOfKills = totalNumberOfKills;
                        Properties.Settings.Default.Save();
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(this, err.Message, "ScumKiller Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        
        
    }
}
