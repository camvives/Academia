using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Util;

namespace UI.Desktop
{
    public partial class Reporte : Form
    {
        public Reporte()
        {
            InitializeComponent();
        }

        private void Reporte_Load(object sender, EventArgs e)
        {
            Certificado_Inscripcion reporte = new Certificado_Inscripcion();
            reporte.SetParameterValue("@ID_PERSONA", "94");
            crystalReportViewer1.ReportSource = reporte;
        }
    }
}
