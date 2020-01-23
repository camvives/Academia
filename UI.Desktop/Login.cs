using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Util;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class formLogin : Form
    {
        public Usuario UsuarioActual { get; set; }
        public Persona PersonaActual { get; set; }

        public formLogin()
        {
            InitializeComponent();
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validaciones.ValidarContraseña(txtUsuario.Text, txtClave.Text))
                {
                    MessageBox.Show("Usuario y/o contraseña incorrectos", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else if (!Validaciones.ValidarHabilitado(txtUsuario.Text, txtClave.Text))
                {
                    MessageBox.Show("Usuario no habilitado", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    this.DialogResult = DialogResult.OK;
                }
            }
            catch
            {
                MessageBox.Show("Error al recuperar datos del usuario. Intente nuevamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public (Usuario, Persona) BuscarUsuario()
        {
            try
            {
                UsuarioLogic ul = new UsuarioLogic();
                (UsuarioActual, PersonaActual) = ul.GetUsuario(txtUsuario.Text);              
            }
            catch
            {
                MessageBox.Show("Error al recuperar datos del usuario. Intente nuevamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
            return (UsuarioActual, PersonaActual);
            
        }


    }
}
