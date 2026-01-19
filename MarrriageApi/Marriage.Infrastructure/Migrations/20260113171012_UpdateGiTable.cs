







using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Marriage.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateGiTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Age",
                table: "BiodataGeneralInfos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "BiodataGeneralInfos");
        }
    }
}
