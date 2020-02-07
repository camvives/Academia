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
    public partial class MateriaDesktop : ApplicationForm
    {
        Materia MateriaActual { get; set; }
        public MateriaDesktop()
        {
            InitializeComponent();
        }
        public MateriaDesktop(Materia mat, ModoForm modo) : this()
        {
            this.Modo = modo;
            this.MateriaActual = mat;

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
            EspecialidadLogic especialidad = new EspecialidadLogic();

            cmbCarrera.DataSource = especialidad.GetAll();
            cmbCarrera.DisplayMember = "Descripcion";
            cmbCarrera.ValueMember = "ID";
        }

        private void CmbCarrera_SelectedIndexChanged(object sender, EventArgs e)
        {
            Especialidad esp = (Especialidad)cmbCarrera.SelectedItem;

            PlanLogic plan = new PlanLogic();
            cmbPlan.DataSource = plan.GetPlanesEsp(esp.ID);
            cmbPlan.DisplayMember = "Descripcion";
            cmbPlan.ValueMember = "ID";
        }

        private void MateriaDesktop_Load(object sender, EventArgs e)
        {
            if (Modo == ModoForm.Alta)
            {
                this.CompletarCombobox();
            }
        }

        public override void MapearADatos()
        {
            if (Modo == ModoForm.Alta)
            {
                MateriaActual = new Materia();
                MateriaActual.State = BusinessEntity.States.New;
            }
            else if (Modo == ModoForm.Modificacion)
            {
                MateriaActual.State = BusinessEntity.States.Modified;
            }

            this.MateriaActual.Descripcion = this.txtDescripcion.Text;
            this.MateriaActual.HorasSemanales = int.Parse(txtHsSem.Text);
            this.MateriaActual.HorasTotales = int.Parse(txtHsTot.Text);
            Plan plan = (Plan)cmbPlan.SelectedItem;
            this.MateriaActual.IDPlan = plan.ID;
        }

        public override void MapearDeDatos()
        {
            PlanLogic pl = new PlanLogic();
            Plan plan = pl.GetOne(MateriaActual.IDPlan);
            EspecialidadLogic el = new EspecialidadLogic();
            Especialidad especialidad = el.GetOne(plan.IDEspecialidad);


            this.btnAgregar.Text = "Guardar";
            this.txtDescripcion.Text = MateriaActual.Descripcion;
            this.txtHsSem.Text = MateriaActual.HorasSemanales.ToString();
            this.txtHsTot.Text = MateriaActual.HorasTotales.ToString();
            this.CompletarCombobox();
            this.cmbPlan.SelectedIndex = cmbPlan.FindStringExact(plan.Descripcion);
            this.cmbCarrera.SelectedIndex = cmbCarrera.FindStringExact(especialidad.Descripcion);
        }

        public void GuardarCambios()
        {
            try
            {
                this.MapearADatos();
                MateriaLogic matLog = new MateriaLogic();
                matLog.Save(MateriaActual);

                if (Modo == ModoForm.Alta)
                {
                    this.Notificar("Nueva Materia", "La materia ha sido registrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (Modo == ModoForm.Modificacion)
                {
                    this.Notificar("Editar Materia", "Los cambios han sido registrados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
            }
            catch
            {
                this.Notificar("Error", "Error al registrar materia, intente nuevamente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool Validar()
        {
            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                this.Notificar("Campo vacío", "Debe completar el campo 'Descripción'", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (cmbPlan.SelectedIndex == -1)
            {
                this.Notificar("Plan no válido", "Debe seleccionar un plan de estudio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (Validar())
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
