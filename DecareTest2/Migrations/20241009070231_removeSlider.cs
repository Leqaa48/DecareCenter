using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DecareCenter.Migrations
{
    /// <inheritdoc />
    public partial class removeSlider : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SliderImageUrl1",
                table: "Centers");

            migrationBuilder.RenameColumn(
                name: "SliderImageUrl2",
                table: "Centers",
                newName: "Image");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Centers",
                newName: "SliderImageUrl2");

            migrationBuilder.AddColumn<string>(
                name: "SliderImageUrl1",
                table: "Centers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
