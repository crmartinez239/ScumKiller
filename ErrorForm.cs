// The warning icon used on this form was downloaded from freepik.com

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScumKiller
{
    public partial class ErrorForm : Form
    {

        public string ErrorMessage;

        public ErrorForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ErrorForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = ErrorMessage;
        }
    }
}
