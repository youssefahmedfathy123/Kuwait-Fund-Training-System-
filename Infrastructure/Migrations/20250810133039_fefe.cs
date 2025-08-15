using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fefe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Cources",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Cources",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "EditedAt",
                table: "Cources",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EditedBy",
                table: "Cources",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Cources",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Cources");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Cources");

            migrationBuilder.DropColumn(
                name: "EditedAt",
                table: "Cources");

            migrationBuilder.DropColumn(
                name: "EditedBy",
                table: "Cources");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Cources");
        }
    }
}
