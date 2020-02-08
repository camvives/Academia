using Business.Entities;
using Business.Logic;
using System;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class EspecialidadDesktop : ApplicationForm
    {
        public Especialidad EspActual { get; set; }

        public EspecialidadDesktop()
        {
            InitializeComponent();
        }

        public EspecialidadDesktop(Especialidad esp, ModoForm modo) : this()
        {
            this.Modo = modo;
            this.EspActual = esp;
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
                MessageBox.Show("Error al recuperar datos de la especialidad", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }


        public override void MapearADatos()
        {
            if (Modo == ModoForm.Alta)
            {
                EspActual = new Especialidad();
                EspActual.State = BusinessEntity.States.New;
            }
            else if (Modo == ModoForm.Modificacion)
            {
                EspActual.State = BusinessEntity.States.Modified;
            }

            this.EspActual.Descripcion = this.txtDesc.Text;
        }

        public override void MapearDeDatos()
        {
            this.txtDesc.Text = EspActual.Descripcion;

            if (this.Modo == ModoForm.Modificacion)
            {
                this.btnAgregar.Text = "Guardar";
            }
        }

        public void GuardarCambios()
        {
            try
            {
                this.MapearADatos();
                EspecialidadLogic espLog = new EspecialidadLogic();
                espLog.Save(EspActual);

                if (Modo == ModoForm.Alta)
                {
                    this.Notificar("Nueva Especialidad", "La especialidad ha sido registrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (Modo == ModoForm.Modificacion)
                {
                    this.Notificar("Editar Especialidad", "Los cambios han sido registrados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool Validar()
        {
            if (string.IsNullOrEmpty(txtDesc.Text))
            {
                this.Notificar("Campo vacío", "Debe completar el campo 'Descripción'", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
