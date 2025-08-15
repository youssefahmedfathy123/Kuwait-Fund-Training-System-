using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class oefd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bi_weeklyReport_AspNetUsers_UserId",
                table: "Bi_weeklyReport");

            migrationBuilder.DropTable(
                name: "Leaves");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bi_weeklyReport",
                table: "Bi_weeklyReport");

            migrationBuilder.RenameTable(
                name: "Bi_weeklyReport",
                newName: "Bi_WeeklyReports");

            migrationBuilder.RenameIndex(
                name: "IX_Bi_weeklyReport_UserId",
                table: "Bi_WeeklyReports",
                newName: "IX_Bi_WeeklyReports_UserId");

            migrationBuilder.AddColumn<int>(
                name: "Activation",
                table: "Trainees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bi_WeeklyReports",
                table: "Bi_WeeklyReports",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "End_of_3phasesReports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TraineeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Pdf = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EditedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_End_of_3phasesReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_End_of_3phasesReports_Trainees_TraineeId",
                        column: x => x.TraineeId,
                        principalTable: "Trainees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Fines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TraineeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EditedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fines_Trainees_TraineeId",
                        column: x => x.TraineeId,
                        principalTable: "Trainees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SenderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ReceiverId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SentAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EditedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Waitings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EditedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Waitings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "withdrawals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Reason = table.Column<int>(type: "int", nullable: false),
                    MedicalReport = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EditedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_withdrawals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_withdrawals_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_End_of_3phasesReports_TraineeId",
                table: "End_of_3phasesReports",
                column: "TraineeId");

            migrationBuilder.CreateIndex(
                name: "IX_Fines_TraineeId",
                table: "Fines",
                column: "TraineeId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ReceiverId",
                table: "Messages",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderId",
                table: "Messages",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_withdrawals_UserId",
                table: "withdrawals",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bi_WeeklyReports_AspNetUsers_UserId",
                table: "Bi_WeeklyReports",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bi_WeeklyReports_AspNetUsers_UserId",
                table: "Bi_WeeklyReports");

            migrationBuilder.DropTable(
                name: "End_of_3phasesReports");

            migrationBuilder.DropTable(
                name: "Fines");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Waitings");

            migrationBuilder.DropTable(
                name: "withdrawals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bi_WeeklyReports",
                table: "Bi_WeeklyReports");

            migrationBuilder.DropColumn(
                name: "Activation",
                table: "Trainees");

            migrationBuilder.RenameTable(
                name: "Bi_WeeklyReports",
                newName: "Bi_weeklyReport");

            migrationBuilder.RenameIndex(
                name: "IX_Bi_WeeklyReports_UserId",
                table: "Bi_weeklyReport",
                newName: "IX_Bi_weeklyReport_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bi_weeklyReport",
                table: "Bi_weeklyReport",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Leaves",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EditedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    End = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    MedicalReport = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Reason = table.Column<int>(type: "int", nullable: false),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leaves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Leaves_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Leaves_UserId",
                table: "Leaves",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bi_weeklyReport_AspNetUsers_UserId",
                table: "Bi_weeklyReport",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
