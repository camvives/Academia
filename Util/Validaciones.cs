﻿using Business.Entities;
using Business.Logic;
using System;
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

        public static Boolean ValidarUsuario(string user, string clave)
        {
            try
            {
                UsuarioLogic ul = new UsuarioLogic();
                (string claveBD, _) = ul.GetClaveYHabilitado(user);

                if (claveBD == clave)
                {
                    return true;
                }

                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Boolean ValidarHabilitado(string user, string clave)
        {
            try
            {
                UsuarioLogic ul = new UsuarioLogic();
                (_, bool habilitado) = ul.GetClaveYHabilitado(user);

                if (habilitado)
                {
                    return true;
                }

                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static Boolean ValidarCupo(int IDCurso)
        {
            try
            {
                Alumno_InscripcionLogic ail = new Alumno_InscripcionLogic();
                int cantInscriptos = ail.GetCantidadInscriptos(IDCurso);

                CursoLogic cursoLog = new CursoLogic();
                Curso curso = cursoLog.GetOne(IDCurso);

                if (cantInscriptos < curso.Cupo)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
