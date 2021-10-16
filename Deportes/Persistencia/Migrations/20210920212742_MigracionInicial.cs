using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistencia.Migrations
{
    public partial class MigracionInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_equipos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deporte = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    F_creacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_equipos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_municipios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_municipios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_personas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    N_identificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tipo_persona = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Celular = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EPS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    F_nacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rol = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_personas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_torneos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Categoria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    F_Inicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    F_Fin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    N_rondas = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_torneos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_escenario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id_municipio = table.Column<int>(type: "int", nullable: false),
                    municipioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_escenario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_escenario_tb_municipios_municipioId",
                        column: x => x.municipioId,
                        principalTable: "tb_municipios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_personas_equipos",
                columns: table => new
                {
                    Id_persona = table.Column<int>(type: "int", nullable: false),
                    Id_equipo = table.Column<int>(type: "int", nullable: false),
                    personasId = table.Column<int>(type: "int", nullable: true),
                    equiposId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_personas_equipos", x => new { x.Id_persona, x.Id_equipo });
                    table.ForeignKey(
                        name: "FK_tb_personas_equipos_tb_equipos_equiposId",
                        column: x => x.equiposId,
                        principalTable: "tb_equipos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tb_personas_equipos_tb_personas_personasId",
                        column: x => x.personasId,
                        principalTable: "tb_personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_equipos_torneos",
                columns: table => new
                {
                    Id_equipo = table.Column<int>(type: "int", nullable: false),
                    Id_torneo = table.Column<int>(type: "int", nullable: false),
                    equiposId = table.Column<int>(type: "int", nullable: true),
                    torneosId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_equipos_torneos", x => new { x.Id_equipo, x.Id_torneo });
                    table.ForeignKey(
                        name: "FK_tb_equipos_torneos_tb_equipos_equiposId",
                        column: x => x.equiposId,
                        principalTable: "tb_equipos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tb_equipos_torneos_tb_torneos_torneosId",
                        column: x => x.torneosId,
                        principalTable: "tb_torneos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_canchas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deporte = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    N_Espectadores = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Medidas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id_escenario = table.Column<int>(type: "int", nullable: false),
                    escenarioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_canchas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_canchas_tb_escenario_escenarioId",
                        column: x => x.escenarioId,
                        principalTable: "tb_escenario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_encuentros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_torneo = table.Column<int>(type: "int", nullable: false),
                    Id_cancha = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Id_persona = table.Column<int>(type: "int", nullable: false),
                    canchaId = table.Column<int>(type: "int", nullable: true),
                    personaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_encuentros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_encuentros_tb_canchas_canchaId",
                        column: x => x.canchaId,
                        principalTable: "tb_canchas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tb_encuentros_tb_personas_personaId",
                        column: x => x.personaId,
                        principalTable: "tb_personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_torneos_encuentros",
                columns: table => new
                {
                    Id_torneo = table.Column<int>(type: "int", nullable: false),
                    Id_encuentro = table.Column<int>(type: "int", nullable: false),
                    Id_equipo = table.Column<int>(type: "int", nullable: false),
                    Id_equipo2 = table.Column<int>(type: "int", nullable: false),
                    Id_ganador = table.Column<int>(type: "int", nullable: false),
                    torneosId = table.Column<int>(type: "int", nullable: true),
                    encuentrosId = table.Column<int>(type: "int", nullable: true),
                    equipoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_torneos_encuentros", x => new { x.Id_torneo, x.Id_encuentro, x.Id_equipo });
                    table.ForeignKey(
                        name: "FK_tb_torneos_encuentros_tb_encuentros_encuentrosId",
                        column: x => x.encuentrosId,
                        principalTable: "tb_encuentros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tb_torneos_encuentros_tb_equipos_equipoId",
                        column: x => x.equipoId,
                        principalTable: "tb_equipos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tb_torneos_encuentros_tb_torneos_torneosId",
                        column: x => x.torneosId,
                        principalTable: "tb_torneos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_canchas_escenarioId",
                table: "tb_canchas",
                column: "escenarioId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_encuentros_canchaId",
                table: "tb_encuentros",
                column: "canchaId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_encuentros_personaId",
                table: "tb_encuentros",
                column: "personaId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_equipos_torneos_equiposId",
                table: "tb_equipos_torneos",
                column: "equiposId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_equipos_torneos_torneosId",
                table: "tb_equipos_torneos",
                column: "torneosId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_escenario_municipioId",
                table: "tb_escenario",
                column: "municipioId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_personas_equipos_equiposId",
                table: "tb_personas_equipos",
                column: "equiposId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_personas_equipos_personasId",
                table: "tb_personas_equipos",
                column: "personasId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_torneos_encuentros_encuentrosId",
                table: "tb_torneos_encuentros",
                column: "encuentrosId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_torneos_encuentros_equipoId",
                table: "tb_torneos_encuentros",
                column: "equipoId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_torneos_encuentros_torneosId",
                table: "tb_torneos_encuentros",
                column: "torneosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_equipos_torneos");

            migrationBuilder.DropTable(
                name: "tb_personas_equipos");

            migrationBuilder.DropTable(
                name: "tb_torneos_encuentros");

            migrationBuilder.DropTable(
                name: "tb_encuentros");

            migrationBuilder.DropTable(
                name: "tb_equipos");

            migrationBuilder.DropTable(
                name: "tb_torneos");

            migrationBuilder.DropTable(
                name: "tb_canchas");

            migrationBuilder.DropTable(
                name: "tb_personas");

            migrationBuilder.DropTable(
                name: "tb_escenario");

            migrationBuilder.DropTable(
                name: "tb_municipios");
        }
    }
}
