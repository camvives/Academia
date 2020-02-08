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
    public partial class CursoWeb : UI.Web.ApplicationForm
    {
        public Curso CursoActual { get; set; }

        protected new void Page_Load(object sender, EventArgs e)
        {
            CursoActual = (Curso)Session["Curso"];

            if (!IsPostBack)
            {
                this.Modo = (ModoForm)this.Context.Items["Modo"];
                this.CompletarDDLEsp();

                if (this.Modo == ModoForm.Modificacion)
                {
                    MapearDeDatos();
                }
            }

        }

        public void CompletarDDLEsp()
        {
            try
            {
                EspecialidadLogic especialidad = new EspecialidadLogic();
                ddlCarrera.DataTextField = "Descripcion";
                ddlCarrera.DataValueField = "ID";
                ddlCarrera.DataSource = especialidad.GetAll();
                ddlCarrera.DataBind();

                if (this.Modo != ModoForm.Modificacion)
                {
                    ddlCarrera.Items.Insert(0, "Seleccionar Carrera");
                    if (!(ddlPlan.Items.Contains(ddlPlan.Items.FindByValue("Plan"))))
                    {
                        ddlPlan.Items.Insert(0, "Plan");
                    }
                    ddlPlan.Text = "Plan";
                }
            }
            catch
            {
                Response.Write("<script>alert('Error al cargar el formulario')</script>");
                Response.Redirect("~/Main.aspx");
            }

        }

        protected void ddlCarrera_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlPlan.Enabled = true;
            ddlCarrera.Items.Remove("Seleccionar Carrera");

            ddlMateria.Items.Clear();
            ddlComision.Items.Clear();
            ddlMateria.Items.Insert(0, " ");
            ddlComision.Items.Insert(0, " ");
            ddlMateria.Text = " ";
            ddlComision.Text = " ";

            this.CargaPlanes();
            
        }

        protected void ddlPlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CargaMatCom();
        }

        public void CargaPlanes()
        {
            try
            {
                int EspId = int.Parse(ddlCarrera.SelectedValue.ToString());

                PlanLogic plan = new PlanLogic();
                ddlPlan.DataTextField = "Descripcion";
                ddlPlan.DataValueField = "ID";
                ddlPlan.DataSource = plan.GetPlanesEsp(EspId);
                ddlPlan.DataBind();

                if (!(ddlPlan.Items.Contains(ddlPlan.Items.FindByValue("Plan"))))
                {
                    ddlPlan.Items.Insert(0, "Plan");
                }
                ddlPlan.Text = "Plan";
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message + "')", true);

            }

        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Cursos.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    this.MapearADatos();
                    CursoLogic cl = new CursoLogic();
                    cl.Save(CursoActual);

                    if (this.Modo == ModoForm.Modificacion)
                    {
                        Response.Write("<script>alert('El curso ha sido actualizado')</script>");
                    }
                    else if (this.Modo == ModoForm.Alta)
                    {
                        Response.Write("<script>alert('El curso ha sido Registrado')</script>");
                    }

                    Response.AddHeader("REFRESH", "0.1;URL=Cursos.aspx");

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message + "')", true);
            }

        }

        protected void ddlMateria_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlMateria.Items.Remove(" ");
        }

        protected void ddlComision_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlComision.Items.Remove(" ");
        }

        public override void MapearADatos()
        {
            if (Modo == ModoForm.Alta)
            {
                CursoActual = new Curso();
                CursoActual.State = BusinessEntity.States.New;
            }
            else if (Modo == ModoForm.Modificacion)
            {
                CursoActual.State = BusinessEntity.States.Modified;
            }

            this.CursoActual.IDMateria = int.Parse(this.ddlMateria.SelectedValue);
            this.CursoActual.IDComision = int.Parse(this.ddlComision.SelectedValue);
            this.CursoActual.AnioCalendario = int.Parse(txtAnio.Text);
            this.CursoActual.Cupo = int.Parse(TxtCupo.Text);
        }

        public override void MapearDeDatos()
        {
            ddlCarrera.SelectedValue = this.Context.Items["Carrera"].ToString();
            this.CargaPlanes();
            ddlPlan.SelectedValue = this.Context.Items["Plan"].ToString();
            this.CargaMatCom();
            ddlComision.SelectedValue = CursoActual.IDComision.ToString();
            ddlMateria.SelectedValue = CursoActual.IDMateria.ToString();
            this.txtAnio.Text = CursoActual.AnioCalendario.ToString();
            this.TxtCupo.Text = CursoActual.Cupo.ToString();
        }

        public void CargaMatCom()
        {
            try
            {
                ddlPlan.Items.Remove("Plan");
                int PlanId = int.Parse(ddlPlan.SelectedValue.ToString());

                MateriaLogic materiaLogic = new MateriaLogic();
                ddlMateria.DataTextField = "Descripcion";
                ddlMateria.DataValueField = "ID";
                ddlMateria.DataSource = materiaLogic.GetMateriasPlan(PlanId);
                ddlMateria.DataBind();


                ComisionLogic comisionLog = new ComisionLogic();
                ddlComision.DataTextField = "Descripcion";
                ddlComision.DataValueField = "ID";
                ddlComision.DataSource = comisionLog.GetComisionesMat(PlanId);
                ddlComision.DataBind();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message + "')", true);
            }
        }
    }
}