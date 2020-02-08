using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class PlanLogic
    {
        public PlanAdapter PlanData { get; set; }

        public PlanLogic()
        {
            PlanData = new PlanAdapter();
        }

        public void Save(Plan plan)
        {
            try
            {
                PlanData.Save(plan);
            }
            catch
            {
                throw new Exception("Error al registrar plan, intente nuevamente");
            }
        }

        public List<Plan> GetPlanesEsp(int idesp)
        {
            try
            {
                return PlanData.GetPlanesEsp(idesp);
            }
            catch
            {
                throw new Exception("Error al recuperar datos del plan, intente nuevamente");
            }

        }

        public Plan GetOne(int ID)
        {
            try
            {
                return PlanData.GetOne(ID);
            }
            catch
            {
                throw new Exception("Error al recuperar datos del plan, intente nuevamente");
            }
        }

        public List<Plan> GetAll()
        {
            try
            {
                return PlanData.GetAll();
            }
            catch
            {
                throw new Exception("Error al recuperar lista de planes, intente nuevamente");
            }
        }
    }
}
