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
    public partial class ComisionWeb : UI.Web.ApplicationForm
    {
        public Comision ComisionActual { get; set; }

        protected new void Page_Load(object sender, EventArgs e)
        {
            ComisionActual = (Comision)Session["Comision"];

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


        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Comisiones.aspx");
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

                if (this.Modo != ModoForm.Modificacion)
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
                Response.Redirect("~/Main.aspx");
            }

        }

        protected void ddlCarrera_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlPlan.Enabled = true;
            ddlCarrera.Items.Remove("Seleccionar Carrera");
            ddlPlan.Items.Remove("Plan");
            this.CargaPlanes();
        }

        public override void MapearADatos()
        {
            if (Modo == ModoForm.Alta)
            {
                ComisionActual = new Comision();
                ComisionActual.State = BusinessEntity.States.New;
            }
            else if (Modo == ModoForm.Modificacion)
            {
                ComisionActual.State = BusinessEntity.States.Modified;
            }

            this.ComisionActual.Descripcion = this.txtDescripcion.Text;
            this.ComisionActual.AnioEspecialidad = int.Parse(this.ddlAnio.SelectedItem.ToString());
            int idPlan = int.Parse(ddlPlan.SelectedValue.ToString());
            this.ComisionActual.IDPlan = idPlan;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                this.MapearADatos();
                ComisionLogic cl = new ComisionLogic();
                cl.Save(ComisionActual);

                if (this.Modo == ModoForm.Modificacion)
                {
                    Response.Write("<script>alert('La Comisión ha sido actualizada')</script>");
                }
                else if (this.Modo == ModoForm.Alta)
                {
                    Response.Write("<script>alert('La Comisión ha sido Registrada')</script>");
                }

                Response.AddHeader("REFRESH", "0.1;URL=Comisiones.aspx");

            }
        }

        public override void MapearDeDatos()
        {
            ddlCarrera.SelectedValue = this.Context.Items["Carrera"].ToString();
            this.CargaPlanes();
            ddlPlan.SelectedValue = ComisionActual.IDPlan.ToString();
            txtDescripcion.Text = ComisionActual.Descripcion;
            ddlAnio.SelectedValue = ComisionActual.AnioEspecialidad.ToString();
        }

        public void CargaPlanes()
        {
            try
            {
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

    }
}