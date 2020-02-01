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
    public partial class Cursos : System.Web.UI.Page
    {
        public class DatosCursos
        {
            public int ID { get; set; }
            public string DescMateria { get; set; }
            public string DescComision { get; set; }
            public int AnioCalendario { get; set; }
            public int Cupo { get; set; }
            public string DescEspecialidad { get; set; }
            public string DescPlan { get; set; }
        }

        public Persona PersonaActual { get; set; }

        public CursoLogic CursoLog
        {
            get { return new CursoLogic(); }
        }

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
            throw new NotImplementedException();
        }

        private void BtnEliminar_ButtonClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnNuevo_ButtonClick(object sender, EventArgs e)
        {
            this.Context.Items["Modo"] = ModoForm.Alta;
            Server.Transfer("CursoWeb.aspx", true);
        }

        public List<DatosCursos> ObtenerDatosUsr()
        {
            List<DatosCursos> datosCursos = new List<DatosCursos>();
            List<Curso> cursos = CursoLog.GetCursosUsuario(PersonaActual.IDPlan);

            foreach (Curso c in cursos)
            {
                DatosCursos datosCurso = new DatosCursos();
                Alumno_InscripcionLogic ail = new Alumno_InscripcionLogic();
                int cupoActual = c.Cupo - ail.GetCantidadInscriptos(c.ID);

                datosCurso.Cupo = cupoActual;
                datosCurso.ID = c.ID;

                MateriaLogic ml = new MateriaLogic();
                Materia mat = ml.GetOne(c.IDMateria);
                datosCurso.DescMateria = mat.Descripcion;

                ComisionLogic cl = new ComisionLogic();
                Comision com = cl.GetOne(c.IDComision);
                datosCurso.DescComision = com.Descripcion;

                datosCursos.Add(datosCurso);

            }

            return datosCursos;
        }

        public List<DatosCursos> ObtenerDatos()
        {
            List<DatosCursos> datosCursos = new List<DatosCursos>();
            List<Curso> cursos = CursoLog.GetAll();

            foreach (Curso c in cursos)
            {
                DatosCursos datosCurso = new DatosCursos();
                datosCurso.ID = c.ID;
                datosCurso.AnioCalendario = c.AnioCalendario;
                datosCurso.Cupo = c.Cupo;

                MateriaLogic ml = new MateriaLogic();
                Materia mat = ml.GetOne(c.IDMateria);
                datosCurso.DescMateria = mat.Descripcion;

                ComisionLogic cl = new ComisionLogic();
                Comision com = cl.GetOne(c.IDComision);
                datosCurso.DescComision = com.Descripcion;

                PlanLogic pl = new PlanLogic();
                Plan plan = pl.GetOne(com.IDPlan);
                datosCurso.DescPlan = plan.Descripcion;
                EspecialidadLogic el = new EspecialidadLogic();
                Especialidad especialidad = el.GetOne(plan.IDEspecialidad);
                datosCurso.DescEspecialidad = especialidad.Descripcion;

                datosCursos.Add(datosCurso);
            }

            return datosCursos;
        }

        public void Listar()
        {
            if (PersonaActual == null)
            {
                this.gdvCursos.DataSource = this.ObtenerDatos();
                this.gdvCursos.DataBind();
            }
            //else
            //{
            //    this.gdvCursos.DataSource = this.ObtenerDatosUsr();
            //    Alumno_InscripcionLogic alInscLog = new Alumno_InscripcionLogic();
            //    List<Alumno_Inscripcion> inscripciones = alInscLog.GetMateriasInscripto(PersonaActual.ID);

            //    List<int> idInscripciones = new List<int>();
            //    foreach (Alumno_Inscripcion ai in inscripciones)
            //    {
            //        int idCurso = ai.IDCurso;
            //        idInscripciones.Add(idCurso);
            //    }

            //    foreach (DataGridViewRow row in dgvCursos.Rows)
            //    {
            //        if (idInscripciones.Contains(int.Parse(row.Cells["ID"].Value.ToString())))
            //        {
            //            row.DefaultCellStyle.BackColor = Color.LightGray;
            //            row.Cells["Inscribirse"].ReadOnly = true;
            //            row.Cells["Inscribirse"].Value = 2;
            //        }

            //    }
            //}

        }

        protected void gdvComisiones_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.gdvCursos.DataSource = this.ObtenerDatos();
            gdvCursos.PageIndex = e.NewPageIndex;
            gdvCursos.DataBind();

        }

        protected void gdvComisiones_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gdvCursos, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click para seleccionar fila";
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Main.aspx");
        }
    }
}