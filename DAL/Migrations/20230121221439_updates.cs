using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class updates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_GenreOfItems_GenreId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GenreOfItems",
                table: "GenreOfItems");

            migrationBuilder.RenameTable(
                name: "GenreOfItems",
                newName: "Genres");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genres",
                table: "Genres",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Genres_GenreId",
                table: "Products",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "GenreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Genres_GenreId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genres",
                table: "Genres");

            migrationBuilder.RenameTable(
                name: "Genres",
                newName: "GenreOfItems");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GenreOfItems",
                table: "GenreOfItems",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_GenreOfItems_GenreId",
                table: "Products",
                column: "GenreId",
                principalTable: "GenreOfItems",
                principalColumn: "GenreId");
        }
    }
}
