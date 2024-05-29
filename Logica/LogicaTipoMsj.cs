using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using Persistencia;


namespace Logica
{
    public class LogicaTipoMsj
    {
        public static void AltaTipoMsj(TipoMsj unTipo)
        {
            PersistenciaTipoMsj.AltaTipoMsj(unTipo);
        }

        public static void BajaTipoMsj(TipoMsj unTipo)
        {
            PersistenciaTipoMsj.BajaTipoMsj(unTipo);
        }

        public static void ModificarTipoMsj(TipoMsj unTipo)
        {
            PersistenciaTipoMsj.ModificarTipoMsj(unTipo);
        }

        public static TipoMsj Buscar(string pCodInt)
        {
            return PersistenciaTipoMsj.Buscar(pCodInt);
        }

        public static List<TipoMsj> ListaTipos()
        {
            return PersistenciaTipoMsj.ListaTipos();
        }
    }
}
