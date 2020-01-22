using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class Alumno_InscripcionLogic
    {
        public Alumno_InscripcionAdapter AlumInscData { get; set; }

        public Alumno_InscripcionLogic()
        {
            AlumInscData = new Alumno_InscripcionAdapter();
        }

        public void Save(Alumno_Inscripcion ai)
        {
            AlumInscData.Save(ai);
        }

        public List<Alumno_Inscripcion> GetMateriasInscripto(int IDPersona)
        {
            return AlumInscData.GetMateriasInscripto(IDPersona);
        }

        public int GetCantidadInscriptos(int IDCurso)
        {
            return AlumInscData.GetCantidadInscriptos(IDCurso);

        }

        public List<Alumno_Inscripcion> GetAlumnosInscriptos(int IDCurso)
        {
            return AlumInscData.GetAlumnosInscriptos(IDCurso);
        }


    }
}
