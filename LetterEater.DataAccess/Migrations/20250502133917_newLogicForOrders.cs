using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LetterEater.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class newLogicForOrders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<List<Guid>>(
                name: "OrdersId",
                table: "Users",
                type: "uuid[]",
                nullable: false);

            migrationBuilder.AddColumn<List<Guid>>(
                name: "BooksId",
                table: "PublishingHouses",
                type: "uuid[]",
                nullable: false);

            migrationBuilder.AddColumn<List<Guid>>(
                name: "OrderItemsId",
                table: "Orders",
                type: "uuid[]",
                nullable: false);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "OrderItems",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<List<Guid>>(
                name: "BooksId",
                table: "Authors",
                type: "uuid[]",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrdersId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "BooksId",
                table: "PublishingHouses");

            migrationBuilder.DropColumn(
                name: "OrderItemsId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "BooksId",
                table: "Authors");

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "OrderItems",
                type: "integer",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");
        }
    }
}
