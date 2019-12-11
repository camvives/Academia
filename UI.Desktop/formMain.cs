using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class formMain : Form
    {
        public formMain()
        {
            InitializeComponent();

        }

        private void SalirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void UsuarioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormPersonaDesktop formPersona = new FormPersonaDesktop();
            formPersona.ShowDialog();
        }

        private void UsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUsuarios formUsuarios = new FormUsuarios();
            formUsuarios.ShowDialog();
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            formLogin login = new formLogin();
            if (login.ShowDialog() != DialogResult.OK)
            {
                this.Dispose();
            }
        }
    }
}
