using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DecareCenter.Migrations
{
    /// <inheritdoc />
    public partial class addImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Faq");

            migrationBuilder.AddColumn<string>(
                name: "FaqImage",
                table: "Centers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image2",
                table: "Centers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FaqImage",
                table: "Centers");

            migrationBuilder.DropColumn(
                name: "Image2",
                table: "Centers");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Faq",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
