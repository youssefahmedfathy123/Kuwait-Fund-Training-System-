using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class feeew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendance_AspNetUsers_TraineeId",
                table: "Attendance");

            migrationBuilder.DropForeignKey(
                name: "FK_Attendance_Cources_CourceId",
                table: "Attendance");

            migrationBuilder.DropForeignKey(
                name: "FK_Certificate_AspNetUsers_TraineeId",
                table: "Certificate");

            migrationBuilder.DropForeignKey(
                name: "FK_Certificate_Cources_CourceId",
                table: "Certificate");

            migrationBuilder.DropForeignKey(
                name: "FK_CourceEvaluation_AspNetUsers_TraineeId",
                table: "CourceEvaluation");

            migrationBuilder.DropForeignKey(
                name: "FK_CourceEvaluation_Cources_CourceId",
                table: "CourceEvaluation");

            migrationBuilder.DropForeignKey(
                name: "FK_Cources_AspNetUsers_TrainerId",
                table: "Cources");

            migrationBuilder.DropForeignKey(
                name: "FK_Cources_Batches_BatchId",
                table: "Cources");

            migrationBuilder.DropForeignKey(
                name: "FK_FieldReport_AspNetUsers_TraineeId",
                table: "FieldReport");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequest_AspNetUsers_TraineeId",
                table: "LeaveRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_AspNetUsers_ReceiverId",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_AspNetUsers_SenderId",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainerEvaluation_AspNetUsers_TraineeId",
                table: "TrainerEvaluation");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainerEvaluation_AspNetUsers_TrainerId",
                table: "TrainerEvaluation");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainerEvaluation_Cources_CourceId",
                table: "TrainerEvaluation");

            migrationBuilder.DropForeignKey(
                name: "FK_WithDrawal_AspNetUsers_TraineeId",
                table: "WithDrawal");

            migrationBuilder.DropIndex(
                name: "IX_Cources_BatchId",
                table: "Cources");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WithDrawal",
                table: "WithDrawal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainerEvaluation",
                table: "TrainerEvaluation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Message",
                table: "Message");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LeaveRequest",
                table: "LeaveRequest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FieldReport",
                table: "FieldReport");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourceEvaluation",
                table: "CourceEvaluation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Certificate",
                table: "Certificate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attendance",
                table: "Attendance");

            migrationBuilder.DropColumn(
                name: "BatchId",
                table: "Cources");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Cources");

            migrationBuilder.DropColumn(
                name: "ScheduleDate",
                table: "Cources");

            migrationBuilder.RenameTable(
                name: "WithDrawal",
                newName: "withDrawals");

            migrationBuilder.RenameTable(
                name: "TrainerEvaluation",
                newName: "TrainerEvaluations");

            migrationBuilder.RenameTable(
                name: "Message",
                newName: "Messages");

            migrationBuilder.RenameTable(
                name: "LeaveRequest",
                newName: "LeaveRequests");

            migrationBuilder.RenameTable(
                name: "FieldReport",
                newName: "FieldReports");

            migrationBuilder.RenameTable(
                name: "CourceEvaluation",
                newName: "CourceEvaluations");

            migrationBuilder.RenameTable(
                name: "Certificate",
                newName: "Certificates");

            migrationBuilder.RenameTable(
                name: "Attendance",
                newName: "Attendances");

            migrationBuilder.RenameColumn(
                name: "DurationHours",
                table: "Cources",
                newName: "Credits");

            migrationBuilder.RenameIndex(
                name: "IX_WithDrawal_TraineeId",
                table: "withDrawals",
                newName: "IX_withDrawals_TraineeId");

            migrationBuilder.RenameIndex(
                name: "IX_TrainerEvaluation_TrainerId",
                table: "TrainerEvaluations",
                newName: "IX_TrainerEvaluations_TrainerId");

            migrationBuilder.RenameIndex(
                name: "IX_TrainerEvaluation_TraineeId",
                table: "TrainerEvaluations",
                newName: "IX_TrainerEvaluations_TraineeId");

            migrationBuilder.RenameIndex(
                name: "IX_TrainerEvaluation_CourceId",
                table: "TrainerEvaluations",
                newName: "IX_TrainerEvaluations_CourceId");

            migrationBuilder.RenameIndex(
                name: "IX_Message_SenderId",
                table: "Messages",
                newName: "IX_Messages_SenderId");

            migrationBuilder.RenameIndex(
                name: "IX_Message_ReceiverId",
                table: "Messages",
                newName: "IX_Messages_ReceiverId");

            migrationBuilder.RenameIndex(
                name: "IX_LeaveRequest_TraineeId",
                table: "LeaveRequests",
                newName: "IX_LeaveRequests_TraineeId");

            migrationBuilder.RenameIndex(
                name: "IX_FieldReport_TraineeId",
                table: "FieldReports",
                newName: "IX_FieldReports_TraineeId");

            migrationBuilder.RenameIndex(
                name: "IX_CourceEvaluation_TraineeId",
                table: "CourceEvaluations",
                newName: "IX_CourceEvaluations_TraineeId");

            migrationBuilder.RenameIndex(
                name: "IX_CourceEvaluation_CourceId",
                table: "CourceEvaluations",
                newName: "IX_CourceEvaluations_CourceId");

            migrationBuilder.RenameIndex(
                name: "IX_Certificate_TraineeId",
                table: "Certificates",
                newName: "IX_Certificates_TraineeId");

            migrationBuilder.RenameIndex(
                name: "IX_Certificate_CourceId",
                table: "Certificates",
                newName: "IX_Certificates_CourceId");

            migrationBuilder.RenameIndex(
                name: "IX_Attendance_TraineeId",
                table: "Attendances",
                newName: "IX_Attendances_TraineeId");

            migrationBuilder.RenameIndex(
                name: "IX_Attendance_CourceId",
                table: "Attendances",
                newName: "IX_Attendances_CourceId");

            migrationBuilder.AlterColumn<Guid>(
                name: "TrainerId",
                table: "Cources",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<Guid>(
                name: "TrainerId1",
                table: "Cources",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_withDrawals",
                table: "withDrawals",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainerEvaluations",
                table: "TrainerEvaluations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Messages",
                table: "Messages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LeaveRequests",
                table: "LeaveRequests",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FieldReports",
                table: "FieldReports",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourceEvaluations",
                table: "CourceEvaluations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Certificates",
                table: "Certificates",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attendances",
                table: "Attendances",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Cources_TrainerId1",
                table: "Cources",
                column: "TrainerId1");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Certificates_AspNetUsers_TraineeId",
                table: "Certificates",
                column: "TraineeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Certificates_Cources_CourceId",
                table: "Certificates",
                column: "CourceId",
                principalTable: "Cources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CourceEvaluations_AspNetUsers_TraineeId",
                table: "CourceEvaluations",
                column: "TraineeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CourceEvaluations_Cources_CourceId",
                table: "CourceEvaluations",
                column: "CourceId",
                principalTable: "Cources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cources_Trainers_TrainerId",
                table: "Cources",
                column: "TrainerId",
                principalTable: "Trainers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cources_Trainers_TrainerId1",
                table: "Cources",
                column: "TrainerId1",
                principalTable: "Trainers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FieldReports_AspNetUsers_TraineeId",
                table: "FieldReports",
                column: "TraineeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequests_AspNetUsers_TraineeId",
                table: "LeaveRequests",
                column: "TraineeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_ReceiverId",
                table: "Messages",
                column: "ReceiverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_SenderId",
                table: "Messages",
                column: "SenderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainerEvaluations_AspNetUsers_TraineeId",
                table: "TrainerEvaluations",
                column: "TraineeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainerEvaluations_AspNetUsers_TrainerId",
                table: "TrainerEvaluations",
                column: "TrainerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainerEvaluations_Cources_CourceId",
                table: "TrainerEvaluations",
                column: "CourceId",
                principalTable: "Cources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_withDrawals_AspNetUsers_TraineeId",
                table: "withDrawals",
                column: "TraineeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_AspNetUsers_TraineeId",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Cources_CourceId",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_Certificates_AspNetUsers_TraineeId",
                table: "Certificates");

            migrationBuilder.DropForeignKey(
                name: "FK_Certificates_Cources_CourceId",
                table: "Certificates");

            migrationBuilder.DropForeignKey(
                name: "FK_CourceEvaluations_AspNetUsers_TraineeId",
                table: "CourceEvaluations");

            migrationBuilder.DropForeignKey(
                name: "FK_CourceEvaluations_Cources_CourceId",
                table: "CourceEvaluations");

            migrationBuilder.DropForeignKey(
                name: "FK_Cources_Trainers_TrainerId",
                table: "Cources");

            migrationBuilder.DropForeignKey(
                name: "FK_Cources_Trainers_TrainerId1",
                table: "Cources");

            migrationBuilder.DropForeignKey(
                name: "FK_FieldReports_AspNetUsers_TraineeId",
                table: "FieldReports");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequests_AspNetUsers_TraineeId",
                table: "LeaveRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_ReceiverId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_SenderId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainerEvaluations_AspNetUsers_TraineeId",
                table: "TrainerEvaluations");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainerEvaluations_AspNetUsers_TrainerId",
                table: "TrainerEvaluations");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainerEvaluations_Cources_CourceId",
                table: "TrainerEvaluations");

            migrationBuilder.DropForeignKey(
                name: "FK_withDrawals_AspNetUsers_TraineeId",
                table: "withDrawals");

            migrationBuilder.DropIndex(
                name: "IX_Cources_TrainerId1",
                table: "Cources");

            migrationBuilder.DropPrimaryKey(
                name: "PK_withDrawals",
                table: "withDrawals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainerEvaluations",
                table: "TrainerEvaluations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Messages",
                table: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LeaveRequests",
                table: "LeaveRequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FieldReports",
                table: "FieldReports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourceEvaluations",
                table: "CourceEvaluations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Certificates",
                table: "Certificates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attendances",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "TrainerId1",
                table: "Cources");

            migrationBuilder.RenameTable(
                name: "withDrawals",
                newName: "WithDrawal");

            migrationBuilder.RenameTable(
                name: "TrainerEvaluations",
                newName: "TrainerEvaluation");

            migrationBuilder.RenameTable(
                name: "Messages",
                newName: "Message");

            migrationBuilder.RenameTable(
                name: "LeaveRequests",
                newName: "LeaveRequest");

            migrationBuilder.RenameTable(
                name: "FieldReports",
                newName: "FieldReport");

            migrationBuilder.RenameTable(
                name: "CourceEvaluations",
                newName: "CourceEvaluation");

            migrationBuilder.RenameTable(
                name: "Certificates",
                newName: "Certificate");

            migrationBuilder.RenameTable(
                name: "Attendances",
                newName: "Attendance");

            migrationBuilder.RenameColumn(
                name: "Credits",
                table: "Cources",
                newName: "DurationHours");

            migrationBuilder.RenameIndex(
                name: "IX_withDrawals_TraineeId",
                table: "WithDrawal",
                newName: "IX_WithDrawal_TraineeId");

            migrationBuilder.RenameIndex(
                name: "IX_TrainerEvaluations_TrainerId",
                table: "TrainerEvaluation",
                newName: "IX_TrainerEvaluation_TrainerId");

            migrationBuilder.RenameIndex(
                name: "IX_TrainerEvaluations_TraineeId",
                table: "TrainerEvaluation",
                newName: "IX_TrainerEvaluation_TraineeId");

            migrationBuilder.RenameIndex(
                name: "IX_TrainerEvaluations_CourceId",
                table: "TrainerEvaluation",
                newName: "IX_TrainerEvaluation_CourceId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_SenderId",
                table: "Message",
                newName: "IX_Message_SenderId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_ReceiverId",
                table: "Message",
                newName: "IX_Message_ReceiverId");

            migrationBuilder.RenameIndex(
                name: "IX_LeaveRequests_TraineeId",
                table: "LeaveRequest",
                newName: "IX_LeaveRequest_TraineeId");

            migrationBuilder.RenameIndex(
                name: "IX_FieldReports_TraineeId",
                table: "FieldReport",
                newName: "IX_FieldReport_TraineeId");

            migrationBuilder.RenameIndex(
                name: "IX_CourceEvaluations_TraineeId",
                table: "CourceEvaluation",
                newName: "IX_CourceEvaluation_TraineeId");

            migrationBuilder.RenameIndex(
                name: "IX_CourceEvaluations_CourceId",
                table: "CourceEvaluation",
                newName: "IX_CourceEvaluation_CourceId");

            migrationBuilder.RenameIndex(
                name: "IX_Certificates_TraineeId",
                table: "Certificate",
                newName: "IX_Certificate_TraineeId");

            migrationBuilder.RenameIndex(
                name: "IX_Certificates_CourceId",
                table: "Certificate",
                newName: "IX_Certificate_CourceId");

            migrationBuilder.RenameIndex(
                name: "IX_Attendances_TraineeId",
                table: "Attendance",
                newName: "IX_Attendance_TraineeId");

            migrationBuilder.RenameIndex(
                name: "IX_Attendances_CourceId",
                table: "Attendance",
                newName: "IX_Attendance_CourceId");

            migrationBuilder.AlterColumn<string>(
                name: "TrainerId",
                table: "Cources",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "BatchId",
                table: "Cources",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Cources",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ScheduleDate",
                table: "Cources",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_WithDrawal",
                table: "WithDrawal",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainerEvaluation",
                table: "TrainerEvaluation",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Message",
                table: "Message",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LeaveRequest",
                table: "LeaveRequest",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FieldReport",
                table: "FieldReport",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourceEvaluation",
                table: "CourceEvaluation",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Certificate",
                table: "Certificate",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attendance",
                table: "Attendance",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Cources_BatchId",
                table: "Cources",
                column: "BatchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendance_AspNetUsers_TraineeId",
                table: "Attendance",
                column: "TraineeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Attendance_Cources_CourceId",
                table: "Attendance",
                column: "CourceId",
                principalTable: "Cources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Certificate_AspNetUsers_TraineeId",
                table: "Certificate",
                column: "TraineeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Certificate_Cources_CourceId",
                table: "Certificate",
                column: "CourceId",
                principalTable: "Cources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CourceEvaluation_AspNetUsers_TraineeId",
                table: "CourceEvaluation",
                column: "TraineeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CourceEvaluation_Cources_CourceId",
                table: "CourceEvaluation",
                column: "CourceId",
                principalTable: "Cources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cources_AspNetUsers_TrainerId",
                table: "Cources",
                column: "TrainerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cources_Batches_BatchId",
                table: "Cources",
                column: "BatchId",
                principalTable: "Batches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FieldReport_AspNetUsers_TraineeId",
                table: "FieldReport",
                column: "TraineeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequest_AspNetUsers_TraineeId",
                table: "LeaveRequest",
                column: "TraineeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Message_AspNetUsers_ReceiverId",
                table: "Message",
                column: "ReceiverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Message_AspNetUsers_SenderId",
                table: "Message",
                column: "SenderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainerEvaluation_AspNetUsers_TraineeId",
                table: "TrainerEvaluation",
                column: "TraineeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainerEvaluation_AspNetUsers_TrainerId",
                table: "TrainerEvaluation",
                column: "TrainerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainerEvaluation_Cources_CourceId",
                table: "TrainerEvaluation",
                column: "CourceId",
                principalTable: "Cources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WithDrawal_AspNetUsers_TraineeId",
                table: "WithDrawal",
                column: "TraineeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
