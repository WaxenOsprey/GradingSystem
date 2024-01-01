using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GradingSystemApi.Migrations
{
    /// <inheritdoc />
    public partial class addStudentAdveragefix9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "average",
                table: "Students");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "average",
                table: "Students",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
