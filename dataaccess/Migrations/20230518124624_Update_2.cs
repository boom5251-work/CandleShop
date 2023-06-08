using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CandleShop.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Update_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Images",
                type: "nvarchar(260)",
                maxLength: 260,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Images_FileName",
                table: "Images",
                column: "FileName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Images_FileName",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Images");
        }
    }
}
