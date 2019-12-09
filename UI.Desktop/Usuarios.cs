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

        private void FormUsuarios_Load(object sender, EventArgs e)
        {
            this.Listar();
        }
    }
}
