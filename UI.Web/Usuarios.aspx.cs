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

        public UsuarioLogic UsrLog
        {
            get { return new UsuarioLogic(); }
        }

        public Especialidad Especialidad { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.CompletarGrid();

            //Event Bubblig
            MenuABM.BtnNuevoClick += new EventHandler(BtnNuevo_ButtonClick);
            MenuABM.BtnEliminarClick += new EventHandler(BtnEliminar_ButtonClick);
            MenuABM.BtnEditarClick += new EventHandler(BtnEditar_ButtonClick);

        }

        private void BtnEditar_ButtonClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnEliminar_ButtonClick(object sender, EventArgs e)
        {
            this.EliminarUsuario();
            Response.Redirect("~/Usuarios.aspx");
        }

        private void BtnNuevo_ButtonClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #region METODOS

        public void CompletarGrid()
        {
            try
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

                gdvUsuarios.DataSource = dt;
                gdvUsuarios.DataBind();
            }
            catch
            {
                Response.Write("<script>alert('Error al recuperar la lista de usuarios')</script>");
            }

        }

        public void MapearDatos()
        {
            this.Context.Items["Modo"] = ModoForm.Modificacion;
            Session["Usuario"] = UsuarioActual;
            Session.Add("Persona", PersonaActual);
            this.Context.Items["Carrera"] = Especialidad.ID;
            Server.Transfer("UsuarioWeb.aspx", true);
        }

        public void EliminarUsuario()
        {
            try
            {
                this.GetUsuario();
                UsuarioActual.State = BusinessEntity.States.Deleted;
                UsrLog.Save(UsuarioActual, PersonaActual);
            }
            catch
            {
                Response.Write("<script>alert('Error al eliminar al usuario')</script>");
            }
        }

        #endregion

        private void Confirmar1_ButtonClick(object sender, EventArgs e)
        {
            this.EliminarUsuario();
            Response.Redirect("Usuarios.aspx");
        }



        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            this.Context.Items["Modo"] = ModoForm.Alta;
            Server.Transfer("UsuarioWeb.aspx", true);
            Response.Redirect("UsuarioWeb.aspx");
        }



        protected void gdvUsuarios_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gdvUsuarios, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click para seleccionar fila";
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Main.aspx");
        }

        public void GetUsuario()
        {
            GridViewRow row = gdvUsuarios.SelectedRow;
            int ID = int.Parse(row.Cells[0].Text);
            (UsuarioActual, PersonaActual) = UsrLog.GetOne(ID);
        }

    }
}