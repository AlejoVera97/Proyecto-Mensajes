using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using Persistencia;


namespace Logica
{
    public class LogicaUsuario
    {
        public static void AltaUsuario(Usuario unUsuario)
        {
            PersistenciaUsuario.AltaUsuario(unUsuario);
        }

        public static void BajaUsuario(Usuario unUsuario)
        {
            PersistenciaUsuario.BajaUsuario(unUsuario);
        }

        public static void ModificarUsuario(Usuario unUsuario)
        {
            PersistenciaUsuario.ModificarUsuario(unUsuario);
        }

        public static Usuario Buscar(string pNombreUsuario)
        {
            return PersistenciaUsuario.Buscar(pNombreUsuario);
        }

        public static List<Usuario> ListaUsuarios()
        {
            return PersistenciaUsuario.ListaUsuarios();
        }
    }
}
