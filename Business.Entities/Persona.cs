using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Persona : BusinessEntity
    {
        public enum TiposPersonas { Admin, Docente, Alumno }

        #region CAMPOS
        private string _apellido;
        private string _nombre;
        private string _direccion;
        private string _email;
        private string _telefono;
        private DateTime _fechaNacimiento;
        private int _legajo;
        private TiposPersonas _tipoPersona;
        private int _idPlan;
        #endregion

        #region PROPIEDADES
        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string Direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }

        public DateTime FechaNacimiento
        {
            get { return _fechaNacimiento; }
            set { _fechaNacimiento = value; }
        }

        public int Legajo
        {
            get { return _legajo; }
            set { _legajo = value; }
        }

        public TiposPersonas TipoPersona
        {
            get { return _tipoPersona; }
            set { _tipoPersona = value; }
        }
        public int IDPlan
        {
            get { return _idPlan; }
            set { _idPlan = value; }
        }

        #endregion
    }
}
