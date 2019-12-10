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
using Util;

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


        #region METODOS
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
            this.Hide();
            usuarioDesktop.ShowDialog();
            if (usuarioDesktop.DialogResult == DialogResult.OK)
            {
                this.DialogResult = DialogResult.OK;
            }
 
        }

        public bool Validar()
        {

           if (cmbTipo.SelectedIndex == -1)
           {
                this.Notificar("Usuario no válido", "Debe seleccionar un tipo de usuario.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
           }
           else if (!this.CamposVacios())
           {
                this.Notificar("Campos vacíos", "Debe completar todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
           }
           else if (!(Validaciones.EmailValido(txtEmail.Text)))
           {
                this.Notificar("Email no válido", "Por favor, ingrese un formato de mail válido.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
           }


           return true;      
        }

        public bool CamposVacios()
        {
            if (txtApellido.Text == " ")
            {
                return false;
            }
            else if (txtNombre.Text == " ")
            {
                return false;
            }
            else if (txtNombre.Text == " ")
            {
                return false;
            }
            else if (txtDireccion.Text == " ")
            {
                return false;
            }
            else if (txtDireccionNum.Text == " ")
            {
                return false;
            }
            else if(txtEmail.Text == " ")
            {
                return false;
            }
            else if ((cmbTipo.SelectedItem.ToString() == "Docente" || cmbTipo.SelectedItem.ToString() == "Alumno") && txtLegajo.Text == " ")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region ELEMENTOS DEL FORM
        private void CmbCarrera_SelectedValueChanged(object sender, EventArgs e)
        {
            //Obtiene el objeto seleccionado del combobox
            Especialidad esp = (Especialidad)cmbCarrera.SelectedItem;

            PlanLogic plan = new PlanLogic();
            cmbPlan.DataSource = plan.GetPlanesEsp(esp.ID);
            cmbPlan.DisplayMember = "Descripcion";
            cmbPlan.ValueMember = "ID";
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

        private void TxtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Verifica que solo se puedan ingresar números en telefono
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TxtLegajo_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Verifica que solo se puedan ingresar números en el legajo
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TxtDireccionNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Verifica que solo se puedan ingresar números en la direccion
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TxtDireccion_Enter(object sender, EventArgs e)
        {
            if (txtDireccion.Text == "Calle")
            {
                txtDireccion.Text = "";
                txtDireccion.ForeColor = Color.Black;
            }
        }

        private void TxtDireccion_Leave(object sender, EventArgs e)
        {
            if (txtDireccion.Text == "")
            {
                txtDireccion.Text = "Calle";
                txtDireccion.ForeColor = Color.Silver;
            }
        }

        private void TxtDireccionNum_Enter(object sender, EventArgs e)
        {
            if (txtDireccionNum.Text == "Nro")
            {
                txtDireccionNum.Text = "";
                txtDireccionNum.ForeColor = Color.Black;
            }
        }

        private void TxtDireccionNum_Leave(object sender, EventArgs e)
        {
            if (txtDireccionNum.Text == "")
            {
                txtDireccionNum.Text = "Nro";
                txtDireccionNum.ForeColor = Color.Silver;
            }
        }

        private void CmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipo.SelectedItem.ToString() == "Administrador")
            {
                txtLegajo.Enabled = false;
                txtLegajo.Text = "";
                cmbCarrera.Enabled = false;
                cmbCarrera.Text = "";
                cmbPlan.Enabled = false;
                cmbPlan.Text = "";
            }
            else if (cmbTipo.SelectedItem.ToString() == "Docente")
            {
                cmbCarrera.Enabled = false;
                cmbPlan.Enabled = false;
                txtLegajo.Enabled = true;

                cmbCarrera.Text = "";
                cmbPlan.Text = "";
            }
            else
            {
                cmbCarrera.Enabled = true;
                cmbPlan.Enabled = true;
                txtLegajo.Enabled = true;
            }
        }
        #endregion
    }
}
