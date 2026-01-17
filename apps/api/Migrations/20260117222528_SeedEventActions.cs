using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StageLabApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedEventActions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Action",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Allows users to create event records", "CreateEvent" },
                    { 2, "Allows users to delete their own event record", "DeleteOwnEvent" },
                    { 3, "Allows users to delete any event record", "DeleteAnyEvent" },
                    { 4, "Allows users to edit their own event record", "EditOwnEvent" },
                    { 5, "Allows users to edit any event record", "EditAnyEvent" },
                    { 6, "Allows users to view their own event record", "ViewOwnEvent" },
                    { 7, "Allows users to view any event records", "ViewAnyEvent" },
                }
            );

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    {
                        1,
                        "Role owned by administrator users in the arts org (has all actions assigned to them)",
                        "Admin",
                    },
                    {
                        2,
                        "Role owned by artist users in the arts org (has restricted actions)",
                        "Artist",
                    },
                }
            );

            migrationBuilder.InsertData(
                table: "ActionRole",
                columns: new[] { "Id", "ActionId", "RoleId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 2, 1 },
                    { 4, 2, 2 },
                    { 5, 3, 1 },
                    { 6, 4, 1 },
                    { 7, 4, 2 },
                    { 8, 5, 1 },
                    { 9, 6, 1 },
                    { 10, 6, 2 },
                    { 11, 7, 1 },
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(table: "ActionRole", keyColumn: "Id", keyValue: 1);

            migrationBuilder.DeleteData(table: "ActionRole", keyColumn: "Id", keyValue: 2);

            migrationBuilder.DeleteData(table: "ActionRole", keyColumn: "Id", keyValue: 3);

            migrationBuilder.DeleteData(table: "ActionRole", keyColumn: "Id", keyValue: 4);

            migrationBuilder.DeleteData(table: "ActionRole", keyColumn: "Id", keyValue: 5);

            migrationBuilder.DeleteData(table: "ActionRole", keyColumn: "Id", keyValue: 6);

            migrationBuilder.DeleteData(table: "ActionRole", keyColumn: "Id", keyValue: 7);

            migrationBuilder.DeleteData(table: "ActionRole", keyColumn: "Id", keyValue: 8);

            migrationBuilder.DeleteData(table: "ActionRole", keyColumn: "Id", keyValue: 9);

            migrationBuilder.DeleteData(table: "ActionRole", keyColumn: "Id", keyValue: 10);

            migrationBuilder.DeleteData(table: "ActionRole", keyColumn: "Id", keyValue: 11);

            migrationBuilder.DeleteData(table: "Action", keyColumn: "Id", keyValue: 1);

            migrationBuilder.DeleteData(table: "Action", keyColumn: "Id", keyValue: 2);

            migrationBuilder.DeleteData(table: "Action", keyColumn: "Id", keyValue: 3);

            migrationBuilder.DeleteData(table: "Action", keyColumn: "Id", keyValue: 4);

            migrationBuilder.DeleteData(table: "Action", keyColumn: "Id", keyValue: 5);

            migrationBuilder.DeleteData(table: "Action", keyColumn: "Id", keyValue: 6);

            migrationBuilder.DeleteData(table: "Action", keyColumn: "Id", keyValue: 7);

            migrationBuilder.DeleteData(table: "Role", keyColumn: "Id", keyValue: 1);

            migrationBuilder.DeleteData(table: "Role", keyColumn: "Id", keyValue: 2);
        }
    }
}
