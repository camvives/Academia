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
            return DocenteCursoData.GetOne(ID);
        }

        public void Save(Docentes_Cursos docCurso)
        {
            DocenteCursoData.Save(docCurso);
        }


        public List<Docentes_Cursos> GetDocentesPorCurso(int idCurso)
        {
            return DocenteCursoData.GetDocentesPorCurso(idCurso);
        }

        public List<Docentes_Cursos> GetCursosPorDocente(int idDocente)
        {
            return DocenteCursoData.GetCursosPorDocente(idDocente);
        }
    }

}
