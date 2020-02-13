using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;
using Util;

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

        public Curso CursoActual { get; set; }

        public CursoLogic CursoLog
        {
            get { return new CursoLogic(); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            PersonaActual = (Persona)Session["Persona"];
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
            try
            {
                this.GetCurso();

                MateriaLogic ml = new MateriaLogic();
                Materia mat = ml.GetOne(CursoActual.IDMateria);

                PlanLogic pl = new PlanLogic();
                Plan plan = pl.GetOne(mat.IDPlan);

                EspecialidadLogic el = new EspecialidadLogic();
                Especialidad especialidad = el.GetOne(plan.IDEspecialidad);

                this.Context.Items["Carrera"] = especialidad.ID;
                this.Context.Items["Plan"] = plan.ID;
                this.Context.Items["Modo"] = ModoForm.Modificacion;
                Session["Curso"] = CursoActual;
                Server.Transfer("CursoWeb.aspx", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message + "')", true);

            }
        }

        private void BtnEliminar_ButtonClick(object sender, EventArgs e)
        {
            this.EliminarCurso();
            Response.Redirect("Cursos.aspx");
        }

        private void BtnNuevo_ButtonClick(object sender, EventArgs e)
        {
            this.Context.Items["Modo"] = ModoForm.Alta;
            Server.Transfer("CursoWeb.aspx", true);
        }

        public List<DatosCursos> ObtenerDatosUsr()
        {
            List<DatosCursos> datosCursos = new List<DatosCursos>();
            try
            {
                List<Curso> cursos = CursoLog.GetCursosUsuario(PersonaActual.IDPlan);
                Alumno_InscripcionLogic alInscLog = new Alumno_InscripcionLogic();
                List<Alumno_Inscripcion> inscripciones = alInscLog.GetMateriasInscripto(PersonaActual.ID);

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

                foreach (Alumno_Inscripcion ai in inscripciones)
                {
                    foreach (DatosCursos dc in datosCursos)
                    {
                        if (ai.IDCurso == dc.ID)
                        {
                            datosCursos.Remove(dc);
                            break;
                        }
                    }


                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message + "')", true);

            }

            return datosCursos;
        }

        public List<DatosCursos> ObtenerDatos()
        {
            List<DatosCursos> datosCursos = new List<DatosCursos>();
            try
            {
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
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message + "')", true);

            }

            return datosCursos;
        }

        public void Listar()
        {
            if (PersonaActual.TipoPersona == Persona.TiposPersonas.Administrador)
            {
                this.gdvCursos.DataSource = this.ObtenerDatos();
                this.gdvCursos.DataBind();
            }
            else
            {
                List<DatosCursos> datos = this.ObtenerDatosUsr();
                if(datos.Count() == 0)
                {
                    Response.Write("<script>alert('No hay cursos disponibles para inscribirse')</script>");
                    Response.AddHeader("REFRESH", "0.1;URL=Main.aspx");
                }
                else
                {
                    this.gdvCursos.DataSource = datos;

                    this.gdvCursos.DataBind();
                    this.btnDocentes.Visible = false;
                    this.MenuABM.Visible = false;
                    gdvCursos.Columns[0].Visible = false;
                    gdvCursos.Columns[3].Visible = false;
                    gdvCursos.Columns[4].HeaderText = "Cupo Disponible";
                    gdvCursos.Columns[5].Visible = false;
                    gdvCursos.Columns[6].Visible = false;
                    gdvCursos.Columns[7].Visible = true;
                }

            }

        }

        private void EliminarCurso()
        {
            try
            {
                this.GetCurso();
                CursoActual.State = BusinessEntity.States.Deleted;
                CursoLog.Save(CursoActual);
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error al eliminar el curso')", true);

            }
        }

        public void GetCurso()
        {
            try
            {
                GridViewRow row = gdvCursos.SelectedRow;
                int ID = int.Parse(row.Cells[0].Text);
                CursoActual = CursoLog.GetOne(ID);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message + "')", true);
            }
        }

        public void Inscribirse()
        {
            try
            {
                this.GetCurso();
                if (Validaciones.ValidarCupo(CursoActual.ID))
                {
                    Alumno_Inscripcion alInsc = new Alumno_Inscripcion();
                    alInsc.IDAlumno = PersonaActual.ID;
                    alInsc.IDCurso = CursoActual.ID;

                    Alumno_InscripcionLogic aiLog = new Alumno_InscripcionLogic();
                    aiLog.Save(alInsc);
                    Response.Redirect("~/Cursos.aspx");
                }
                else
                {
                    Response.Write("<script>alert('No hay cupo en el curso seleccionado')</script>");

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message + "')", true);
            }
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

        protected void btnDocentes_Click(object sender, ImageClickEventArgs e)
        {
            this.GetCurso();
            Session["Curso"] = CursoActual;
            Response.Redirect("~/Docentes_Curso.aspx");
        }

        protected void gdvCursos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PersonaActual.TipoPersona == Persona.TiposPersonas.Alumno)
            {
                this.Inscribirse();
            }

        }

    }
}