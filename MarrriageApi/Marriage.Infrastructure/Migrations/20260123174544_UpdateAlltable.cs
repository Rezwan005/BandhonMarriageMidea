using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Marriage.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAlltable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BiodataContacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    GroomName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GuardianMobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GuardianRelation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BiodataEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BiodataContacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BiodataGeneralInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    BiodataType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MaritalStatus = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", maxLength: 200, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SkinTone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    BloodGroup = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BiodataGeneralInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BioSteps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StepId = table.Column<int>(type: "int", nullable: false),
                    StepName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StepOrder = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BioSteps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DataLookups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataLookups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OccupationalInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Profession = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfessionDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MonthlyIncome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OccupationalInfos", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "UserAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PermanentCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PermanentDivisionId = table.Column<int>(type: "int", nullable: true),
                    PermanentDistrictId = table.Column<int>(type: "int", nullable: true),
                    PermanentUpazilaId = table.Column<int>(type: "int", nullable: true),
                    PermanentDivision = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PermanentDistrict = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PermanentUpazila = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PermanentVillage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PermanentRoad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PermanentHouse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentDivisionId = table.Column<int>(type: "int", nullable: true),
                    CurrentDistrictId = table.Column<int>(type: "int", nullable: true),
                    CurrentUpazilaId = table.Column<int>(type: "int", nullable: true),
                    CurrentDivision = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentDistrict = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentUpazila = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentVillage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentRoad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentHouse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hometown = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsSameAddress = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAddresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserBiodata",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    BiodataNo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBiodata", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserBioStepProgress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    StepId = table.Column<int>(type: "int", nullable: false),
                    BiodataId = table.Column<int>(type: "int", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    CompletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBioStepProgress", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GoogleId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserBiodata_BiodataNo",
                table: "UserBiodata",
                column: "BiodataNo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserBioStepProgress_UserId_StepId",
                table: "UserBioStepProgress",
                columns: new[] { "UserId", "StepId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BiodataContacts");

            migrationBuilder.DropTable(
                name: "BiodataGeneralInfos");

            migrationBuilder.DropTable(
                name: "BioSteps");

            migrationBuilder.DropTable(
                name: "DataLookups");

            migrationBuilder.DropTable(
                name: "OccupationalInfos");

            migrationBuilder.DropTable(
                name: "PersonalInfos");

            migrationBuilder.DropTable(
                name: "UserAddresses");

            migrationBuilder.DropTable(
                name: "UserBiodata");

            migrationBuilder.DropTable(
                name: "UserBioStepProgress");

            migrationBuilder.DropTable(
                name: "UserEducations");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
