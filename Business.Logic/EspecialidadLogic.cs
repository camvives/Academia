using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;


namespace Business.Logic
{
    public class EspecialidadLogic
    {
        public EspecialidadAdapter EspecialidadData { get; set; }

        public EspecialidadLogic()
        {
            EspecialidadData = new EspecialidadAdapter();
        }

        public List<Especialidad> GetAll()
        {
            try
            {
                return EspecialidadData.GetAll();
            }
            catch
            {
                throw new Exception("Error al recuperar la lista de Carreras, intente nuevamente");
            }
        }

        public Especialidad GetOne(int ID)
        {
            try
            {
                return EspecialidadData.GetOne(ID);
            }
            catch
            {
                throw new Exception("Error al recuperar los datos de la Especialidad, intente nuevamente");
            }
        }

        public void Save(Especialidad especialidad)
        {
            try
            {
                EspecialidadData.Save(especialidad);
            }
            catch
            {
                throw new Exception("Error al registrar datos de la Especialidad, intente nuevamente");
            }
        }
    }
}
