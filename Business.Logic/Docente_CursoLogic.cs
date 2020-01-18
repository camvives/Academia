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

        public List<Docentes_Cursos> GetDocentesPorCurso(int idCurso)
        {
            return DocenteCursoData.GetDocentesPorCurso(idCurso);
        }
    }
}
