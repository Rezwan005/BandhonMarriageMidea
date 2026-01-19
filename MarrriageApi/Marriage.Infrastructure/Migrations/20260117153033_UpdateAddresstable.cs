using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Marriage.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAddresstable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PermanentAddress",
                table: "UserAddresses",
                newName: "PermanentVillage");

            migrationBuilder.RenameColumn(
                name: "CurrentAddress",
                table: "UserAddresses",
                newName: "PermanentUpazila");

            migrationBuilder.AddColumn<string>(
                name: "CurrentCountry",
                table: "UserAddresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CurrentDistrict",
                table: "UserAddresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CurrentDistrictId",
                table: "UserAddresses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CurrentDivision",
                table: "UserAddresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CurrentDivisionId",
                table: "UserAddresses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CurrentHouse",
                table: "UserAddresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CurrentRoad",
                table: "UserAddresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CurrentUpazila",
                table: "UserAddresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CurrentUpazilaId",
                table: "UserAddresses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CurrentVillage",
                table: "UserAddresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PermanentCountry",
                table: "UserAddresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PermanentDistrict",
                table: "UserAddresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PermanentDistrictId",
                table: "UserAddresses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PermanentDivision",
                table: "UserAddresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PermanentDivisionId",
                table: "UserAddresses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PermanentHouse",
                table: "UserAddresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PermanentRoad",
                table: "UserAddresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PermanentUpazilaId",
                table: "UserAddresses",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentCountry",
                table: "UserAddresses");

            migrationBuilder.DropColumn(
                name: "CurrentDistrict",
                table: "UserAddresses");

            migrationBuilder.DropColumn(
                name: "CurrentDistrictId",
                table: "UserAddresses");

            migrationBuilder.DropColumn(
                name: "CurrentDivision",
                table: "UserAddresses");

            migrationBuilder.DropColumn(
                name: "CurrentDivisionId",
                table: "UserAddresses");

            migrationBuilder.DropColumn(
                name: "CurrentHouse",
                table: "UserAddresses");

            migrationBuilder.DropColumn(
                name: "CurrentRoad",
                table: "UserAddresses");

            migrationBuilder.DropColumn(
                name: "CurrentUpazila",
                table: "UserAddresses");

            migrationBuilder.DropColumn(
                name: "CurrentUpazilaId",
                table: "UserAddresses");

            migrationBuilder.DropColumn(
                name: "CurrentVillage",
                table: "UserAddresses");

            migrationBuilder.DropColumn(
                name: "PermanentCountry",
                table: "UserAddresses");

            migrationBuilder.DropColumn(
                name: "PermanentDistrict",
                table: "UserAddresses");

            migrationBuilder.DropColumn(
                name: "PermanentDistrictId",
                table: "UserAddresses");

            migrationBuilder.DropColumn(
                name: "PermanentDivision",
                table: "UserAddresses");

            migrationBuilder.DropColumn(
                name: "PermanentDivisionId",
                table: "UserAddresses");

            migrationBuilder.DropColumn(
                name: "PermanentHouse",
                table: "UserAddresses");

            migrationBuilder.DropColumn(
                name: "PermanentRoad",
                table: "UserAddresses");

            migrationBuilder.DropColumn(
                name: "PermanentUpazilaId",
                table: "UserAddresses");

            migrationBuilder.RenameColumn(
                name: "PermanentVillage",
                table: "UserAddresses",
                newName: "PermanentAddress");

            migrationBuilder.RenameColumn(
                name: "PermanentUpazila",
                table: "UserAddresses",
                newName: "CurrentAddress");
        }
    }
}
