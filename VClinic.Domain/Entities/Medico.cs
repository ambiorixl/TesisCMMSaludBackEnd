using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VClinic.Domain.Entities;


public class Medico
{
    public long IdMedico { get;  set; }
    public long IdPersona { get; set; }

    public string NumeroColegiado { get; private set; } = default!;   
    public bool EstaActivo { get; private set; } = true;

    public DatosPersona Persona { get; private set; } = default!;

    protected Medico() { } // EF

    public Medico(long IdMedico, DatosPersona persona, string numeroColegiado)
    {
        this.IdMedico = IdMedico;
        Persona = persona ?? throw new ArgumentNullException(nameof(persona));

        ActualizarDatosMedico(numeroColegiado);
    }

    public void ActualizarDatosMedico(string numeroColegiado)
    {
        if (string.IsNullOrWhiteSpace(numeroColegiado))
            throw new ArgumentException("El número de colegiado es requerido.", nameof(numeroColegiado));
                
        NumeroColegiado = numeroColegiado.Trim();       
    }

    public void CambiarEstatus(bool estaActivo) => EstaActivo = estaActivo;
}