﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;
using Util;

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
                this.CompletarDDLEsp();
                this.CompletarFecha();
            }
        }



        public void CompletarDDLEsp()
        {
            EspecialidadLogic especialidad = new EspecialidadLogic();
            ddlCarrera.DataTextField = "Descripcion";
            ddlCarrera.DataValueField = "ID";
            ddlCarrera.DataSource = especialidad.GetAll();
            ddlCarrera.DataBind();


            ddlCarrera.Items.Insert(0, "Seleccionar Carrera");          
            if (!(ddlPlan.Items.Contains(ddlPlan.Items.FindByValue("Plan"))))
            {
                ddlPlan.Items.Insert(0, "Plan");
            }
            ddlPlan.Text = "Plan";
        }

        protected void ddlCarrera_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlPlan.Enabled = true;
            ddlCarrera.Items.Remove("Seleccionar Carrera");
            ddlPlan.Items.Remove("Plan");
            int EspId = int.Parse(ddlCarrera.SelectedValue.ToString());

            PlanLogic plan = new PlanLogic();
            ddlPlan.DataTextField = "Descripcion";
            ddlPlan.DataValueField = "ID";
            ddlPlan.DataSource = plan.GetPlanesEsp(EspId);
            ddlPlan.DataBind();         

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar() && Page.IsValid)
            {
                this.MapearADatos();
                UsuarioLogic usuarioLogic = new UsuarioLogic();
                usuarioLogic.Save(UsuarioActual, PersonaActual);
            }
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
            this.PersonaActual.FechaNacimiento = DateTime.Parse(FormatFecha());
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

        public override void MapearDeDatos()
        {
            PlanLogic pl = new PlanLogic();
            Plan plan = pl.GetOne(PersonaActual.IDPlan);
            EspecialidadLogic el = new EspecialidadLogic();
            Especialidad especialidad = el.GetOne(plan.IDEspecialidad);

            this.txtNombre.Text = this.PersonaActual.Nombre;
            this.txtApellido.Text = this.PersonaActual.Apellido;
            this.txtEmail.Text = this.PersonaActual.Email;
            this.ddlDia.Text = this.PersonaActual.FechaNacimiento.Day.ToString();
            this.ddlMes.Text = this.PersonaActual.FechaNacimiento.Month.ToString();
            this.ddlAnio.Text = this.PersonaActual.FechaNacimiento.Year.ToString();
            this.txtTelefono.Text = this.PersonaActual.Telefono;
            this.ddlTipo.Text = this.PersonaActual.TipoPersona.ToString();
            this.txtDireccion.Text = this.PersonaActual.Direccion;

            if (PersonaActual.Legajo != 0)
            {
                this.txtLegajo.Text = this.PersonaActual.Legajo.ToString();
            }
            else
            {
                this.txtLegajo.Enabled = false;
            }

            if (PersonaActual.TipoPersona == Persona.TiposPersonas.Administrador)
            {
                this.ddlCarrera.Enabled = false;
                this.ddlPlan.Enabled = false;
            }

            if (PersonaActual.TipoPersona == Persona.TiposPersonas.Alumno)
            {
                this.CompletarDDLEsp();
                this.ddlPlan.Text = plan.Descripcion ;
                this.ddlCarrera.Text = especialidad.Descripcion;
            }

            if (this.Modo == ModoForm.Modificacion)
            {
                this.btnAceptar.Text = "Guardar";
            }
        }

        public bool CamposVacios()
        {
            if (string.IsNullOrEmpty(txtApellido.Text))
            {
                return false;
            }
            else if (string.IsNullOrEmpty(txtNombre.Text))
            {
                return false;
            }
            else if (string.IsNullOrEmpty(txtTelefono.Text))
            {
                return false;
            }
            else if (string.IsNullOrEmpty(txtDireccion.Text))
            {
                return false;
            }
            else if (string.IsNullOrEmpty(txtEmail.Text))
            {
                return false;
            }
            else if ((ddlTipo.SelectedItem.ToString() == "Docente" || ddlTipo.SelectedItem.ToString() == "Alumno") && string.IsNullOrEmpty(txtLegajo.Text))
            {
                return false;
            }
            else if (string.IsNullOrEmpty(txtUsuario.Text))
            {
                return false;
            }
            else if (string.IsNullOrEmpty(txtClave.Text))
            {
                return false;
            }
            else if (string.IsNullOrEmpty(txtConfirmaClave.Text))
            {
                return false;
            }
            else if(ddlCarrera.SelectedIndex == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool Validar()
        {

            if (ddlTipo.SelectedIndex == -1)
            {
                this.lblError.Text = "Debe seleccionar un tipo de usuario";
                this.lblError.Visible = true;
                System.Threading.Thread.Sleep(5000);
                this.lblError.Visible = false;

                return false;
            }
            else if (!this.CamposVacios())
            {
                this.lblError.Text = "Debe completar todos los campos";
                this.lblError.Visible = true;

                return false;
            }
            else if (!(Validaciones.EmailValido(txtEmail.Text)))
            {
                this.lblError.Text = "Formato de mail inválido";
                this.lblError.Visible = true;

                return false;
            }

            return true;
        }

        protected void ddlTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTipo.SelectedItem.ToString() == "Administrador")
            {
                ddlPlan.Items.Remove("Plan");
                txtLegajo.Enabled = false;
                txtLegajo.Text = "";
                ddlCarrera.Enabled = false;
                ddlCarrera.Items.Insert(0, "Seleccionar Carrera");
                ddlCarrera.Text = "Seleccionar Carrera";
                ddlPlan.Enabled = false;
                if (!(ddlPlan.Items.Contains(ddlPlan.Items.FindByValue(""))))
                {
                    ddlPlan.Items.Insert(0, "");
                }
                ddlPlan.Text = "";
            }
            else if (ddlTipo.SelectedItem.ToString() == "Docente")
            {
                ddlCarrera.Enabled = false;
                ddlPlan.Enabled = false;
                txtLegajo.Enabled = true;

                ddlPlan.Items.Remove("Plan");
                ddlCarrera.Items.Insert(0, "Seleccionar Carrera");
                ddlCarrera.Text = "Seleccionar Carrera";
                if (!(ddlPlan.Items.Contains(ddlPlan.Items.FindByValue(""))))
                {
                    ddlPlan.Items.Insert(0, "");
                }
                ddlPlan.Text = "";
            }
            else
            {
                this.CompletarDDLEsp();
                ddlCarrera.Enabled = true;
                ddlPlan.Enabled = true;
                txtLegajo.Enabled = true;
                ddlPlan.Items.Remove("");
            }
        }


        public void CompletarFecha()
        {
            for (int i = 1; i <= 31; i++)
            {
                ddlDia.Items.Add(i.ToString("D2"));
            }

            for (int i = 1; i <= 12; i++)
            {

                ddlMes.Items.Add(i.ToString("D2"));
            }
            for (int i = 1930; i <= DateTime.Today.Year; i++)
            {
                ddlAnio.Items.Add(i.ToString());
            }
        }


        protected void reqLegajo_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (ddlTipo.SelectedValue == "Administrador")
            {
                reqLegajo1.Enabled = false ;
            }
        }

        protected void reqCarrera_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if(ddlTipo.SelectedValue == "Alumno")
            {
                reqCarrera1.Enabled = true;
            }

        }


        public string FormatFecha()
        {
            return ddlAnio.Text + "/" + ddlMes.Text + "/" + ddlDia.Text;
        }

        protected void ddlDia_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFecha.Text = FormatFecha();
        }

        protected void ddlMes_SelectedIndexChanged(object sender, EventArgs e)
        {
           txtFecha.Text = FormatFecha();
        }

        protected void ddlAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFecha.Text = FormatFecha();
        }
    }
}