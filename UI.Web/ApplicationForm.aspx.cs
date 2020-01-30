using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public enum ModoForm { Alta, Baja, Modificacion, Consulta };
    public partial class ApplicationForm : System.Web.UI.Page
    {
        public ModoForm Modo
        {
            get { return (ModoForm)this.ViewState["Modo"]; }
            set { this.ViewState["Modo"] = value; }
        }
            

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public virtual void MapearADatos() { }

        public virtual void MapearDeDatos() { }
    }
}