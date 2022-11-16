using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Serve.API.Migrations.ServeDb
{
    public partial class RenamedAppointmentTitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppoinmentTitle",
                table: "Appointment",
                type: "varchar(40)",
                unicode: false,
                maxLength: 40,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppoinmentTitle",
                table: "Appointment");
        }
    }
}
