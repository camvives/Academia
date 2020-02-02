﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;

namespace UI.Web
{
    public partial class Docentes_Curso : System.Web.UI.Page
    {
        public class Docente
        {
            public int ID { get; set; }
            public string Nombre { get; set; }

            public string Apellido { get; set; }

            public int Legajo { get; set; }

            public string Cargo { get; set; }
        }
        public Docente Doc { get; set; }

        public Docentes_Cursos DocenteActual {get; set;}

        public Docente_CursoLogic DocCursoLog
        {
            get { return new Docente_CursoLogic(); }
        }

        public Curso CursoActual { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.CursoActual = (Curso)Session["Curso"];
            this.lblCurso.Text = "Docentes del curso " + CursoActual.ID.ToString();
            if (!IsPostBack)
            {
                this.gdvDocCur.DataSource = this.ObtenerDatos();
                this.gdvDocCur.DataBind();
            }

            //Event Bubblig
            MenuABM.BtnNuevoClick += new EventHandler(BtnNuevo_ButtonClick);
            MenuABM.BtnEliminarClick += new EventHandler(BtnEliminar_ButtonClick);
            MenuABM.BtnEditarClick += new EventHandler(BtnEditar_ButtonClick);
        }

        private void BtnEditar_ButtonClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnEliminar_ButtonClick(object sender, EventArgs e)
        {
            this.EliminarDocente();
            Response.Redirect("Docentes_Curso.aspx");
        }

        private void BtnNuevo_ButtonClick(object sender, EventArgs e)
        {
            this.Context.Items["Modo"] = ModoForm.Alta;
            Server.Transfer("Docente_CursoWeb.aspx", true);
        }

        public List<Docente> ObtenerDatos()
        {
            List<Docente> datosDocentes = new List<Docente>();
            Docente_CursoLogic dcl = new Docente_CursoLogic();
            List<Docentes_Cursos> docentes = dcl.GetDocentesPorCurso(CursoActual.ID);

            foreach (Docentes_Cursos dc in docentes)
            {
                Doc = new Docente();
                UsuarioLogic ul = new UsuarioLogic();

                Persona docente = ul.GetPersona(dc.IDDocente);
                Doc.Nombre = docente.Nombre;
                Doc.Apellido = docente.Apellido;
                Doc.Legajo = docente.Legajo;
                Doc.Cargo = dc.Cargo;
                Doc.ID = dc.ID;

                datosDocentes.Add(Doc);
            }

            return datosDocentes;
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Cursos.aspx");
        }

        protected void gdvDocCur_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.gdvDocCur.DataSource = this.ObtenerDatos();
            gdvDocCur.PageIndex = e.NewPageIndex;
            gdvDocCur.DataBind();
        }

        protected void gdvDocCur_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gdvDocCur, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click para seleccionar fila";
            }
        }

        public void EliminarDocente()
        {
            try
            {
                this.GetDocente();
                DocenteActual.State = BusinessEntity.States.Deleted;
                DocCursoLog.Save(DocenteActual);
            }
            catch
            {
                Response.Write("<script>alert('Error al eliminar la comisión')</script>");
            }
        }

        public void GetDocente()
        {
            GridViewRow row = gdvDocCur.SelectedRow;
            int ID = int.Parse(row.Cells[0].Text);
            DocenteActual = DocCursoLog.GetOne(ID);
        }
    }
}