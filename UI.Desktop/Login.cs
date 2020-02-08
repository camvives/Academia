using Business.Entities;
using Business.Logic;
using System;
using System.Windows.Forms;
using Util;

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

        public (Usuario, Persona) BuscarUsuario()
        {
            try
            {
                UsuarioLogic ul = new UsuarioLogic();
                (UsuarioActual, PersonaActual) = ul.GetUsuario(txtUsuario.Text);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return (UsuarioActual, PersonaActual);

        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validaciones.ValidarUsuario(txtUsuario.Text, txtClave.Text))
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

    }
}
