using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data.SqlClient;

namespace Data.Database
{
    public class PlanAdapter : Adapter
    {

        public void Save(Plan plan)
        {
            if (plan.State == BusinessEntity.States.New)
            {
                this.Insert(plan);
            }
            else if (plan.State == BusinessEntity.States.Deleted)
            {
                this.Delete(plan.ID);
            }
            else if (plan.State == BusinessEntity.States.Modified)
            {
                this.Update(plan);
            }
        }

        public Plan GetOne(int ID)
        {
            Plan plan = new Plan();
            try
            {
                this.OpenConnection();

                SqlCommand cmdPlanes = new SqlCommand("SELECT * FROM planes WHERE id_plan=@id", sqlConn);
                cmdPlanes.Parameters.AddWithValue("@id", ID);

                SqlDataReader drPlanes = cmdPlanes.ExecuteReader();

                if (drPlanes.Read())
                {
                    plan.ID = (int)drPlanes["id_plan"];
                    plan.Descripcion = (string)drPlanes["desc_plan"];
                    plan.IDEspecialidad = (int)drPlanes["id_especialidad"];
                }

                drPlanes.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.CloseConnection();
            }

            return plan;
        }

        public List<Plan> GetAll()
        {
            List<Plan> planes = new List<Plan>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdPlanes = new SqlCommand("SELECT * FROM planes", sqlConn);
                SqlDataReader drPlanes = cmdPlanes.ExecuteReader();

                while (drPlanes.Read())
                {
                    Plan plan = new Plan
                    {
                        ID = (int)drPlanes["id_plan"],
                        Descripcion = (string)drPlanes["desc_plan"],
                        IDEspecialidad = (int)drPlanes["id_especialidad"],
                        
                    };

                    planes.Add(plan);
                }

                drPlanes.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.CloseConnection();
            }

            return planes;

        }


        public List<Plan> GetPlanesEsp(int idesp)
        {
            List<Plan> planes = new List<Plan>();

            try
            {
                this.OpenConnection();
                SqlCommand cmdPlanesEsp = new SqlCommand("SELECT * FROM planes "
                                                       + "WHERE id_especialidad = @idesp", sqlConn);
                cmdPlanesEsp.Parameters.AddWithValue("@idesp", idesp);
                SqlDataReader drPlanes = cmdPlanesEsp.ExecuteReader();

                while (drPlanes.Read())
                {
                    Plan plan = new Plan()
                    {
                        ID = (int)drPlanes["id_plan"],
                        Descripcion = (string)drPlanes["desc_plan"]
                    };

                    planes.Add(plan);
                }

                drPlanes.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.CloseConnection();
            }

            return planes;
        }


        protected void Insert(Plan plan)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("INSERT INTO planes(desc_plan, id_especialidad) " +
                                                                  "VALUES(@desc_plan, @id_especialidad)", sqlConn);

                cmdSave.Parameters.AddWithValue("@desc_plan", plan.Descripcion);
                cmdSave.Parameters.AddWithValue("@id_especialidad", plan.IDEspecialidad);
                plan.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteNonQuery());
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
                SqlCommand cmdDelete = new SqlCommand("DELETE planes WHERE id_plan = @id", sqlConn);
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

        protected void Update(Plan plan)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE planes SET desc_plan = @desc_plan," +                                                                           
                                                                            " id_especialidad = @id_especialidad "
                                                                            + "WHERE id_plan = @id", sqlConn);

                cmdSave.Parameters.AddWithValue("@desc_plan", plan.Descripcion);
                cmdSave.Parameters.AddWithValue("@id_especialidad", plan.IDEspecialidad);               
                cmdSave.Parameters.AddWithValue("@id", plan.ID);
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
