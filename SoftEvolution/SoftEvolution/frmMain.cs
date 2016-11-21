using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftEvolution
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void toolLogin_Click(object sender, EventArgs e)
        {
            // LOGIN
            frmLogin login = new frmLogin(toolStripLabel_Usuario);
            login.MdiParent = this;
            login.Show();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // LOGIN
            frmLogin login = new frmLogin(toolStripLabel_Usuario);
            login.MdiParent = this;
            login.Show();
        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {
            // COMPRAS
            frmCompras compras = new frmCompras(toolStripLabel_Usuario);
            compras.MdiParent = this;
            compras.Show();
        }
    }
}
