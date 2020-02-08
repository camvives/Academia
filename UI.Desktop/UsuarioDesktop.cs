using Business.Entities;
using Business.Logic;
using System;
using System.Windows.Forms;
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

        public UsuarioDesktop(Usuario usuario, Persona persona, ModoForm modo) : this()
        {
            UsuarioActual = usuario;
            PersonaActual = persona;
            Modo = modo;

            if (Modo == ModoForm.ModificacionUsr)
            {
                this.Text = "Mis Datos";
                this.chkHabilitado.Visible = false;
                this.lblHabilitado.Visible = false;

            }
            else
            {
                this.Text = "Editar Usuario";
            }

            try
            {
                this.MapearDeDatos();
            }
            catch
            {
                MessageBox.Show("Error al recuperar datos del usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

        }

        #region METODOS
        public override void MapearADatos()
        {
            if (Modo == ModoForm.Alta)
            {
                UsuarioActual = new Usuario();
                this.UsuarioActual.State = BusinessEntity.States.New;
            }
            else if (this.Modo == ModoForm.Modificacion || this.Modo == ModoForm.ModificacionUsr)
            {
                this.UsuarioActual.State = BusinessEntity.States.Modified;
            }

            this.UsuarioActual.NombreUsuario = this.txtUsuario.Text;
            this.UsuarioActual.Clave = this.txtClave.Text;
            this.UsuarioActual.Habilitado = this.chkHabilitado.Checked;

        }

        public override void MapearDeDatos()
        {
            this.txtUsuario.Text = this.UsuarioActual.NombreUsuario;
            this.chkHabilitado.Checked = this.UsuarioActual.Habilitado;
            this.txtClave.Text = this.UsuarioActual.Clave;
            this.txtConfirmarClave.Text = this.UsuarioActual.Clave;

            if (this.Modo == ModoForm.Modificacion)
            {
                this.btnGuardar.Text = "Guardar";
            }
        }

        public void GuardarCambios()
        {
            try
            {
                this.MapearADatos();
                UsuarioLogic usuarioLogic = new UsuarioLogic();
                usuarioLogic.Save(UsuarioActual, PersonaActual);

                if (Modo == ModoForm.Alta)
                {
                    this.Notificar("Nuevo Usuario", "El usuario ha sido registrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (Modo == ModoForm.Modificacion)
                {
                    this.Notificar("Editar Usuario", "Los cambios han sido registrados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    this.Notificar("Editar Usuario", "Los cambios han sido registrados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            else if (string.IsNullOrEmpty(txtConfirmarClave.Text))
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
