﻿using Business.Entities;
using Business.Logic;
using System;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class InscriptosDesktop : Form
    {
        public formInscriptos.DatosAlumnos AlumnoActual { get; set; }

        public Alumno_Inscripcion Alumno { get; set; }

        public InscriptosDesktop()
        {
            InitializeComponent();
        }

        public InscriptosDesktop(formInscriptos.DatosAlumnos alumno) : this()
        {
            AlumnoActual = alumno;
            this.Text = AlumnoActual.Nombre + " " + AlumnoActual.Apellido + " - " + AlumnoActual.Legajo.ToString();
        }

        public void MapearADatos()
        {
            Alumno = new Alumno_Inscripcion();
            Alumno.Condicion = cmbCondicion.Text;
            if (cmbNota.Text == " ")
            {
                Alumno.Nota = 0;
            }
            else
            {
                Alumno.Nota = int.Parse(cmbNota.Text);
            }
            Alumno.State = BusinessEntity.States.Modified;
            Alumno.ID = AlumnoActual.ID_Inscripcion;
            Alumno.IDAlumno = AlumnoActual.ID_persona;
            Alumno.IDCurso = AlumnoActual.ID_Curso;
        }

        public bool Validar()
        {

            if (cmbCondicion.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar una Condición", "Condición no válida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (cmbNota.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar una nota", "Nota no válida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }


        private void CmbDocente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCondicion.SelectedIndex == 2)
            {
                this.cmbNota.Enabled = true;
            }
            else
            {
                this.cmbNota.Text = " ";
                this.cmbNota.Enabled = false;
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validar())
                {
                    this.MapearADatos();
                    Alumno_InscripcionLogic al = new Alumno_InscripcionLogic();
                    al.Save(Alumno);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
