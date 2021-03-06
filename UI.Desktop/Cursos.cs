﻿using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Util;


namespace UI.Desktop
{
    public partial class formCursos : Form
    {
        public class DatosCursos
        {
            public int ID { get; set; }
            public string DescMateria { get; set; }
            public string DescComision { get; set; }
            public int AnioCalendario { get; set; }
            public int Cupo { get; set; }
            public string DescEspecialidad { get; set; }
            public string DescPlan { get; set; }
        }

        public Persona PersonaActual { get; set; }

        public CursoLogic CursoLog
        {
            get { return new CursoLogic(); }
        }

        public formCursos()
        {
            InitializeComponent();
            this.dgvCursos.AutoGenerateColumns = false;
            this.dgvCursos.Columns["Inscribirse"].Visible = false;
        }

        public formCursos(Persona per) : this()
        {
            this.tspCurso.Visible = false;
            this.btnActualizar.Text = "Inscribirse";
            this.dgvCursos.Columns["id"].Visible = false;
            this.dgvCursos.Columns["AnioCalendario"].Visible = false;
            this.dgvCursos.Columns["Carrera"].Visible = false;
            this.dgvCursos.Columns["Inscribirse"].Visible = true;
            this.dgvCursos.Columns["Plan"].Visible = false;
            this.dgvCursos.Columns["Cupo"].HeaderText = "Cupo Disponible";

            PersonaActual = per;
        }


