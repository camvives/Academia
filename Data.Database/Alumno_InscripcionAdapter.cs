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


    }
}
