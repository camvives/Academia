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
    public partial class EspecialidadWeb : UI.Web.ApplicationForm
    {
        public Especialidad EspActual { get; set; }

        protected new void Page_Load(object sender, EventArgs e)
        {
            EspActual = (Especialidad)Session["Especialidad"];

            if (!IsPostBack)
            {
                this.Modo = (ModoForm)this.Context.Items["Modo"];

                if (this.Modo == ModoForm.Modificacion)
                {
                    MapearDeDatos();
                }
            }
        }

        public override void MapearADatos()
        {
            if (Modo == ModoForm.Alta)
            {
                EspActual = new Especialidad();
                EspActual.State = BusinessEntity.States.New;
            }
            else if (Modo == ModoForm.Modificacion)
            {
                EspActual.State = BusinessEntity.States.Modified;
            }

            this.EspActual.Descripcion = this.txtDescripcion.Text;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                this.MapearADatos();
                EspecialidadLogic el = new EspecialidadLogic();
                el.Save(EspActual);

                if (this.Modo == ModoForm.Modificacion)
                {
                    Response.Write("<script>alert('La Especialidad ha sido actualizada')</script>");
                }
                else if (this.Modo == ModoForm.Alta)
                {
                    Response.Write("<script>alert('La Especialidad ha sido Registrada')</script>");
                }

                Response.AddHeader("REFRESH", "0.1;URL=Especialidades.aspx");

            }
        }

        public override void MapearDeDatos()
        {
            txtDescripcion.Text = EspActual.Descripcion;
        }


        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Especialidades.aspx");
        }
    }
}