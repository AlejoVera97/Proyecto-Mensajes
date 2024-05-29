using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data;
using EntidadesCompartidas;


namespace Persistencia
{
    public class PersistenciaMsjPrivado
    {
        public static int AltaMsjPrivado(MsjPrivado mPrivado)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("SP_ALTAMSJPRIVADO", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@Asunto", mPrivado.Asunto);
            oComando.Parameters.AddWithValue("@Texto", mPrivado.Texto);
            oComando.Parameters.AddWithValue("@FechaCad", mPrivado.FechaCad);
            oComando.Parameters.AddWithValue("@UsuarioEnvia", mPrivado.UsuarioEnvia.NombreUsuario);
            oComando.Parameters.AddWithValue("@UsuarioRecibe", mPrivado.UsuarioRecibe.NombreUsuario);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            int oAfectados = 0;
            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                oAfectados = (int)oComando.Parameters["Retorno"].Value;
                if (oAfectados == -1)
                    throw new Exception("ERROR - El usuarios que envía no existe.");
                else if (oAfectados == -2)
                    throw new Exception("ERROR - El usuario que recibe no existe.");
                else if (oAfectados == -3)
                    throw new Exception("ERROR - No se pudo cargar el mensaje.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oConexion.Close();
            }
            return oAfectados;
        }
    }
}
