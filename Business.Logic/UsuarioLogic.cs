using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;
using System.Data;


namespace Business.Logic
{
    public class UsuarioLogic 
    {
        public UsuarioAdapter UsuarioData { get; set; }

        public UsuarioLogic()
        {
            UsuarioData = new UsuarioAdapter();
        }

        public void Save(Usuario usuario, Persona persona)
        {
            try
            {
                if (usuario.State == BusinessEntity.States.New)
                {
                    int cant = this.BuscarLegajo(persona.Legajo);
                    if (cant != 0)
                    {
                        throw new Exception("El legajo ya se encuentra registrado");
                    }
                    else
                    {
                        UsuarioData.Save(usuario, persona);
                    }

                }
                else
                {
                    UsuarioData.Save(usuario, persona);
                }

            }
            catch(System.Data.SqlClient.SqlException e)
            {
                switch (e.Number)
                {
                    case 2601:
                        throw new Exception("El nombre de usuario ya se encuentra registrado");
                        
                    default:
                        throw new Exception("Error al registrar el usuario. Intente Nuevamente");
                }
                
            }
         
        }

        public (List<Usuario>, List<Persona>) GetAll()
        {
            try
            {
                return UsuarioData.GetAll();
            }
            catch 
            {
                throw new Exception("Error al recuperar la lista de Usuarios");
            }
        }

        public (Usuario, Persona) GetOne(int id)
        {
            try
            {
                return UsuarioData.GetOne(id);
            }
            catch
            {
                throw new Exception("Error al recuperar datos del Usuario");
            }
            
        }

        public (string, bool) GetClaveYHabilitado(string nombreUsuario)
        {
            try
            {
                return UsuarioData.GetClaveYHabilitado(nombreUsuario);
            }
            catch
            {
                throw new Exception("Error al obtener datos de acceso. Intente nuevamente");
            }
        }

        public (Usuario, Persona) GetUsuario(string nombreUsuario)
        {
            try
            {
                return UsuarioData.GetUsuario(nombreUsuario);
            }
            catch
            {
                throw new Exception("Error al obtener datos de Usuario. Intente nuevamente");
            }
        }

        public Persona GetPersona(int IDPersona)
        {
            try
            {
                return UsuarioData.GetPersona(IDPersona);
            }
            catch
            {
                throw new Exception("Error al obtener lista. Intente nuevamente");
            }
        }

        public List<Persona> GetDocentes()
        {
            try
            {
                return UsuarioData.GetDocentes();
            }
            catch
            {
                throw new Exception("Error al obtener lista. Intente nuevamente");

            }
        }

        public int BuscarLegajo(int legajo)
        {
            return UsuarioData.BuscarLegajo(legajo);
        }
    }
}
