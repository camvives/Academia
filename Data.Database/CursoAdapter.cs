using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data.SqlClient;

namespace Data.Database
{
    public class CursoAdapter : Adapter
    {
        public void Save(Curso curso)
        {
            if (curso.State == BusinessEntity.States.New)
            {
                this.Insert(curso);
            }
            else if (curso.State == BusinessEntity.States.Deleted)
            {
                this.Delete(curso.ID);
            }
            else if (curso.State == BusinessEntity.States.Modified)
            {
                this.Update(curso);
            }
        }

        public List<Curso> GetAll()
        {
            List<Curso> cursos = new List<Curso>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdCursos = new SqlCommand("SELECT * FROM cursos", sqlConn);
                SqlDataReader drCursos = cmdCursos.ExecuteReader();

                while (drCursos.Read())
                {
                    Curso cur = new Curso
                    {
                        ID = (int)drCursos["id_curso"],
                        IDMateria = (int)drCursos["id_materia"],
                        IDComision = (int)drCursos["id_comision"],
                        AnioCalendario = (int)drCursos["anio_calendario"],
                        Cupo = (int)drCursos["cupo"]
                    };

                    cursos.Add(cur);
                }

                drCursos.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.CloseConnection();
            }

            return cursos;

        }

        public Curso GetOne(int ID)
        {
            Curso curso = new Curso();

            try
            {
                this.OpenConnection();

                SqlCommand cmdCursos = new SqlCommand("SELECT * FROM cursos WHERE id_curso=@id", sqlConn);
                cmdCursos.Parameters.AddWithValue("id", ID);

                SqlDataReader drCursos = cmdCursos.ExecuteReader();

                if (drCursos.Read())
                {
                    curso.ID = (int)drCursos["id_curso"];
                    curso.IDMateria = (int)drCursos["id_materia"];
                    curso.IDComision = (int)drCursos["id_comision"];
                    curso.AnioCalendario = (int)drCursos["anio_calendario"];
                    curso.Cupo = (int)drCursos["cupo"];
                }

                drCursos.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.CloseConnection();
            }

            return curso;
        }

        protected void Insert(Curso curso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("INSERT INTO cursos(id_materia, id_comision, anio_calendario, cupo) " +
                                                                  "VALUES(@id_materia, @id_comision, @anioCalendario, @cupo)", sqlConn);

                cmdSave.Parameters.AddWithValue("@id_materia", curso.IDMateria);
                cmdSave.Parameters.AddWithValue("@id_comision", curso.IDComision);
                cmdSave.Parameters.AddWithValue("@anioCalendario", curso.AnioCalendario);
                cmdSave.Parameters.AddWithValue("@cupo", curso.Cupo);
                curso.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteNonQuery());
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
                SqlCommand cmdDelete = new SqlCommand("DELETE FROM cursos WHERE id_curso = @id", sqlConn);
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

        protected void Update(Curso curso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE cursos SET id_materia = @id_materia," +
                                                                            " id_comision = @id_comision, " +
                                                                            " anio_calendario = @anioCalendario " +
                                                                            " cupo = @cupo "
                                                                            + "WHERE id_curso = @id", sqlConn);

                cmdSave.Parameters.AddWithValue("@id_materia", curso.IDMateria);
                cmdSave.Parameters.AddWithValue("@id_comision", curso.IDComision);
                cmdSave.Parameters.AddWithValue("@anioCalendario", curso.AnioCalendario);
                cmdSave.Parameters.AddWithValue("@cupo", curso.Cupo);
                cmdSave.Parameters.AddWithValue("@id", curso.ID);
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

        public List<Curso> GetCursosUsuario(int IDPlan)
        {
            List<Curso> cursos = new List<Curso>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdCursos = new SqlCommand("SELECT * FROM cursos WHERE anio_calendario = @anio " +
                                                   " AND id_materia IN (SELECT id_materia FROM materias WHERE id_plan = @id)", sqlConn);
                cmdCursos.Parameters.AddWithValue("@anio", DateTime.Today.Year);
                cmdCursos.Parameters.AddWithValue("id", IDPlan);
                SqlDataReader drCursos = cmdCursos.ExecuteReader();

                while (drCursos.Read())
                {
                    Curso cur = new Curso
                    {
                        ID = (int)drCursos["id_curso"],
                        IDMateria = (int)drCursos["id_materia"],
                        IDComision = (int)drCursos["id_comision"],
                        AnioCalendario = (int)drCursos["anio_calendario"],
                        Cupo = (int)drCursos["cupo"]
                    };

                    cursos.Add(cur);
                }

                drCursos.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.CloseConnection();
            }

            return cursos;

        }

    }
}
