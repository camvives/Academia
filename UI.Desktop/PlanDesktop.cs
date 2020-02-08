using Business.Entities;
using Business.Logic;
using System;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class PlanDesktop : ApplicationForm
    {
        public Plan PlanActual { get; set; }

        public PlanDesktop()
        {
            InitializeComponent();
        }

        public PlanDesktop(Plan plan, ModoForm modo) : this()
        {
            this.Modo = modo;
            this.PlanActual = plan;

            try
            {
                this.MapearDeDatos();
                this.Text = "Editar Plan";
            }
            catch
            {
                MessageBox.Show("Error al recuperar datos del plan", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        #region METODOS
        public void CompletarCombobox()
        {
            try
            {
                EspecialidadLogic especialidad = new EspecialidadLogic();

                cmbCarrera.DataSource = especialidad.GetAll();
                cmbCarrera.DisplayMember = "Descripcion";
                cmbCarrera.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override void MapearADatos()
        {
            if (Modo == ModoForm.Alta)
            {
                PlanActual = new Plan();
                PlanActual.State = BusinessEntity.States.New;
            }
            else if (Modo == ModoForm.Modificacion)
            {
                PlanActual.State = BusinessEntity.States.Modified;
            }

            this.PlanActual.Descripcion = this.txtDescripcion.Text;
            Especialidad esp = (Especialidad)cmbCarrera.SelectedItem;
            this.PlanActual.IDEspecialidad = esp.ID;
        }

        public override void MapearDeDatos()
        {
            try
            {
                EspecialidadLogic el = new EspecialidadLogic();
                Especialidad especialidad = el.GetOne(PlanActual.IDEspecialidad);


                this.btnAgregar.Text = "Guardar";
                this.txtDescripcion.Text = PlanActual.Descripcion;
                this.CompletarCombobox();
                this.cmbCarrera.SelectedIndex = cmbCarrera.FindStringExact(especialidad.Descripcion);
            }
            catch (Exception ex)
            {
                this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void GuardarCambios()
        {
            try
            {
                this.MapearADatos();
                PlanLogic planLog = new PlanLogic();
                planLog.Save(PlanActual);

                if (Modo == ModoForm.Alta)
                {
                    this.Notificar("Nuevo Plan", "El plan ha sido registrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (Modo == ModoForm.Modificacion)
                {
                    this.Notificar("Editar Plan", "Los cambios han sido registrados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception e)
            {
                this.Notificar("Error", e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public bool Validar()
        {
            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                this.Notificar("Campo vacío", "Debe completar el campo 'Descripción'", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (cmbCarrera.SelectedIndex == -1)
            {
                this.Notificar("Especialidad no válida", "Debe seleccionar una especialidad.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region ELEMENTOS DEL FORM
        private void PlanDesktop_Load(object sender, EventArgs e)
        {
            if (Modo == ModoForm.Alta)
            {
                this.CompletarCombobox();
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (this.Validar())
            {
                this.GuardarCambios();
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
