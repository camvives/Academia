using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class Materias : System.Web.UI.Page
    {
        public class DatosMaterias
        {
            public int ID { get; set; }
            public string Descripcion { get; set; }
            public int HorasSemanales { get; set; }
            public int HorasTotales { get; set; }
            public string DescPlan { get; set; }
            public string DescEspecialidad { get; set; }
        }

        public Materia MateriaActual { get; set; }

        public MateriaLogic MatLog
        {
            get { return new MateriaLogic(); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.gdvMaterias.DataSource = this.ObtenerDatos();
                this.gdvMaterias.DataBind();
            }

            //Event Bubblig
            MenuABM.BtnNuevoClick += new EventHandler(BtnNuevo_ButtonClick);
            MenuABM.BtnEliminarClick += new EventHandler(BtnEliminar_ButtonClick);
            MenuABM.BtnEditarClick += new EventHandler(BtnEditar_ButtonClick);
        }

        public List<DatosMaterias> ObtenerDatos()
        {
            List<DatosMaterias> datosMaterias = new List<DatosMaterias>();
            try
            {
                List<Materia> materias = MatLog.GetAll();

                foreach (Materia m in materias)
                {
                    DatosMaterias datosMateria = new DatosMaterias();
                    datosMateria.ID = m.ID;
                    datosMateria.Descripcion = m.Descripcion;
                    datosMateria.HorasSemanales = m.HorasSemanales;
                    datosMateria.HorasTotales = m.HorasTotales;

                    PlanLogic pl = new PlanLogic();
                    Plan plan = pl.GetOne(m.IDPlan);
                    datosMateria.DescPlan = plan.Descripcion;

                    EspecialidadLogic el = new EspecialidadLogic();
                    Especialidad especialidad = el.GetOne(plan.IDEspecialidad);
                    datosMateria.DescEspecialidad = especialidad.Descripcion;

                    datosMaterias.Add(datosMateria);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message + "')", true);

            }

            return datosMaterias;
        }
        public void GetMateria()
        {
            try
            {
                GridViewRow row = gdvMaterias.SelectedRow;
                int ID = int.Parse(row.Cells[0].Text);
                MateriaActual = MatLog.GetOne(ID);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message + "')", true);
            }
        }

        public void EliminarMateria()
        {
            try
            {
                this.GetMateria();
                MateriaActual.State = BusinessEntity.States.Deleted;
                MatLog.Save(MateriaActual);
            }
            catch
            {
                Response.Write("<script>alert('Error al eliminar la materia')</script>");
            }
        }



        private void BtnEditar_ButtonClick(object sender, EventArgs e)
        {
            try
            {
                this.GetMateria();
                PlanLogic pl = new PlanLogic();
                Plan plan = pl.GetOne(this.MateriaActual.IDPlan);

                EspecialidadLogic el = new EspecialidadLogic();
                Especialidad especialidad = el.GetOne(plan.IDEspecialidad);

                this.Context.Items["Carrera"] = especialidad.ID;
                this.Context.Items["Modo"] = ModoForm.Modificacion;
                Session["Materia"] = MateriaActual;
                Server.Transfer("MateriaWeb.aspx", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message + "')", true);

            }
        }

        private void BtnEliminar_ButtonClick(object sender, EventArgs e)
        {
            this.EliminarMateria();
            Response.Redirect("Materias.aspx");
        }

        private void BtnNuevo_ButtonClick(object sender, EventArgs e)
        {
            this.Context.Items["Modo"] = ModoForm.Alta;
            Server.Transfer("MateriaWeb.aspx", true);
        }

        protected void gdvMaterias_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.gdvMaterias.DataSource = this.ObtenerDatos();
            gdvMaterias.PageIndex = e.NewPageIndex;
            gdvMaterias.DataBind();

        }

        protected void gdvMaterias_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gdvMaterias, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click para seleccionar fila";
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Main.aspx");
        }
    }
}