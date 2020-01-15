using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Alumno_Inscripcion : BusinessEntity
    {
        private int _IDCurso;
        private int _IDAlumno;
        private string _condicion;
        private int _nota;

        public int IDCurso
        {
            get { return _IDCurso; }
            set { _IDCurso = value; }
        }
        public int IDAlumno
        {
            get { return _IDAlumno; }
            set { _IDAlumno = value; }
        }

        public string Condicion
        {
            get { return _condicion; }
            set { _condicion = value; }
        }

        public int Nota
        {
            get { return _nota; }
            set { _nota = value; }
        }

    }
}
