using System;
using System.Windows.Forms;
using Util;

namespace UI.Desktop
{
    public partial class Reporte : Form
    {
        int IDAlumno { get; set; }

        public Reporte()
        {
            InitializeComponent();
            crystalReportViewer1.ShowRefreshButton = false;
            crystalReportViewer1.ShowTextSearchButton = false;
            crystalReportViewer1.ShowGroupTreeButton = false;
            crystalReportViewer1.ShowCloseButton = false;
            crystalReportViewer1.ShowGotoPageButton = false;
        }

        public Reporte(int idAlumno) : this()
        {
            IDAlumno = idAlumno;
        }

        private void Reporte_Load(object sender, EventArgs e)
        {
            Certificado_Inscripcion reporte = new Certificado_Inscripcion();
            reporte.SetParameterValue("@ID_PERSONA", IDAlumno);
            crystalReportViewer1.ReportSource = reporte;
        }
    }
}
