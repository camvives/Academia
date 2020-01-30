using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class WebUserControl2 : System.Web.UI.UserControl
    {
        public event EventHandler BtnNuevoClick;
        public event EventHandler BtnEliminarClick;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnNuevo_Click(object sender, ImageClickEventArgs e)
        {
            BtnNuevoClick(sender, e);
        }

        protected void btnEliminar_Click(object sender, ImageClickEventArgs e)
        {
            BtnEliminarClick(sender, e);
        }
    }
}