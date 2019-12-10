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
    }
}
