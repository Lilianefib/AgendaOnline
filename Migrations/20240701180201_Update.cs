using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgendaOnline.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Gerência",
                table: "Agenda",
                newName: "Gerencia");

            migrationBuilder.AddColumn<DateTime>(
                name: "UltimaAtualizacao",
                table: "Agenda",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UltimaAtualizacao",
                table: "Agenda");

            migrationBuilder.RenameColumn(
                name: "Gerencia",
                table: "Agenda",
                newName: "Gerência");
        }
    }
}
