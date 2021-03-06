﻿using Business.Entities;
using Business.Logic;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class UsuarioWeb : UI.Web.ApplicationForm
    {
        public Persona PersonaActual { get; set; }
        public Usuario UsuarioActual { get; set; }

        public bool Admin
        {
            get
            {
                object admin = ViewState["admin"];
                return (bool)admin;
            }
            set { ViewState["admin"] = value; }

        }

        protected new void Page_Load(object sender, EventArgs e)
        {
            if ((Persona.TiposPersonas)Session["Tipo"] != Persona.TiposPersonas.Administrador)
            {
                Response.Redirect("~/Login.aspx");
            }

            PersonaActual = (Persona)Session["PersonaEdit"];
            UsuarioActual = (Usuario)Session["Usuario"];
            this.Modo = (ModoForm)Session["Modo"];

            if (!IsPostBack)
            {
                this.CompletarDDLEsp();
                this.CompletarFecha();

                if (this.Modo == ModoForm.Modificacion)
                {
                    MapearDeDatos();
                    Admin = true;
                }
                if (this.Modo == ModoForm.Consulta)
                {
                    MapearDeDatos();
                    this.txtApellido.Enabled = false;
                    this.txtNombre.Enabled = false;
                    this.ddlTipo.Enabled = false;
                    this.txtDireccion.Enabled = false;
                    this.txtEmail.Enabled = false;
                    this.txtLegajo.Enabled = false;
                    this.ddlCarrera.Enabled = false;
                    this.ddlPlan.Enabled = false;
                    this.ddlDia.Enabled = false;
                    this.ddlMes.Enabled = false;
                    this.ddlAnio.Enabled = false;
                    this.txtTelefono.Enabled = false;
                    this.chkHabilitado.Enabled = false;
                    this.txtUsuario.Enabled = false;
                    this.btnGuardar.Text = "Modificar";
                    Admin = false;
                }
                else
                {
                    Admin = true;
                }

            }

        }

        #region METODOS
        public void CompletarDDLEsp()
        {
            try
            {
                EspecialidadLogic especialidad = new EspecialidadLogic();
                ddlCarrera.DataTextField = "Descripcion";
                ddlCarrera.DataValueField = "ID";
                ddlCarrera.DataSource = especialidad.GetAll();
                ddlCarrera.DataBind();

                if (this.Modo == ModoForm.Alta)
                {
                    ddlCarrera.Items.Insert(0, "Seleccionar Carrera");
                    if (!(ddlPlan.Items.Contains(ddlPlan.Items.FindByValue("Plan"))))
                    {
                        ddlPlan.Items.Insert(0, "Plan");
                    }
                    ddlPlan.Text = "Plan";
                }
            }
            catch
            {
                Response.Write("<script>alert('Error al cargar el formulario')</script>");
            }

        }

        public override void MapearADatos()
        {
            try
            {

                if (Modo == ModoForm.Alta)
                {
                    PersonaActual = new Persona();
                    UsuarioActual = new Usuario();
                    this.UsuarioActual.State = BusinessEntity.States.New;
                }
                else if (Modo == ModoForm.Modificacion)
                {
                    this.UsuarioActual.State = BusinessEntity.States.Modified;
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
            catch
            {
                Response.Write("<script>alert('Error al guardar datos del usuario')</script>");
            }

        }

        public override void MapearDeDatos()
        {
            try
            {
                ddlTipo.SelectedValue = PersonaActual.TipoPersona.ToString();
                txtLegajo.Text = PersonaActual.Legajo.ToString();
                this.CambiaTipo();
                ddlCarrera.SelectedValue = this.Context.Items["Carrera"].ToString();
                this.CargaPlanes();
                ddlPlan.SelectedValue = PersonaActual.IDPlan.ToString();
                txtNombre.Text = PersonaActual.Nombre;
                txtApellido.Text = PersonaActual.Apellido;
                txtDireccion.Text = PersonaActual.Direccion;
                txtEmail.Text = PersonaActual.Email;
                txtTelefono.Text = PersonaActual.Telefono;
                ddlDia.Text = PersonaActual.FechaNacimiento.Day.ToString("D2");
                ddlMes.Text = PersonaActual.FechaNacimiento.Month.ToString("D2");
                ddlAnio.Text = PersonaActual.FechaNacimiento.Year.ToString();
                txtUsuario.Text = UsuarioActual.NombreUsuario;
                txtClave.Attributes["value"] = UsuarioActual.Clave;
                txtConfirmaClave.Attributes["value"] = UsuarioActual.Clave;
                chkHabilitado.Checked = UsuarioActual.Habilitado;
            }
            catch
            {
                Response.Write("<script>alert('Error al recuperar datos del usuario')</script>");
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

        public string FormatFecha()
        {
            return ddlAnio.Text + "/" + ddlMes.Text + "/" + ddlDia.Text;
        }

        public void CambiaTipo()
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

        public void CargaPlanes()
        {
            try
            {
                if (ddlTipo.SelectedValue == "Alumno")
                {
                    int EspId = int.Parse(ddlCarrera.SelectedValue.ToString());

                    PlanLogic plan = new PlanLogic();
                    ddlPlan.DataTextField = "Descripcion";
                    ddlPlan.DataValueField = "ID";
                    ddlPlan.DataSource = plan.GetPlanesEsp(EspId);
                    ddlPlan.DataBind();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message + "')", true);
            }
        }

        public void Guardar()
        {
            if (this.Modo != ModoForm.Consulta)
            {

                if (Page.IsValid)
                {
                    try
                    {
                        this.MapearADatos();
                        UsuarioLogic ul = new UsuarioLogic();
                        ul.Save(UsuarioActual, PersonaActual);

                        if (Admin)
                        {
                            if (this.Modo == ModoForm.Modificacion)
                            {
                                Response.Write("<script>alert('El usuario ha sido actualizado')</script>");
                            }
                            else if (this.Modo == ModoForm.Alta)
                            {
                                Response.Write("<script>alert('El usuario ha sido registrado')</script>");
                            }

                            Response.AddHeader("REFRESH", "0.1;URL=Usuarios.aspx");
                        }
                        else
                        {
                            Response.Write("<script>alert('Los datos han sido actualizados')</script>");
                            Response.AddHeader("REFRESH", "0.1;URL=Main.aspx");
                        }
                    }
                    catch (Exception ex)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message + "')", true);

                    }

                }

            }
            else if (this.Modo == ModoForm.Consulta)
            {
                this.btnGuardar.Text = "Guardar";
                Modo = ModoForm.Modificacion;
                this.txtApellido.Enabled = true;
                this.txtNombre.Enabled = true;
                this.txtDireccion.Enabled = true;
                this.txtEmail.Enabled = true;
                this.txtLegajo.Enabled = true;
                this.ddlDia.Enabled = true;
                this.ddlMes.Enabled = true;
                this.ddlAnio.Enabled = true;
                this.txtTelefono.Enabled = true;
                this.txtUsuario.Enabled = true;

            }
        }

        #endregion

        #region ELEMENTOS DEL FORM
        protected void ddlCarrera_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message + "')", true);

            }

        }

        protected void ddlTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CambiaTipo();
        }

        protected void reqLegajo_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (ddlTipo.SelectedValue == "Alumno")
            {
                reqLegajo1.Enabled = true;
            }
            else if (ddlTipo.SelectedValue == "Docente")
            {
                reqLegajo1.Enabled = true;
            }
        }

        protected void reqCarrera_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (ddlTipo.SelectedValue == "Alumno")
            {
                reqCarrera1.Enabled = true;
            }

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

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Usuarios.aspx");
        }

       

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            if (Admin)
            {
                Response.Redirect("~/Usuarios.aspx");
            }
            else
            {
                Response.Redirect("~/Main.aspx");
            }

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            this.Guardar();
        }



        #endregion
    }

}