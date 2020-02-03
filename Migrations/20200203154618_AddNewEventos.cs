using Microsoft.EntityFrameworkCore.Migrations;

namespace CrudBandas.Migrations
{
    public partial class AddNewEventos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Imagem",
                table: "Evento",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imagem",
                table: "Evento");
        }
    }
}
