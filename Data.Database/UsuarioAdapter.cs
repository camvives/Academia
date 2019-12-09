﻿using System;
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
                SqlCommand cmdUsuarios = new SqlCommand("SELECT * FROM usuarios us INNER JOIN personas per ON us.id_persona = per.id_persona", sqlConn);
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();

                while (drUsuarios.Read())
                {
                    Usuario usr = new Usuario();
                    Persona per = new Persona();

                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Clave = (string)drUsuarios["clave"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];

                    per.ID = (int)drUsuarios["id_persona"];
                    per.Apellido = (string)drUsuarios["apellido"];
                    per.Nombre = (string)drUsuarios["nombre"];
                    per.Direccion = (string)drUsuarios["direccion"];
                    per.Email = (string)drUsuarios["email"];
                    per.Telefono = (string)drUsuarios["telefono"];
                    per.FechaNacimiento = (DateTime)drUsuarios["fecha_nac"];
                    //per.Legajo = (int)drUsuarios["legajo"];
                    ////AGREGAR TIPO PERSONA
                    //per.IDPlan = (int)drUsuarios["id_plan"];

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
    }
}