using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Docentes_Cursos : BusinessEntity
    {
        private int _IDCurso;
        private int _IDDocente;
        private string _cargo;

        public int IDCurso
        {
            get { return _IDCurso; }
            set { _IDCurso = value; }
        }

        public int IDDocente
        {
            get { return _IDDocente; }
            set { _IDDocente = value; }
        }

        public string Cargo
        {
            get { return _cargo; }
            set { _cargo = value; }
        }
    }
}
