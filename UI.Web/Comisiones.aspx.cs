using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;
using System.Data;

namespace UI.Web
{
    public partial class Comisiones : System.Web.UI.Page
    {
        public Comision ComisionActual { get; set; }
        public ComisionLogic ComLog
        {
            get { return new ComisionLogic(); }
        }
        public class DatosComisiones
        {
            public int ID { get; set; }
            public string Descripcion { get; set; }
            public int Anio { get; set; }
            public string DescPlan { get; set; }
            public string DescEspecialidad { get; set; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.gdvComisiones.DataSource = this.ObtenerDatos();
                this.gdvComisiones.DataBind();
            }

            //Event Bubblig
            MenuABM.BtnNuevoClick += new EventHandler(BtnNuevo_ButtonClick);
            MenuABM.BtnEliminarClick += new EventHandler(BtnEliminar_ButtonClick);
            MenuABM.BtnEditarClick += new EventHandler(BtnEditar_ButtonClick);

        }

        public void GetComision()
        {
            try
            {
                GridViewRow row = gdvComisiones.SelectedRow;
                int ID = int.Parse(row.Cells[0].Text);
                ComisionActual = ComLog.GetOne(ID);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message + "')", true);
            }
        }

        public void EliminarComision()
        {
            try
            {
                this.GetComision();
                ComisionActual.State = BusinessEntity.States.Deleted;
                ComLog.Save(ComisionActual);
            }
            catch
            {
                Response.Write("<script>alert('Error al eliminar la comisión')</script>");
            }
        }


        public List<DatosComisiones> ObtenerDatos()
        {
            List<DatosComisiones> datosComisiones = new List<DatosComisiones>();
            try
            {
                List<Comision> comisiones = ComLog.GetAll();

                foreach (Comision c in comisiones)
                {
                    DatosComisiones datosComision = new DatosComisiones();
                    datosComision.ID = c.ID;
                    datosComision.Descripcion = c.Descripcion;
                    datosComision.Anio = c.AnioEspecialidad;

                    PlanLogic pl = new PlanLogic();
                    Plan plan = pl.GetOne(c.IDPlan);
                    datosComision.DescPlan = plan.Descripcion;

                    EspecialidadLogic el = new EspecialidadLogic();
                    Especialidad especialidad = el.GetOne(plan.IDEspecialidad);
                    datosComision.DescEspecialidad = especialidad.Descripcion;

                    datosComisiones.Add(datosComision);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message + "')", true);
            }

            return datosComisiones;
        }

        private void BtnEditar_ButtonClick(object sender, EventArgs e)
        {
            try
            {
                this.GetComision();
                PlanLogic pl = new PlanLogic();
                Plan plan = pl.GetOne(this.ComisionActual.IDPlan);

                EspecialidadLogic el = new EspecialidadLogic();
                Especialidad especialidad = el.GetOne(plan.IDEspecialidad);

                this.Context.Items["Carrera"] = especialidad.ID;
                this.Context.Items["Modo"] = ModoForm.Modificacion;
                Session["Comision"] = ComisionActual;
                Server.Transfer("ComisionWeb.aspx", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message + "')", true);
            }
        }

        private void BtnNuevo_ButtonClick(object sender, EventArgs e)
        {
            this.Context.Items["Modo"] = ModoForm.Alta;
            Server.Transfer("ComisionWeb.aspx", true);
        }

        private void BtnEliminar_ButtonClick(object sender, EventArgs e)
        {
            this.EliminarComision();
            Response.Redirect("Comisiones.aspx");
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Main.aspx");
        }

        protected void gdvComisiones_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gdvComisiones, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click para seleccionar fila";
            }
        }

        protected void gdvComisiones_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.gdvComisiones.DataSource = this.ObtenerDatos();
            gdvComisiones.PageIndex = e.NewPageIndex;
            gdvComisiones.DataBind();
        }


    }
}