using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment2.Migrations
{
    public partial class AddUserIdToItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                schema: "Identity",
                table: "Items",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Items_UserId",
                schema: "Identity",
                table: "Items",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_User_UserId",
                schema: "Identity",
                table: "Items",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_User_UserId",
                schema: "Identity",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_UserId",
                schema: "Identity",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "Identity",
                table: "Items");
        }
    }
}
