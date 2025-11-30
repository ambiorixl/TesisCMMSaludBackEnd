using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VClinic.Domain.Entities.Catalogos
{
    public class Genero
    {
        public int IdGenero { get; private set; }
        public string Codigo { get; private set; } = null!;  
        public string Nombre { get; private set; } = null!;  
        public bool EstaActivo { get; private set; } = true;
    }
}
