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
        public Persona PersonaActual { get; set; }

        public Especialidad Especialidad { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.CompletarGrid();
            this.Confirmar1.Visible = false;
            
            //Event Bubblig
            Confirmar1.ButtonClick += new EventHandler(Confirmar1_ButtonClick);
        }

        private void Confirmar1_ButtonClick(object sender, EventArgs e)
        {
            this.EliminarUsuario();
            Response.Redirect("Usuarios.aspx");
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
            int ID = int.Parse(gridView.SelectedRow.Cells[0].Text);
            (UsuarioActual, PersonaActual) = ul.GetOne(ID);

            PlanLogic pl = new PlanLogic();
            Plan plan = pl.GetOne(this.PersonaActual.IDPlan);

            EspecialidadLogic el = new EspecialidadLogic();
            Especialidad = el.GetOne(plan.IDEspecialidad);
            

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
            if (Especialidad.Descripcion is null)
            {
                espdesc = "-";
            }
            else
            {
                espdesc = Especialidad.Descripcion;
            }

            string leg;
            if (this.PersonaActual.Legajo == 0)
            {
                leg = "-";
            }
            else
            {
                leg = this.PersonaActual.Legajo.ToString();
            }
            #endregion

            this.lblID.Text = UsuarioActual.ID.ToString();
            this.lblNombreUsuario.Text = UsuarioActual.NombreUsuario;
            this.lblHabilitado.Text = hab;
            this.lblNombre.Text = this.PersonaActual.Nombre;
            this.lblApellido.Text = this.PersonaActual.Apellido;
            this.lblDireccion.Text = PersonaActual.Direccion;
            this.lblEmail.Text = PersonaActual.Email;
            this.lblTelefono.Text = PersonaActual.Telefono;
            this.lblFechaNac.Text = PersonaActual.FechaNacimiento.ToString("dd/MM/yyyy");
            this.lblTipo.Text = PersonaActual.TipoPersona.ToString();
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
            this.MapearDatos();
            Response.Redirect("UsuarioWeb.aspx");
        }

        public void MapearDatos()
        {
            this.Context.Items["Modo"] = ModoForm.Modificacion;
            Session["Usuario"] = UsuarioActual;
            Session.Add("Persona", PersonaActual);
            this.Context.Items["Carrera"] = Especialidad.ID; 
            Server.Transfer("UsuarioWeb.aspx", true);
        }

        protected void gridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            this.Confirmar1.Visible = true;
        }


        public void EliminarUsuario()
        {
            UsuarioLogic ul = new UsuarioLogic();
            UsuarioActual.State = BusinessEntity.States.Deleted;
            ul.Save(UsuarioActual, PersonaActual);
        }
    }

}