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
        public class Docente
        {
            public int ID { get; set; }
            public string Nombre { get; set; }

            public string Apellido { get; set; }

            public int Legajo { get; set; }

            public string Cargo { get; set; }
        }

        public Docente Doc { get; set; }

        public Docente_CursoLogic DocCursoLog
        {
            get { return new Docente_CursoLogic(); }
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
            this.Text = "Curso ID " + CursoActual.ID.ToString();
        }

        private void Docentes_curso_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        public void Listar()
        {
            this.dgvDocCur.DataSource = this.ObtenerDatos();
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

                Persona docente = ul.GetDocente(dc.IDDocente);
                Doc.Nombre = docente.Nombre;
                Doc.Apellido = docente.Apellido;
                Doc.Legajo = docente.Legajo;
                Doc.Cargo = dc.Cargo;
                Doc.ID = dc.ID;

                datosDocentes.Add(Doc);
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


        public void EliminarAsignacion()
        {
            try
            {
                int ID = (int)dgvDocCur.SelectedRows[0].Cells["ID"].Value;
                Docentes_Cursos DocCursoActual = DocCursoLog.GetOne(ID);
                DocCursoActual.State = BusinessEntity.States.Deleted;
                DocCursoLog.Save(DocCursoActual);
            }
            catch
            {
                MessageBox.Show("Error al eliminar la asignación del docente al curso, intente nuevamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TsbEliminar_Click(object sender, EventArgs e)
        {
            var mensaje = MessageBox.Show("¿Está seguro que desea eliminar la asignación del docente al curso?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (mensaje == DialogResult.Yes)
            {
                this.EliminarAsignacion();
                MessageBox.Show("La asignación se ha eliminado", "Eliminar docente");
                this.Listar();
            }
        }

        private void TsbNuevo_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            Docentes_CursosDesktop formCurDesk = new Docentes_CursosDesktop(CursoActual);
            formCurDesk.ShowDialog();
            this.Enabled = true;
            this.Focus();

            this.Listar();
        }
    }
}
