﻿using Business.Entities;
using Business.Logic;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Util;

namespace UI.Web
{
    public partial class Login1 : System.Web.UI.Page
    {
        public Usuario UsuarioActual { get; set; }
        public Persona PersonaActual { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public (Usuario, Persona) BuscarUsuario()
        {
            try
            {
                UsuarioLogic ul = new UsuarioLogic();
                (UsuarioActual, PersonaActual) = ul.GetUsuario(txtUser.Text);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message + "')", true);
            }

            return (UsuarioActual, PersonaActual);

        }

        protected void valUser_ServerValidate(object source, ServerValidateEventArgs args)
        {
            try
            {
                if (!Validaciones.ValidarUsuario(this.txtUser.Text, this.txtPass.Text))
                {
                    args.IsValid = false;
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message + "')", true);
            }
        }

        protected void valHabilitado_ServerValidate(object source, ServerValidateEventArgs args)
        {
            try
            {
                if (valUser.IsValid)
                {
                    if (!Validaciones.ValidarHabilitado(this.txtUser.Text, this.txtPass.Text))
                    {
                        args.IsValid = false;
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message + "')", true);
            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                (UsuarioActual, PersonaActual) = this.BuscarUsuario();
                Session.Add("Usuario", UsuarioActual);
                Session.Add("Persona", PersonaActual);
                Session.Add("Tipo", PersonaActual.TipoPersona);
                Response.Redirect("~/Main.aspx");
            }
        }


    }
}