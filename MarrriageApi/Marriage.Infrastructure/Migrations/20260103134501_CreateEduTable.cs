using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Marriage.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateEduTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserEducations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Method = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HighestDegree = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SscPY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SscGroup = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SscResult = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SscInsName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HscPY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HscGroup = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HscResult = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HscInsName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UgPY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GSubject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UgInsName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OtherDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEducations", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserEducations");
        }
    }
}
