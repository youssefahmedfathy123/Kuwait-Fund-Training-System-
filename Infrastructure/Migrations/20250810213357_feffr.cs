using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class feffr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Schedual_SchedualId",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedual_Cources_CourseId",
                table: "Schedual");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedual_Groups_GroupId",
                table: "Schedual");

            migrationBuilder.DropTable(
                name: "Certificates");

            migrationBuilder.DropTable(
                name: "CourceEvaluations");

            migrationBuilder.DropTable(
                name: "FieldReports");

            migrationBuilder.DropTable(
                name: "LeaveRequests");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "TrainerEvaluations");

            migrationBuilder.DropTable(
                name: "withDrawals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Schedual",
                table: "Schedual");

            migrationBuilder.RenameTable(
                name: "Schedual",
                newName: "Scheduals");

            migrationBuilder.RenameIndex(
                name: "IX_Schedual_GroupId",
                table: "Scheduals",
                newName: "IX_Scheduals_GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Schedual_CourseId",
                table: "Scheduals",
                newName: "IX_Scheduals_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Scheduals",
                table: "Scheduals",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Exams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Start = table.Column<TimeSpan>(type: "time", nullable: false),
                    End = table.Column<TimeSpan>(type: "time", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EditedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exams_Cources_CourceId",
                        column: x => x.CourceId,
                        principalTable: "Cources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Exams_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExamStatuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TraineeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: false),
                    Evaluation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EditedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamStatuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExamStatuses_Exams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExamStatuses_Trainees_TraineeId",
                        column: x => x.TraineeId,
                        principalTable: "Trainees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exams_CourceId",
                table: "Exams",
                column: "CourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_GroupId",
                table: "Exams",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamStatuses_ExamId",
                table: "ExamStatuses",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamStatuses_TraineeId",
                table: "ExamStatuses",
                column: "TraineeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Scheduals_SchedualId",
                table: "Attendances",
                column: "SchedualId",
                principalTable: "Scheduals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Scheduals_Cources_CourseId",
                table: "Scheduals",
                column: "CourseId",
                principalTable: "Cources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Scheduals_Groups_GroupId",
                table: "Scheduals",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Scheduals_SchedualId",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_Scheduals_Cources_CourseId",
                table: "Scheduals");

            migrationBuilder.DropForeignKey(
                name: "FK_Scheduals_Groups_GroupId",
                table: "Scheduals");

            migrationBuilder.DropTable(
                name: "ExamStatuses");

            migrationBuilder.DropTable(
                name: "Exams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Scheduals",
                table: "Scheduals");

            migrationBuilder.RenameTable(
                name: "Scheduals",
                newName: "Schedual");

            migrationBuilder.RenameIndex(
                name: "IX_Scheduals_GroupId",
                table: "Schedual",
                newName: "IX_Schedual_GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Scheduals_CourseId",
                table: "Schedual",
                newName: "IX_Schedual_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Schedual",
                table: "Schedual",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Certificates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TraineeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsCollected = table.Column<bool>(type: "bit", nullable: false),
                    UploadUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Certificates_AspNetUsers_TraineeId",
                        column: x => x.TraineeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Certificates_Cources_CourceId",
                        column: x => x.CourceId,
                        principalTable: "Cources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourceEvaluations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TraineeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CoordinatorEvaluation = table.Column<int>(type: "int", nullable: false),
                    ExamScore = table.Column<int>(type: "int", nullable: false),
                    IsPassed = table.Column<bool>(type: "bit", nullable: false),
                    TotalScore = table.Column<int>(type: "int", nullable: false),
                    TrainerEvaluation = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourceEvaluations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourceEvaluations_AspNetUsers_TraineeId",
                        column: x => x.TraineeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourceEvaluations_Cources_CourceId",
                        column: x => x.CourceId,
                        principalTable: "Cources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FieldReports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TraineeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phase = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    SubmissionDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FieldReports_AspNetUsers_TraineeId",
                        column: x => x.TraineeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LeaveRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TraineeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeaveType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicalReportUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phase = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaveRequests_AspNetUsers_TraineeId",
                        column: x => x.TraineeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReceiverId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SenderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainerEvaluations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TraineeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TrainerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainerEvaluations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainerEvaluations_AspNetUsers_TraineeId",
                        column: x => x.TraineeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainerEvaluations_AspNetUsers_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainerEvaluations_Cources_CourceId",
                        column: x => x.CourceId,
                        principalTable: "Cources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "withDrawals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TraineeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsPenaltyApplied = table.Column<bool>(type: "bit", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupportingDocumentUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_withDrawals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_withDrawals_AspNetUsers_TraineeId",
                        column: x => x.TraineeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_CourceId",
                table: "Certificates",
                column: "CourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_TraineeId",
                table: "Certificates",
                column: "TraineeId");

            migrationBuilder.CreateIndex(
                name: "IX_CourceEvaluations_CourceId",
                table: "CourceEvaluations",
                column: "CourceId");

            migrationBuilder.CreateIndex(
                name: "IX_CourceEvaluations_TraineeId",
                table: "CourceEvaluations",
                column: "TraineeId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldReports_TraineeId",
                table: "FieldReports",
                column: "TraineeId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_TraineeId",
                table: "LeaveRequests",
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
                name: "IX_TrainerEvaluations_CourceId",
                table: "TrainerEvaluations",
                column: "CourceId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainerEvaluations_TraineeId",
                table: "TrainerEvaluations",
                column: "TraineeId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainerEvaluations_TrainerId",
                table: "TrainerEvaluations",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_withDrawals_TraineeId",
                table: "withDrawals",
                column: "TraineeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Schedual_SchedualId",
                table: "Attendances",
                column: "SchedualId",
                principalTable: "Schedual",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedual_Cources_CourseId",
                table: "Schedual",
                column: "CourseId",
                principalTable: "Cources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedual_Groups_GroupId",
                table: "Schedual",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
