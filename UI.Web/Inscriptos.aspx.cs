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
    public partial class Inscriptos : System.Web.UI.Page
    {
        public class DatosAlumnos
        {
            public int ID { get; set; }
            //public int ID_Curso { get; set; }
            //public int ID_persona { get; set; }
            public int Legajo { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string Condicion { get; set; }
            public string NotaMostrar { get; set; }
            public int Nota { get; set; }
        }

        public DatosAlumnos AlumnoActual { get; set; }

        public Persona Docente { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            Docente = (Persona)Session["Persona"];

            if (!IsPostBack)
            {
                this.CompletarCombobox();
                gdvInscriptos.DataSource = this.ObtenerDatos();
                gdvInscriptos.DataBind();

            }

        }

        public void CompletarCombobox()
        {
            List<String> cursos = new List<string>();
            Docente_CursoLogic dcLog = new Docente_CursoLogic();
            List<Docentes_Cursos> docentesCursos = new List<Docentes_Cursos>();
            docentesCursos = dcLog.GetCursosPorDocente(Docente.ID);

            foreach (Docentes_Cursos dc in docentesCursos)
            {
                string curso;

                CursoLogic cl = new CursoLogic();
                Curso cur = cl.GetOne(dc.IDCurso);

                ComisionLogic col = new ComisionLogic();
                Comision com = col.GetOne(cur.IDComision);

                MateriaLogic mat = new MateriaLogic();
                Materia materia = mat.GetOne(cur.IDMateria);

                PlanLogic pl = new PlanLogic();
                Plan plan = pl.GetOne(materia.IDPlan);

                EspecialidadLogic el = new EspecialidadLogic();
                Especialidad especialidad = el.GetOne(plan.IDEspecialidad);


                curso = com.Descripcion + " - " + materia.Descripcion + " - " + especialidad.Descripcion + " - " + cur.AnioCalendario.ToString() + " - " + dc.IDCurso.ToString();

                cursos.Add(curso);
            }

            this.ddlCurso.DataSource = cursos;
            ddlCurso.DataBind();
        }

        public List<DatosAlumnos> ObtenerDatos()
        {
            string curso = this.ddlCurso.SelectedItem.ToString();
            int IDCurso = int.Parse(curso.Substring(curso.LastIndexOf(" ") + 1));

            Alumno_InscripcionLogic ail = new Alumno_InscripcionLogic();
            List<Alumno_Inscripcion> alumnos = ail.GetAlumnosInscriptos(IDCurso);
            List<DatosAlumnos> datosAlumnos = new List<DatosAlumnos>();

            foreach (Alumno_Inscripcion ai in alumnos)
            {
                DatosAlumnos alumno = new DatosAlumnos();
                alumno.ID = ai.ID;
                alumno.Condicion = ai.Condicion;
                alumno.Nota = ai.Nota;
                //alumno.ID_Curso = ai.IDCurso;
                //alumno.ID_persona = ai.IDAlumno;
                if (ai.Nota == 0)
                {
                    alumno.NotaMostrar = "-";
                }
                else
                {
                    alumno.NotaMostrar = ai.Nota.ToString();
                }

                UsuarioLogic ul = new UsuarioLogic();
                Persona persona = ul.GetPersona(ai.IDAlumno);

                alumno.Nombre = persona.Nombre;
                alumno.Legajo = persona.Legajo;
                alumno.Apellido = persona.Apellido;

                datosAlumnos.Add(alumno);

            }

            return datosAlumnos;
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Main.aspx");
        }

        protected void gdvComisiones_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void gdvInscriptos_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        protected void ddlCurso_SelectedIndexChanged(object sender, EventArgs e)
        {
            gdvInscriptos.DataSource = this.ObtenerDatos();
            gdvInscriptos.DataBind();
        }
    }
}