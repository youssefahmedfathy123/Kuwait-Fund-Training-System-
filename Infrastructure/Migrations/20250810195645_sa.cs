using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class sa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

           


            migrationBuilder.DropColumn(
                name: "IsPresent",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "IsSickLeave",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "MedicalReportUrl",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "SessionDate",
                table: "Attendances");

            migrationBuilder.RenameColumn(
                name: "CourceId",
                table: "Attendances",
                newName: "SchedualId");

            migrationBuilder.RenameIndex(
                name: "IX_Attendances_CourceId",
                table: "Attendances",
                newName: "IX_Attendances_SchedualId");

            migrationBuilder.AlterColumn<Guid>(
                name: "TraineeId",
                table: "Attendances",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Attendances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Schedual",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Day = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    table.PrimaryKey("PK_Schedual", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedual_Cources_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Cources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Schedual_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Schedual_CourseId",
                table: "Schedual",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedual_GroupId",
                table: "Schedual",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Schedual_SchedualId",
                table: "Attendances",
                column: "SchedualId",
                principalTable: "Schedual",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Trainees_TraineeId",
                table: "Attendances",
                column: "TraineeId",
                principalTable: "Trainees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);



        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
           

           

            migrationBuilder.DropTable(
                name: "Schedual");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Attendances");

            migrationBuilder.RenameColumn(
                name: "SchedualId",
                table: "Attendances",
                newName: "CourceId");

            migrationBuilder.RenameIndex(
                name: "IX_Attendances_SchedualId",
                table: "Attendances",
                newName: "IX_Attendances_CourceId");

            migrationBuilder.AlterColumn<string>(
                name: "TraineeId",
                table: "Attendances",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<bool>(
                name: "IsPresent",
                table: "Attendances",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSickLeave",
                table: "Attendances",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "MedicalReportUrl",
                table: "Attendances",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SessionDate",
                table: "Attendances",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_AspNetUsers_TraineeId",
                table: "Attendances",
                column: "TraineeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Cources_CourceId",
                table: "Attendances",
                column: "CourceId",
                principalTable: "Cources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);


        }
    }
}
