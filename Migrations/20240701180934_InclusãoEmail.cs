using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgendaOnline.Migrations
{
    /// <inheritdoc />
    public partial class InclusãoEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Agenda",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Agenda");
        }
    }
}
