using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class isdele : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeePersonalData_Department_DepartmentId",
                table: "EmployeePersonalData");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "EmployeePersonalData",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "Isdeleted",
                table: "EmployeePersonalData",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Isdeleted",
                table: "Department",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeePersonalData_Department_DepartmentId",
                table: "EmployeePersonalData",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeePersonalData_Department_DepartmentId",
                table: "EmployeePersonalData");

            migrationBuilder.DropColumn(
                name: "Isdeleted",
                table: "EmployeePersonalData");

            migrationBuilder.DropColumn(
                name: "Isdeleted",
                table: "Department");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "EmployeePersonalData",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeePersonalData_Department_DepartmentId",
                table: "EmployeePersonalData",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
