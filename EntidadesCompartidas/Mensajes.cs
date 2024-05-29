using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public abstract class Mensaje
    {
        // atributos

        private int numint;
        private DateTime fechahora;
        private string asunto;
        private string texto;

        // atributos asociados
        Usuario usuarioenvia;
        Usuario usuariorecibe;

        // propiedades

        public int NumInt
        {
            get { return numint; }
            set { numint = value; }
        }

        public DateTime FechaHora
        {
            get { return fechahora; }
            set { fechahora = value; }
        }

        public String Asunto
        {
            get { return asunto; }
            set
            {
                if (value.Length > 0 && value.Length <= 50)
                    asunto = value;
                else
                    throw new Exception("ERROR - El Asunto no puede ser vacío ni tener mas de 50 caracteres.");
            }
        }

        public String Texto
        {
            get { return texto; }
            set
            {
                if (value.Length > 0 && value.Length <= 200)
                    texto = value;
                else
                    throw new Exception("ERROR - El Texto no puede ser vacío ni tener mas de 200 caracteres.");
            }
        }

        public Usuario UsuarioEnvia
        {
            get { return usuarioenvia; }
            set
            {
                if (value == null)
                    throw new Exception("ERROR - Es necesario ingresar el usuario que envía.");
                else
                    usuarioenvia = value;
            }
        }

        public Usuario UsuarioRecibe
        {
            get { return usuariorecibe; }
            set
            {
                if (value == null)
                    throw new Exception("ERROR - Es necesario ingresar el usuario que envía.");
                else
                    usuariorecibe = value;
            }
        }
        //constructores

        public Mensaje(int pNumInt, DateTime pFechaHora, string pAsunto, string pTexto, Usuario pUsuarioEnvia, Usuario pUsuarioRecibe)
        {
            NumInt = pNumInt;
            FechaHora = pFechaHora;
            Asunto = pAsunto;
            Texto = pTexto;
            UsuarioEnvia = pUsuarioEnvia;
            UsuarioRecibe = pUsuarioRecibe;
        }
        // Operaciones

        public override string ToString()
        {
            return ("- Numero interno: " + NumInt + " - Fecha y Hora: " + FechaHora + " - Usuario Envía: " + UsuarioEnvia + " - Usuario Recibe: " + UsuarioRecibe + " - Asunto: " + Asunto + " - Texto de Mensaje: " + Texto);
        }
    }
}