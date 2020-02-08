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
            try
            {
                return MateriaData.GetAll();
            }
            catch
            {
                throw new Exception("Error al recuperar la lista de materias, intente nuevamente");
            }
        }

        public Materia GetOne(int ID)
        {
            try
            {
                return MateriaData.GetOne(ID);
            }
            catch
            {

                throw new Exception("Error al recuperar datos de la materia, intente nuevamente");
            }
        }

        public void Save(Materia materia)
        {
            try
            {
                MateriaData.Save(materia);
            }
            catch
            {
                throw new Exception("Error al registrar datos de la materia, intente nuevamente");
            }
        }

        public List<Materia> GetMateriasPlan(int IDPlan)
        {
            try
            {
                return MateriaData.GetMateriasPlan(IDPlan);
            }
            catch
            {
                throw new Exception("Error al recuperar materias, intente nuevamente");
            }
        }
    }
}
