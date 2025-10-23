using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ejercicio1.Models
{
    public class Persona : IComparable<Persona>
    {
        protected string nombre;
        public string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                Match match = Regex.Match(value, @"^\s*(?<apellido>[\p{L}\s]{2,}?),\s*(?<nombres>[\p{L}\s]{2,})\s*$");
                if (match.Success == false)
                {
                    throw new FormatoNombreNoValidoException();
                }
                nombre = value;
            }
        }
        public Persona(string nombre)
        {
            this.nombre = nombre;
        }
        public virtual string Describir()
        {
            return nombre;
        }

        public int CompareTo(Persona obj)
        {
            if (obj == null)
            {
                return nombre.CompareTo(obj.nombre);
            }
            return -1;
        }
    }
}
