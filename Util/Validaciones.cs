using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using Business.Logic;
using Business.Entities;

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

        public static Boolean ValidarUsuario(string user, string clave)
        {
            UsuarioLogic ul = new UsuarioLogic();
            string claveBD = ul.GetClave(user);

            if (claveBD == clave)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        public static Boolean ValidarCupo(int IDCurso)
        {
            Alumno_InscripcionLogic ail = new Alumno_InscripcionLogic();
            int cantInscriptos = ail.GetCantidadInscriptos(IDCurso);

            CursoLogic cursoLog = new CursoLogic();
            Curso curso = cursoLog.GetOne(IDCurso);

            if(cantInscriptos < curso.Cupo)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
