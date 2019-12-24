using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Logic;
using Business.Entities;
using System.Data;


namespace UI.Web
{
    public partial class UsuariosWeb : System.Web.UI.Page
    {
        public Usuario UsuarioActual { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            this.CompletarGrid();
        }

        public void CompletarGrid()
        {
            
            UsuarioLogic ul = new UsuarioLogic();
            List<Persona> personas;
            List<Business.Entities.Usuario> usuarios;
            (usuarios, personas) = ul.GetAll();

            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Apellido");
            dt.Columns.Add("NombreUsuario");
            dt.Columns.Add("Email");
            dt.Columns.Add("Habilitado");

            foreach (var usr in personas.Zip(usuarios, (a, b) => new { a, b }))  //Linq combina las dos listas
            {
                dt.Rows.Add(usr.b.ID, usr.a.Nombre, usr.a.Apellido, usr.b.NombreUsuario, usr.a.Email, usr.b.Habilitado);
            }

            gridView.DataSource = dt;
            gridView.DataBind();
            
        }

       public void MostrarDatos()
       {
                UsuarioLogic ul = new UsuarioLogic();
                Persona persona;
                int ID = int.Parse(gridView.SelectedRow.Cells[0].Text);
                (UsuarioActual, persona) = ul.GetOne(ID);

                PlanLogic pl = new PlanLogic();
                Plan plan = pl.GetOne(persona.IDPlan);

                EspecialidadLogic el = new EspecialidadLogic();
                Especialidad especialidad = el.GetOne(plan.IDEspecialidad);

            #region Validaciones
            string hab;
            if (UsuarioActual.Habilitado == true)
            {
                hab = "Sí";
            }
            else
            {
                hab = "No";
            }

            string plandesc;
            if (plan.Descripcion is null)
            {
                plandesc = "-";
            }
            else
            {
                plandesc = plan.Descripcion;
            }

            string espdesc;
            if (especialidad.Descripcion is null)
            {
                espdesc = "-";
            }
            else
            {
                espdesc = especialidad.Descripcion;
            }

            string leg;
            if (persona.Legajo == 0)
            {
                leg = "-";
            }
            else
            {
                leg = persona.Legajo.ToString();
            }
            #endregion

            this.lblID.Text = UsuarioActual.ID.ToString();
            this.lblNombreUsuario.Text = UsuarioActual.NombreUsuario;
            this.lblHabilitado.Text = hab;
            this.lblNombre.Text = persona.Nombre;
            this.lblApellido.Text = persona.Apellido;
            this.lblDireccion.Text = persona.Direccion;
            this.lblEmail.Text = persona.Email;
            this.lblTelefono.Text = persona.Telefono;
            this.lblFechaNac.Text = persona.FechaNacimiento.ToString("dd/MM/yyyy");
            this.lblTipo.Text = persona.TipoPersona.ToString();
            this.lblLegajo.Text = leg;
            this.lblCarrera.Text = espdesc;
            this.lblPlan.Text = plandesc;
       }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.MostrarDatos();
        }

        protected void gridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
           
            Application["UsuarioWeb"] = ModoForm.Modificacion;
            this.MapearDatos();
            Response.Redirect("UsuarioWeb.aspx");
        }

        public void MapearDatos()
        {
            this.Context.Items["Nombre"] = lblNombre.Text;
            this.Context.Items["Apellido"] = lblApellido.Text;
            this.Context.Items["Apellido"] = lblApellido.Text;
            this.Context.Items["Direccion"] = lblDireccion.Text;
            this.Context.Items["Email"] = lblEmail.Text;
            this.Context.Items["Telefono"] = lblTelefono.Text;
            this.Context.Items["Fecha"] = lblFechaNac.Text;
            this.Context.Items["Carrera"] = lblCarrera.Text;
            this.Context.Items["Plan"] = lblPlan.Text;
            this.Context.Items["Usuario"] = UsuarioActual.NombreUsuario;
            this.Context.Items["Clave"] = UsuarioActual.Clave;
            this.Context.Items["Legajo"] = lblLegajo.Text;
            this.Context.Items["Tipo"] = lblTipo.Text;
            this.Context.Items["Habilitado"] = UsuarioActual.Habilitado;
            Server.Transfer("UsuarioWeb.aspx", true);
        }
    }
}