using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrarions
{
    public partial class ItemsToListRelationshipAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskItems_TodoLists_TodoListId",
                table: "TaskItems");

            migrationBuilder.DropIndex(
                name: "IX_TaskItems_TodoListId",
                table: "TaskItems");

            migrationBuilder.DropColumn(
                name: "TodoListId",
                table: "TaskItems");

            migrationBuilder.CreateIndex(
                name: "IX_TaskItems_ListId",
                table: "TaskItems",
                column: "ListId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskItems_TodoLists_ListId",
                table: "TaskItems",
                column: "ListId",
                principalTable: "TodoLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskItems_TodoLists_ListId",
                table: "TaskItems");

            migrationBuilder.DropIndex(
                name: "IX_TaskItems_ListId",
                table: "TaskItems");

            migrationBuilder.AddColumn<int>(
                name: "TodoListId",
                table: "TaskItems",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaskItems_TodoListId",
                table: "TaskItems",
                column: "TodoListId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskItems_TodoLists_TodoListId",
                table: "TaskItems",
                column: "TodoListId",
                principalTable: "TodoLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
