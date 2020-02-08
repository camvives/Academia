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
            try
            {
                AlumInscData.Save(ai);
            }
            catch
            {
                throw new Exception("Error al recuperar lista de inscripciones, intente nuevamente");
            }
        }

        public List<Alumno_Inscripcion> GetMateriasInscripto(int IDPersona)
        {
            try
            {
                return AlumInscData.GetMateriasInscripto(IDPersona);
            }
            catch
            {
                throw new Exception("Error al recuperar datos, intente nuevamente");
            }
        }

        public int GetCantidadInscriptos(int IDCurso)
        {
            try
            {
                return AlumInscData.GetCantidadInscriptos(IDCurso);
            }
            catch
            {
                throw new Exception("Error al recuperar datos, intente nuevamente");
            }

        }

        public List<Alumno_Inscripcion> GetAlumnosInscriptos(int IDCurso)
        {
            try
            {
                return AlumInscData.GetAlumnosInscriptos(IDCurso);
            }
            catch
            {
                throw new Exception("Error al recuperar lista de inscripciones, intente nuevamente");
            }
        }


    }
}
