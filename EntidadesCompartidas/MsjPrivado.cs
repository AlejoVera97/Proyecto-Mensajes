using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class MsjPrivado : Mensaje
    {
        //atributos
        private DateTime fechacad;

        // propiedades
        public DateTime FechaCad
        {
            get { return fechacad; }
            set 
            {
                if (FechaCad >= DateTime.Now)
                    fechacad = value;
                else
                    throw new Exception("ERROR - La fecha de caducidad debe ser posterior a hoy.");
            }
        }

        //contructor 
        public MsjPrivado(int pNumInt, DateTime pFechaHora, string pAsunto, String pTexto, DateTime pFechaCad, Usuario pUsuarioEnvia, Usuario pUsuarioRecibe)
            : base(pNumInt, pFechaHora, pAsunto, pTexto, pUsuarioEnvia, pUsuarioRecibe)
        {
            FechaCad = pFechaCad;
        }
        //operaciones 

        public override string ToString()
        {
            string _completo = base.ToString() + " - Fecha de Caducidad: " + FechaCad;

            return _completo;
        }
    }
}

