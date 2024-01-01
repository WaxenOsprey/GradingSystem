using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GradingSystemApi.Migrations
{
    /// <inheritdoc />
    public partial class addStudentAdverage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "average",
                table: "Students",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "average",
                table: "Students");
        }
    }
}
