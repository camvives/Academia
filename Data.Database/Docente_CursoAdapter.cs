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
        public void Save(Docentes_Cursos docCur)
        {
            if (docCur.State == BusinessEntity.States.New)
            {
                this.Insert(docCur);
            }
            else if (docCur.State == BusinessEntity.States.Deleted)
            {
                this.Delete(docCur.ID);
            }
            else if (docCur.State == BusinessEntity.States.Modified)
            {
                this.Update(docCur);
            }
        }

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

        public Docentes_Cursos GetOne(int ID)
        {
            Docentes_Cursos docCurso = new Docentes_Cursos();

            try
            {
                this.OpenConnection();

                SqlCommand cmdDocCursos = new SqlCommand("SELECT * FROM docentes_cursos WHERE id_dictado=@id", sqlConn);
                cmdDocCursos.Parameters.AddWithValue("id", ID);

                SqlDataReader drDocCursos = cmdDocCursos.ExecuteReader();

                if (drDocCursos.Read())
                {
                    docCurso.ID = (int)drDocCursos["id_dictado"];
                    docCurso.IDCurso = (int)drDocCursos["id_curso"];
                    docCurso.IDDocente = (int)drDocCursos["id_docente"];
                    docCurso.Cargo = (string)drDocCursos["cargo"];
                }

                drDocCursos.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.CloseConnection();
            }

            return docCurso;
        }


        protected void Insert(Docentes_Cursos docCurso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("INSERT INTO docentes_cursos(id_curso, id_docente, cargo) " +
                                                                  "VALUES(@id_curso, @id_docente, @cargo)", sqlConn);

                cmdSave.Parameters.AddWithValue("@id_curso", docCurso.IDCurso);
                cmdSave.Parameters.AddWithValue("@id_docente", docCurso.IDDocente);
                cmdSave.Parameters.AddWithValue("@cargo", docCurso.Cargo);
                docCurso.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteNonQuery());
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

        protected void Delete(int Id)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("DELETE FROM docentes_cursos WHERE id_dictado = @id", sqlConn);
                cmdDelete.Parameters.AddWithValue("@id", Id);
                cmdDelete.ExecuteNonQuery();
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

        protected void Update(Docentes_Cursos docCurso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE docentes_cursos SET id_curso = @id_curso," +
                                                                            " id_docente = @id_docente, " +
                                                                            " cargo = @cargo " +
                                                                            "WHERE id_dictado = @id", sqlConn);

                cmdSave.Parameters.AddWithValue("@id_curso", docCurso.IDCurso);
                cmdSave.Parameters.AddWithValue("@id_docente", docCurso.IDDocente);
                cmdSave.Parameters.AddWithValue("@cargo", docCurso.Cargo);
                cmdSave.Parameters.AddWithValue("@id", docCurso.ID);
                cmdSave.ExecuteNonQuery();
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
