using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Usuario
    {
        //atributos
        private string nombreusuario;
        private int cedula;
        private string nombrecompleto;


        //propiedades

        public string NombreUsuario
        {
            get { return nombreusuario; }
            set
            {
                if (value.Length > 0 && value.Length <= 10)
                    nombreusuario = value;
                else
                    throw new Exception("ERROR - El Nombre de Usuario no puede ser vacío ni tener mas de 10 caracteres.");
            }
        }

        public int Cedula
        {
            get { return cedula; }
            set
            {
                if (value > 0)
                    cedula = value;
                else
                    throw new Exception("ERROR - El número de cedula no puede estar vacío.");
            }
        }

        public string NombreCompleto
        {
            get { return nombrecompleto; }
            set
            {
                if (value.Length > 0 && value.Length <= 50)
                    nombrecompleto = value;
                else
                    throw new Exception("ERROR - El Nombre Completo no puede ser vacío ni tener mas de 50 caracteres.");
            }
        }
        //constructores

        public Usuario (string pNombreUsuario, int pCedula, string pNombreCompleto)
        {
            NombreUsuario = pNombreUsuario;
            Cedula = pCedula;
            NombreCompleto = pNombreCompleto;
        }

        //operacion       
        public override string ToString()
        {
            return "Nombre de Usuario" + nombreusuario +"Cédula" + cedula + "Nombre Completo" + nombrecompleto;
        }

    }
}