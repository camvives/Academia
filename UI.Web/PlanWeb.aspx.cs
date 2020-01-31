using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Logic;
using Business.Entities;

namespace UI.Web
{
    public partial class PlanWeb : UI.Web.ApplicationForm
    {
        public Plan PlanActual { get; set; }
        protected new void Page_Load(object sender, EventArgs e)
        {
            PlanActual = (Plan)Session["Plan"];

            if (!IsPostBack)
            {
                this.Modo = (ModoForm)this.Context.Items["Modo"];
                this.CompletarDDLEsp();

                if (this.Modo == ModoForm.Modificacion)
                {
                    MapearDeDatos();
                }
            }

        }

        public void CompletarDDLEsp()
        {
            try
            {
                EspecialidadLogic especialidad = new EspecialidadLogic();
                ddlCarrera.DataTextField = "Descripcion";
                ddlCarrera.DataValueField = "ID";
                ddlCarrera.DataSource = especialidad.GetAll();
                ddlCarrera.DataBind();
            }
            catch
            {
                Response.Write("<script>alert('Error al cargar el formulario')</script>");
                Response.Redirect("~/Main.aspx");
            }

        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Planes.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                this.MapearADatos();
                PlanLogic pl = new PlanLogic();
                pl.Save(PlanActual);

                if (this.Modo == ModoForm.Modificacion)
                {
                    Response.Write("<script>alert('El Plan ha sido actualizado')</script>");
                }
                else if (this.Modo == ModoForm.Alta)
                {
                    Response.Write("<script>alert('El Plan ha sido Registrado')</script>");
                }

                Response.AddHeader("REFRESH", "0.1;URL=Planes.aspx");

            }
        }

        public override void MapearADatos()
        {
            if (Modo == ModoForm.Alta)
            {
                PlanActual = new Plan();
                PlanActual.State = BusinessEntity.States.New;
            }
            else if (Modo == ModoForm.Modificacion)
            {
                PlanActual.State = BusinessEntity.States.Modified;
            }

            this.PlanActual.Descripcion = this.txtDescripcion.Text;
            int idEsp = int.Parse(ddlCarrera.SelectedValue.ToString());
            this.PlanActual.IDEspecialidad = idEsp;
        }

        public override void MapearDeDatos()
        {
            ddlCarrera.SelectedValue = this.Context.Items["Carrera"].ToString();
            txtDescripcion.Text = PlanActual.Descripcion;
        }

        protected void ddlCarrera_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}