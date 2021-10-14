using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndIntegrador.Migrations
{
    public partial class MigracionInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Materia",
                columns: table => new
                {
                    id_materia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materia", x => x.id_materia);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    id_usuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    celular = table.Column<int>(type: "int", nullable: false),
                    correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    es_tutor = table.Column<bool>(type: "bit", nullable: false),
                    rol = table.Column<int>(type: "int", nullable: false),
                    contraseña = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    salt = table.Column<int>(type: "int", nullable: false),
                    is_mail_confirmed = table.Column<bool>(type: "bit", nullable: false),
                    activation_code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    can_publicaciones = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.id_usuario);
                });

            migrationBuilder.CreateTable(
                name: "Publicacion",
                columns: table => new
                {
                    id_publicacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fecha_publicacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_actualización = table.Column<DateTime>(type: "datetime2", nullable: false),
                    titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    id_usuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publicacion", x => x.id_publicacion);
                    table.ForeignKey(
                        name: "FK_Publicacion_Usuario_id_usuario",
                        column: x => x.id_usuario,
                        principalTable: "Usuario",
                        principalColumn: "id_usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    id_rol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    id_usuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.id_rol);
                    table.ForeignKey(
                        name: "FK_Rol_Usuario_id_usuario",
                        column: x => x.id_usuario,
                        principalTable: "Usuario",
                        principalColumn: "id_usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioMateria",
                columns: table => new
                {
                    id_usuario_materia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    calificacon = table.Column<double>(type: "float", nullable: false),
                    content_file = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    file_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    file_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    id_materia = table.Column<int>(type: "int", nullable: false),
                    id_usuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioMateria", x => x.id_usuario_materia);
                    table.ForeignKey(
                        name: "FK_UsuarioMateria_Materia_id_materia",
                        column: x => x.id_materia,
                        principalTable: "Materia",
                        principalColumn: "id_materia",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioMateria_Usuario_id_usuario",
                        column: x => x.id_usuario,
                        principalTable: "Usuario",
                        principalColumn: "id_usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tema",
                columns: table => new
                {
                    id_tema = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    contenido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    content_file = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    file_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    file_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    id_publicacion = table.Column<int>(type: "int", nullable: false),
                    id_publicaión = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tema", x => x.id_tema);
                    table.ForeignKey(
                        name: "FK_Tema_Publicacion_id_publicaión",
                        column: x => x.id_publicaión,
                        principalTable: "Publicacion",
                        principalColumn: "id_publicacion",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Publicacion_id_usuario",
                table: "Publicacion",
                column: "id_usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Rol_id_usuario",
                table: "Rol",
                column: "id_usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Tema_id_publicaión",
                table: "Tema",
                column: "id_publicaión");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioMateria_id_materia",
                table: "UsuarioMateria",
                column: "id_materia");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioMateria_id_usuario",
                table: "UsuarioMateria",
                column: "id_usuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropTable(
                name: "Tema");

            migrationBuilder.DropTable(
                name: "UsuarioMateria");

            migrationBuilder.DropTable(
                name: "Publicacion");

            migrationBuilder.DropTable(
                name: "Materia");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
