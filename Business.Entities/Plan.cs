using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Plan: BusinessEntity
    {
        private string _descripcion;
        private int _idEspecialidad;

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
        
        public int IDEspecialidad
        {
            get { return _idEspecialidad; }
            set { _idEspecialidad = value; }
        }
    }
}