        #region METODOS
        public List<DatosCursos> ObtenerDatosUsr()
        {
            List<DatosCursos> datosCursos = new List<DatosCursos>();

            try
            {
                List<Curso> cursos = CursoLog.GetCursosUsuario(PersonaActual.IDPlan);

                foreach (Curso c in cursos)
                {
                    DatosCursos datosCurso = new DatosCursos();
                    Alumno_InscripcionLogic ail = new Alumno_InscripcionLogic();
                    int cupoActual = c.Cupo - ail.GetCantidadInscriptos(c.ID);

                    datosCurso.Cupo = cupoActual;
                    datosCurso.ID = c.ID;

                    MateriaLogic ml = new MateriaLogic();
                    Materia mat = ml.GetOne(c.IDMateria);
                    datosCurso.DescMateria = mat.Descripcion;

                    ComisionLogic cl = new ComisionLogic();
                    Comision com = cl.GetOne(c.IDComision);
                    datosCurso.DescComision = com.Descripcion;

                    datosCursos.Add(datosCurso);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

            return datosCursos;
        }

        public List<DatosCursos> ObtenerDatos()
        {
            List<DatosCursos> datosCursos = new List<DatosCursos>();
            try
            {
                List<Curso> cursos = CursoLog.GetAll();

                foreach (Curso c in cursos)
                {
                    DatosCursos datosCurso = new DatosCursos();
                    datosCurso.ID = c.ID;
                    datosCurso.AnioCalendario = c.AnioCalendario;
                    datosCurso.Cupo = c.Cupo;

                    MateriaLogic ml = new MateriaLogic();
                    Materia mat = ml.GetOne(c.IDMateria);
                    datosCurso.DescMateria = mat.Descripcion;

                    ComisionLogic cl = new ComisionLogic();
                    Comision com = cl.GetOne(c.IDComision);
                    datosCurso.DescComision = com.Descripcion;

                    PlanLogic pl = new PlanLogic();
                    Plan plan = pl.GetOne(com.IDPlan);
                    datosCurso.DescPlan = plan.Descripcion;
                    EspecialidadLogic el = new EspecialidadLogic();
                    Especialidad especialidad = el.GetOne(plan.IDEspecialidad);
                    datosCurso.DescEspecialidad = especialidad.Descripcion;

                    datosCursos.Add(datosCurso);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return datosCursos;
        }

        public void Listar()
        {
            try
            {
                if (PersonaActual == null)
                {
                    this.dgvCursos.DataSource = this.ObtenerDatos();
                }
                else
                {
                    this.dgvCursos.DataSource = this.ObtenerDatosUsr();
                    Alumno_InscripcionLogic alInscLog = new Alumno_InscripcionLogic();
                    List<Alumno_Inscripcion> inscripciones = alInscLog.GetMateriasInscripto(PersonaActual.ID);

                    List<int> idInscripciones = new List<int>();
                    foreach (Alumno_Inscripcion ai in inscripciones)
                    {
                        int idCurso = ai.IDCurso;
                        idInscripciones.Add(idCurso);
                    }

                    foreach (DataGridViewRow row in dgvCursos.Rows)
                    {
                        if (idInscripciones.Contains(int.Parse(row.Cells["ID"].Value.ToString())))
                        {
                            row.DefaultCellStyle.BackColor = Color.LightGray;
                            row.Cells["Inscribirse"].ReadOnly = true;
                            row.Cells["Inscribirse"].Value = 2;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void EliminarCurso()
        {
            try
            {
                int ID = (int)dgvCursos.SelectedRows[0].Cells["ID"].Value;
                Curso cursoActual = CursoLog.GetOne(ID);
                cursoActual.State = BusinessEntity.States.Deleted;
                CursoLog.Save(cursoActual);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Inscribir()
        {
            try
            {
                List<Alumno_Inscripcion> alumnosInsc = new List<Alumno_Inscripcion>();

                foreach (DataGridViewRow row in dgvCursos.Rows)
                {
                    if (row.Cells["Inscribirse"].Value != null)
                    {
                        if (int.Parse(row.Cells["Inscribirse"].Value.ToString()) == 1)
                        {
                            if (Validaciones.ValidarCupo(int.Parse(row.Cells["ID"].Value.ToString())))
                            {
                                Alumno_Inscripcion alInsc = new Alumno_Inscripcion();
                                alInsc.IDAlumno = PersonaActual.ID;
                                alInsc.IDCurso = int.Parse(row.Cells[0].Value.ToString());

                                alumnosInsc.Add(alInsc);

                            }
                            else
                            {
                                MessageBox.Show("No hay cupo en uno o más cursos seleccionados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }

                        }

                    }
                }

                foreach (Alumno_Inscripcion ai in alumnosInsc)
                {
                    Alumno_InscripcionLogic aiLog = new Alumno_InscripcionLogic();
                    aiLog.Save(ai);
                }

                var mensaje = MessageBox.Show("¿Desea imprimir certificado de inscripción?", "Finalizar Inscripción", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (mensaje == DialogResult.Yes)
                {
                    Reporte rep = new Reporte(PersonaActual.ID);
                    rep.Show();
                    this.Close();
                }
                else
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        #endregion

        #region ELEMENTOS DEL FORM

        private void Cursos_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void TsbEliminar_Click(object sender, EventArgs e)
        {
            var mensaje = MessageBox.Show("¿Está seguro que desea eliminar el curso?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (mensaje == DialogResult.Yes)
            {
                this.EliminarCurso();
                MessageBox.Show("El curso se ha eliminado", "Eliminar curso");
                this.Listar();
            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            if (PersonaActual == null)
            {
                this.Listar();
            }
            else
            {
                this.Inscribir();
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TsbNuevo_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            CursoDesktop formCurDesk = new CursoDesktop();
            formCurDesk.ShowDialog();
            this.Enabled = true;
            this.Focus();

            this.Listar();
        }

        private void TsbEditar_Click(object sender, EventArgs e)
        {
            try
            {
                int ID = (int)dgvCursos.SelectedRows[0].Cells["ID"].Value;
                Curso cursoActual = CursoLog.GetOne(ID);
                CursoDesktop formCurDesk = new CursoDesktop(cursoActual, ModoForm.Modificacion);
                formCurDesk.ShowDialog();
                this.Listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void TsbtnDocentes_Click(object sender, EventArgs e)
        {
            try
            {
                int ID = (int)dgvCursos.SelectedRows[0].Cells["ID"].Value;
                Curso cursoActual = CursoLog.GetOne(ID);
                formDocentes_Cursos dc = new formDocentes_Cursos(cursoActual);
                dc.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

    }
}
