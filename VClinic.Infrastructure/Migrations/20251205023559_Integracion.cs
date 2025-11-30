using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VClinic.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Integracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdCargo",
                table: "Empleados",
                newName: "IdProfesion");

            migrationBuilder.AddColumn<int>(
                name: "IdEstadoCivil",
                table: "Personas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdGenero",
                table: "Personas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GrupoSanguinioIdGrupoSangre",
                table: "Pacientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdOcupacion",
                table: "Pacientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OcupacionIdOcupacion",
                table: "Pacientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdDepartamento",
                table: "Empleados",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdPosicion",
                table: "Empleados",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    IdDepartamento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EstaActivo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.IdDepartamento);
                });

            migrationBuilder.CreateTable(
                name: "Equipamento",
                columns: table => new
                {
                    IdEquipamento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IdTipoEquipo = table.Column<int>(type: "int", nullable: false),
                    EstaActivo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipamento", x => x.IdEquipamento);
                });

            migrationBuilder.CreateTable(
                name: "EstadoCivil",
                columns: table => new
                {
                    IdEstadoCivil = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EstaActivo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoCivil", x => x.IdEstadoCivil);
                });

            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    IdGenero = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EstaActivo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.IdGenero);
                });

            migrationBuilder.CreateTable(
                name: "GrupoSangre",
                columns: table => new
                {
                    IdGrupoSangre = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoSangre = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    GrupoABO = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    FactorRH = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    EstaActivo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupoSangre", x => x.IdGrupoSangre);
                });

            migrationBuilder.CreateTable(
                name: "Ocupacions",
                columns: table => new
                {
                    IdOcupacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    EstaActivo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ocupacions", x => x.IdOcupacion);
                });

            migrationBuilder.CreateTable(
                name: "Posiciones",
                columns: table => new
                {
                    IdPosicion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Nivel = table.Column<int>(type: "int", nullable: false),
                    EstaActivo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posiciones", x => x.IdPosicion);
                });

            migrationBuilder.CreateTable(
                name: "Profesion",
                columns: table => new
                {
                    IdProfesion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EstaActivo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesion", x => x.IdProfesion);
                });

            migrationBuilder.CreateTable(
                name: "TipoEquipamento",
                columns: table => new
                {
                    IdTipoEquipamento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EstaActivo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoEquipamento", x => x.IdTipoEquipamento);
                });

            migrationBuilder.CreateTable(
                name: "TipoIdentificacion",
                columns: table => new
                {
                    IdTipoIdentificacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EstaActivo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoIdentificacion", x => x.IdTipoIdentificacion);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personas_IdEstadoCivil",
                table: "Personas",
                column: "IdEstadoCivil");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_IdGenero",
                table: "Personas",
                column: "IdGenero");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_GrupoSanguinioIdGrupoSangre",
                table: "Pacientes",
                column: "GrupoSanguinioIdGrupoSangre");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_OcupacionIdOcupacion",
                table: "Pacientes",
                column: "OcupacionIdOcupacion");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_IdDepartamento",
                table: "Empleados",
                column: "IdDepartamento");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_IdPosicion",
                table: "Empleados",
                column: "IdPosicion");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_IdProfesion",
                table: "Empleados",
                column: "IdProfesion");

            migrationBuilder.AddForeignKey(
                name: "FK_Empleados_Departamentos_IdDepartamento",
                table: "Empleados",
                column: "IdDepartamento",
                principalTable: "Departamentos",
                principalColumn: "IdDepartamento",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Empleados_Posiciones_IdPosicion",
                table: "Empleados",
                column: "IdPosicion",
                principalTable: "Posiciones",
                principalColumn: "IdPosicion",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Empleados_Profesion_IdProfesion",
                table: "Empleados",
                column: "IdProfesion",
                principalTable: "Profesion",
                principalColumn: "IdProfesion",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pacientes_GrupoSangre_GrupoSanguinioIdGrupoSangre",
                table: "Pacientes",
                column: "GrupoSanguinioIdGrupoSangre",
                principalTable: "GrupoSangre",
                principalColumn: "IdGrupoSangre",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pacientes_Ocupacions_OcupacionIdOcupacion",
                table: "Pacientes",
                column: "OcupacionIdOcupacion",
                principalTable: "Ocupacions",
                principalColumn: "IdOcupacion",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_EstadoCivil_IdEstadoCivil",
                table: "Personas",
                column: "IdEstadoCivil",
                principalTable: "EstadoCivil",
                principalColumn: "IdEstadoCivil",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Generos_IdGenero",
                table: "Personas",
                column: "IdGenero",
                principalTable: "Generos",
                principalColumn: "IdGenero",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_TipoIdentificacion_IdTipoIdentificacion",
                table: "Personas",
                column: "IdTipoIdentificacion",
                principalTable: "TipoIdentificacion",
                principalColumn: "IdTipoIdentificacion",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleados_Departamentos_IdDepartamento",
                table: "Empleados");

            migrationBuilder.DropForeignKey(
                name: "FK_Empleados_Posiciones_IdPosicion",
                table: "Empleados");

            migrationBuilder.DropForeignKey(
                name: "FK_Empleados_Profesion_IdProfesion",
                table: "Empleados");

            migrationBuilder.DropForeignKey(
                name: "FK_Pacientes_GrupoSangre_GrupoSanguinioIdGrupoSangre",
                table: "Pacientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Pacientes_Ocupacions_OcupacionIdOcupacion",
                table: "Pacientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Personas_EstadoCivil_IdEstadoCivil",
                table: "Personas");

            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Generos_IdGenero",
                table: "Personas");

            migrationBuilder.DropForeignKey(
                name: "FK_Personas_TipoIdentificacion_IdTipoIdentificacion",
                table: "Personas");

            migrationBuilder.DropTable(
                name: "Departamentos");

            migrationBuilder.DropTable(
                name: "Equipamento");

            migrationBuilder.DropTable(
                name: "EstadoCivil");

            migrationBuilder.DropTable(
                name: "Generos");

            migrationBuilder.DropTable(
                name: "GrupoSangre");

            migrationBuilder.DropTable(
                name: "Ocupacions");

            migrationBuilder.DropTable(
                name: "Posiciones");

            migrationBuilder.DropTable(
                name: "Profesion");

            migrationBuilder.DropTable(
                name: "TipoEquipamento");

            migrationBuilder.DropTable(
                name: "TipoIdentificacion");

            migrationBuilder.DropIndex(
                name: "IX_Personas_IdEstadoCivil",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_IdGenero",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Pacientes_GrupoSanguinioIdGrupoSangre",
                table: "Pacientes");

            migrationBuilder.DropIndex(
                name: "IX_Pacientes_OcupacionIdOcupacion",
                table: "Pacientes");

            migrationBuilder.DropIndex(
                name: "IX_Empleados_IdDepartamento",
                table: "Empleados");

            migrationBuilder.DropIndex(
                name: "IX_Empleados_IdPosicion",
                table: "Empleados");

            migrationBuilder.DropIndex(
                name: "IX_Empleados_IdProfesion",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "IdEstadoCivil",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "IdGenero",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "GrupoSanguinioIdGrupoSangre",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "IdOcupacion",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "OcupacionIdOcupacion",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "IdDepartamento",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "IdPosicion",
                table: "Empleados");

            migrationBuilder.RenameColumn(
                name: "IdProfesion",
                table: "Empleados",
                newName: "IdCargo");
        }
    }
}
