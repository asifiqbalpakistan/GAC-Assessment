using Microsoft.EntityFrameworkCore.Migrations;

namespace timesheet.data.Migrations
{
    public partial class timesheet2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTimeSheet_Employees_EmployeeId",
                table: "EmployeeTimeSheet");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTimeSheet_Tasks_TaskId",
                table: "EmployeeTimeSheet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeTimeSheet",
                table: "EmployeeTimeSheet");

            migrationBuilder.RenameTable(
                name: "EmployeeTimeSheet",
                newName: "EmployeeTimeSheets");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeTimeSheet_TaskId",
                table: "EmployeeTimeSheets",
                newName: "IX_EmployeeTimeSheets_TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeTimeSheet_EmployeeId",
                table: "EmployeeTimeSheets",
                newName: "IX_EmployeeTimeSheets_EmployeeId");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Tasks",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeTimeSheets",
                table: "EmployeeTimeSheets",
                column: "EmployeeTimeSheetId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_EmployeeId",
                table: "Tasks",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTimeSheets_Employees_EmployeeId",
                table: "EmployeeTimeSheets",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTimeSheets_Tasks_TaskId",
                table: "EmployeeTimeSheets",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Employees_EmployeeId",
                table: "Tasks",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTimeSheets_Employees_EmployeeId",
                table: "EmployeeTimeSheets");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTimeSheets_Tasks_TaskId",
                table: "EmployeeTimeSheets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Employees_EmployeeId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_EmployeeId",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeTimeSheets",
                table: "EmployeeTimeSheets");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Tasks");

            migrationBuilder.RenameTable(
                name: "EmployeeTimeSheets",
                newName: "EmployeeTimeSheet");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeTimeSheets_TaskId",
                table: "EmployeeTimeSheet",
                newName: "IX_EmployeeTimeSheet_TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeTimeSheets_EmployeeId",
                table: "EmployeeTimeSheet",
                newName: "IX_EmployeeTimeSheet_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeTimeSheet",
                table: "EmployeeTimeSheet",
                column: "EmployeeTimeSheetId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTimeSheet_Employees_EmployeeId",
                table: "EmployeeTimeSheet",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTimeSheet_Tasks_TaskId",
                table: "EmployeeTimeSheet",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
