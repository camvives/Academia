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
    public partial class ComisionDesktop : ApplicationForm
    {
        Comision ComisionActual { get; set; }
        public ComisionDesktop()
        {
            InitializeComponent();
        }

        

        public ComisionDesktop(Comision com, ModoForm modo) : this()
        {
            this.Modo = modo;
            this.ComisionActual = com;

            if (Modo == ModoForm.Modificacion)
            {
                this.Text = "Editar Especialidad";
            }

            try
            {
                this.MapearDeDatos();
            }
            catch
            {
                MessageBox.Show("Error al recuperar datos de la comisión", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

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

        private void ComisionDesktop_Load(object sender, EventArgs e)
        {
            if (Modo == ModoForm.Alta)
            {
                this.CompletarCombobox();
            }
        }

        private void CmbCarrera_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Especialidad esp = (Especialidad)cmbCarrera.SelectedItem;

                PlanLogic plan = new PlanLogic();
                cmbPlan.DataSource = plan.GetPlanesEsp(esp.ID);
                cmbPlan.DisplayMember = "Descripcion";
                cmbPlan.ValueMember = "ID";
            }
            catch(Exception ex)
            {
                this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override void MapearADatos()
        {
            if (Modo == ModoForm.Alta)
            {
                ComisionActual = new Comision();
                ComisionActual.State = BusinessEntity.States.New;
            }
            else if (Modo == ModoForm.Modificacion)
            {
                ComisionActual.State = BusinessEntity.States.Modified;
            }

            this.ComisionActual.Descripcion = this.txtDescripcion.Text;
            this.ComisionActual.AnioEspecialidad = int.Parse(this.cmbAnio.SelectedItem.ToString());
            Plan plan = (Plan)cmbPlan.SelectedItem;
            this.ComisionActual.IDPlan = plan.ID;  
        }

        public override void MapearDeDatos()
        {
            try
            {
                PlanLogic pl = new PlanLogic();
                Plan plan = pl.GetOne(ComisionActual.IDPlan);
                EspecialidadLogic el = new EspecialidadLogic();
                Especialidad especialidad = el.GetOne(plan.IDEspecialidad);


                this.btnAgregar.Text = "Guardar";
                this.txtDescripcion.Text = ComisionActual.Descripcion;
                this.CompletarCombobox();
                this.cmbAnio.SelectedIndex = cmbAnio.FindStringExact(ComisionActual.AnioEspecialidad.ToString());
                this.cmbPlan.SelectedIndex = cmbPlan.FindStringExact(plan.Descripcion);
                this.cmbCarrera.SelectedIndex = cmbCarrera.FindStringExact(especialidad.Descripcion);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void GuardarCambios()
        {
            try
            {
                this.MapearADatos();
                ComisionLogic comLog = new ComisionLogic();
                comLog.Save(ComisionActual);

                if (Modo == ModoForm.Alta)
                {
                    this.Notificar("Nueva Comisión", "La comisión ha sido registrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (Modo == ModoForm.Modificacion)
                {
                    this.Notificar("Editar Comisión", "Los cambios han sido registrados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
            }
            catch
            {
                this.Notificar("Error", "Error al registrar comisión, intente nuevamente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool Validar()
        {
            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                this.Notificar("Campo vacío", "Debe completar el campo 'Descripción'", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if(cmbAnio.SelectedIndex == -1)
            {
                this.Notificar("Año no válido", "Debe seleccionar un año de especialidad.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
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
    }
}
