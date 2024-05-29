using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaMensaje
    {
        public static void AgregarMsj(Mensaje unMsj)
        {
            if (unMsj is MsjComun)
                PersistenciaMsjComun.AltaMsjComun((MsjComun)unMsj);
            else
                PersistenciaMsjPrivado.AltaMsjPrivado((MsjPrivado)unMsj);
            
        }

       
    }
}
