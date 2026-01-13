using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StageLabApi.Migrations
{
    /// <inheritdoc />
    public partial class DbUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "startDateTime",
                table: "Events",
                newName: "StartDateTime");

            migrationBuilder.RenameColumn(
                name: "endDateTime",
                table: "Events",
                newName: "EndDateTime");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Events",
                newName: "Description");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Events",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartDateTime",
                table: "Events",
                newName: "startDateTime");

            migrationBuilder.RenameColumn(
                name: "EndDateTime",
                table: "Events",
                newName: "endDateTime");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Events",
                newName: "description");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "Events",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true);
        }
    }
}
