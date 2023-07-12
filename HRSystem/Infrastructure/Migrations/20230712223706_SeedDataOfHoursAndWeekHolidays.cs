using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataOfHoursAndWeekHolidays : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
               table: "Hours",
               columns: new[] { "Id", "AddHours", "RemoveHours" },
               values: new object[] { 1, 2, 2 }
            );
            migrationBuilder.InsertData(
                table: "WeeklyHoliday",
                columns: new[] { "Id", "Day1", "Day2" },
                values: new object[] { 1, "الجمعة", "السبت" }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [Hours]");
            migrationBuilder.Sql("DELETE FROM [WeeklyHoliday]");
        }
    }
}
