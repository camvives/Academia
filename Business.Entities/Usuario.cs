using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Usuario : BusinessEntity
    {
        #region CAMPOS
        private string _nombreUsuario;
        private string _clave;
        private bool _habilitado;
        #endregion

        #region PROPIEDADES
        public string NombreUsuario
        {
            get { return _nombreUsuario; }
            set { _nombreUsuario = value; }
        }

        public string Clave
        {
            get { return _clave; }
            set { _clave = value; }
        }

        public bool Habilitado
        {
            get { return _habilitado;}
            set { _habilitado = value; }
        }
        #endregion
    }
}
