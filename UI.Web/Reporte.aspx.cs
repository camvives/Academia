using System;
using Util;
using Business.Entities;

namespace UI.Web
{
    public partial class Reporte : System.Web.UI.Page
    {
        int IDAlumno { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Persona.TiposPersonas)Session["Tipo"] != Persona.TiposPersonas.Alumno)
            {
                Response.Redirect("~/Login.aspx");
            }

            IDAlumno = (int)Session["ID"];
            Certificado_Inscripcion reporte = new Certificado_Inscripcion();
            reporte.SetParameterValue("@ID_PERSONA", IDAlumno);
            CertificadoInscripcion.ReportSource = reporte;
        }
    }
}