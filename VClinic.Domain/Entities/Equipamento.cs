using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VClinic.Domain.Enums;

namespace VClinic.Domain.Entities
{
    public class Equipamento
    {
        public int IdEquipamento { get; set; }
        public string Nombre { get; set; } = default!;
        public string Descripcion { get; set; } = default!;
        public int IdTipoEquipo { get; set; }
        public bool EstaActivo { get; set; } = true;    
    }
}
