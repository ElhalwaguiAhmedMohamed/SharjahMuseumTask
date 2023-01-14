using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SharjahMuseumTask.EF.Migrations
{
    /// <inheritdoc />
    public partial class CreateEmployeeAttendenceTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmpAttendances",
                columns: table => new
                {
                    EventLGUID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SRVDT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DEVDT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DevId = table.Column<int>(type: "int", nullable: false),
                    EmpId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpAttendances", x => x.EventLGUID);
                    table.ForeignKey(
                        name: "FK_EmpAttendances_Devices_DevId",
                        column: x => x.DevId,
                        principalTable: "Devices",
                        principalColumn: "DevUid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpAttendances_Employees_EmpId",
                        column: x => x.EmpId,
                        principalTable: "Employees",
                        principalColumn: "EmpId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmpAttendances_DevId",
                table: "EmpAttendances",
                column: "DevId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpAttendances_EmpId",
                table: "EmpAttendances",
                column: "EmpId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmpAttendances");
        }
    }
}
