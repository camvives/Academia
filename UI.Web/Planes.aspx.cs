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
    public partial class Planes : System.Web.UI.Page
    {
        public Plan PlanActual { get; set; }

        public PlanLogic PlanLog
        {
            get { return new PlanLogic(); }
        }

        public class DatosPlanes
        {
            public int ID { get; set; }
            public string Descripcion { get; set; }
            public string DescEspecialidad { get; set; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.gdvPlanes.DataSource = this.ObtenerDatos();
                this.gdvPlanes.DataBind();
            }

            //Event Bubblig
            MenuABM.BtnNuevoClick += new EventHandler(BtnNuevo_ButtonClick);
            MenuABM.BtnEliminarClick += new EventHandler(BtnEliminar_ButtonClick);
            MenuABM.BtnEditarClick += new EventHandler(BtnEditar_ButtonClick);
        }

        private void BtnEditar_ButtonClick(object sender, EventArgs e)
        {
            this.GetPlan();

            EspecialidadLogic el = new EspecialidadLogic();
            Especialidad especialidad = el.GetOne(PlanActual.IDEspecialidad);

            this.Context.Items["Carrera"] = especialidad.ID;
            this.Context.Items["Modo"] = ModoForm.Modificacion;
            Session["Plan"] = PlanActual;
            Server.Transfer("PlanWeb.aspx", true);
        }

        private void BtnEliminar_ButtonClick(object sender, EventArgs e)
        {
            this.EliminarPlan();
            Response.Redirect("Planes.aspx");
        }

        private void BtnNuevo_ButtonClick(object sender, EventArgs e)
        {
            this.Context.Items["Modo"] = ModoForm.Alta;
            Server.Transfer("PlanWeb.aspx", true);
        }

        public List<DatosPlanes> ObtenerDatos()
        {
            List<DatosPlanes> datosPlanes = new List<DatosPlanes>();
            List<Plan> planes = PlanLog.GetAll();

            foreach (Plan p in planes)
            {
                DatosPlanes datosPlan = new DatosPlanes();
                datosPlan.ID = p.ID;
                datosPlan.Descripcion = p.Descripcion;

                EspecialidadLogic el = new EspecialidadLogic();
                Especialidad especialidad = el.GetOne(p.IDEspecialidad);
                datosPlan.DescEspecialidad = especialidad.Descripcion;

                datosPlanes.Add(datosPlan);
            }

            return datosPlanes;
        }

        public void GetPlan()
        {
            try
            {
                GridViewRow row = gdvPlanes.SelectedRow;
                int ID = int.Parse(row.Cells[0].Text);
                PlanActual = PlanLog.GetOne(ID);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message + "')", true);

            }
        }

        public void EliminarPlan()
        {
            try
            {
                this.GetPlan();
                PlanActual.State = BusinessEntity.States.Deleted;
                PlanLog.Save(PlanActual);
            }
            catch
            {
                Response.Write("<script>alert('Error al eliminar el plan')</script>");
            }
        }

        protected void gdvComisiones_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.gdvPlanes.DataSource = this.ObtenerDatos();
            gdvPlanes.PageIndex = e.NewPageIndex;
            gdvPlanes.DataBind();
        }

        protected void gdvComisiones_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gdvPlanes, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click para seleccionar fila";
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Main.aspx");
        }
    }
}