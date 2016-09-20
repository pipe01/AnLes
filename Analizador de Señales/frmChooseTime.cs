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
    public partial class frmChooseTime : Form
    {
        public frmChooseTime()
        {
            InitializeComponent();
        }

        public TimeSpan Result;

        private void button1_Click(object sender, EventArgs e)
        {
            Result = new TimeSpan((int)nudHoras.Value, (int)nudMinutos.Value, (int)nudSegundos.Value);
        }
    }
}
