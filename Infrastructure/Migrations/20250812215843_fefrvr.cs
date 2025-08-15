using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fefrvr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainees_Batches_BatchId",
                table: "Trainees");

            migrationBuilder.DropIndex(
                name: "IX_Trainees_BatchId",
                table: "Trainees");

            migrationBuilder.DropColumn(
                name: "BatchId",
                table: "Trainees");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BatchId",
                table: "Trainees",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Trainees_BatchId",
                table: "Trainees",
                column: "BatchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainees_Batches_BatchId",
                table: "Trainees",
                column: "BatchId",
                principalTable: "Batches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
