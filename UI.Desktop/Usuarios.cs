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
            //try
            //{
                dgvUsuarios.Rows.Clear();
                UsuarioLogic ul = new UsuarioLogic();
                List<Persona> personas;
                List<Usuario> usuarios;
                (usuarios, personas) = ul.GetAll();

                foreach (var usr in personas.Zip(usuarios, (a, b) => new { a, b }))  //Linq combina las dos listas
                {
                    dgvUsuarios.Rows.Add(usr.b.ID, usr.a.Nombre, usr.a.Apellido, usr.b.NombreUsuario, usr.a.Email, usr.b.Habilitado);
                }
            //}
            //catch
            //{
            //    MessageBox.Show("Error al recuperar la lista de usuarios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    this.Close();
            //}
        }

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
        }
    }
}
