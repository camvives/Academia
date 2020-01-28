using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;

namespace UI.Web
{
    public partial class Main1 : System.Web.UI.Page
    {
        public Persona PersonaActual { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PersonaActual = (Persona)Session["PersonaActual"];
                this.lblNombre.Text = PersonaActual.Nombre + "!";
                this.MostrarMenu();
            }

        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login.aspx");
        }

        public void MostrarMenu()
        {
            if(PersonaActual.TipoPersona == Persona.TiposPersonas.Alumno)
            {
                mnuPrincipal.Items.Remove(mnuPrincipal.FindItem("Usuario"));
                mnuPrincipal.Items.Remove(mnuPrincipal.FindItem("Cursos")); 
                mnuPrincipal.Items.Remove(mnuPrincipal.FindItem("Especialidades"));
                mnuPrincipal.Items.Remove(mnuPrincipal.FindItem("Planes"));
                mnuPrincipal.Items.Remove(mnuPrincipal.FindItem("Materias"));
                mnuPrincipal.Items.Remove(mnuPrincipal.FindItem("Comisiones"));
                mnuPrincipal.Items.Remove(mnuPrincipal.FindItem("ConsultaCur"));
            }
            else if(PersonaActual.TipoPersona == Persona.TiposPersonas.Administrador)
            {
                mnuPrincipal.Items.Remove(mnuPrincipal.FindItem("Datos"));
                mnuPrincipal.Items.Remove(mnuPrincipal.FindItem("Estado"));
                mnuPrincipal.Items.Remove(mnuPrincipal.FindItem("Certificado"));
                mnuPrincipal.Items.Remove(mnuPrincipal.FindItem("Inscripcion"));
                mnuPrincipal.Items.Remove(mnuPrincipal.FindItem("ConsultaCur"));
            }
            else
            {
                mnuPrincipal.Items.Remove(mnuPrincipal.FindItem("Usuario"));
                mnuPrincipal.Items.Remove(mnuPrincipal.FindItem("Cursos"));
                mnuPrincipal.Items.Remove(mnuPrincipal.FindItem("Especialidades"));
                mnuPrincipal.Items.Remove(mnuPrincipal.FindItem("Planes"));
                mnuPrincipal.Items.Remove(mnuPrincipal.FindItem("Materias"));
                mnuPrincipal.Items.Remove(mnuPrincipal.FindItem("Comisiones"));
                mnuPrincipal.Items.Remove(mnuPrincipal.FindItem("Estado"));
                mnuPrincipal.Items.Remove(mnuPrincipal.FindItem("Certificado"));
                mnuPrincipal.Items.Remove(mnuPrincipal.FindItem("Inscripcion"));
            }
        }

        protected void mnuPrincipal_MenuItemClick(object sender, MenuEventArgs e)
        {
            if(e.Item == mnuPrincipal.FindItem("Usuario"))
            {
                Response.Redirect("~/Usuarios.aspx");
            }
            else if(e.Item == mnuPrincipal.FindItem("Cursos"))
            {
                Response.Redirect("~/Cursos.aspx");
            }
            else if (e.Item == mnuPrincipal.FindItem("Especialidades"))
            {
                Response.Redirect("~/Especialidades.aspx");
            }
            else if (e.Item == mnuPrincipal.FindItem("Planes"))
            {
                Response.Redirect("~/Planes.aspx");
            }
            else if (e.Item == mnuPrincipal.FindItem("Materias"))
            {
                Response.Redirect("~/Materias.aspx");
            }
            else if (e.Item == mnuPrincipal.FindItem("Comisiones"))
            {
                Response.Redirect("~/Comisiones.aspx");
            }

        }
    }
}