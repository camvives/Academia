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
    public partial class Docentes_CursosDesktop : ApplicationForm
    {
        public Curso CursoActual { get; set; }
        public Docentes_Cursos Docentes_CursosActual { get; set; }


        public Docentes_CursosDesktop()
        {
            InitializeComponent();
        }

        public Docentes_CursosDesktop(Curso curso) : this()
        {
            CursoActual = curso;
            this.Text = "Curso ID " + CursoActual.ID;

        }

        public Docentes_CursosDesktop(int legajo, string cargo, int ID, Curso curso, ModoForm modo) : this()
        {
            CursoActual = curso;
            this.MapearDeDatos(legajo, cargo);
            Modo = modo;
            this.Text = "Editar";
            Docentes_CursosActual = new Docentes_Cursos();
            Docentes_CursosActual.ID = ID;
            
        }


        public void CompletarCombobox()
        {
            UsuarioLogic ul = new UsuarioLogic();
            List<Persona> docentes = ul.GetDocentes();
            List<string> datosDocentes = new List<string>();
            
            foreach (Persona per in docentes)
            {
                string datos;
                datos = per.Legajo + " - " + per.Nombre + " " + per.Apellido + " - " +  per.ID;
                datosDocentes.Add(datos);
            }

            this.cmbDocente.DataSource = datosDocentes;
        }

        private void Docentes_CursosDesktop_Load(object sender, EventArgs e)
        {
            if(this.Modo == ModoForm.Alta)
            {
                this.CompletarCombobox();
            }
        }

        public override void MapearADatos()
        {
            if (Modo == ModoForm.Alta)
            {
                Docentes_CursosActual = new Docentes_Cursos();
                Docentes_CursosActual.State = BusinessEntity.States.New;
            }
            else if (Modo == ModoForm.Modificacion)
            {
                Docentes_CursosActual.State = BusinessEntity.States.Modified;
            }

            string docente = this.cmbDocente.SelectedItem.ToString();
            int ID = int.Parse(docente.Substring(docente.LastIndexOf(" ") + 1));

            Docentes_CursosActual.IDDocente = ID;
            Docentes_CursosActual.IDCurso = CursoActual.ID;
            Docentes_CursosActual.Cargo = this.txtCargo.Text;

        }

        public void MapearDeDatos(int legajo, string cargo)
        {
            this.txtCargo.Text = cargo;
            this.CompletarCombobox();
            cmbDocente.SelectedIndex = cmbDocente.FindString(legajo.ToString());
        }


        public void GuardarCambios()
        {
            //try
            //{
                this.MapearADatos();
                Docente_CursoLogic docCurLog = new Docente_CursoLogic();
                docCurLog.Save(Docentes_CursosActual);

                if (Modo == ModoForm.Alta)
                {
                    this.Notificar("Nuevo docente asignado", "El docente ha sido asignado al curso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (Modo == ModoForm.Modificacion)
                {
                    this.Notificar("Editar Asignación", "Los cambios han sido registrados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
            //}
            //catch
            //{
            //    this.Notificar("Error", "Error al registrar asignación de docente al curso, intente nuevamente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        public bool Validar()
        {
            if (string.IsNullOrEmpty(txtCargo.Text))
            {
                this.Notificar("Campo vacío", "Debe completar el campo 'Cargo'", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                this.GuardarCambios();
            }
           
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
