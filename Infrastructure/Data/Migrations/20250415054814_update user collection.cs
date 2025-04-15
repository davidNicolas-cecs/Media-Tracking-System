using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateusercollection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCollections_MediaItems_MediaItemId",
                table: "UserCollections");

            migrationBuilder.DropIndex(
                name: "IX_UserCollections_MediaItemId",
                table: "UserCollections");

            migrationBuilder.DropColumn(
                name: "MediaItemId",
                table: "UserCollections");



        

           

          
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "MediaItemId",
                table: "UserCollections",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserCollections_MediaItemId",
                table: "UserCollections",
                column: "MediaItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCollections_MediaItems_MediaItemId",
                table: "UserCollections",
                column: "MediaItemId",
                principalTable: "MediaItems",
                principalColumn: "Id");
        }
    }
}
