using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data.SqlClient;

namespace Data.Database
{
    public class Docente_CursoAdapter : Adapter
    {
        public List<Docentes_Cursos> GetDocentesPorCurso(int idCurso)
        {
            List<Docentes_Cursos> docentesCurso = new List<Docentes_Cursos>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdDocentes = new SqlCommand("SELECT * FROM docentes_cursos WHERE id_curso = @id", sqlConn);
                cmdDocentes.Parameters.AddWithValue("@id", idCurso);
                SqlDataReader drDocente = cmdDocentes.ExecuteReader();

                while (drDocente.Read())
                {
                    Docentes_Cursos doccur = new Docentes_Cursos()
                    {
                        ID = (int)drDocente["id_dictado"],
                        IDCurso = (int)drDocente["id_curso"],
                        IDDocente = (int)drDocente["id_docente"],
                        Cargo = (string)drDocente["cargo"]
                    };

                    docentesCurso.Add(doccur);
                }

                drDocente.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.CloseConnection();
            }

            return docentesCurso;

        }
    }
}
