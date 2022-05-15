using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class AttendRefTrainType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TrainTypeId",
                table: "Attendance",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Abonement",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FinishDate",
                table: "Abonement",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_TrainTypeId",
                table: "Attendance",
                column: "TrainTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendance_TrainType_TrainTypeId",
                table: "Attendance",
                column: "TrainTypeId",
                principalTable: "TrainType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendance_TrainType_TrainTypeId",
                table: "Attendance");

            migrationBuilder.DropIndex(
                name: "IX_Attendance_TrainTypeId",
                table: "Attendance");

            migrationBuilder.DropColumn(
                name: "TrainTypeId",
                table: "Attendance");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Abonement",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FinishDate",
                table: "Abonement",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date");
        }
    }
}
