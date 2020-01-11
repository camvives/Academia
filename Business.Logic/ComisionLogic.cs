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
            return ComisionData.GetAll();
        }

        public Comision GetOne(int ID)
        {
            return ComisionData.GetOne(ID);
        }

        public void Save(Comision comision)
        {
            ComisionData.Save(comision);
        }

        public List<Comision> GetComisionesMat(int IDPlan)
        {
            return ComisionData.GetComisionesMat(IDPlan);
        }
    }
}
