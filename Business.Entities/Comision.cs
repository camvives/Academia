using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Comision : BusinessEntity
    {
        private string _descripcion;
        private int _anioEsp;
        private int _idPlan;

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        public int AnioEspecialidad
        {
            get { return _anioEsp; }
            set { _anioEsp = value; }
        }

        public int IDPlan
        {
            get { return _idPlan; }
            set { _idPlan = value; }
        }
    }
}
