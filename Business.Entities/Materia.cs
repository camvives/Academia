using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Materia : BusinessEntity
    {
        private string _descMateria;
        private int _horasSemanales;
        private int _horasTotales;
        private int _idPlan;

        public string Descripcion
        {
            get { return _descMateria; }
            set { _descMateria = value; }
        }

        public int HorasSemanales
        {
            get { return _horasSemanales; }
            set { _horasSemanales = value; }
        }

        public int HorasTotales
        {
            get { return _horasTotales; }
            set { _horasTotales = value; }
        }

        public int IDPlan
        {
            get { return _idPlan; }
            set { _idPlan = value;  }
        }

    }
}
