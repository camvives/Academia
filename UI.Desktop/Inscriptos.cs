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
            public int ID_Curso { get; set; }
            public int ID_persona { get; set; }
            public int Legajo { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string Condicion { get; set; }
            public string NotaMostrar { get; set; }
            public int Nota { get; set; }
        }

        public DatosAlumnos AlumnoActual { get; set;}

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
            this.Listar();   
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
            List<DatosAlumnos> datosAlumnos = new List<DatosAlumnos>();
            Alumno_InscripcionLogic ail = new Alumno_InscripcionLogic();

            try
            {
                List<Alumno_Inscripcion> alumnos = ail.GetAlumnosInscriptos(IDCurso);

                foreach (Alumno_Inscripcion ai in alumnos)
                {
                    DatosAlumnos alumno = new DatosAlumnos();
                    alumno.ID_Inscripcion = ai.ID;
                    alumno.Condicion = ai.Condicion;
                    alumno.Nota = ai.Nota;
                    alumno.ID_Curso = ai.IDCurso;
                    alumno.ID_persona = ai.IDAlumno;
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
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return datosAlumnos;
        }

        private void DgvCursos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        public void Listar()
        {
            this.dgvCursos.DataSource = this.ObtenerDatos();
        }

        private void DgvCursos_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.MapearDatos();
            InscriptosDesktop ides = new InscriptosDesktop(AlumnoActual);
            ides.ShowDialog();
            this.Listar();
            
        }

        public void MapearDatos()
        {
            AlumnoActual = new DatosAlumnos();
            AlumnoActual.ID_Inscripcion = (int)dgvCursos.SelectedRows[0].Cells["ID_Inscripcion"].Value;
            AlumnoActual.ID_persona = (int)dgvCursos.SelectedRows[0].Cells["ID_Persona"].Value;
            AlumnoActual.ID_Curso = (int)dgvCursos.SelectedRows[0].Cells["ID_Curso"].Value;
            AlumnoActual.Legajo = (int)dgvCursos.SelectedRows[0].Cells["Legajo"].Value;
            AlumnoActual.Nombre = (string)dgvCursos.SelectedRows[0].Cells["Nombre"].Value;
            AlumnoActual.Apellido = (string)dgvCursos.SelectedRows[0].Cells["Apellido"].Value;
            AlumnoActual.Nota = (int)dgvCursos.SelectedRows[0].Cells["Nota2"].Value;

        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
