using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StageLabApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateConstraints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_EventUser_EventId",
                table: "EventUser",
                column: "EventId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_EventUser_UserId",
                table: "EventUser",
                column: "UserId"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_EventUser_Event_EventId",
                table: "EventUser",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade
            );

            migrationBuilder.AddForeignKey(
                name: "FK_EventUser_User_UserId",
                table: "EventUser",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_EventUser_Event_EventId", table: "EventUser");

            migrationBuilder.DropForeignKey(name: "FK_EventUser_User_UserId", table: "EventUser");

            migrationBuilder.DropIndex(name: "IX_EventUser_EventId", table: "EventUser");

            migrationBuilder.DropIndex(name: "IX_EventUser_UserId", table: "EventUser");
        }
    }
}
