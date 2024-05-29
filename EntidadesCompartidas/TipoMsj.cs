using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class TipoMsj
    {
         private string codmsj;
        private string nombcod;

        //Propiedades

        public string CodMsj
        {
            set
            {
                if (value.Trim().Length != 3)
                    throw new Exception("ERROR - El código del tipo de mensaje debe contener 3 letras");
                else
                    codmsj = value;
            }
            get { return codmsj; }
            
        }

        public string NombCod
        {
            get { return nombcod; }
            set
            {
                if (value.Trim().Length > 3 && value.Length <= 20)
                    nombcod = value;
                else
                    throw new Exception("ERROR - El nombre de código de mensaje debe contener al menos 4 letras y no mas de 20");
            }
        }
    //Constructor

        public TipoMsj(string pCodMsj, string pNombCod)
        {
            CodMsj = pCodMsj;
            NombCod = pNombCod;
        }
        
        public override string  ToString()
        {
 	 return "Código de mensaje: " + CodMsj + "Nombre del código: " + NombCod;
        }
    }
}
