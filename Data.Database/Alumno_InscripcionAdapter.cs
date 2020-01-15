using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Business.Entities;


namespace Data.Database
{
    public class Alumno_InscripcionAdapter : Adapter
    {
        public void Save(Alumno_Inscripcion ai)
        {
            this.Insert(ai);
        }

        protected void Insert(Alumno_Inscripcion ai)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("INSERT INTO alumnos_inscripciones(id_alumno, id_curso, condicion) " +
                                                                  "VALUES(@id_alumno, @id_curso, @condicion)", sqlConn);

                cmdSave.Parameters.AddWithValue("@id_alumno", ai.IDAlumno);
                cmdSave.Parameters.AddWithValue("@id_curso", ai.IDCurso);
                cmdSave.Parameters.AddWithValue("@condicion", "Inscripto");
                ai.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteNonQuery());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public List<Alumno_Inscripcion> GetMateriasInscripto(int IDPersona)
        {
            List<Alumno_Inscripcion> inscripciones = new List<Alumno_Inscripcion>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdInscrpciones = new SqlCommand("SELECT * FROM alumnos_inscripciones WHERE id_alumno = @idPersona", sqlConn);

                cmdInscrpciones.Parameters.AddWithValue("@idPersona", IDPersona);
                SqlDataReader drInscripciones = cmdInscrpciones.ExecuteReader();

                while (drInscripciones.Read())
                {
                    Alumno_Inscripcion AlInsc = new Alumno_Inscripcion
                    {
                        ID = (int)drInscripciones["id_inscripcion"],
                        IDAlumno = (int)drInscripciones["id_alumno"],
                        IDCurso = (int)drInscripciones["id_curso"], 
                        Condicion = (string)drInscripciones["condicion"]
                                   
                    };

                    if (drInscripciones["nota"] != DBNull.Value)
                    {
                        AlInsc.Nota = (int)drInscripciones["nota"];
                    }


                    inscripciones.Add(AlInsc);
                }

                drInscripciones.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.CloseConnection();
            }

            return inscripciones;

        }

    }
}
