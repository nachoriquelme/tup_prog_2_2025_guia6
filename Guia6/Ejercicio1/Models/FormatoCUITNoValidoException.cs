using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1.Models
{
    public class FormatoCUITNoValidoException : ApplicationException
    {
        public FormatoCUITNoValidoException() : base("El CUIT debe tener 11 dígitos numéricos y se debe verificar con el digito verificador.")
        { }

        public FormatoCUITNoValidoException(string message) : base(message)
        { }

        public FormatoCUITNoValidoException(string message, Exception inner) : base(message, inner)
        { }
    }
}
