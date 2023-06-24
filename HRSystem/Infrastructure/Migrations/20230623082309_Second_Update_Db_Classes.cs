using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Second_Update_Db_Classes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bonus_Hours");

            migrationBuilder.DropTable(
                name: "Minus_Hours");

            migrationBuilder.CreateTable(
                name: "EmployeeWorkData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    salary = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    AttandanceDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OutDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmployeeID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeWorkData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeWorkData_EmployeePersonalData_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "EmployeePersonalData",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Hours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddHours = table.Column<int>(type: "int", nullable: true),
                    RemoveHours = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hours", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeWorkData_EmployeeID",
                table: "EmployeeWorkData",
                column: "EmployeeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeWorkData");

            migrationBuilder.DropTable(
                name: "Hours");

            migrationBuilder.CreateTable(
                name: "Bonus_Hours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Hours = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bonus_Hours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bonus_Hours_EmployeePersonalData_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EmployeePersonalData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Minus_Hours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hours = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Minus_Hours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Minus_Hours_EmployeePersonalData_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EmployeePersonalData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bonus_Hours_EmployeeId",
                table: "Bonus_Hours",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Minus_Hours_EmployeeId",
                table: "Minus_Hours",
                column: "EmployeeId");
        }
    }
}
