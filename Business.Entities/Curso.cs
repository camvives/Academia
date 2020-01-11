using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Curso : BusinessEntity
    {
        private int _IDMateria;
        private int _IDComision;
        private int _anioCalendario;
        private int _cupo;

        public int IDMateria
        {
            get { return _IDMateria; }
            set { _IDMateria = value; }
        }

        public int IDComision
        {
            get { return _IDComision; }
            set { _IDComision = value; }
        }

        public int AnioCalendario
        {
            get { return _anioCalendario; }
            set { _anioCalendario = value; }
        }

        public int Cupo
        {
            get { return _cupo; }
            set { _cupo = value; }
        }
    }
}
