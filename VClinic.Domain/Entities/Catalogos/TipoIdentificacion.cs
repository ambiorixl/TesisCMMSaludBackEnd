using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VClinic.Domain.Entities.Catalogos
{
    public class TipoIdentificacion
    {
        public int IdTipoIdentificacion { get; private set; }
        public string Codigo { get; private set; } = null!;  // "CEDULA", "PASAPORTE"
        public string Nombre { get; private set; } = null!;  // "Cédula de Identidad", etc.
        public bool EstaActivo { get; private set; } = true;

        private TipoIdentificacion() { }

        public TipoIdentificacion(string codigo, string nombre)
        {
            ActualizarDatos(codigo, nombre, true);
        }

        public void ActualizarDatos(string codigo, string nombre, bool estaActivo)
        {
            if (string.IsNullOrWhiteSpace(codigo))
                throw new ArgumentException("El código es obligatorio.", nameof(codigo));
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre es obligatorio.", nameof(nombre));

            Codigo = codigo.Trim().ToUpperInvariant();
            Nombre = nombre.Trim();
            EstaActivo = estaActivo;
        }

        public void Activar() => EstaActivo = true;
        public void Desactivar() => EstaActivo = false;
    }
}
