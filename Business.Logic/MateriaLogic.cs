using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class MateriaLogic
    {
        public MateriaAdapter MateriaData { get; set; }

        public MateriaLogic()
        {
            MateriaData = new MateriaAdapter();
        }


        public List<Materia> GetAll()
        {
            return MateriaData.GetAll();
        }

        public Materia GetOne(int ID)
        {
            return MateriaData.GetOne(ID);
        }

        public void Save(Materia materia)
        {
            MateriaData.Save(materia);
        }

        public List<Materia> GetMateriasPlan(int IDPlan)
        {
            return MateriaData.GetMateriasPlan(IDPlan);
        }
    }
}
