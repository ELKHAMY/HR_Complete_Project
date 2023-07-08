using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class delworkk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeWorkData");

            migrationBuilder.RenameColumn(
                name: "Salary",
                table: "EmployeePersonalData",
                newName: "salary");

            migrationBuilder.AddColumn<DateTime>(
                name: "AttandanceDate",
                table: "EmployeePersonalData",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "OutDate",
                table: "EmployeePersonalData",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AttandanceDate",
                table: "EmployeePersonalData");

            migrationBuilder.DropColumn(
                name: "OutDate",
                table: "EmployeePersonalData");

            migrationBuilder.RenameColumn(
                name: "salary",
                table: "EmployeePersonalData",
                newName: "Salary");

            migrationBuilder.CreateTable(
                name: "EmployeeWorkData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(type: "int", nullable: true),
                    AttandanceDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OutDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WorkDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    salary = table.Column<decimal>(type: "decimal(18,4)", nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeWorkData_EmployeeID",
                table: "EmployeeWorkData",
                column: "EmployeeID");
        }
    }
}
