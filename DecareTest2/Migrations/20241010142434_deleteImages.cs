using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DecareCenter.Migrations
{
    /// <inheritdoc />
    public partial class deleteImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FaqImage",
                table: "Centers");

            migrationBuilder.DropColumn(
                name: "Image2",
                table: "Centers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
