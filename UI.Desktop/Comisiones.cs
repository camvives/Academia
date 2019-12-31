using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;

namespace UI.Desktop
{
    public partial class formComisiones : Form
    {
        public class DatosComisiones
        {
            public int ID { get; set; }
            public string Descripcion { get; set; }
            public int Anio { get; set; }
            public string DescPlan { get; set; }
            public string DescEspecialidad { get; set; }
        }

        

        public ComisionLogic ComLog
        {
            get { return new ComisionLogic(); }
        }

        public formComisiones()
        {
            InitializeComponent();
            dgvComisiones.AutoGenerateColumns = false;
        }

        private void FormComisiones_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        public void Listar()
        {
            dgvComisiones.DataSource = this.ObtenerDatos();
         
        }

        public List<DatosComisiones> ObtenerDatos()
        {
            List<DatosComisiones> datosComisiones = new List<DatosComisiones>();
            List<Comision> comisiones = ComLog.GetAll();

            foreach (Comision c in comisiones)
            {
                DatosComisiones datosComision = new DatosComisiones();
                datosComision.ID = c.ID;
                datosComision.Descripcion = c.Descripcion;
                datosComision.Anio = c.AnioEspecialidad;

                PlanLogic pl = new PlanLogic();
                Plan plan = pl.GetOne(c.IDPlan);
                datosComision.DescPlan = plan.Descripcion;

                EspecialidadLogic el = new EspecialidadLogic();
                Especialidad especialidad = el.GetOne(plan.IDEspecialidad);
                datosComision.DescEspecialidad = especialidad.Descripcion;

                datosComisiones.Add(datosComision);
            }

            return datosComisiones;
        }

        public void EliminarComision()
        {
            try
            {
                int ID = (int)dgvComisiones.SelectedRows[0].Cells["ID"].Value;
                Comision ComActual = ComLog.GetOne(ID);
                ComActual.State = BusinessEntity.States.Deleted;
                ComLog.Save(ComActual);
            }
            catch
            {
                MessageBox.Show("Error al eliminar la comisión, intente nuevamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TsbEliminar_Click(object sender, EventArgs e)
        {
            var mensaje = MessageBox.Show("¿Está seguro que desea eliminar la comisión?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (mensaje == DialogResult.Yes)
            {
                this.EliminarComision();
                MessageBox.Show("La comisión se ha eliminado", "Eliminar Comisión");
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
    }
}
