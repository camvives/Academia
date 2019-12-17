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
    public partial class Usuario : UI.Web.ApplicationFrom
    {
        public Persona PersonaActual { get; set; }
        public Business.Entities.Usuario UsuarioActual { get; set; }
        

        protected new void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.CompletarDDList();
            } 
        }

        public void CompletarDDList()
        {
            EspecialidadLogic especialidad = new EspecialidadLogic();

            //Completa el DropDownList de carrera con la descripcion de la tabla especialidades
            List<Especialidad> especialidades = new List<Especialidad>();

            especialidades = especialidad.GetAll();
            ddlCarrera.DataTextField = "Descripcion";
            ddlCarrera.DataValueField = "ID";
            ddlCarrera.DataSource = especialidades;  
            ddlCarrera.DataBind();
            ddlCarrera.Items.Insert(0, "Seleccionar Carrera");
        }


        protected void ddlCarrera_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCarrera.Items.Remove("Seleccionar Carrera");
            int EspId = int.Parse(ddlCarrera.SelectedValue.ToString());

            PlanLogic plan = new PlanLogic();
            ddlPlan.DataTextField = "Descripcion";
            ddlPlan.DataValueField = "ID";
            ddlPlan.DataSource = plan.GetPlanesEsp(EspId);
            ddlPlan.DataBind();
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            this.MapearADatos();
            UsuarioLogic usuarioLogic = new UsuarioLogic();
            usuarioLogic.Save(UsuarioActual, PersonaActual);
        }

        public override void MapearADatos()
        {

            if (Modo == ModoForm.Alta)
            {
                PersonaActual = new Persona();
                UsuarioActual = new Business.Entities.Usuario();
                this.UsuarioActual.State = BusinessEntity.States.New;
            }

            this.PersonaActual.Nombre = this.txtNombre.Text;
            this.PersonaActual.Apellido = this.txtApellido.Text;
            this.PersonaActual.Email = this.txtEmail.Text;
            this.PersonaActual.Direccion = this.txtDireccion.Text;
            this.PersonaActual.Telefono = this.txtTelefono.Text;
            this.PersonaActual.FechaNacimiento = DateTime.Parse(txtAnio.Text + "-" + txtMes.Text + "-" + txtDia.Text);
            this.UsuarioActual.NombreUsuario = this.txtUsuario.Text;
            this.UsuarioActual.Clave = this.txtClave.Text;
            this.UsuarioActual.Habilitado = this.chkHabilitado.Checked;

            //DE ACUERDO AL TIPO DE USUARIO
            if (ddlTipo.SelectedItem.ToString() == "Alumno")
            {
                this.PersonaActual.TipoPersona = Persona.TiposPersonas.Alumno;
                this.PersonaActual.Legajo = int.Parse(this.txtLegajo.Text);
                int idPlan = int.Parse(ddlPlan.SelectedValue.ToString());
                this.PersonaActual.IDPlan = idPlan;
            }

            else if (ddlTipo.SelectedItem.ToString() == "Administrador")
            {
                this.PersonaActual.TipoPersona = Persona.TiposPersonas.Administrador;
                this.PersonaActual.Legajo = 0;
                this.PersonaActual.IDPlan = 0;
            }

            else if (ddlTipo.SelectedItem.ToString() == "Docente")
            {
                this.PersonaActual.TipoPersona = Persona.TiposPersonas.Docente;
                this.PersonaActual.Legajo = int.Parse(this.txtLegajo.Text);
                this.PersonaActual.IDPlan = 0;
            }

        }
    }
}