using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DecareCenter.Migrations
{
    /// <inheritdoc />
    public partial class CenterForein : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CenterId",
                table: "Services",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CenterId",
                table: "GalleryImages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CenterId",
                table: "Faq",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Services_CenterId",
                table: "Services",
                column: "CenterId");

            migrationBuilder.CreateIndex(
                name: "IX_GalleryImages_CenterId",
                table: "GalleryImages",
                column: "CenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Faq_CenterId",
                table: "Faq",
                column: "CenterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Faq_Centers_CenterId",
                table: "Faq",
                column: "CenterId",
                principalTable: "Centers",
                principalColumn: "CenterId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GalleryImages_Centers_CenterId",
                table: "GalleryImages",
                column: "CenterId",
                principalTable: "Centers",
                principalColumn: "CenterId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Centers_CenterId",
                table: "Services",
                column: "CenterId",
                principalTable: "Centers",
                principalColumn: "CenterId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Faq_Centers_CenterId",
                table: "Faq");

            migrationBuilder.DropForeignKey(
                name: "FK_GalleryImages_Centers_CenterId",
                table: "GalleryImages");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Centers_CenterId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_CenterId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_GalleryImages_CenterId",
                table: "GalleryImages");

            migrationBuilder.DropIndex(
                name: "IX_Faq_CenterId",
                table: "Faq");

            migrationBuilder.DropColumn(
                name: "CenterId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "CenterId",
                table: "GalleryImages");

            migrationBuilder.DropColumn(
                name: "CenterId",
                table: "Faq");
        }
    }
}
