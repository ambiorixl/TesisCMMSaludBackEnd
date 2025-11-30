// VClinic.Infrastructure/Persistence/Configurations/EmpleadoConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VClinic.Domain.Entities;

namespace VClinic.Infrastructure.Persistence.Configurations;

public class EmpleadoConfiguration : IEntityTypeConfiguration<Empleado>
{
    public void Configure(EntityTypeBuilder<Empleado> builder)
    {
        builder.ToTable("Empleados");

        builder.HasKey(e => e.IdEmpleado);

        builder.Property(e => e.CodigoEmpleado)
            .IsRequired()
            .HasMaxLength(10);

        builder.Property(e => e.IdCargo)
            .IsRequired();

        builder.HasIndex(e => e.CodigoEmpleado)
            .IsUnique();

        builder.HasOne(e => e.Persona)
            .WithOne(p => p.Empleado)
            .HasForeignKey<Empleado>(e => e.IdPersona)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(e => e.IdPersona)
            .IsUnique();
    }
}
