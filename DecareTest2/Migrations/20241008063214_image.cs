using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DecareCenter.Migrations
{
    /// <inheritdoc />
    public partial class image : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "GalleryImages");

            migrationBuilder.RenameColumn(
                name: "AboutUsImageUrl",
                table: "AboutUs",
                newName: "Image");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "GalleryImages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DoctorImage",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "SliderImageUrl2",
                table: "Centers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "SliderImageUrl1",
                table: "Centers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "GalleryImages");

            migrationBuilder.DropColumn(
                name: "DoctorImage",
                table: "Doctors");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "AboutUs",
                newName: "AboutUsImageUrl");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "GalleryImages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "SliderImageUrl2",
                table: "Centers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SliderImageUrl1",
                table: "Centers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
