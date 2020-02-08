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
    public partial class formPlanes : Form
    {
        public class DatosPlanes
        {
            public int ID { get; set; }
            public string Descripcion { get; set; }
            public string DescEspecialidad { get; set; }
        }

        public PlanLogic PlanLog
        {
            get { return new PlanLogic(); }
        }

        public formPlanes()
        {
            InitializeComponent();
            this.dgvPlanes.AutoGenerateColumns = false;
        }


        public void Listar()
        {
            this.dgvPlanes.DataSource = this.ObtenerDatos();
        }

        public List<DatosPlanes> ObtenerDatos()
        {
            List<DatosPlanes> datosPlanes = new List<DatosPlanes>();

            try
            {
                List<Plan> planes = PlanLog.GetAll();

                foreach (Plan p in planes)
                {
                    DatosPlanes datosPlan = new DatosPlanes();
                    datosPlan.ID = p.ID;
                    datosPlan.Descripcion = p.Descripcion;

                    EspecialidadLogic el = new EspecialidadLogic();
                    Especialidad especialidad = el.GetOne(p.IDEspecialidad);
                    datosPlan.DescEspecialidad = especialidad.Descripcion;

                    datosPlanes.Add(datosPlan);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return datosPlanes;
        }

        public void EliminarPlan()
        {
            try
            {
                int ID = (int)dgvPlanes.SelectedRows[0].Cells["ID"].Value;
                Plan planActual = PlanLog.GetOne(ID);
                planActual.State = BusinessEntity.States.Deleted;
                PlanLog.Save(planActual);
            }
            catch
            {
                MessageBox.Show("Error al eliminar el plan, intente nuevamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void FormPlanes_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void TsbNuevo_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            PlanDesktop formPlanDesk = new PlanDesktop();
            formPlanDesk.ShowDialog();
            this.Enabled = true;
            this.Focus();

            this.Listar();
        }

        private void TsbEditar_Click(object sender, EventArgs e)
        {
            try
            {
                int ID = (int)dgvPlanes.SelectedRows[0].Cells["ID"].Value;
                Plan planActual = PlanLog.GetOne(ID);
                PlanDesktop formPlanDesk = new PlanDesktop(planActual, ModoForm.Modificacion);
                formPlanDesk.ShowDialog();
                this.Listar();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TsbEliminar_Click(object sender, EventArgs e)
        {
            var mensaje = MessageBox.Show("¿Está seguro que desea eliminar el plan? \n Se eliminaran usuarios, materias, comisiones y cursos asociados al plan.", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (mensaje == DialogResult.Yes)
            {

               this.EliminarPlan();
               MessageBox.Show("El plan se ha eliminado", "Eliminar Plan");
               this.Listar();

            }
        }
    }
}
