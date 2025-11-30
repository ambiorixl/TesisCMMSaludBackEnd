using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VClinic.Api.Middlewares;
using VClinic.Api.Models;
using VClinic.Application.Abstractions;
using VClinic.Application.Services;
using VClinic.Infrastructure.Persistence;
using VClinic.Infrastructure.Persistence.Repositories;
using VClinic.Infrastructure.Repositories;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(connectionString);
});

// 2. Inyección de dependencias (Application / Infrastructure)
builder.Services.AddScoped<ICentroMedicoRepository, CentroMedicoRepository>();
builder.Services.AddScoped<IPacienteRepository, PacienteRepository>();
builder.Services.AddScoped<IEmpleadoRepository, EmpleadoRepository>();
builder.Services.AddScoped<IPersonaRepository, PersonaRepository>();
builder.Services.AddScoped<IMedicoRepository, MedicoRepository>();
builder.Services.AddScoped<IPersonaService, PersonaService>();

builder.Services.AddScoped<CentroMedicoService>();
builder.Services.AddScoped<PacienteService>();
builder.Services.AddScoped<EmpleadoService>();
builder.Services.AddScoped<PersonaService>();
builder.Services.AddScoped<MedicoService>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var errors = context.ModelState
            .Where(e => e.Value?.Errors.Count > 0)
            .ToDictionary(
                kvp => kvp.Key,
                kvp => kvp.Value!.Errors.Select(err => err.ErrorMessage).ToArray()
            );

        var errorResponse = new ErrorResponse
        {
            Success = false,
            StatusCode = StatusCodes.Status400BadRequest,
            ErrorCode = "ValidationError",
            Message = "Se encontraron errores de validación.",
            Errors = errors,
            TraceId = context.HttpContext.TraceIdentifier
        };

        return new BadRequestObjectResult(errorResponse);
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseMiddleware<ExceptionHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwagger();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
        options.RoutePrefix = string.Empty; // Swagger en la raíz: https://localhost:xxxx/
    });
}

app.UseStatusCodePages(async context =>
{
    var response = context.HttpContext.Response;

    if (response.StatusCode >= 400 && response.StatusCode < 500 && !response.HasStarted)
    {
        response.ContentType = "application/json";

        var error = new ErrorResponse
        {
            Success = false,
            StatusCode = response.StatusCode,
            ErrorCode = response.StatusCode switch
            {
                StatusCodes.Status401Unauthorized => "Unauthorized",
                StatusCodes.Status403Forbidden => "Forbidden",
                StatusCodes.Status404NotFound => "NotFound",
                _ => "ClientError"
            },
            Message = response.StatusCode switch
            {
                StatusCodes.Status401Unauthorized => "No está autorizado para realizar esta acción.",
                StatusCodes.Status403Forbidden => "No tiene permisos para acceder a este recurso.",
                StatusCodes.Status404NotFound => "Recurso no encontrado.",
                _ => "Se ha producido un error en la solicitud."
            },
            Errors = null,
            TraceId = context.HttpContext.TraceIdentifier
        };

        await response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(error));
    }
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();