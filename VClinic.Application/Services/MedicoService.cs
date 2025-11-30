// VClinic.Application/Services/MedicoService.cs
using VClinic.Application.Abstractions;
using VClinic.Application.Common.Exceptions;
using VClinic.Application.DTOs.Medico;
using VClinic.Application.DTOs.Persona;
using VClinic.Application.Services;
using VClinic.Domain.Entities;
using VClinic.Infrastructure.Repositories;

namespace VClinic.Application.Services;

public sealed class MedicoService
{
    private readonly IPersonaService _personaService;
    private readonly IPersonaRepository _personaRepository;
    private readonly IMedicoRepository _medicoRepository;

    public MedicoService(
        IPersonaService personaService,
        IPersonaRepository personaRepository,
        IMedicoRepository medicoRepository)
    {
        _personaService = personaService;
        _personaRepository = personaRepository;
        _medicoRepository = medicoRepository;
    }

    public async Task<long> CrearMedicoAsync(MedicoInsDto request, CancellationToken ct = default)
    {
        // 1. Obtener o crear Persona
        var persona = await _personaService.GetOrCreatePersonaAsync(request, ct);

        // 2. Verificar si ya es médico
        var yaEsMedico = await _medicoRepository.ExistsByPersonaIdAsync(persona.IdPersona, ct);
        if (yaEsMedico)
            throw new ConflictException("Esta persona ya está registrada como médico.");

        // 2. Verificar si ya el Id del médico esta usado por otro
        var s4Existe = await _medicoRepository.ExistsByNroColegiadoAsync(0, request.NumeroColegiado, ct);
        if (s4Existe)
            throw new ConflictException("El numero colegiado ya está registrado para otro medico.");

        // 3. Crear médico
        var medico = new Medico(0, persona, request.NumeroColegiado);

        await _medicoRepository.AddAsync(medico, ct);
        await _medicoRepository.SaveChangesAsync(ct);

        return medico.IdMedico;
    }

    public async Task<List<MedicoLstDto>> GetAllAsync(CancellationToken ct = default)
    {
        var medicos = await _medicoRepository.GetAllWithPersonaAsync(ct);

        return medicos.Select(m => new MedicoLstDto
        {
            IdMedico = m.IdMedico,
            Nombres = m.Persona.Nombres,
            Apellidos = m.Persona.Apellidos,
            Telefono = m.Persona.Telefono,
            Celular = m.Persona.Celular,
            Email = m.Persona.Email,
            NumeroColegiado = m.NumeroColegiado,
            EstaActivo = m.EstaActivo
        }).ToList();
    }

    public async Task<MedicoDetailDto?> GetByIdAsync(long idMedico, CancellationToken ct = default)
    {
        var medico = await _medicoRepository.GetByIdWithPersonaAsync(idMedico, ct);
        if (medico is null) return null;

        return new MedicoDetailDto
        {
            IdMedico = medico.IdMedico,
            // Persona
            Nombres = medico.Persona.Nombres,
            Apellidos = medico.Persona.Apellidos,
            FechaNacimiento = medico.Persona.FechaNacimiento,
            Telefono = medico.Persona.Telefono,
            Celular = medico.Persona.Celular,
            Email = medico.Persona.Email,
            Direccion = medico.Persona.Direccion,
            IdTipoIdentificacion = (int)medico.Persona.IdTipoIdentificacion,
            NumeroIdentificacion = medico.Persona.NumeroIdentificacion,
            // Medico
            NumeroColegiado = medico.NumeroColegiado,
            EstaActivo = medico.EstaActivo
        };
    }

    public async Task ActualizarMedicoAsync(long idMedico, MedicoUpdDto request, CancellationToken ct = default)
    {
        if (idMedico != request.IdMedico)
            throw new BadRequestException("El identificador del médico no coincide con el enviado en la URL.");

        var medico = await _medicoRepository.GetByIdWithPersonaAsync(idMedico, ct);
        if (medico is null)
            throw new NotFoundException("Médico no encontrado.");

        var personaDto = new PersonaDto
        {
            IdPersona = medico.Persona.IdPersona,
            Nombres = medico.Persona.Nombres,
            Apellidos = medico.Persona.Apellidos,
            FechaNacimiento = medico.Persona.FechaNacimiento,
            Telefono = medico.Persona.Telefono,
            Celular = medico.Persona.Celular,
            Email = medico.Persona.Email,
            Direccion = medico.Persona.Direccion,
            IdTipoIdentificacion = (int)medico.Persona.IdTipoIdentificacion,
            NumeroIdentificacion = medico.Persona.NumeroIdentificacion
        };

        // Actualizar Persona
        await _personaService.UpdatePersonaAsync(medico.Persona, personaDto, ct);

        // Verificar número de colegiado duplicado (si aplica)
        // Aquí podrías agregar un método ExistsByNumeroColegiadoAsync en el repo si quieres.

        // Actualizar datos de Médico
        medico.ActualizarDatosMedico(request.NumeroColegiado);
        medico.CambiarEstatus(request.EstaActivo);

        await _medicoRepository.UpdateAsync(medico, ct);
        await _medicoRepository.SaveChangesAsync(ct);
    }

    public async Task EliminarMedicoAsync(long idMedico, CancellationToken ct = default)
    {
        var medico = await _medicoRepository.GetByIdWithPersonaAsync(idMedico, ct);
        if (medico is null)
            throw new NotFoundException("Médico no encontrado.");

        // Aquí podrías validar si tiene citas asociadas, etc.
        // Si tiene, lanzar ConflictException.

        await _medicoRepository.DeleteAsync(medico, ct);
        await _medicoRepository.SaveChangesAsync(ct);
        await _personaService.DeletePersonaAsync(medico.IdPersona, ct);
    }
}
