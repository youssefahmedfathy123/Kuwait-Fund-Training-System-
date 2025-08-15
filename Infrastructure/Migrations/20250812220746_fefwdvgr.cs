using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fefwdvgr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Trainees_TraineeId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Trainers_TrainerId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_TraineeId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_TrainerId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TraineeId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TrainerId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Trainers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Trainees",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Trainers_UserId",
                table: "Trainers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainees_UserId",
                table: "Trainees",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainees_AspNetUsers_UserId",
                table: "Trainees",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainers_AspNetUsers_UserId",
                table: "Trainers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainees_AspNetUsers_UserId",
                table: "Trainees");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainers_AspNetUsers_UserId",
                table: "Trainers");

            migrationBuilder.DropIndex(
                name: "IX_Trainers_UserId",
                table: "Trainers");

            migrationBuilder.DropIndex(
                name: "IX_Trainees_UserId",
                table: "Trainees");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Trainers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Trainees");

            migrationBuilder.AddColumn<Guid>(
                name: "TraineeId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TrainerId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TraineeId",
                table: "AspNetUsers",
                column: "TraineeId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TrainerId",
                table: "AspNetUsers",
                column: "TrainerId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Trainees_TraineeId",
                table: "AspNetUsers",
                column: "TraineeId",
                principalTable: "Trainees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Trainers_TrainerId",
                table: "AspNetUsers",
                column: "TrainerId",
                principalTable: "Trainers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
