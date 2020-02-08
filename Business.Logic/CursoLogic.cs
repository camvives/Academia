using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class CursoLogic
    {
        public CursoAdapter  CursoData { get; set; }

        public CursoLogic()
        {
            CursoData = new CursoAdapter();
        }

        public List<Curso> GetAll()
        {
            try
            {
                return CursoData.GetAll();
            }
            catch
            {
                throw new Exception("Error al recuperar lista de cursos, intente nuevamente");
            }
        }

        public Curso GetOne(int ID)
        {
            try
            {
                return CursoData.GetOne(ID);
            }
            catch
            {
                throw new Exception("Error al recuperar datos del curso, intente nuevamente");
            }
        }

        public void Save(Curso curso)
        {
            try
            {
                CursoData.Save(curso);
            }
            catch
            {
                throw new Exception("Error al registrar datos del curso, intente nuevamente");
            }
        }

        public List<Curso> GetCursosUsuario(int IDPLan)
        {
            try
            {
                return CursoData.GetCursosUsuario(IDPLan);
            }
            catch
            {
                throw new Exception("Error al recuperar datos, intente nuevamente");
            }
        }

    }
}
