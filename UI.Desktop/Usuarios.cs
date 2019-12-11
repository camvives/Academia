using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class FormUsuarios : Form
    {
        public FormUsuarios()
        {
            InitializeComponent();
            this.dgvUsuarios.AutoGenerateColumns = false;
        }

        public void Listar()
        {
            try
            {
                dgvUsuarios.Rows.Clear();
                UsuarioLogic ul = new UsuarioLogic();
                List<Persona> personas;
                List<Usuario> usuarios;
                (usuarios, personas) = ul.GetAll();

                foreach (var usr in personas.Zip(usuarios, (a, b) => new { a, b }))  //Linq combina las dos listas
                {
                    dgvUsuarios.Rows.Add(usr.b.ID, usr.a.Nombre, usr.a.Apellido, usr.b.NombreUsuario, usr.a.Email, usr.b.Habilitado);
                }
            }
            catch
            {
                MessageBox.Show("Error al recuperar la lista de usuarios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        public void MostrarDatos()
        {
            UsuarioLogic ul = new UsuarioLogic();
            Usuario usuario;
            Persona persona;
            int ID = (int)dgvUsuarios.SelectedRows[0].Cells["ID"].Value;
            (usuario, persona) = ul.GetOne(ID);

            PlanLogic pl = new PlanLogic();
            Plan plan = pl.GetOne(persona.IDPlan);

            EspecialidadLogic el = new EspecialidadLogic();
            Especialidad especialidad = el.GetOne(plan.IDEspecialidad);

            #region Validaciones
            string hab;
            if (usuario.Habilitado == true)
            {
                hab = "Sí";
            }
            else
            {
                hab = "No";
            }

            string plandesc;
            if (plan.Descripcion is null)
            {
                plandesc = "-";
            }
            else
            {
                plandesc = plan.Descripcion;
            }

            string espdesc;
            if (especialidad.Descripcion is null)
            {
                espdesc = "-";
            }
            else
            {
                espdesc = especialidad.Descripcion;
            }

            string leg;
            if (persona.Legajo == 0)
            {
                leg = "-";
            }
            else
            {
                leg = persona.Legajo.ToString();
            }
            #endregion

            MessageBox.Show("ID: " + usuario.ID + "\n" +
                            "Nombre de Usuario: " + usuario.NombreUsuario + "\n" +
                            "Habilitado: " + hab + "\n" +
                            "\n" +
                            "Nombre: " + persona.Nombre + "\n" +
                            "Apellido: " + persona.Apellido + "\n" +
                            "Dirección: " + persona.Direccion + "\n" +
                            "Email: " + persona.Email + "\n" +
                            "Teléfono: " + persona.Telefono + "\n" +
                            "Fecha de Nacimiento: " + persona.FechaNacimiento.ToString("dd/MM/yyyy") + "\n" +
                            "Tipo: " + persona.TipoPersona.ToString() + "\n" +
                            "Legajo: " + leg + "\n" +
                            "Carrera: " + espdesc + "\n" +
                            "Plan: " + plandesc,
                            "Datos del Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void EliminarUsuario()
        {
            try
            {
                UsuarioLogic ul = new UsuarioLogic();
                Usuario usuario;
                Persona persona;
                int ID = (int)dgvUsuarios.SelectedRows[0].Cells["ID"].Value;
                (usuario, persona) = ul.GetOne(ID);

                usuario.State = BusinessEntity.States.Deleted;
                ul.Save(usuario, persona);
            }
            catch
            {
                MessageBox.Show("Error al eliminar usuario, intente nuevamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        #region ELEMENTOS DEL FORM

        private void FormUsuarios_Load(object sender, EventArgs e)
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
            FormPersonaDesktop persona = new FormPersonaDesktop();
            persona.ShowDialog();
            if (persona.DialogResult == DialogResult.OK || persona.DialogResult == DialogResult.Cancel)
            {
                this.Enabled = true;
                this.Focus();
            }
           
            this.Listar();
        }

        private void TsbInformacion_Click(object sender, EventArgs e)
        {
            this.MostrarDatos();
        }

        private void TsbEliminar_Click(object sender, EventArgs e)
        {
            var mensaje = MessageBox.Show("¿Está seguro que desea eliminar al Usuario?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (mensaje == DialogResult.Yes)
            {
                this.EliminarUsuario();
                MessageBox.Show("El usuario se ha eliminado", "Eliminar Usuario");
                this.Listar();
            }
        }

        private void TsbEditar_Click(object sender, EventArgs e)
        {
            int ID = (int)dgvUsuarios.SelectedRows[0].Cells["ID"].Value;
            FormPersonaDesktop formPersona = new FormPersonaDesktop(ID, ModoForm.Modificacion);
            formPersona.ShowDialog();
            this.Listar();
        }
        #endregion


    }
}
