using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data;
using EntidadesCompartidas;

namespace Persistencia
{
    public class PersistenciaUsuario
    {
        public static void AltaUsuario(Usuario unUsuario)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("SP_ALTAUSUARIO", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@NombreUsu", unUsuario.NombreUsuario);
            oComando.Parameters.AddWithValue("@cedula", unUsuario.Cedula);
            oComando.Parameters.AddWithValue("@NombreCompl", unUsuario.NombreCompleto);
            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                int oAfectados = (int)oComando.Parameters["@Retorno"].Value;
                if (oAfectados == -1)
                    throw new Exception("ERROR - El Usuario ya existe.");
                else if (oAfectados == -2)
                    throw new Exception("ERROR");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oConexion.Close();
            }
        }

        public static void BajaUsuario(Usuario unUsuario)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("SP_ELIMINARUSUARIO", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter oNombreUsuario = new SqlParameter("@NombreUsuario", unUsuario.NombreUsuario);
            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oNombreUsuario);
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int oAfectados = (int)oComando.Parameters["@Retorno"].Value;
                if (oAfectados == -1)
                    throw new Exception("ERROR - El usuario no existe");
                else if (oAfectados == -2)
                    throw new Exception("ERROR - El usuario tiene mensajes - No se elimina.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oConexion.Close();
            }
        }

        public static void ModificarUsuario(Usuario unUsuario)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("SP_MODIFICARUSUARIO", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@NombreUsu", unUsuario.NombreUsuario);
            oComando.Parameters.AddWithValue("@cedula", unUsuario.Cedula);
            oComando.Parameters.AddWithValue("@NombreCompl", unUsuario.NombreCompleto);
            SqlParameter oRetorno = new SqlParameter("@oRetorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                int oAfectados = (int)oComando.Parameters["@Retorno"].Value;
                if (oAfectados == -1)
                    throw new Exception("ERROR - El Usuario no existe, no se modifica.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oConexion.Close();
            }
        }

        public static Usuario Buscar(string pNombreUsuario)
        {
            string oNombreUsuario, oNombreCompleto;
            int oCedula;
            Usuario u = null;
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("Exec SP_BUSCARUSUARIO " + pNombreUsuario, oConexion);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                if (oReader.Read())
                {
                    oNombreUsuario = (string)oReader["NombreUsuario"];
                    oCedula = (int)oReader["Cedula"];
                    oNombreCompleto = (string)oReader["NombreCompleto"];
                    u = new Usuario(oNombreUsuario, oCedula, oNombreCompleto);
                }
                oReader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oConexion.Close();
            }
            return u;
        }

        public static List<Usuario> ListaUsuarios()
        {
            string oNombreUsuario, oNombreCompleto;
            int oCedula;
            List<Usuario> oListaUsuarios = new List<Usuario>();
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("Exec SP_LISTARUSUARIOS", oConexion);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                while (oReader.Read())
                {
                    oNombreUsuario = (string)oReader["NombreUsuario"];
                    oCedula = (int)oReader["Cedula"];
                    oNombreCompleto = (string)oReader["NombreCompleto"];
                    Usuario u = new Usuario(oNombreUsuario, oCedula, oNombreCompleto);
                    oListaUsuarios.Add(u);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oConexion.Close();
            }
            return oListaUsuarios;
        }
    }
}
