using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data.SqlClient;


namespace Data.Database
{
    public class UsuarioAdapter : Adapter
    {
        public void Save(Usuario usuario, Persona persona)
        {
            if (usuario.State == BusinessEntity.States.New)
            {
                this.Insert(usuario, persona);
            }
            else if (usuario.State == BusinessEntity.States.Deleted)
            {
                this.Delete(usuario.ID, persona.ID);
            }
            else if(usuario.State == BusinessEntity.States.Modified)
            {
                this.Update(usuario, persona);
            }
        }

        public void Insert(Usuario usuario, Persona persona)
        {

                this.OpenConnection();

                SqlCommand cmdUsuario = sqlConn.CreateCommand();
                SqlTransaction transaction = sqlConn.BeginTransaction("InsertUsuario");
                cmdUsuario.Transaction = transaction;

            try
            {
                #region INSERT PERSONA
                cmdUsuario.CommandText = "INSERT INTO personas (nombre, apellido, direccion, email, telefono, fecha_nac, legajo, tipo_persona, id_plan) " +
                                                      "VALUES (@nombre, @apellido, @direccion, @email, @telefono, @fecha_nac, @legajo, @tipo_persona, @id_plan) " +
                                                      "SELECT CONVERT(int, SCOPE_IDENTITY())"; //Devuelve el id que se autogeneró
                cmdUsuario.Parameters.AddWithValue("@nombre", persona.Nombre);
                cmdUsuario.Parameters.AddWithValue("@apellido", persona.Apellido);
                cmdUsuario.Parameters.AddWithValue("@direccion", persona.Direccion);
                cmdUsuario.Parameters.AddWithValue("@email", persona.Email);
                cmdUsuario.Parameters.AddWithValue("@telefono", persona.Telefono);
                cmdUsuario.Parameters.AddWithValue("@fecha_nac", persona.FechaNacimiento);
                cmdUsuario.Parameters.AddWithValue("@tipo_persona", persona.TipoPersona);

                if (persona.IDPlan == 0)
                {
                    cmdUsuario.Parameters.AddWithValue("@id_plan", DBNull.Value);
                }
                else
                {
                    cmdUsuario.Parameters.AddWithValue("@id_plan", persona.IDPlan);
                }

                if (persona.Legajo == 0)
                {
                    cmdUsuario.Parameters.AddWithValue("@legajo", DBNull.Value);
                }
                else
                {
                    cmdUsuario.Parameters.AddWithValue("@legajo", persona.Legajo);
                }

                persona.ID = (int)cmdUsuario.ExecuteScalar();
                #endregion

                #region INSERT USUARIO
                cmdUsuario.CommandText = "INSERT INTO usuarios (nombre_usuario, clave, habilitado, id_persona)" +
                                                       "VALUES (@nombreUsuario, @clave, @habilitado, @id_persona)";
                cmdUsuario.Parameters.AddWithValue("@nombreUsuario", usuario.NombreUsuario);
                cmdUsuario.Parameters.AddWithValue("@clave", usuario.Clave);
                cmdUsuario.Parameters.AddWithValue("@habilitado", usuario.Habilitado);
                cmdUsuario.Parameters.AddWithValue("@id_persona", persona.ID);
                cmdUsuario.ExecuteNonQuery();
                #endregion

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

        public (List<Usuario>, List<Persona>) GetAll()
        {
            List<Persona> personas = new List<Persona>();
            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("SELECT * FROM usuarios us " +
                                                        "INNER JOIN personas per " +
                                                        "ON us.id_persona = per.id_persona", sqlConn);
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();

                while (drUsuarios.Read())
                {
                    Usuario usr = new Usuario();
                    Persona per = new Persona();

                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];

                    per.Apellido = (string)drUsuarios["apellido"];
                    per.Nombre = (string)drUsuarios["nombre"];
                    per.Email = (string)drUsuarios["email"];
                    
                    personas.Add(per);
                    usuarios.Add(usr);
                }

                drUsuarios.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.CloseConnection();
            }

            return (usuarios, personas);
            
        }

