using Business.Entities;
using Business.Logic;
using System;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class formEspecialidades : Form
    {
        public EspecialidadLogic EspLog
        {
            get { return new EspecialidadLogic(); }
        }

        public Especialidad EspActual { get; set; }

        public formEspecialidades()
        {
            InitializeComponent();
            dgvEspecialidades.AutoGenerateColumns = false;
        }

        public void Listar()
        {
            try
            {
                dgvEspecialidades.DataSource = EspLog.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

        }

        public void EliminarEspecialidad()
        {
            try
            {
                int ID = (int)dgvEspecialidades.SelectedRows[0].Cells["ID"].Value;
                EspActual = EspLog.GetOne(ID);
                EspActual.State = BusinessEntity.States.Deleted;
                EspLog.Save(EspActual);
            }
            catch
            {
                MessageBox.Show("Error al eliminar la especialidad, intente nuevamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void FormEspecialidades_Load(object sender, EventArgs e)
        {
            this.Listar();
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
            EspecialidadDesktop formEspDesk = new EspecialidadDesktop();
            formEspDesk.ShowDialog();
            this.Enabled = true;
            this.Focus();

            this.Listar();
        }

        private void TsbEliminar_Click(object sender, EventArgs e)
        {
            var mensaje = MessageBox.Show("¿Está seguro que desea eliminar la especialidad?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (mensaje == DialogResult.Yes)
            {
                this.EliminarEspecialidad();
                MessageBox.Show("La especialidad se ha eliminado", "Eliminar Especialidad");
                this.Listar();
            }
        }

        private void TsbEditar_Click(object sender, EventArgs e)
        {
            try
            {
                int ID = (int)dgvEspecialidades.SelectedRows[0].Cells["ID"].Value;
                EspActual = EspLog.GetOne(ID);
                EspecialidadDesktop formEspDesk = new EspecialidadDesktop(EspActual, ModoForm.Modificacion);
                formEspDesk.ShowDialog();
                this.Listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
