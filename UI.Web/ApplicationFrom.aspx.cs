using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public enum ModoForm { Alta, Baja, Modificacion, Consulta };
    public partial class ApplicationFrom : System.Web.UI.Page
    {
        public ModoForm Modo { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public virtual void MapearADatos() { }
    }
}