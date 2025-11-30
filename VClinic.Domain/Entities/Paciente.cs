using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VClinic.Domain.Entities
{
    public class Paciente
    {
        public long IdPaciente { get; set; }
        public long IdPersona { get; set; }
        public DatosPersona Persona { get; set; } = null!;
        public int IdGrupoSangre { get; set; }

        public int IdHistorial { get; set; } = default!;
        public bool EstaActivo { get; set; } = true;

        private Paciente() { }

        public Paciente(DatosPersona persona, int historial, int idgrupoSangre)
        {
            Persona = persona ?? throw new ArgumentNullException(nameof(persona));
            ActualizarDatosPaciente(idgrupoSangre);
        }

        public void ActualizarDatosPaciente(int tipoSanguinio)
        {           
            IdGrupoSangre = tipoSanguinio;           
        }

        public void CambiarEstatus(bool estaActivo) => EstaActivo = estaActivo;
    }
}
