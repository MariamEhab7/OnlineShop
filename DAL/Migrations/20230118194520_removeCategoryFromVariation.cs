using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class removeCategoryFromVariation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Variations_Categories_CategoryId",
                table: "Variations");

            migrationBuilder.DropIndex(
                name: "IX_Variations_CategoryId",
                table: "Variations");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Variations");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "Variations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Variations_CategoryId",
                table: "Variations",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Variations_Categories_CategoryId",
                table: "Variations",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
