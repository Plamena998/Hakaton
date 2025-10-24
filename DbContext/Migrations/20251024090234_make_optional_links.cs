using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBContext.Migrations
{
    /// <inheritdoc />
    public partial class make_optional_links : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mentors_sciences_ScienceId",
                table: "mentors");

            migrationBuilder.DropForeignKey(
                name: "FK_procedures_sciences_ScienceId",
                table: "procedures");

            migrationBuilder.AlterColumn<int>(
                name: "ScienceId",
                table: "procedures",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ScienceId",
                table: "mentors",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_mentors_sciences_ScienceId",
                table: "mentors",
                column: "ScienceId",
                principalTable: "sciences",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_procedures_sciences_ScienceId",
                table: "procedures",
                column: "ScienceId",
                principalTable: "sciences",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mentors_sciences_ScienceId",
                table: "mentors");

            migrationBuilder.DropForeignKey(
                name: "FK_procedures_sciences_ScienceId",
                table: "procedures");

            migrationBuilder.AlterColumn<int>(
                name: "ScienceId",
                table: "procedures",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ScienceId",
                table: "mentors",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_mentors_sciences_ScienceId",
                table: "mentors",
                column: "ScienceId",
                principalTable: "sciences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_procedures_sciences_ScienceId",
                table: "procedures",
                column: "ScienceId",
                principalTable: "sciences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
