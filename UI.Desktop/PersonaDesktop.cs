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
        public Persona PersonaActual { get; set; }

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

        public override void MapearADatos()
        {
            if (this.Modo == ModoForm.Alta)
            {
                PersonaActual = new Persona();

                this.PersonaActual.Nombre = this.txtNombre.Text;
                this.PersonaActual.Apellido = this.txtApellido.Text;
                this.PersonaActual.Email = this.txtEmail.Text;
                this.PersonaActual.Direccion = this.txtDireccion.Text + ' ' + this.txtDireccionNum.Text;
                this.PersonaActual.Telefono = this.txtTelefono.Text;
                this.PersonaActual.FechaNacimiento = dtpNacimiento.Value;

                //DE ACUERDO AL TIPO DE USUARIO
                if (cmbTipo.SelectedItem.ToString() == "Alumno")
                {
                    this.PersonaActual.TipoPersona = Persona.TiposPersonas.Alumno;
                    this.PersonaActual.Legajo = int.Parse(this.txtLegajo.Text);

                    //Obtiene el objeto seleccionado del combobox Planes
                    Plan plan = (Plan)cmbPlan.SelectedItem; 
                    PlanLogic planLogic = new PlanLogic();
                    this.PersonaActual.IDPlan = planLogic.GetOne(plan.ID).ID;
                }

                else if (cmbTipo.SelectedItem.ToString() == "Administrador")
                {
                    this.PersonaActual.TipoPersona = Persona.TiposPersonas.Admin;
                    this.PersonaActual.Legajo = 0;
                    this.PersonaActual.IDPlan = 0;
                }

                else if (cmbTipo.SelectedItem.ToString() == "Docente")
                {
                    this.PersonaActual.TipoPersona = Persona.TiposPersonas.Docente;
                    this.PersonaActual.Legajo = int.Parse(this.txtLegajo.Text);
                    this.PersonaActual.IDPlan = 0;
                }

                this.PersonaActual.State = BusinessEntity.States.New;
            }

        }

        public void GuardarCambios()
        {
            this.MapearADatos();

            UsuarioDesktop usuarioDesktop = new UsuarioDesktop(PersonaActual);
            usuarioDesktop.Show();
            
  
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            this.GuardarCambios();
        }
    }
}
