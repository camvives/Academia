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
    public partial class formCursos : Form
    {
  

        public formCursos()
        {
            InitializeComponent();
            this.dgvCursos.AutoGenerateColumns = false;
        }

        public class DatosCursos
        {
            public int ID { get; set; }
            public string DescMateria { get; set; }
            public string DescComision { get; set; }
            public int AnioCalendario { get; set; }
            public int  Cupo { get; set; }
        }

        public CursoLogic CursoLog
        {
            get { return new CursoLogic(); }
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

                datosCursos.Add(datosCurso);
            }

            return datosCursos;
        }

        private void Cursos_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        public void Listar()
        {
            this.dgvCursos.DataSource = this.ObtenerDatos();
        }


        public void EliminarCurso()
        {
            try
            {
                int ID = (int)dgvCursos.SelectedRows[0].Cells["ID"].Value;
                Curso cursoActual = CursoLog.GetOne(ID);
                cursoActual.State = BusinessEntity.States.Deleted;
                CursoLog.Save(cursoActual);
            }
            catch
            {
                MessageBox.Show("Error al eliminar el curso, intente nuevamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TsbEliminar_Click(object sender, EventArgs e)
        {
            var mensaje = MessageBox.Show("¿Está seguro que desea eliminar el curso?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (mensaje == DialogResult.Yes)
            {
                this.EliminarCurso();
                MessageBox.Show("El curso se ha eliminado", "Eliminar curso");
                this.Listar();
            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TsbNuevo_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            CursoDesktop formCurDesk = new CursoDesktop();
            formCurDesk.ShowDialog();
            this.Enabled = true;
            this.Focus();

            this.Listar();
        }

        private void TsbEditar_Click(object sender, EventArgs e)
        {
            int ID = (int)dgvCursos.SelectedRows[0].Cells["ID"].Value;
            Curso cursoActual = CursoLog.GetOne(ID);
            CursoDesktop formCurDesk = new CursoDesktop(cursoActual, ModoForm.Modificacion);
            formCurDesk.ShowDialog();
            this.Listar();
        }
    }
}
