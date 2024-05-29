using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data;
using EntidadesCompartidas;


namespace Persistencia
{
    public class PersistenciaTipoMsj
    {
        public static void AltaTipoMsj(TipoMsj unTipo)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("SP_ALTATIPOMSJ", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@CodInt", unTipo.CodMsj);
            oComando.Parameters.AddWithValue("@NombreCod", unTipo.NombCod);
            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                int oAfectados = (int)oComando.Parameters["@Retorno"].Value;
                if (oAfectados == -1)
                    throw new Exception("ERROR - El tipo de mensaje ya existe.");
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

        public static void BajaTipoMsj(TipoMsj unTipo)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("SP_ELIMINARTIPOMSJ", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter oCodInt = new SqlParameter("@CodInt", unTipo.CodMsj);
            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oCodInt);
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int oAfectados = (int)oComando.Parameters["@Retorno"].Value;
                if (oAfectados == -1)
                    throw new Exception("ERROR - El tipo de mensaje no existe");
                else if (oAfectados == -2)
                    throw new Exception("ERROR - El tipo de mensaje tiene mensajes asociados. No se elimina.");
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

        public static void ModificarTipoMsj(TipoMsj unTipo)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("SP_MODIFTIPOMSJ", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@CodInt", unTipo.CodMsj);
            oComando.Parameters.AddWithValue("@NombreCod", unTipo.NombCod);
            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                int oAfectados = (int)oComando.Parameters["@Retorno"].Value;
                if (oAfectados == -1)
                    throw new Exception("ERROR - El tipo de mensaje no existe, no se modifica.");
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

        public static TipoMsj Buscar(string pCodInt)
        {
            string oCodInt, oNombreCod;
            TipoMsj tm = null;
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("Exec SP_BUSCATIPOMSJ " + pCodInt, oConexion);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                if (oReader.Read())
                {
                    oCodInt = (string)oReader["CodigoInterno"];
                    oNombreCod = (string)oReader["NombreCodigo"];
                    tm = new TipoMsj(oCodInt, oNombreCod);
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
            return tm;
        }

        public static List<TipoMsj> ListaTipos()
        {
            string oCodInt, oNombreCod;
            List<TipoMsj> oListaTipos = new List<TipoMsj>();
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("Exec SP_LISTARTIPOMSJ", oConexion);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                while (oReader.Read())
                {
                    oCodInt = (string)oReader["CodigoInterno"];
                    oNombreCod = (string)oReader["NombreCodigo"];
                    TipoMsj tm = new TipoMsj(oCodInt, oNombreCod);
                    oListaTipos.Add(tm);
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
            return oListaTipos;
        }
    }
}
