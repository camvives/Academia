﻿using Business.Entities;
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
            this.Enabled = true;
        }

        private void TsbInformacion_Click(object sender, EventArgs e)
        {
            this.MostrarDatos();
        }

        public void MostrarDatos()
        {
            UsuarioLogic ul = new UsuarioLogic();
            Usuario usuario;
            Persona persona;
            int ID = (int)dgvUsuarios.SelectedRows[0].Cells["ID"].Value;
            (usuario, persona) = ul.GetOne(ID);

            string hab;
            if (usuario.Habilitado == true)
            {
                hab = "Sí";
            }
            else
            {
                hab = "No";
            }

            PlanLogic pl = new PlanLogic();
            Plan plan = pl.GetOne(persona.IDPlan);

            string plandesc;
            if(plan.Descripcion is null)
            {
                plandesc = "-";
            }
            else
            {
                plandesc = plan.Descripcion;
            }

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
                            "Legajo: " + persona.Legajo + "\n" +
                            "Tipo: " + persona.TipoPersona.ToString() + "\n" +
                            "Plan: "+ plandesc,
                            "Datos del Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
