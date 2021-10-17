using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndIntegrador.Migrations
{
    public partial class UpdtModelUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "activation_code",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "salt",
                table: "Usuario");

            migrationBuilder.AddColumn<byte[]>(
                name: "pass_hash",
                table: "Usuario",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "pass_hash",
                table: "Usuario");

            migrationBuilder.AddColumn<string>(
                name: "activation_code",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "salt",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
