using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScumKiller
{

    public class UserSettings
    {
        private const string settingsFileName = "settings.txt";

        private string enableScumKiller;
        private string openOnStartUp;
        private string killCount;

        public UserSettings()
        {
            string filePath = Application.StartupPath + "\\" + settingsFileName;
            
        }
    }
}
