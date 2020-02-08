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
    public partial class Especialidades : System.Web.UI.Page
    {
        public EspecialidadLogic EspLog
        {
            get { return new EspecialidadLogic(); }
        }

        public Especialidad EspActual { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Listar();
            }

            //Event Bubblig
            MenuABM.BtnNuevoClick += new EventHandler(BtnNuevo_ButtonClick);
            MenuABM.BtnEliminarClick += new EventHandler(BtnEliminar_ButtonClick);
            MenuABM.BtnEditarClick += new EventHandler(BtnEditar_ButtonClick);
        }

        private void BtnEditar_ButtonClick(object sender, EventArgs e)
        {
            this.GetEspecialidad();
            this.Context.Items["Modo"] = ModoForm.Modificacion;
            Session["Especialidad"] = EspActual;
            Server.Transfer("EspecialidadWeb.aspx", true);
        }

        private void BtnEliminar_ButtonClick(object sender, EventArgs e)
        {
            this.EliminarEspecialidad();
            Response.Redirect("Especialidades.aspx");
        }

        private void BtnNuevo_ButtonClick(object sender, EventArgs e)
        {
            this.Context.Items["Modo"] = ModoForm.Alta;
            Server.Transfer("EspecialidadWeb.aspx", true);
        }

        public void Listar()
        {
            try
            {
                gdvEspecialidades.DataSource = EspLog.GetAll();
                gdvEspecialidades.DataBind();
            }
            catch
            {
                Response.Write("<script>alert('Error al recuperar la lista de especialidades')</script>");
                Response.Redirect("~/Main.aspx");
            }
        }

        protected void gdvEspecialidades_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gdvEspecialidades, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click para seleccionar fila";
            }
        }

        public void GetEspecialidad()
        {
            GridViewRow row = gdvEspecialidades.SelectedRow;
            int ID = int.Parse(row.Cells[0].Text);
            EspActual = EspLog.GetOne(ID);
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Main.aspx");
        }


        public void EliminarEspecialidad()
        {
            try
            {
                this.GetEspecialidad();
                EspActual.State = BusinessEntity.States.Deleted;
                EspLog.Save(EspActual);
            }
            catch
            {
                Response.Write("<script>alert('Error al eliminar la Especialidad')</script>");
            }
        }

        protected void gdvEspecialidades_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                this.gdvEspecialidades.DataSource = EspLog.GetAll();
                gdvEspecialidades.PageIndex = e.NewPageIndex;
                gdvEspecialidades.DataBind();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message + "')", true);

            }
        }
    }

}