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
    public partial class CursoDesktop : ApplicationForm
    {
        public Curso CursoActual { get; set; }
        public CursoDesktop()
        {
            InitializeComponent();
        }
        public CursoDesktop(Curso cur, ModoForm modo) : this()
        {
            this.Modo = modo;
            this.CursoActual = cur;

            try
            {
                this.MapearDeDatos();
            }
            catch
            {
                MessageBox.Show("Error al recuperar datos del curso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void CursoDesktop_Load(object sender, EventArgs e)
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
                CursoActual = new Curso();
                CursoActual.State = BusinessEntity.States.New;
            }
            else if (Modo == ModoForm.Modificacion)
            {
                CursoActual.State = BusinessEntity.States.Modified;
            }

            this.CursoActual.AnioCalendario = int.Parse(this.txtAnio.Text);
            this.CursoActual.Cupo = int.Parse(this.txtCupo.Text);
            Materia materia = (Materia)cmbMateria.SelectedItem;
            this.CursoActual.IDMateria = materia.ID;
            Comision comision = (Comision)cmbComision.SelectedItem;
            this.CursoActual.IDComision = comision.ID;

        }


        public override void MapearDeDatos()
        {
            
            this.CompletarCombobox();


            ComisionLogic cl = new ComisionLogic();
            Comision comision = cl.GetOne(CursoActual.IDComision);
            

            MateriaLogic ml = new MateriaLogic();
            Materia materia = ml.GetOne(CursoActual.IDMateria);


            PlanLogic pl = new PlanLogic();
            Plan plan = pl.GetOne(comision.IDPlan);
            EspecialidadLogic el = new EspecialidadLogic();
            Especialidad especialidad = el.GetOne(plan.IDEspecialidad);


            this.cmbCarrera.SelectedIndex = cmbCarrera.FindStringExact(especialidad.Descripcion);
            this.cmbPlan.SelectedIndex = cmbPlan.FindStringExact(plan.Descripcion);

            cmbPlan.Text = plan.Descripcion;
            this.cmbMateria.SelectedIndex = cmbMateria.FindStringExact(materia.Descripcion);
            this.cmbComision.SelectedIndex = cmbComision.FindStringExact(comision.Descripcion);


            this.btnGuardar.Text = "Guardar";
            this.txtAnio.Text = CursoActual.AnioCalendario.ToString();
            this.txtCupo.Text = CursoActual.Cupo.ToString();
           
        }

        public void GuardarCambios()
        {
            try
            {
                this.MapearADatos();
                CursoLogic curLog = new CursoLogic();
                curLog.Save(CursoActual);

                if (Modo == ModoForm.Alta)
                {
                    this.Notificar("Nuevo Curso", "El curso ha sido registrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (Modo == ModoForm.Modificacion)
                {
                    this.Notificar("Editar Curso", "Los cambios han sido registrados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
            }
            catch
            {
                this.Notificar("Error", "Error al registrar curso, intente nuevamente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        public bool Validar()
        {
            if (string.IsNullOrEmpty(txtAnio.Text))
            {
                this.Notificar("Campo vacío", "Debe completar el campo 'Año Calendario'", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (string.IsNullOrEmpty(txtCupo.Text))
            {
                this.Notificar("Campo vacío", "Debe completar el campo 'Cupo'", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (cmbComision.SelectedIndex == -1)
            {
                this.Notificar("Comisión no válida", "Debe seleccionar una comisión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (cmbMateria.SelectedIndex == -1)
            {
                this.Notificar("Materia no válida", "Debe seleccionar una materia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (this.Validar())
            {
                this.GuardarCambios();
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CmbCarrera_SelectedIndexChanged(object sender, EventArgs e)
        {
            Especialidad esp = (Especialidad)cmbCarrera.SelectedItem;

            PlanLogic pl = new PlanLogic();
            cmbPlan.DataSource = pl.GetPlanesEsp(esp.ID);
            cmbPlan.DisplayMember = "Descripcion";
            cmbPlan.ValueMember = "ID";
        }

        private void CmbPlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            Plan plan = (Plan)cmbPlan.SelectedItem;
            MateriaLogic materiaLogic = new MateriaLogic();
            this.cmbMateria.DataSource = materiaLogic.GetMateriasPlan(plan.ID);
            this.cmbMateria.DisplayMember = "Descripcion";
            this.cmbMateria.ValueMember = "ID";

            ComisionLogic comisionLog = new ComisionLogic();
            cmbComision.DataSource = comisionLog.GetComisionesMat(plan.ID);
            cmbComision.DisplayMember = "Descripcion";
            cmbComision.ValueMember = "ID";
        }

        private void TxtAnio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TxtCupo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
