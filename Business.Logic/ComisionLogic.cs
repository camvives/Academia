using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using Business.Entities;

namespace Business.Logic
{
    public class ComisionLogic
    {
        public ComisionAdapter ComisionData { get; set; }

        public ComisionLogic()
        {
            ComisionData = new ComisionAdapter();
        }


        public List<Comision> GetAll()
        {
            try
            {
                return ComisionData.GetAll();
            }
            catch
            {
                throw new Exception("Error al recuperar lista de comisiones, intente nuevamente");
            }
        }

        public Comision GetOne(int ID)
        {
            try
            {
                return ComisionData.GetOne(ID);
            }
            catch
            {
                throw new Exception("Error al recuperar datos de la comisión, intente nuevamente");
            }
        }

        public void Save(Comision comision)
        {
            try
            {
                ComisionData.Save(comision);
            }
            catch
            {
                throw new Exception("Error al registrar datos del curso, intente nuevamente");
            }
        }

        public List<Comision> GetComisionesMat(int IDPlan)
        {
            try
            {
                return ComisionData.GetComisionesMat(IDPlan);
            }
            catch
            {
                throw new Exception("Error al recuperar datos, intente nuevamente");
            }
        }
    }
}
