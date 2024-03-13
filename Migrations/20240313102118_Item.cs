using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ItemAPI.Migrations
{
    /// <inheritdoc />
    public partial class Item : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Item_name",
                table: "Item",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Item_Id",
                table: "Item",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Item",
                newName: "Item_name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Item",
                newName: "Item_Id");
        }
    }
}
