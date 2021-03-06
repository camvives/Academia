﻿using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.Web.UI;

namespace UI.Web
{
    public partial class EstadoAcademico : System.Web.UI.Page
    {

        public Persona PersonaActual { get; set; }

        public Alumno_InscripcionLogic AILog
        {
            get { return new Alumno_InscripcionLogic(); }
        }

        public class DatosInscripciones
        {
            public int ID { get; set; }
            public int AnioCursado { get; set; }
            public string DescMateria { get; set; }
            public string DescComision { get; set; }
            public string Condicion { get; set; }
            public string Nota { get; set; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Persona.TiposPersonas)Session["Tipo"] != Persona.TiposPersonas.Alumno)
            {
                Response.Redirect("~/Login.aspx");
            }

            PersonaActual = (Persona)Session["Persona"];
            gdvEstAcademico.DataSource = this.ObtenerDatos();
            gdvEstAcademico.DataBind();
        }

        public List<DatosInscripciones> ObtenerDatos()
        {
            List<DatosInscripciones> datosInscripciones = new List<DatosInscripciones>();
            try
            {
                List<Alumno_Inscripcion> inscripciones = AILog.GetMateriasInscripto(PersonaActual.ID);

                foreach (Alumno_Inscripcion ai in inscripciones)
                {
                    DatosInscripciones datosInscripcion = new DatosInscripciones();
                    datosInscripcion.ID = ai.ID;
                    datosInscripcion.Condicion = ai.Condicion;
                    if (ai.Nota == 0)
                    {
                        datosInscripcion.Nota = "-";
                    }
                    else
                    {
                        datosInscripcion.Nota = ai.Nota.ToString();
                    }

                    CursoLogic cl = new CursoLogic();
                    Curso curso = cl.GetOne(ai.IDCurso);
                    datosInscripcion.AnioCursado = curso.AnioCalendario;

                    MateriaLogic ml = new MateriaLogic();
                    Materia materia = ml.GetOne(curso.IDMateria);
                    datosInscripcion.DescMateria = materia.Descripcion;

                    ComisionLogic cml = new ComisionLogic();
                    Comision comision = cml.GetOne(curso.IDComision);
                    datosInscripcion.DescComision = comision.Descripcion;

                    datosInscripciones.Add(datosInscripcion);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message + "')", true);

            }

            return datosInscripciones;
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session["Persona"] = PersonaActual;
            Response.Redirect("~/Main.aspx");
        }
    }
}