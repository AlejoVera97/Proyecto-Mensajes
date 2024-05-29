using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class MsjComun : Mensaje
    {
        //Atributo de asociación
        TipoMsj codmsj;

        //propiedades

        public TipoMsj CodMsj
        {
            get { return codmsj; }
            set
            {
                if (value == null)
                    throw new Exception("Error - Se debe ingresar el tipo de mensaje.");
                else
                    codmsj = value;
            }
        }

        //contructor

        public MsjComun(int pNumInt, DateTime pFechaHora, string pAsunto, String pTexto, TipoMsj unTipo, Usuario pUsuarioEnvia, Usuario pUsuarioRecibe)
            : base(pNumInt, pFechaHora, pAsunto, pTexto, pUsuarioEnvia, pUsuarioRecibe)
        {
            CodMsj = unTipo;
        }

        //operacion

        public override string ToString()
        {
            string _completo = base.ToString() + " - Tipo de Mensaje: " + CodMsj;
            return _completo;
        }
    }
}
