using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class Inscriptos : System.Web.UI.Page
    {
        public class DatosAlumnos
        {
            public int ID { get; set; }
            public int ID_Curso { get; set; }
            public int ID_persona { get; set; }
            public int Legajo { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string Condicion { get; set; }
            public string NotaMostrar { get; set; }
            public int Nota { get; set; }
        }

        public Alumno_Inscripcion Alumno { get; set; }

        public string Condicion { get; set; }

        public DatosAlumnos AlumnoActual { get; set; }

        public Persona Docente { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Persona.TiposPersonas)Session["Tipo"] != Persona.TiposPersonas.Docente)
            {
                Response.Redirect("~/Login.aspx");
            }

            Docente = (Persona)Session["Persona"];

            if (!IsPostBack)
            {
                this.CompletarCombobox();
                gdvInscriptos.DataSource = this.ObtenerDatos();
                gdvInscriptos.DataBind();
                gdvInscriptos.Columns[7].Visible = false;
                gdvInscriptos.Columns[8].Visible = false;
                gdvInscriptos.Columns[6].Visible = false;
            }

        }

        public void CompletarCombobox()
        {
            try
            {
                List<String> cursos = new List<string>();
                Docente_CursoLogic dcLog = new Docente_CursoLogic();
                List<Docentes_Cursos> docentesCursos = new List<Docentes_Cursos>();
                docentesCursos = dcLog.GetCursosPorDocente(Docente.ID);

                foreach (Docentes_Cursos dc in docentesCursos)
                {
                    string curso;

                    CursoLogic cl = new CursoLogic();
                    Curso cur = cl.GetOne(dc.IDCurso);

                    ComisionLogic col = new ComisionLogic();
                    Comision com = col.GetOne(cur.IDComision);

                    MateriaLogic mat = new MateriaLogic();
                    Materia materia = mat.GetOne(cur.IDMateria);

                    PlanLogic pl = new PlanLogic();
                    Plan plan = pl.GetOne(materia.IDPlan);

                    EspecialidadLogic el = new EspecialidadLogic();
                    Especialidad especialidad = el.GetOne(plan.IDEspecialidad);


                    curso = com.Descripcion + " - " + materia.Descripcion + " - " + especialidad.Descripcion + " - " + cur.AnioCalendario.ToString() + " - " + dc.IDCurso.ToString();

                    cursos.Add(curso);
                }

                this.ddlCurso.DataSource = cursos;
                ddlCurso.DataBind();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message + "')", true);

            }
        }

        public List<DatosAlumnos> ObtenerDatos()
        {
            string curso = this.ddlCurso.SelectedItem.ToString();
            int IDCurso = int.Parse(curso.Substring(curso.LastIndexOf(" ") + 1));
            List<DatosAlumnos> datosAlumnos = new List<DatosAlumnos>();
            Alumno_InscripcionLogic ail = new Alumno_InscripcionLogic();

            try
            {
                List<Alumno_Inscripcion> alumnos = ail.GetAlumnosInscriptos(IDCurso);


                foreach (Alumno_Inscripcion ai in alumnos)
                {
                    DatosAlumnos alumno = new DatosAlumnos();
                    alumno.ID = ai.ID;
                    alumno.Condicion = ai.Condicion;
                    alumno.Nota = ai.Nota;
                    alumno.ID_Curso = ai.IDCurso;
                    alumno.ID_persona = ai.IDAlumno;
                    if (ai.Nota == 0)
                    {
                        alumno.NotaMostrar = " ";
                    }
                    else
                    {
                        alumno.NotaMostrar = ai.Nota.ToString();
                    }

                    UsuarioLogic ul = new UsuarioLogic();
                    Persona persona = ul.GetPersona(ai.IDAlumno);

                    alumno.Nombre = persona.Nombre;
                    alumno.Legajo = persona.Legajo;
                    alumno.Apellido = persona.Apellido;

                    datosAlumnos.Add(alumno);

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message + "')", true);

            }

            return datosAlumnos;
        }

        public void MapearADatos()
        {

            Alumno = new Alumno_Inscripcion();
            Alumno = (Alumno_Inscripcion)Session["AlumnoAct"];
            Alumno.Condicion = (string)Session["Condicion"];

            GridViewRow row = gdvInscriptos.SelectedRow;
            string Nota = (string)Session["Nota"];
            if (Nota == " ")
            {
                Alumno.Nota = 0;
            }
            else
            {
                Alumno.Nota = int.Parse(Nota);
            }
            Alumno.State = BusinessEntity.States.Modified;

        }


        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Main.aspx");
        }

        protected void ddlCurso_SelectedIndexChanged(object sender, EventArgs e)
        {
            gdvInscriptos.DataSource = this.ObtenerDatos();
            gdvInscriptos.DataBind();
        }

        protected void gdvInscriptos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gdvInscriptos.EditIndex = e.NewEditIndex;
            gdvInscriptos.Columns[4].Visible = false;
            gdvInscriptos.Columns[3].Visible = true;
        }

        protected void ddlCond_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = (GridViewRow)(((Control)sender).NamingContainer);
            DropDownList ddl = (DropDownList)row.FindControl("ddlCondicion");
            RequiredFieldValidator req = (RequiredFieldValidator)row.FindControl("reqNota");
            TextBox txtNota = (TextBox)row.FindControl("txtNota");
            txtNota.Enabled = true;
            //Session["Nota"] = txtNota.Text;
            Session["Condicion"] = ddl.SelectedItem.Value;
            Condicion = ddl.SelectedItem.Value;
            if (Condicion == "Aprobado")
            {
                txtNota.Text = "";
                req.Enabled = true;
                row.Cells[6].Enabled = true;
            }
            else
            {
                req.Enabled = false;
                txtNota.Text = " ";
                row.Cells[6].Enabled = false;
            }

        }

        protected void gdvInscriptos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                Label lblID = gdvInscriptos.Rows[e.RowIndex].FindControl("lblID") as Label;
                Label lblIDCur = gdvInscriptos.Rows[e.RowIndex].FindControl("lblCurso") as Label;
                Label lblIDPer = gdvInscriptos.Rows[e.RowIndex].FindControl("lblPersona") as Label;
                DropDownList ddlCondicion = gdvInscriptos.Rows[e.RowIndex].FindControl("ddlCondicion") as DropDownList;
                TextBox txtNota = gdvInscriptos.Rows[e.RowIndex].FindControl("txtNota") as TextBox;

                Alumno_Inscripcion ai = new Alumno_Inscripcion();
                ai.ID = int.Parse(lblID.Text);
                ai.IDCurso = int.Parse(lblIDCur.Text);
                ai.IDAlumno = int.Parse(lblIDPer.Text);
                ai.Condicion = ddlCondicion.SelectedValue;

                if (txtNota.Text == " ")
                {
                    ai.Nota = 0;
                }
                else
                {
                    ai.Nota = int.Parse(txtNota.Text);
                }


                ai.State = BusinessEntity.States.Modified;

                Alumno_InscripcionLogic al = new Alumno_InscripcionLogic();
                al.Save(ai);
                Response.Redirect("~/Inscriptos.aspx");
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message + "')", true);
            }

        }

        protected void gdvInscriptos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Response.Redirect("~/Inscriptos.aspx");
        }

     



    }
}