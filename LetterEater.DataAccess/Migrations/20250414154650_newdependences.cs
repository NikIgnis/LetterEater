using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LetterEater.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class newdependences : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_PublishingHouses_PublishingHouseId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_PublishingHouseId",
                table: "Books");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_PublishingHouses_BookId",
                table: "Books",
                column: "BookId",
                principalTable: "PublishingHouses",
                principalColumn: "PublishingHouseId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_PublishingHouses_BookId",
                table: "Books");

            migrationBuilder.CreateIndex(
                name: "IX_Books_PublishingHouseId",
                table: "Books",
                column: "PublishingHouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_PublishingHouses_PublishingHouseId",
                table: "Books",
                column: "PublishingHouseId",
                principalTable: "PublishingHouses",
                principalColumn: "PublishingHouseId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
