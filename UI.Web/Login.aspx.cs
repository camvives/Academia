using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Util;

namespace UI.Web
{
    public partial class Login1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void valUser_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (!Validaciones.ValidarUsuario(this.txtUser.Text, this.txtPass.Text))
            {
                args.IsValid = false;
            }
        }

        protected void valHabilitado_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (valUser.IsValid)
            {
                if (!Validaciones.ValidarHabilitado(this.txtUser.Text, this.txtPass.Text))
                {
                    args.IsValid = false;
                }
            }
        }
    }
}