using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Util;
using Business.Entities;
using Business.Logic;

namespace UI.Web
{
    public partial class Login1 : System.Web.UI.Page
    {
        public Usuario UsuarioActual { get; set; }
        public Persona PersonaActual { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void valUser_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (!Validaciones.ValidarUsuario(this.txtUser.Text, this.txtPass.Text))
            {
                args.IsValid = false;
            }
        }

        protected void valHabilitado_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (valUser.IsValid)
            {
                if (!Validaciones.ValidarHabilitado(this.txtUser.Text, this.txtPass.Text))
                {
                    args.IsValid = false;
                }
            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                (_, PersonaActual) = this.BuscarUsuario();
                Session.Add("PersonaActual", PersonaActual);                
                Response.Redirect("~/Main.aspx");
            }       
        }

        public (Usuario, Persona) BuscarUsuario()
        {
            try
            {
                UsuarioLogic ul = new UsuarioLogic();
                (UsuarioActual, PersonaActual) = ul.GetUsuario(txtUser.Text);
            }
            catch
            {
                //fire custom validator
            }

            return (UsuarioActual, PersonaActual);

        }
    }
}