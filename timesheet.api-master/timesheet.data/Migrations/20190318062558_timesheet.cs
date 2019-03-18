using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace timesheet.data.Migrations
{
    public partial class timesheet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeTimeSheet",
                columns: table => new
                {
                    EmployeeTimeSheetId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmployeeId = table.Column<int>(nullable: false),
                    TaskId = table.Column<int>(nullable: false),
                    WorkingDate = table.Column<DateTime>(nullable: false),
                    WorkingHours = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTimeSheet", x => x.EmployeeTimeSheetId);
                    table.ForeignKey(
                        name: "FK_EmployeeTimeSheet_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeTimeSheet_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTimeSheet_EmployeeId",
                table: "EmployeeTimeSheet",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTimeSheet_TaskId",
                table: "EmployeeTimeSheet",
                column: "TaskId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeTimeSheet");
        }
    }
}
