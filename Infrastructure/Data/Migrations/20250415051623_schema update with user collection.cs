using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class schemaupdatewithusercollection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCollections_AspNetUsers_UserId",
                table: "UserCollections");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCollections_MediaItems_MediaItemId",
                table: "UserCollections");

            migrationBuilder.DropIndex(
                name: "IX_UserCollections_UserId",
                table: "UserCollections");

            migrationBuilder.DropColumn(
                name: "Progress",
                table: "UserCollections");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserCollections",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "MediaItemId",
                table: "UserCollections",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Rating",
                table: "MediaItems",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "UserCollectionId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserCollectionItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserCollectionId = table.Column<int>(type: "int", nullable: false),
                    MediaItemId = table.Column<int>(type: "int", nullable: false),
                    Progress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCollectionItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserCollectionItems_MediaItems_MediaItemId",
                        column: x => x.MediaItemId,
                        principalTable: "MediaItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCollectionItems_UserCollections_UserCollectionId",
                        column: x => x.UserCollectionId,
                        principalTable: "UserCollections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserCollectionId",
                table: "AspNetUsers",
                column: "UserCollectionId",
                unique: true,
                filter: "[UserCollectionId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserCollectionItems_MediaItemId",
                table: "UserCollectionItems",
                column: "MediaItemId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCollectionItems_UserCollectionId",
                table: "UserCollectionItems",
                column: "UserCollectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_UserCollections_UserCollectionId",
                table: "AspNetUsers",
                column: "UserCollectionId",
                principalTable: "UserCollections",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCollections_MediaItems_MediaItemId",
                table: "UserCollections",
                column: "MediaItemId",
                principalTable: "MediaItems",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_UserCollections_UserCollectionId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCollections_MediaItems_MediaItemId",
                table: "UserCollections");

            migrationBuilder.DropTable(
                name: "UserCollectionItems");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UserCollectionId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserCollectionId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserCollections",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "MediaItemId",
                table: "UserCollections",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Progress",
                table: "UserCollections",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Rating",
                table: "MediaItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserCollections_UserId",
                table: "UserCollections",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCollections_AspNetUsers_UserId",
                table: "UserCollections",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCollections_MediaItems_MediaItemId",
                table: "UserCollections",
                column: "MediaItemId",
                principalTable: "MediaItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
