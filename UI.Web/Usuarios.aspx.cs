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
    public partial class WebForm1 : System.Web.UI.Page
    {
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

    }
}