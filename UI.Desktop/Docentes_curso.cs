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
    public partial class formDocentes_Cursos : Form
    {
        public class DatosDocente
        {
            public string Nombre { get; set; }

            public string Apellido { get; set; }

            public int Legajo { get; set; }

            public string Cargo { get; set; }
        }

        public Curso CursoActual { get; set; }

        public formDocentes_Cursos()
        {
            InitializeComponent();
            dgvDocCur.AutoGenerateColumns = false;
        }

        public formDocentes_Cursos(Curso curso) : this()
        {
            CursoActual = curso;
        }

        private void Docentes_curso_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        public void Listar()
        {
            this.dgvDocCur.DataSource = this.ObtenerDatos();
        }

        public List<DatosDocente> ObtenerDatos()
        {
            List<DatosDocente> datosDocentes = new List<DatosDocente>();          
            Docente_CursoLogic dcl = new Docente_CursoLogic();
            List<Docentes_Cursos> docentes = dcl.GetDocentesPorCurso(CursoActual.ID);

            foreach (Docentes_Cursos dc in docentes)
            {
                DatosDocente datosDocente = new DatosDocente();
                UsuarioLogic ul = new UsuarioLogic();

                Persona docente = ul.GetDocente(dc.IDDocente);
                datosDocente.Nombre = docente.Nombre;
                datosDocente.Apellido = docente.Apellido;
                datosDocente.Legajo = docente.Legajo;
                datosDocente.Cargo = dc.Cargo;

                datosDocentes.Add(datosDocente);
            }

            return datosDocentes;
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
