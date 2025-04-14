using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LetterEater.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class tryagain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_BookEntity",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_PublishingHouses_BookId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_BookEntity",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "BookEntity",
                table: "Books");

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_PublishingHouseId",
                table: "Books",
                column: "PublishingHouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_AuthorId",
                table: "Books",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "AuthorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_PublishingHouses_PublishingHouseId",
                table: "Books",
                column: "PublishingHouseId",
                principalTable: "PublishingHouses",
                principalColumn: "PublishingHouseId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_AuthorId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_PublishingHouses_PublishingHouseId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_AuthorId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_PublishingHouseId",
                table: "Books");

            migrationBuilder.AddColumn<Guid>(
                name: "BookEntity",
                table: "Books",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Books_BookEntity",
                table: "Books",
                column: "BookEntity");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_BookEntity",
                table: "Books",
                column: "BookEntity",
                principalTable: "Authors",
                principalColumn: "AuthorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_PublishingHouses_BookId",
                table: "Books",
                column: "BookId",
                principalTable: "PublishingHouses",
                principalColumn: "PublishingHouseId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
