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

        private void FormMain_Shown(object sender, EventArgs e)
        {
            using (formLogin login = new formLogin())
            {
                login.ShowDialog();

                if (login.DialogResult != DialogResult.OK)
                {
                    this.Dispose();
                }
                else
                {
                    (UsuarioActual, PersonaActual) = login.BuscarUsuario();
                    if (PersonaActual.TipoPersona == Persona.TiposPersonas.Administrador)
                    {
                        this.tsddbtnArchivoAdmin.Visible = true;
                        this.tsddbtnEditarAdmin.Visible = true;
                    }
                    else if (PersonaActual.TipoPersona == Persona.TiposPersonas.Alumno)
                    {
                        this.tsddBtnArchivoAlumno.Visible = true;
                        this.tsbtnInscribirse.Visible = true;
                        this.tsbtnEstadoAcademico.Visible = true;
                        this.tss1.Visible = true;
                        this.tss2.Visible = true;
                    }
                    else if (PersonaActual.TipoPersona == Persona.TiposPersonas.Docente)
                    {
                        this.tsddBtnArchivoAlumno.Visible = true;
                        this.tsbtnConsultaCursos.Visible = true;
                        this.tss3.Visible = true;
                        this.imprimirCertificadoDeInscripciónToolStripMenuItem.Visible = false;
                    }
                }

            }

        }

        public void IrALogin()
        {
            this.tsMenu.Visible = false;
            formLogin login = new formLogin();
            login.ShowDialog();
            if (login.DialogResult != DialogResult.OK)
            {
                this.Close();
            }
        }

        #region MENU

        private void SalirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.IrALogin();
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
            this.IrALogin();
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

        private void TsbtnInscribirse_Click(object sender, EventArgs e)
        {
            formCursos formCursos = new formCursos(PersonaActual);
            formCursos.ShowDialog();
        }

        private void TsbtnEstadoAcademico_Click(object sender, EventArgs e)
        {
            formEstadoAcademico formEstado = new formEstadoAcademico(PersonaActual);
            formEstado.ShowDialog();
        }

        private void TsbtnConsultaCursos_Click(object sender, EventArgs e)
        {
            formInscriptos formInscriptos = new formInscriptos(PersonaActual);
            formInscriptos.ShowDialog();
        }

        private void CursoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CursoDesktop curdesk = new CursoDesktop();
            curdesk.ShowDialog();
        }

        private void ComisiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ComisionDesktop comdesk = new ComisionDesktop();
            comdesk.ShowDialog();
        }

        private void imprimirCertificadoDeInscripciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reporte reporte = new Reporte(PersonaActual.ID);
            reporte.ShowDialog();
        }

        #endregion
    }


}
