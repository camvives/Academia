using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class EspecialidadAdapter : Adapter
    {
        public void Save(Especialidad especialidad)
        {
            if (especialidad.State == BusinessEntity.States.New)
            {
                this.Insert(especialidad);
            }
            else if (especialidad.State == BusinessEntity.States.Deleted)
            {
                this.Delete(especialidad.ID);
            }
            else if (especialidad.State == BusinessEntity.States.Modified)
            {
                this.Update(especialidad);
            }
        }

        public List<Especialidad> GetAll()
        {
            List<Especialidad> especialidades = new List<Especialidad>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdEspecialidades = new SqlCommand("SELECT * FROM especialidades", sqlConn);
                SqlDataReader drEspecialidades = cmdEspecialidades.ExecuteReader();

                while (drEspecialidades.Read())
                {
                    Especialidad esp = new Especialidad
                    {
                        ID = (int)drEspecialidades["id_especialidad"],
                        Descripcion = (string)drEspecialidades["desc_especialidad"]
                    };

                    especialidades.Add(esp);
                }

                drEspecialidades.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.CloseConnection();
            }

            return especialidades;

        }

        public Especialidad GetOne(int ID)
        {
            Especialidad especialidad = new Especialidad();
            try
            {
                this.OpenConnection();

                SqlCommand cmdEspecialidades = new SqlCommand("SELECT * FROM especialidades WHERE id_especialidad=@id", sqlConn);
                cmdEspecialidades.Parameters.AddWithValue("id", ID);

                SqlDataReader drEspecialidades = cmdEspecialidades.ExecuteReader();

                if (drEspecialidades.Read())
                {
                    especialidad.ID = (int)drEspecialidades["id_especialidad"];
                    especialidad.Descripcion = (string)drEspecialidades["desc_especialidad"];
                }

                drEspecialidades.Close();
            }
            catch (Exception ex)
            {
                Exception exception = new Exception("Error al recuperar datos de especialidad", ex);
                throw exception;
            }
            finally
            {
                this.CloseConnection();
            }

            return especialidad;
        }

        protected void Insert(Especialidad especialidad)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("INSERT INTO especialidades(desc_especialidad) " +
                                                                  "VALUES(@desc_especialidad)", sqlConn);

                cmdSave.Parameters.Add("@desc_especialidad", SqlDbType.VarChar, 50).Value = especialidad.Descripcion;
                especialidad.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteNonQuery());
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
                SqlCommand cmdDelete = sqlConn.CreateCommand();
                SqlTransaction transaction = sqlConn.BeginTransaction("DeleteEspecialidades");
                cmdDelete.Transaction = transaction;

                try
                {
                    cmdDelete.Parameters.AddWithValue("@id", Id);

                    cmdDelete.CommandText = "DELETE FROM alumnos_inscripciones WHERE id_alumno IN (SELECT id_persona FROM personas per" +
                                                                                          " INNER JOIN planes pl on per.id_plan = pl.id_plan" +
                                                                                          "  WHERE pl.id_especialidad=@id)";
                    cmdDelete.ExecuteNonQuery();

                    cmdDelete.CommandText = "DELETE FROM usuarios WHERE id_persona IN (SELECT id_persona FROM personas per" +
                                                                                          " INNER JOIN planes pl on per.id_plan = pl.id_plan" +
                                                                                          "  WHERE pl.id_especialidad=@id)";
                    cmdDelete.ExecuteNonQuery();

                    cmdDelete.CommandText = "DELETE FROM personas WHERE id_plan IN (SELECT id_plan FROM planes WHERE id_especialidad = @id)";
                    cmdDelete.ExecuteNonQuery();

                    cmdDelete.CommandText = "DELETE FROM docentes_cursos WHERE id_curso IN (SELECT cur.id_curso " +
                                                                                      " FROM cursos cur " +
                                                                                      "INNER JOIN materias mat on cur.id_materia = mat.id_materia" +
                                                                                      " INNER JOIN planes pl on pl.id_plan = mat.id_plan" +
                                                                                      " WHERE pl.id_especialidad = @id)";
                    cmdDelete.ExecuteNonQuery();

                    cmdDelete.CommandText = "DELETE FROM cursos WHERE id_materia IN (SELECT id_materia FROM materias mat " +
                                                                                          " INNER JOIN planes pl ON mat.id_plan = pl.id_plan" +
                                                                                          " WHERE pl.id_especialidad=@id)";
                    cmdDelete.ExecuteNonQuery();

              

                    cmdDelete.CommandText = "DELETE FROM materias WHERE id_plan IN (SELECT id_plan FROM planes WHERE id_especialidad = @id)";
                    cmdDelete.ExecuteNonQuery();

                    cmdDelete.CommandText = "DELETE FROM comisiones WHERE id_plan IN (SELECT id_plan FROM planes WHERE id_especialidad = @id)";
                    cmdDelete.ExecuteNonQuery();

                    cmdDelete.CommandText = "DELETE FROM planes WHERE id_especialidad=@id";
                    cmdDelete.ExecuteNonQuery();

                    cmdDelete.CommandText = "DELETE FROM especialidades WHERE id_especialidad=@id";
                    cmdDelete.ExecuteNonQuery();

                    transaction.Commit();

                }
                catch (Exception ex1)
                {
                    try
                    {
                        transaction.Rollback();
                        throw ex1;
                    }
                    catch (Exception ex2)
                    {
                        throw ex2;
                    }
                }

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

        protected void Update(Especialidad especialidad)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE especialidades SET desc_especialidad = @desc_especialidad "
                    + "WHERE id_especialidad = @id", sqlConn);
                cmdSave.Parameters.Add("id", SqlDbType.Int).Value = especialidad.ID;
                cmdSave.Parameters.Add("@desc_especialidad", SqlDbType.VarChar, 50).Value = especialidad.Descripcion;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception exception = new Exception("Error al modificar los datos de la especialidad", ex);
                throw exception;
            }
            finally
            {
                this.CloseConnection();
            }
        }
    }
}
