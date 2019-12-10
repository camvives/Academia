using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;
using Util;

namespace UI.Desktop
{
    public partial class UsuarioDesktop : ApplicationForm
    {
        public Usuario UsuarioActual { get; set; }
        public Persona PersonaActual { get; set; }

        public UsuarioDesktop()
        {
            InitializeComponent();
        }

        public UsuarioDesktop(Persona persona) : this()
        {
            PersonaActual = persona;
        }

        #region METODOS
        public override void MapearADatos()
        {
            if (this.Modo == ModoForm.Alta)
            {
                Usuario usuario = new Usuario();
                UsuarioActual = usuario;

                this.UsuarioActual.NombreUsuario = this.txtUsuario.Text;
                this.UsuarioActual.Clave = this.txtClave.Text;
                this.UsuarioActual.Habilitado = this.chkHabilitado.Checked;

                this.UsuarioActual.State = BusinessEntity.States.New;
            }
        }

        public void GuardarCambios()
        {
            try
            {
                this.MapearADatos();
                UsuarioLogic usuarioLogic = new UsuarioLogic();
                usuarioLogic.Save(UsuarioActual, PersonaActual);
                this.Notificar("Nuevo Usuario", "El usuario ha sido registrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
            catch
            {
                this.Notificar("Error", "Error al registrar usuario, intente nuevamente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool Validar()
        {
            if (!this.CamposVacios())
            {
                this.Notificar("Campos vacíos", "Debe completar todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (txtClave.Text != txtConfirmarClave.Text)
            {
                this.Notificar("Verifique su contraseña", "Las contraseñas no coinciden", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (Validaciones.ValidarContraseña(txtClave.Text, 8))
            {
                this.Notificar("Verifique su contraseña", "La contraseña debe contener al menos 8 caracteres", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        public bool CamposVacios()
        {
            if (string.IsNullOrEmpty(txtUsuario.Text))
            {
                return false;
            }
            else if (string.IsNullOrEmpty(txtClave.Text))
            {
                return false;
            }
            else if(string.IsNullOrEmpty(txtConfirmarClave.Text))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region ELEMENTOS DEL FORM
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (this.Validar())
            {
                this.GuardarCambios();
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Application.OpenForms["FormPersonaDesktop"].Close();
            this.Close();
        }

        #endregion
    }
}
