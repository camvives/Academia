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
                        throw new Exception("El legajo ya está registrado");
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
            return UsuarioData.GetAll();
        }

        public (Usuario, Persona) GetOne(int id)
        {
            return UsuarioData.GetOne(id);
        }

        public (string, bool) GetClaveYHabilitado(string nombreUsuario)
        {
            return UsuarioData.GetClaveYHabilitado(nombreUsuario);
        }

        public (Usuario, Persona) GetUsuario(string nombreUsuario)
        {
            return UsuarioData.GetUsuario(nombreUsuario);
        }

        public Persona GetPersona(int IDPersona)
        {
            return UsuarioData.GetPersona(IDPersona);
        }

        public List<Persona> GetDocentes()
        {
            return UsuarioData.GetDocentes();
        }

        public int BuscarLegajo(int legajo)
        {
            return UsuarioData.BuscarLegajo(legajo);
        }
    }
}
