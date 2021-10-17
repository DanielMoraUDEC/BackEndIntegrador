using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndIntegrador.Migrations
{
    public partial class UpdtModelUsuario2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "activation_code",
                table: "Usuario",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "salt",
                table: "Usuario",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "activation_code",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "salt",
                table: "Usuario");
        }
    }
}
