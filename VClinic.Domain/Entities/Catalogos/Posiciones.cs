using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VClinic.Domain.Entities.Catalogos
{
    public class Posiciones
    {
        public int IdPosicion { get; set; }
        public int IdDepartamento { get; set; }
        public string Nombre { get; set; } = null!;
        public int Nivel { get; set; }
        public bool EstaActivo { get; set; } = true;
    }
}
