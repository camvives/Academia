using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace Util
{
    public class Validaciones
    {
        static public bool EmailValido(string email)
        {
            try
            {
                MailAddress mail = new MailAddress(email);

                return mail.Address == email;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        public static Boolean ValidarContraseña(string clave, int num)
        {
            if (clave.Length < num)
            {
                return true;
            }
            return false;
        }
    }
}
