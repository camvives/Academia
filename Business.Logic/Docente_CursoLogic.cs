using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class Docente_CursoLogic
    {
        public Docente_CursoAdapter DocenteCursoData { get; set; }

        public Docente_CursoLogic()
        {
            DocenteCursoData = new Docente_CursoAdapter();
        }

        public Docentes_Cursos GetOne(int ID)
        {
            try
            {
                return DocenteCursoData.GetOne(ID);
            }
            catch
            {
                throw new Exception("Error al recuperar datos, intente nuevamente");
            }
        }

        public void Save(Docentes_Cursos docCurso)
        {
            try
            {
                DocenteCursoData.Save(docCurso);
            }
            catch
            {
                throw new Exception("Error al registrar los datos, intente nuevamente");
            }
        }


        public List<Docentes_Cursos> GetDocentesPorCurso(int idCurso)
        {
            try
            {
                return DocenteCursoData.GetDocentesPorCurso(idCurso);
            }
            catch
            {
                throw new Exception("Error al recuperar datos, intente nuevamente");
            }
        }

        public List<Docentes_Cursos> GetCursosPorDocente(int idDocente)
        {
            try
            {
                return DocenteCursoData.GetCursosPorDocente(idDocente);
            }
            catch
            {
                throw new Exception("Error al recuperar datos, intente nuevamente");
            }
        }
    }

}
