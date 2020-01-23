using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data.SqlClient;


namespace Data.Database
{
    public class ComisionAdapter : Adapter
    {
        public void Save(Comision comision)
        {
            if (comision.State == BusinessEntity.States.New)
            {
                this.Insert(comision);
            }
            else if (comision.State == BusinessEntity.States.Deleted)
            {
                this.Delete(comision.ID);
            }
            else if (comision.State == BusinessEntity.States.Modified)
            {
                this.Update(comision);
            }
        }

        public List<Comision> GetAll()
        {
            List<Comision> comisiones = new List<Comision>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdComisiones = new SqlCommand("SELECT * FROM comisiones", sqlConn);
                SqlDataReader drComisiones = cmdComisiones.ExecuteReader();

                while (drComisiones.Read())
                {
                    Comision com = new Comision
                    {
                        ID = (int)drComisiones["id_comision"],
                        Descripcion = (string)drComisiones["desc_comision"],
                        AnioEspecialidad = (int)drComisiones["anio_especialidad"],
                        IDPlan = (int)drComisiones["id_plan"]
                    };

                    comisiones.Add(com);
                }

                drComisiones.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.CloseConnection();
            }

            return comisiones;

        }



        public Comision GetOne(int ID)
        {
            Comision comision = new Comision();

            try
            {
                this.OpenConnection();

                SqlCommand cmdComisiones = new SqlCommand("SELECT * FROM comisiones WHERE id_comision=@id", sqlConn);
                cmdComisiones.Parameters.AddWithValue("id", ID);

                SqlDataReader drComisiones = cmdComisiones.ExecuteReader();

                if (drComisiones.Read())
                {
                    comision.ID = (int)drComisiones["id_comision"];
                    comision.Descripcion = (string)drComisiones["desc_comision"];
                    comision.AnioEspecialidad = (int)drComisiones["anio_especialidad"];
                    comision.IDPlan = (int)drComisiones["id_plan"];
                }

                drComisiones.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.CloseConnection();
            }

            return comision;
        }

        protected void Insert(Comision comision)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("INSERT INTO comisiones(desc_comision, anio_especialidad, id_plan) " +
                                                                  "VALUES(@desc_comision, @anio_especialidad, @id_plan)", sqlConn);

                cmdSave.Parameters.AddWithValue("@desc_comision", comision.Descripcion);
                cmdSave.Parameters.AddWithValue("@anio_especialidad", comision.AnioEspecialidad);
                cmdSave.Parameters.AddWithValue("@id_plan", comision.IDPlan);
                comision.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteNonQuery());
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
                SqlTransaction transaction = sqlConn.BeginTransaction("DeleteMateria");
                cmdDelete.Transaction = transaction;

                try
                {
                    cmdDelete.Parameters.AddWithValue("@id", Id);

                    cmdDelete.CommandText = "DELETE FROM alumnos_inscripciones WHERE id_curso IN (SELECT id_curso FROM cursos WHERE id_comision = @id)";
                    cmdDelete.ExecuteNonQuery();

                    cmdDelete.CommandText = "DELETE FROM docentes_cursos WHERE id_curso IN(SELECT id_curso FROM cursos WHERE id_comision = @id)";
                    cmdDelete.ExecuteNonQuery();

                    cmdDelete.CommandText = "DELETE FROM cursos WHERE id_comision=@id";
                    cmdDelete.ExecuteNonQuery();

                    cmdDelete.CommandText = "DELETE FROM comisiones WHERE id_comision = @id";
                    cmdDelete.ExecuteNonQuery();

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    try
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                    catch (Exception ex2)
                    {
                        throw ex2;
                    }
                }
            }
            catch (Exception ex3)
            {
                throw ex3;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(Comision comision)
            {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE comisiones SET desc_comision = @desc_comision," +
                                                                            " anio_especialidad = @anio_especialidad, " +
                                                                            " id_plan = @id_plan "
                                                                            + "WHERE id_comision = @id", sqlConn);

                cmdSave.Parameters.AddWithValue("@desc_comision", comision.Descripcion);
                cmdSave.Parameters.AddWithValue("@anio_especialidad", comision.AnioEspecialidad);
                cmdSave.Parameters.AddWithValue("@id_plan", comision.IDPlan);
                cmdSave.Parameters.AddWithValue("@id", comision.ID);
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

        public List<Comision> GetComisionesMat(int IDPlan)
        {
            List<Comision> comisiones = new List<Comision>();

            try
            {
                this.OpenConnection();
                SqlCommand cmdComisiones = new SqlCommand("SELECT * FROM comisiones WHERE id_plan = @id", sqlConn);
                cmdComisiones.Parameters.AddWithValue("@id", IDPlan);

                SqlDataReader drComisiones = cmdComisiones.ExecuteReader();

                while (drComisiones.Read())
                {
                    Comision com = new Comision
                    {
                        ID = (int)drComisiones["id_comision"],
                        Descripcion = (string)drComisiones["desc_comision"],
                        AnioEspecialidad = (int)drComisiones["anio_especialidad"],
                        IDPlan = (int)drComisiones["id_plan"]
                    };

                    comisiones.Add(com);
                }

                drComisiones.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.CloseConnection();
            }

            return comisiones;
        }
    }

}

