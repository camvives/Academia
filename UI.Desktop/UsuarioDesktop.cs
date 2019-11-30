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
            this.MapearADatos();
            UsuarioLogic usuarioLogic = new UsuarioLogic();
            usuarioLogic.Save(UsuarioActual, PersonaActual);
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            this.GuardarCambios();
        }
    }
}
