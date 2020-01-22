using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;


namespace UI.Desktop
{
    public partial class formInscriptos : Form
    {
        public class DatosAlumnos
        {
            public int ID_Inscripcion { get; set; }
            public int Legajo { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string Condicion { get; set; }
            public string Nota { get; set; }
        }

        public Persona Docente { get; set; }
        public formInscriptos()
        {
            InitializeComponent();
            this.dgvCursos.AutoGenerateColumns = false;
        }

        public formInscriptos(Persona per) : this()
        {
            Docente = per;
        }

        private void CmbCursos_SelectedIndexChanged(object sender, EventArgs e)
        {        
            this.dgvCursos.DataSource = this.ObtenerDatos();
        }

        private void FormInscriptos_Load(object sender, EventArgs e)
        {
            this.CompletarCombobox();
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

            this.cmbCursos.DataSource = cursos;
        }

        public List<DatosAlumnos> ObtenerDatos()
        {
            string curso = this.cmbCursos.SelectedItem.ToString();
            int IDCurso = int.Parse(curso.Substring(curso.LastIndexOf(" ") + 1));

            Alumno_InscripcionLogic ail = new Alumno_InscripcionLogic();
            List<Alumno_Inscripcion> alumnos = ail.GetAlumnosInscriptos(IDCurso);
            List<DatosAlumnos> datosAlumnos = new List<DatosAlumnos>();

            foreach (Alumno_Inscripcion ai in alumnos)
            {
                DatosAlumnos alumno = new DatosAlumnos();
                alumno.ID_Inscripcion = ai.ID;
                alumno.Condicion = ai.Condicion;
                if (ai.Nota == 0)
                {
                    alumno.Nota = "-";
                }
                else
                {
                    alumno.Nota = ai.Nota.ToString();
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

        private void DgvCursos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void DgvCursos_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }
    }
}
