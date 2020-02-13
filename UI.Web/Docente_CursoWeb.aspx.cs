using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;

namespace UI.Web
{
    public partial class Docente_CursoWeb : UI.Web.ApplicationForm
    {
        public Curso CursoActual { get; set; }
        public Docentes_Cursos Docentes_CursosActual { get; set; }

        protected new void Page_Load(object sender, EventArgs e)
        {
            if ((Persona.TiposPersonas)Session["Tipo"] != Persona.TiposPersonas.Administrador)
            {
                Response.Redirect("~/Login.aspx");
            }

            CursoActual = (Curso)Session["Curso"];
            Docentes_CursosActual = (Docentes_Cursos)Session["Docente"];

            if (!IsPostBack)
            {
                this.Modo = (ModoForm)this.Context.Items["Modo"];
                this.CompletarCombobox();

                if (this.Modo == ModoForm.Modificacion)
                {
                    
                    MapearDeDatos();
                }
            }
        }

        public void CompletarCombobox()
        {
            UsuarioLogic ul = new UsuarioLogic();
            List<Persona> docentes = ul.GetDocentes();
            List<string> datosDocentes = new List<string>();

            foreach (Persona per in docentes)
            {
                string datos;
                datos = per.Legajo + " - " + per.Nombre + " " + per.Apellido + " - " + per.ID;
                datosDocentes.Add(datos);
            }

            this.ddlDocente.DataSource = datosDocentes;
            ddlDocente.DataBind();
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

            string docente = this.ddlDocente.SelectedItem.ToString();
            int ID = int.Parse(docente.Substring(docente.LastIndexOf(" ") + 1));

            this.Docentes_CursosActual.IDCurso = this.CursoActual.ID;
            this.Docentes_CursosActual.IDDocente = ID;
            this.Docentes_CursosActual.Cargo = this.txtCargo.Text;
        }

        public override void MapearDeDatos()
        {
            ddlDocente.SelectedValue = Docentes_CursosActual.IDDocente.ToString();
            this.txtCargo.Text = Docentes_CursosActual.Cargo;
 
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Docentes_Curso.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    this.MapearADatos();
                    Docente_CursoLogic dcl = new Docente_CursoLogic();
                    dcl.Save(Docentes_CursosActual);

                    if (this.Modo == ModoForm.Modificacion)
                    {
                        Response.Write("<script>alert('La asingación ha sido actualizada')</script>");
                    }
                    else if (this.Modo == ModoForm.Alta)
                    {
                        Response.Write("<script>alert('La asignación ha sido Registrada')</script>");
                    }

                    Response.AddHeader("REFRESH", "0.1;URL=Docentes_Curso.aspx");

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message + "')", true);
            }
        }
    }
}