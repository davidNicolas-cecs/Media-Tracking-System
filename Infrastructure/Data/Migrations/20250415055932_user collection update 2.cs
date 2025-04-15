using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class usercollectionupdate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCollectionItems_MediaItems_MediaItemId1",
                table: "UserCollectionItems");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCollectionItems_UserCollections_UserCollectionId1",
                table: "UserCollectionItems");

            migrationBuilder.DropIndex(
                name: "IX_UserCollectionItems_MediaItemId1",
                table: "UserCollectionItems");

            migrationBuilder.DropIndex(
                name: "IX_UserCollectionItems_UserCollectionId1",
                table: "UserCollectionItems");

            migrationBuilder.DropColumn(
                name: "MediaItemId1",
                table: "UserCollectionItems");

            migrationBuilder.DropColumn(
                name: "UserCollectionId1",
                table: "UserCollectionItems");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MediaItemId1",
                table: "UserCollectionItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserCollectionId1",
                table: "UserCollectionItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserCollectionItems_MediaItemId1",
                table: "UserCollectionItems",
                column: "MediaItemId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserCollectionItems_UserCollectionId1",
                table: "UserCollectionItems",
                column: "UserCollectionId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCollectionItems_MediaItems_MediaItemId1",
                table: "UserCollectionItems",
                column: "MediaItemId1",
                principalTable: "MediaItems",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCollectionItems_UserCollections_UserCollectionId1",
                table: "UserCollectionItems",
                column: "UserCollectionId1",
                principalTable: "UserCollections",
                principalColumn: "Id");
        }
    }
}
