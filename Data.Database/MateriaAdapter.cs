using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data.SqlClient;

namespace Data.Database
{
    public class MateriaAdapter : Adapter
    {

        public void Save(Materia materia)
        {
            if (materia.State == BusinessEntity.States.New)
            {
                this.Insert(materia);
            }
            else if (materia.State == BusinessEntity.States.Deleted)
            {
                this.Delete(materia.ID);
            }
            else if (materia.State == BusinessEntity.States.Modified)
            {
                this.Update(materia);
            }
        }

        public List<Materia> GetAll()
        {
            List<Materia> materias = new List<Materia>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdMaterias = new SqlCommand("SELECT * FROM materias", sqlConn);
                SqlDataReader drMaterias = cmdMaterias.ExecuteReader();

                while (drMaterias.Read())
                {
                    Materia mat = new Materia
                    {
                        ID = (int)drMaterias["id_materia"],
                        Descripcion = (string)drMaterias["desc_materia"],
                        HorasSemanales = (int)drMaterias["hs_semanales"],
                        HorasTotales = (int)drMaterias["hs_totales"], 
                        IDPlan = (int)drMaterias["id_plan"]
                    };

                    materias.Add(mat);
                }

                drMaterias.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.CloseConnection();
            }

            return materias;

        }



        public Materia GetOne(int ID)
        {
            Materia materia = new Materia();

            try
            {
                this.OpenConnection();

                SqlCommand cmdMaterias = new SqlCommand("SELECT * FROM materias WHERE id_materia=@id", sqlConn);
                cmdMaterias.Parameters.AddWithValue("id", ID);

                SqlDataReader drMaterias = cmdMaterias.ExecuteReader();

                if (drMaterias.Read())
                {
                    materia.ID = (int)drMaterias["id_materia"];
                    materia.Descripcion = (string)drMaterias["desc_materia"];
                    materia.HorasSemanales = (int)drMaterias["hs_semanales"];
                    materia.HorasTotales = (int)drMaterias["hs_totales"];
                    materia.IDPlan = (int)drMaterias["id_plan"];
                }

                drMaterias.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.CloseConnection();
            }

            return materia;
        }

        protected void Insert(Materia materia)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("INSERT INTO materias(desc_materia, hs_semanales, hs_totales, id_plan) " +
                                                                  "VALUES(@desc_materia, @hsSem, @hsTot, @id_plan)", sqlConn);

                cmdSave.Parameters.AddWithValue("@desc_materia", materia.Descripcion);
                cmdSave.Parameters.AddWithValue("@hsSem", materia.HorasSemanales);
                cmdSave.Parameters.AddWithValue("@hsTot", materia.HorasTotales);
                cmdSave.Parameters.AddWithValue("@id_plan", materia.IDPlan);
                materia.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteNonQuery());
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
                SqlCommand cmdDelete = new SqlCommand("DELETE FROM materias WHERE id_materia = @id", sqlConn);
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

        protected void Update(Materia materia)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE materias SET desc_materia = @desc_materia," +
                                                                            " hs_semanales = @hsSem, " +
                                                                            " hs_totales = @hsTot "
                                                                            + "WHERE id_materia = @id", sqlConn);

                cmdSave.Parameters.AddWithValue("@desc_materia", materia.Descripcion);
                cmdSave.Parameters.AddWithValue("@hsSem", materia.HorasSemanales);
                cmdSave.Parameters.AddWithValue("@hsTot", materia.HorasTotales);
                cmdSave.Parameters.AddWithValue("@id_plan", materia.IDPlan);
                cmdSave.Parameters.AddWithValue("@id", materia.ID);
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

        public List<Materia> GetMateriasPlan(int IDPlan)
        {
            List<Materia> materias = new List<Materia>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdMaterias = new SqlCommand("SELECT * FROM materias WHERE id_plan = @id", sqlConn);
                cmdMaterias.Parameters.AddWithValue("@id", IDPlan);
                SqlDataReader drMaterias = cmdMaterias.ExecuteReader();

                while (drMaterias.Read())
                {
                    Materia mat = new Materia
                    {
                        ID = (int)drMaterias["id_materia"],
                        Descripcion = (string)drMaterias["desc_materia"],
                        HorasSemanales = (int)drMaterias["hs_semanales"],
                        HorasTotales = (int)drMaterias["hs_totales"],
                        IDPlan = (int)drMaterias["id_plan"]
                    };

                    materias.Add(mat);
                }

                drMaterias.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.CloseConnection();
            }

            return materias;

        }
    }
}

