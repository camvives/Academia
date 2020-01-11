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

namespace UI.Desktop
{
    public partial class formMain : Form
    {
        public Usuario UsuarioActual { get; set; }
        public Persona PersonaActual { get; set; }

        public formMain()
        {
            InitializeComponent();

        }

        private void SalirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void UsuarioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormPersonaDesktop formPersona = new FormPersonaDesktop();
            formPersona.ShowDialog();
        }

        private void UsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUsuarios formUsuarios = new FormUsuarios();
            formUsuarios.ShowDialog();
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            using (formLogin login = new formLogin())
            {
                login.ShowDialog();
                (UsuarioActual, PersonaActual) = login.BuscarUsuario();
                if (PersonaActual.TipoPersona == Persona.TiposPersonas.Administrador)
                {
                    this.tsddbtnArchivoAdmin.Visible = true;
                    this.tsddbtnEditarAdmin.Visible = true;
                }
                else
                {
                    this.tsddBtnArchivoAlumno.Visible = true;
                }

                if (login.DialogResult != DialogResult.OK)
                {
                    this.Dispose();
                }

            }
               
        }

        private void EspecialidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EspecialidadDesktop especialidadDesktop = new EspecialidadDesktop();
            especialidadDesktop.ShowDialog();
        }

        private void EspecialidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formEspecialidades formEspecialidades = new formEspecialidades();
            formEspecialidades.ShowDialog();
        }

        private void PlanesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formPlanes formPlanes = new formPlanes();
            formPlanes.ShowDialog();
        }

        private void PlanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlanDesktop planDesktop = new PlanDesktop();
            planDesktop.ShowDialog();
        }

        private void MateriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formMaterias formMaterias = new formMaterias();
            formMaterias.ShowDialog();
        }

        private void MateriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MateriaDesktop materiaDesktop = new MateriaDesktop();
            materiaDesktop.ShowDialog();
        }

        private void DatosPersonalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPersonaDesktop formPersona = new FormPersonaDesktop(UsuarioActual, PersonaActual, ModoForm.Consulta);
            formPersona.Show();
        }

        private void DatosDeUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsuarioDesktop usuarioDesktop = new UsuarioDesktop(UsuarioActual, PersonaActual, ModoForm.ModificacionUsr);
            usuarioDesktop.Show();
        }

        private void SalirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CursosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formCursos formCursos = new formCursos();
            formCursos.ShowDialog();
        }

        private void ComisionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formComisiones formComisiones = new formComisiones();
            formComisiones.ShowDialog();
        }
    }
}
