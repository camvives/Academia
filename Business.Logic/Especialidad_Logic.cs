using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;

namespace Business.Logic
{
    public class Especialidad_Logic
    {
        public List<Especialidad> GetAll()
        {
            EspecialidadData.GetAll();
            return EspecialidadData.GetAll();
        }

    }
}
