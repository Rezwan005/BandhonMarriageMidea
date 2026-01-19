using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Marriage.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreatePersonalInfoTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonalInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DressOutside = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiseaseInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpecialWork = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AboutYourself = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SelfiePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalInfos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonalInfos");
        }
    }
}
