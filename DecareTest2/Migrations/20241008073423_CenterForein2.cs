using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DecareCenter.Migrations
{
    /// <inheritdoc />
    public partial class CenterForein2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Services_ServiceId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Doctors_DoctorId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_DoctorId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_ServiceId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "Appointments");

            migrationBuilder.AddColumn<int>(
                name: "CenterId",
                table: "Doctors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CenterId",
                table: "AboutUs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_CenterId",
                table: "Doctors",
                column: "CenterId");

            migrationBuilder.CreateIndex(
                name: "IX_AboutUs_CenterId",
                table: "AboutUs",
                column: "CenterId");

            migrationBuilder.AddForeignKey(
                name: "FK_AboutUs_Centers_CenterId",
                table: "AboutUs",
                column: "CenterId",
                principalTable: "Centers",
                principalColumn: "CenterId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Centers_CenterId",
                table: "Doctors",
                column: "CenterId",
                principalTable: "Centers",
                principalColumn: "CenterId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AboutUs_Centers_CenterId",
                table: "AboutUs");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Centers_CenterId",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_CenterId",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_AboutUs_CenterId",
                table: "AboutUs");

            migrationBuilder.DropColumn(
                name: "CenterId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "CenterId",
                table: "AboutUs");

            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "Services",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Services_DoctorId",
                table: "Services",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ServiceId",
                table: "Appointments",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Services_ServiceId",
                table: "Appointments",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "ServiceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Doctors_DoctorId",
                table: "Services",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "DoctorId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
