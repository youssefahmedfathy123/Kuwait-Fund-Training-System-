using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class feeeksw : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Excuses");

            migrationBuilder.AddColumn<DateTime>(
                name: "End",
                table: "Leaves",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Start",
                table: "Leaves",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "AttendanceId",
                table: "Excuses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Bi_weeklyReport",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    WeekNumberOfPhase = table.Column<int>(type: "int", nullable: false),
                    StartDateOf2Weekes = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Pdf = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EditedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bi_weeklyReport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bi_weeklyReport_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Excuses_AttendanceId",
                table: "Excuses",
                column: "AttendanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Bi_weeklyReport_UserId",
                table: "Bi_weeklyReport",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Excuses_Attendances_AttendanceId",
                table: "Excuses",
                column: "AttendanceId",
                principalTable: "Attendances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Excuses_Attendances_AttendanceId",
                table: "Excuses");

            migrationBuilder.DropTable(
                name: "Bi_weeklyReport");

            migrationBuilder.DropIndex(
                name: "IX_Excuses_AttendanceId",
                table: "Excuses");

            migrationBuilder.DropColumn(
                name: "End",
                table: "Leaves");

            migrationBuilder.DropColumn(
                name: "Start",
                table: "Leaves");

            migrationBuilder.DropColumn(
                name: "AttendanceId",
                table: "Excuses");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Excuses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
