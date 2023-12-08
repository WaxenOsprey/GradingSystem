using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GradingSystemConsole.Migrations
{
    /// <inheritdoc />
    public partial class SecondCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Students_studentId",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Cohorts_cohortId",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "cohortId",
                table: "Students",
                newName: "CohortId");

            migrationBuilder.RenameIndex(
                name: "IX_Students_cohortId",
                table: "Students",
                newName: "IX_Students_CohortId");

            migrationBuilder.RenameColumn(
                name: "studentId",
                table: "Grades",
                newName: "StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Grades_studentId",
                table: "Grades",
                newName: "IX_Grades_StudentId");

            migrationBuilder.AlterColumn<int>(
                name: "CohortId",
                table: "Students",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "Grades",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Students_StudentId",
                table: "Grades",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "studentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Cohorts_CohortId",
                table: "Students",
                column: "CohortId",
                principalTable: "Cohorts",
                principalColumn: "cohortId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Students_StudentId",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Cohorts_CohortId",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "CohortId",
                table: "Students",
                newName: "cohortId");

            migrationBuilder.RenameIndex(
                name: "IX_Students_CohortId",
                table: "Students",
                newName: "IX_Students_cohortId");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Grades",
                newName: "studentId");

            migrationBuilder.RenameIndex(
                name: "IX_Grades_StudentId",
                table: "Grades",
                newName: "IX_Grades_studentId");

            migrationBuilder.AlterColumn<int>(
                name: "cohortId",
                table: "Students",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "studentId",
                table: "Grades",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Students_studentId",
                table: "Grades",
                column: "studentId",
                principalTable: "Students",
                principalColumn: "studentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Cohorts_cohortId",
                table: "Students",
                column: "cohortId",
                principalTable: "Cohorts",
                principalColumn: "cohortId");
        }
    }
}
