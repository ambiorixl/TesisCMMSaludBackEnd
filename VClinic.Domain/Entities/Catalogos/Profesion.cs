using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VClinic.Domain.Entities.Catalogos
{
    public class Profesion
    {
        public int IdProfesion { get; set; }        
        public string Nombre { get; set; } = null!;
        public bool EstaActivo { get; set; } = true;
    }
}
