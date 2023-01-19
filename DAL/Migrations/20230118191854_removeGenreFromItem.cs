using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class removeGenreFromItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_GenreOfItems_GenreOfItemsGenreId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_GenreOfItemsGenreId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "GenreOfItemsGenreId",
                table: "Items");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "GenreOfItemsGenreId",
                table: "Items",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Items_GenreOfItemsGenreId",
                table: "Items",
                column: "GenreOfItemsGenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_GenreOfItems_GenreOfItemsGenreId",
                table: "Items",
                column: "GenreOfItemsGenreId",
                principalTable: "GenreOfItems",
                principalColumn: "GenreId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
