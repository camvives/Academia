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
    public partial class formMaterias : Form
    {
        public formMaterias()
        {
            InitializeComponent();
            this.dgvMaterias.AutoGenerateColumns = false;
        }

        public class DatosMaterias
        {
            public int ID { get; set; }
            public string Descripcion { get; set; }
            public int HorasSemanales { get; set; }
            public int HorasTotales { get; set; }
            public string DescPlan { get; set; }
            public string DescEspecialidad { get; set; }
        }
        public MateriaLogic MatLog
        {
            get { return new MateriaLogic(); }
        }

        public List<DatosMaterias> ObtenerDatos()
        {
            List<DatosMaterias> datosMaterias = new List<DatosMaterias>();
            try
            {
                List<Materia> materias = MatLog.GetAll();

                foreach (Materia m in materias)
                {
                    DatosMaterias datosMateria = new DatosMaterias();
                    datosMateria.ID = m.ID;
                    datosMateria.Descripcion = m.Descripcion;
                    datosMateria.HorasSemanales = m.HorasSemanales;
                    datosMateria.HorasTotales = m.HorasTotales;

                    PlanLogic pl = new PlanLogic();
                    Plan plan = pl.GetOne(m.IDPlan);
                    datosMateria.DescPlan = plan.Descripcion;

                    EspecialidadLogic el = new EspecialidadLogic();
                    Especialidad especialidad = el.GetOne(plan.IDEspecialidad);
                    datosMateria.DescEspecialidad = especialidad.Descripcion;

                    datosMaterias.Add(datosMateria);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return datosMaterias;
        }

        public void Listar()
        {
            this.dgvMaterias.DataSource = this.ObtenerDatos();
        }

        private void FormMaterias_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        public void EliminarMateria()
        {
            try
            {
                int ID = (int)dgvMaterias.SelectedRows[0].Cells["ID"].Value;
                Materia MatActual = MatLog.GetOne(ID);
                MatActual.State = BusinessEntity.States.Deleted;
                MatLog.Save(MatActual);
            }
            catch
            {
                MessageBox.Show("Error al eliminar la materia, intente nuevamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TsbEliminar_Click(object sender, EventArgs e)
        {
            var mensaje = MessageBox.Show("¿Está seguro que desea eliminar la materia?\nSe eliminarán todos los cursos asociados", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (mensaje == DialogResult.Yes)
            {
                this.EliminarMateria();
                MessageBox.Show("La materia se ha eliminado", "Eliminar materia");
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
            MateriaDesktop formMatDesk = new MateriaDesktop();
            formMatDesk.ShowDialog();
            this.Enabled = true;
            this.Focus();

            this.Listar();
        }

        private void TsbEditar_Click(object sender, EventArgs e)
        {
            int ID = (int)dgvMaterias.SelectedRows[0].Cells["ID"].Value;
            Materia materiaActual = MatLog.GetOne(ID);
            MateriaDesktop formMatDesk = new MateriaDesktop(materiaActual, ModoForm.Modificacion);
            formMatDesk.ShowDialog();
            this.Listar();
        }
    }
}
