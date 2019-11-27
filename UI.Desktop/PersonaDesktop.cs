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
    public partial class FormPersonaDesktop : ApplicationForm
    {
        public Persona personaAct = new Persona();
        public FormPersonaDesktop()
        {
            InitializeComponent();
        }

        private void FormPersonaDesktop_Load(object sender, EventArgs e)
        {
            EspecialidadLogic especialidad = new EspecialidadLogic();

            //Completa el combobox de carrera con la descripcion de la tabla especialidades
            cmbCarrera.DataSource = especialidad.GetAll();
            cmbCarrera.DisplayMember = "Descripcion";
            cmbCarrera.ValueMember = "ID";
        }

        private void CmbCarrera_SelectedValueChanged(object sender, EventArgs e)
        {
            //Obtiene el objeto seleccionado del combobox
            Especialidad esp = (Especialidad)cmbCarrera.SelectedItem;

            PlanLogic plan = new PlanLogic();
            cmbPlan.DataSource = plan.GetPlanesEsp(esp.ID);
            cmbPlan.DisplayMember = "Descripcion";
            cmbPlan.ValueMember = "ID";
        }
    }
}
