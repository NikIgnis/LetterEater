using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LetterEater.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class newLogicBooks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_AuthorId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_PublishingHouses_PublishingHouseId",
                table: "Books");

            migrationBuilder.AlterColumn<Guid>(
                name: "PublishingHouseId",
                table: "Books",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "AuthorId",
                table: "Books",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<string>(
                name: "AuthorName",
                table: "Books",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PublicationYear",
                table: "Books",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PublishingHouseName",
                table: "Books",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_AuthorId",
                table: "Books",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_PublishingHouses_PublishingHouseId",
                table: "Books",
                column: "PublishingHouseId",
                principalTable: "PublishingHouses",
                principalColumn: "PublishingHouseId");
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

            migrationBuilder.DropColumn(
                name: "AuthorName",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "PublicationYear",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "PublishingHouseName",
                table: "Books");

            migrationBuilder.AlterColumn<Guid>(
                name: "PublishingHouseId",
                table: "Books",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "AuthorId",
                table: "Books",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

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
    }
}
