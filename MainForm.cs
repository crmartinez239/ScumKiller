using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
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
        }
    }
}
