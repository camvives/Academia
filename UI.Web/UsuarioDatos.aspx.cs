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
    public partial class UsuariosDatos : System.Web.UI.Page
    {
        public Usuario UsuarioActual { get; set; }
        public Persona PersonaActual { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UsuarioActual = (Usuario)Session["Usuario"];
            this.PersonaActual = (Persona)Session["PersonaEdit"];
            this.MostrarDatos();
        }

        public void MostrarDatos()
        {
                string desesp = (string)this.Context.Items["Carrera"];
                string descplan = (string)this.Context.Items["Plan"];
                string hab;
                if (UsuarioActual.Habilitado == true)
                {
                    hab = "Sí";
                }
                else
                {
                    hab = "No";
                }

                string plandesc;
                if (descplan is null)
                {
                    plandesc = "-";
                }
                else
                {
                    plandesc = descplan;
                }

                string espdesc;
                if (desesp is null)
                {
                    espdesc = "-";
                }
                else
                {
                    espdesc = desesp;
                }

                string leg;
                if (this.PersonaActual.Legajo == 0)
                {
                    leg = "-";
                }
                else
                {
                    leg = this.PersonaActual.Legajo.ToString();
                }
                

                this.lblID.Text = UsuarioActual.ID.ToString();
                this.lblNombreUsuario.Text = UsuarioActual.NombreUsuario;
                this.lblHabilitado.Text = hab;
                this.lblNombre.Text = this.PersonaActual.Nombre;
                this.lblApellido.Text = this.PersonaActual.Apellido;
                this.lblDireccion.Text = PersonaActual.Direccion;
                this.lblEmail.Text = PersonaActual.Email;
                this.lblTelefono.Text = PersonaActual.Telefono;
                this.lblFechaNac.Text = PersonaActual.FechaNacimiento.ToString("dd/MM/yyyy");
                this.lblTipo.Text = PersonaActual.TipoPersona.ToString();
                this.lblLegajo.Text = leg;
                this.lblCarrera.Text = espdesc;
                this.lblPlan.Text = plandesc;
            
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("~/Usuarios.aspx");
        }
    }
}