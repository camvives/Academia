﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class Alumno_InscripcionLogic
    {
        public Alumno_InscripcionAdapter AlumInscData { get; set; }

        public Alumno_InscripcionLogic()
        {
            AlumInscData = new Alumno_InscripcionAdapter();
        }

        public void Save(Alumno_Inscripcion ai)
        {
            AlumInscData.Save(ai);
        }

    }
}
