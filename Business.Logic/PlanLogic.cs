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

        public List<Plan> GetPlanesEsp(int idesp)
        {
            return PlanData.GetPlanesEsp(idesp);
        }

        public Plan GetOne(int ID)
        {
            return PlanData.GetOne(ID);
        }

    }
}
