﻿using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class formEstadoAcademico : Form
    {
        public Persona PersonaActual { get; set; }

        public Alumno_InscripcionLogic AILog
        {
            get { return new Alumno_InscripcionLogic(); }
        }

        public class DatosInscripciones
        {
            public int ID { get; set; }
            public int AnioCursado { get; set; }
            public string DescMateria { get; set; }
            public string DescComision { get; set; }
            public string Condicion { get; set; }
            public string Nota { get; set; }
        }

        public formEstadoAcademico()
        {
            InitializeComponent();
            this.dgvEstadoAcademico.AutoGenerateColumns = false;
            this.dgvEstadoAcademico.Columns["Nota"].ValueType = typeof(string);
        }

        public formEstadoAcademico(Persona per) : this()
        {
            PersonaActual = per;
        }

        private void FormEstadoAcademico_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        public List<DatosInscripciones> ObtenerDatos()
        {
            List<DatosInscripciones> datosInscripciones = new List<DatosInscripciones>();

            try
            {
                List<Alumno_Inscripcion> inscripciones = AILog.GetMateriasInscripto(PersonaActual.ID);

                foreach (Alumno_Inscripcion ai in inscripciones)
                {
                    DatosInscripciones datosInscripcion = new DatosInscripciones();
                    datosInscripcion.ID = ai.ID;
                    datosInscripcion.Condicion = ai.Condicion;
                    if (ai.Nota == 0)
                    {
                        datosInscripcion.Nota = "-";
                    }
                    else
                    {
                        datosInscripcion.Nota = ai.Nota.ToString();
                    }

                    CursoLogic cl = new CursoLogic();
                    Curso curso = cl.GetOne(ai.IDCurso);
                    datosInscripcion.AnioCursado = curso.AnioCalendario;

                    MateriaLogic ml = new MateriaLogic();
                    Materia materia = ml.GetOne(curso.IDMateria);
                    datosInscripcion.DescMateria = materia.Descripcion;

                    ComisionLogic cml = new ComisionLogic();
                    Comision comision = cml.GetOne(curso.IDComision);
                    datosInscripcion.DescComision = comision.Descripcion;

                    datosInscripciones.Add(datosInscripcion);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            return datosInscripciones;
        }

        public void Listar()
        {
            this.dgvEstadoAcademico.DataSource = this.ObtenerDatos();
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