        public (Usuario, Persona) GetOne(int id)
        {
            Usuario usr = new Usuario();
            Persona per = new Persona();

            try
            {
                this.OpenConnection();
                SqlCommand cmdUsuario = new SqlCommand("SELECT * FROM usuarios us " +
                                                       "INNER JOIN personas per " +
                                                       "ON us.id_persona = per.id_persona " +
                                                       "WHERE @id = us.id_usuario", sqlConn);
                cmdUsuario.Parameters.AddWithValue("@id", id);
                SqlDataReader drUsuario = cmdUsuario.ExecuteReader();

                if (drUsuario.Read())
                {
                    usr.ID = (int)drUsuario["id_usuario"];
                    usr.NombreUsuario = (string)drUsuario["nombre_usuario"];
                    usr.Habilitado = (bool)drUsuario["habilitado"];
                    usr.Clave = (string)drUsuario["clave"];

                    per.ID = (int)drUsuario["id_persona"];
                    per.Apellido = (string)drUsuario["apellido"];
                    per.Nombre = (string)drUsuario["nombre"];
                    per.Direccion = (string)drUsuario["direccion"];
                    per.Email = (string)drUsuario["email"];
                    per.Telefono = (string)drUsuario["telefono"];
                    per.FechaNacimiento = (DateTime)drUsuario["fecha_nac"];
                    per.TipoPersona = (Persona.TiposPersonas)(int)drUsuario["tipo_persona"];

                    if (drUsuario["legajo"] is DBNull)
                    {
                        per.Legajo = 0;
                    }
                    else
                    {
                        per.Legajo = (int)drUsuario["legajo"];
                    }

                    if (drUsuario["id_plan"] is DBNull)
                    {
                        per.IDPlan = 0;
                    }
                    else
                    {
                        per.IDPlan = (int)drUsuario["id_plan"];
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

            return (usr, per);
        }

        protected void Delete(int IdUsr, int IdPer)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDeleteUsr = sqlConn.CreateCommand();
                SqlTransaction transaction = sqlConn.BeginTransaction("DeleteUsuario");
                cmdDeleteUsr.Transaction = transaction;

                try
                {
                    cmdDeleteUsr.CommandText = "DELETE FROM usuarios WHERE id_usuario=@id";
                    cmdDeleteUsr.Parameters.AddWithValue("@id", IdUsr);
                    cmdDeleteUsr.ExecuteNonQuery();

                    cmdDeleteUsr.CommandText = "DELETE FROM personas WHERE id_persona=@idper";
                    cmdDeleteUsr.Parameters.AddWithValue("@idper", IdPer);
                    cmdDeleteUsr.ExecuteNonQuery();

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
        }

        protected void Update(Usuario usuario, Persona persona)
        {

            this.OpenConnection();

            SqlCommand cmdUsuario = sqlConn.CreateCommand();
            SqlTransaction transaction = sqlConn.BeginTransaction("UpdateUsuario");
            cmdUsuario.Transaction = transaction;

            try
            {
                #region UPDATE PERSONA
                cmdUsuario.CommandText = "UPDATE personas SET nombre = @nombre," +
                                                            " apellido = @apellido," +
                                                            " direccion = @direccion," +
                                                            " email = @email," +
                                                            " telefono = @telefono," +
                                                            " fecha_nac = @fecha_nac," +
                                                            " legajo = @legajo," +
                                                            " tipo_persona = @tipo_persona," +
                                                            " id_plan = @id_plan " +
                                                            "WHERE id_persona = @idper";
                cmdUsuario.Parameters.AddWithValue("@idper", persona.ID);                                      
                cmdUsuario.Parameters.AddWithValue("@nombre", persona.Nombre);
                cmdUsuario.Parameters.AddWithValue("@apellido", persona.Apellido);
                cmdUsuario.Parameters.AddWithValue("@direccion", persona.Direccion);
                cmdUsuario.Parameters.AddWithValue("@email", persona.Email);
                cmdUsuario.Parameters.AddWithValue("@telefono", persona.Telefono);
                cmdUsuario.Parameters.AddWithValue("@fecha_nac", persona.FechaNacimiento);
                cmdUsuario.Parameters.AddWithValue("@tipo_persona", persona.TipoPersona);

                if (persona.IDPlan == 0)
                {
                    cmdUsuario.Parameters.AddWithValue("@id_plan", DBNull.Value);
                }
                else
                {
                    cmdUsuario.Parameters.AddWithValue("@id_plan", persona.IDPlan);
                }

                if (persona.Legajo == 0)
                {
                    cmdUsuario.Parameters.AddWithValue("@legajo", DBNull.Value);
                }
                else
                {
                    cmdUsuario.Parameters.AddWithValue("@legajo", persona.Legajo);
                }

                cmdUsuario.ExecuteNonQuery();
                #endregion

                #region INSERT USUARIO
                cmdUsuario.CommandText = "UPDATE usuarios SET nombre_usuario = @nombreUsuario," +
                                                           " clave = @clave," +
                                                           " habilitado = @habilitado," +
                                                           " id_persona = @id_persona" +
                                                           " WHERE id_usuario = @idus";

                cmdUsuario.Parameters.AddWithValue("@idus", usuario.ID);
                cmdUsuario.Parameters.AddWithValue("@nombreUsuario", usuario.NombreUsuario);
                cmdUsuario.Parameters.AddWithValue("@clave", usuario.Clave);
                cmdUsuario.Parameters.AddWithValue("@habilitado", usuario.Habilitado);
                cmdUsuario.Parameters.AddWithValue("@id_persona", persona.ID);
                cmdUsuario.ExecuteNonQuery();
                #endregion

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

        public (string, bool) GetClaveYHabilitado(string nombreUsuario)
        {
            string clave = null;
            bool habilitado = false;
            try
            {
                this.OpenConnection();
                SqlCommand cmdClave = new SqlCommand("SELECT clave, habilitado FROM usuarios " +
                                                       " WHERE @nombreUsuario = nombre_usuario", sqlConn);
                cmdClave.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
                SqlDataReader drClave = cmdClave.ExecuteReader();

                if (drClave.Read())
                {
                    clave = (string)drClave["clave"];
                    habilitado = (bool)drClave["habilitado"];
                    
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return (clave, habilitado);

        }

        public (Usuario, Persona) GetUsuario(string nombreUsuario)
        {
            Usuario usr = new Usuario();
            Persona per = new Persona();

            try
            {
                this.OpenConnection();
                SqlCommand cmdUsuario = new SqlCommand("SELECT * FROM usuarios us " +
                                                       "INNER JOIN personas per " +
                                                       "ON us.id_persona = per.id_persona " +
                                                       "WHERE @nombreUsuario = us.nombre_usuario", sqlConn);
                cmdUsuario.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
                SqlDataReader drUsuario = cmdUsuario.ExecuteReader();

                if (drUsuario.Read())
                {
                    usr.ID = (int)drUsuario["id_usuario"];
                    usr.NombreUsuario = (string)drUsuario["nombre_usuario"];
                    usr.Habilitado = (bool)drUsuario["habilitado"];
                    usr.Clave = (string)drUsuario["clave"];

                    per.ID = (int)drUsuario["id_persona"];
                    per.Apellido = (string)drUsuario["apellido"];
                    per.Nombre = (string)drUsuario["nombre"];
                    per.Direccion = (string)drUsuario["direccion"];
                    per.Email = (string)drUsuario["email"];
                    per.Telefono = (string)drUsuario["telefono"];
                    per.FechaNacimiento = (DateTime)drUsuario["fecha_nac"];
                    per.TipoPersona = (Persona.TiposPersonas)(int)drUsuario["tipo_persona"];

                    if (drUsuario["legajo"] is DBNull)
                    {
                        per.Legajo = 0;
                    }
                    else
                    {
                        per.Legajo = (int)drUsuario["legajo"];
                    }

                    if (drUsuario["id_plan"] is DBNull)
                    {
                        per.IDPlan = 0;
                    }
                    else
                    {
                        per.IDPlan = (int)drUsuario["id_plan"];
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

            return (usr, per);
        }


        public Persona GetPersona(int IDPersona)
        {
            Persona per = new Persona();

            try
            {
                this.OpenConnection();
                SqlCommand cmdDocente = new SqlCommand("SELECT * FROM personas " +
                                                       "WHERE @id = id_persona", sqlConn);
                cmdDocente.Parameters.AddWithValue("@id", IDPersona);
                SqlDataReader drDocente = cmdDocente.ExecuteReader();

                if (drDocente.Read())
                {
                    per.ID = (int)drDocente["id_persona"];
                    per.Apellido = (string)drDocente["apellido"];
                    per.Nombre = (string)drDocente["nombre"];
                    per.Legajo = (int)drDocente["legajo"];
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

            return per ;
        }

        public List<Persona> GetDocentes()
        {
            List<Persona> personas = new List<Persona>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("SELECT * FROM personas " +
                                                        "WHERE tipo_persona = 1", sqlConn);
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();

                while (drUsuarios.Read())
                {
                    Persona per = new Persona();

                    per.ID = (int)drUsuarios["id_persona"];
                    per.Apellido = (string)drUsuarios["apellido"];
                    per.Nombre = (string)drUsuarios["nombre"];
                    per.Legajo = (int)drUsuarios["legajo"];

                    personas.Add(per);
                }

                drUsuarios.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.CloseConnection();
            }

            return (personas);

        }

    }
}
