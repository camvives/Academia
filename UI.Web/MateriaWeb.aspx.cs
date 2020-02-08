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
    public partial class MateriaWeb : UI.Web.ApplicationForm
    {
        public Materia MateriaActual { get; set; }
        protected new void Page_Load(object sender, EventArgs e)
        {
            MateriaActual = (Materia)Session["Materia"];

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

        public override void MapearADatos()
        {
            if (Modo == ModoForm.Alta)
            {
                MateriaActual = new Materia();
                MateriaActual.State = BusinessEntity.States.New;
            }
            else if (Modo == ModoForm.Modificacion)
            {
                MateriaActual.State = BusinessEntity.States.Modified;
            }

            this.MateriaActual.Descripcion = this.txtDescripcion.Text;
            this.MateriaActual.HorasSemanales = int.Parse(this.txtHsSem.Text);
            this.MateriaActual.HorasTotales = int.Parse(this.txtHsTot.Text);
            int idPlan = int.Parse(ddlPlan.SelectedValue.ToString());
            this.MateriaActual.IDPlan = idPlan;
        }


        public override void MapearDeDatos()
        {
            ddlCarrera.SelectedValue = this.Context.Items["Carrera"].ToString();
            this.CargaPlanes();
            ddlPlan.SelectedValue = MateriaActual.IDPlan.ToString();
            txtDescripcion.Text = MateriaActual.Descripcion;
            txtHsSem.Text = MateriaActual.HorasSemanales.ToString();
            txtHsTot.Text = MateriaActual.HorasTotales.ToString();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                this.MapearADatos();
                MateriaLogic cl = new MateriaLogic();
                cl.Save(MateriaActual);

                if (this.Modo == ModoForm.Modificacion)
                {
                    Response.Write("<script>alert('La Materia ha sido actualizada')</script>");
                }
                else if (this.Modo == ModoForm.Alta)
                {
                    Response.Write("<script>alert('La Materia ha sido Registrada')</script>");
                }

                Response.AddHeader("REFRESH", "0.1;URL=Materias.aspx");

            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Materias.aspx");
        }
    }
}