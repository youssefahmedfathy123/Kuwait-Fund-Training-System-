using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class fefrfee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PassStatus",
                table: "Trainees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "Pending");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PassStatus",
                table: "Trainees");
        }
    }
}

