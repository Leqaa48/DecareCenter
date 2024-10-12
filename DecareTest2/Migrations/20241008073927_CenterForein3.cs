using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DecareCenter.Migrations
{
    /// <inheritdoc />
    public partial class CenterForein3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CenterId",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_CenterId",
                table: "Appointments",
                column: "CenterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Centers_CenterId",
                table: "Appointments",
                column: "CenterId",
                principalTable: "Centers",
                principalColumn: "CenterId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Centers_CenterId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_CenterId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "CenterId",
                table: "Appointments");
        }
    }
}
