using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analizador_de_Señales
{
    public partial class frmConsole : Form
    {
        public frmConsole()
        {
            InitializeComponent();
        }

        private string NewLine;
        
        private void btnEnviar_Click(object sender, EventArgs e)
        {
            Program.form1.ParseData(txtInput.Text + "\n");
            txtReceived.Text += txtInput.Text + NewLine;
            txtInput.Text = "";
        }

        private void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                btnEnviar_Click(sender, e);
            }
        }

        private void frmConsole_Load(object sender, EventArgs e)
        {
            StringBuilder s = new StringBuilder();
            s.AppendLine();
            NewLine = s.ToString();
            s = null;
        }
    }
}
