using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Util;

namespace UI.Web
{
    public partial class Reporte : System.Web.UI.Page
    {
        int IDAlumno { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            IDAlumno = (int)Session["ID"];
            Certificado_Inscripcion reporte = new Certificado_Inscripcion();
            reporte.SetParameterValue("@ID_PERSONA", IDAlumno);
            CertificadoInscripcion.ReportSource = reporte;
        }
    }
}