using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

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
            UsuarioData.Save(usuario, persona);
        }

        public (List<Usuario>, List<Persona>) GetAll()
        {
            return UsuarioData.GetAll();
        }

        public (Usuario, Persona) GetOne(int id)
        {
            return UsuarioData.GetOne(id);
        }

        public string GetClave(string nombreUsuario)
        {
            return UsuarioData.GetClave(nombreUsuario);
        }
    }
}
