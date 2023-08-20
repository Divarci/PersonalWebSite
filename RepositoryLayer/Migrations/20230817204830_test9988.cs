using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositoryLayer.Migrations
{
    public partial class test9988 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NewsFeeds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: false),
                    CreatedDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    UpdatedDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsFeeds", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AboutMes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: "17/08/2023");

            migrationBuilder.UpdateData(
                table: "AboutMes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: "17/08/2023");

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: "17/08/2023");

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: "17/08/2023");

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: "17/08/2023");

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: "17/08/2023");

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: "17/08/2023");

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: "17/08/2023");

            migrationBuilder.UpdateData(
                table: "Educations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: "17/08/2023");

            migrationBuilder.UpdateData(
                table: "Educations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: "17/08/2023");

            migrationBuilder.UpdateData(
                table: "Educations",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: "17/08/2023");

            migrationBuilder.UpdateData(
                table: "Educations",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: "17/08/2023");

            migrationBuilder.UpdateData(
                table: "Experiences",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: "17/08/2023");

            migrationBuilder.UpdateData(
                table: "Experiences",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: "17/08/2023");

            migrationBuilder.UpdateData(
                table: "Experiences",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: "17/08/2023");

            migrationBuilder.UpdateData(
                table: "Experiences",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: "17/08/2023");

            migrationBuilder.UpdateData(
                table: "Facts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: "17/08/2023");

            migrationBuilder.UpdateData(
                table: "Facts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: "17/08/2023");

            migrationBuilder.UpdateData(
                table: "HomePages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: "17/08/2023");

            migrationBuilder.UpdateData(
                table: "HomePages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: "17/08/2023");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: "17/08/2023");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: "17/08/2023");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: "17/08/2023");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: "17/08/2023");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: "17/08/2023");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: "17/08/2023");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: "17/08/2023");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: "17/08/2023");

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: "17/08/2023");

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: "17/08/2023");

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: "17/08/2023");

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: "17/08/2023");

            migrationBuilder.UpdateData(
                table: "ProjectCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: "17/08/2023");

            migrationBuilder.UpdateData(
                table: "ProjectCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: "17/08/2023");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: "17/08/2023");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: "17/08/2023");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: "17/08/2023");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: "17/08/2023");

            migrationBuilder.UpdateData(
                table: "Resumes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: "17/08/2023");

            migrationBuilder.UpdateData(
                table: "Resumes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: "17/08/2023");

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: "17/08/2023");

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: "17/08/2023");

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: "17/08/2023");

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: "17/08/2023");

            migrationBuilder.UpdateData(
                table: "SocialMedias",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: "17/08/2023");

            migrationBuilder.UpdateData(
                table: "SocialMedias",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: "17/08/2023");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NewsFeeds");

            migrationBuilder.UpdateData(
                table: "AboutMes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: "12/08/2023");

            migrationBuilder.UpdateData(
                table: "AboutMes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: "12/08/2023");

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: "12/08/2023");

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: "12/08/2023");

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: "12/08/2023");

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: "12/08/2023");

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: "12/08/2023");

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: "12/08/2023");

            migrationBuilder.UpdateData(
                table: "Educations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: "12/08/2023");

            migrationBuilder.UpdateData(
                table: "Educations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: "12/08/2023");

            migrationBuilder.UpdateData(
                table: "Educations",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: "12/08/2023");

            migrationBuilder.UpdateData(
                table: "Educations",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: "12/08/2023");

            migrationBuilder.UpdateData(
                table: "Experiences",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: "12/08/2023");

            migrationBuilder.UpdateData(
                table: "Experiences",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: "12/08/2023");

            migrationBuilder.UpdateData(
                table: "Experiences",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: "12/08/2023");

            migrationBuilder.UpdateData(
                table: "Experiences",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: "12/08/2023");

            migrationBuilder.UpdateData(
                table: "Facts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: "12/08/2023");

            migrationBuilder.UpdateData(
                table: "Facts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: "12/08/2023");

            migrationBuilder.UpdateData(
                table: "HomePages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: "12/08/2023");

            migrationBuilder.UpdateData(
                table: "HomePages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: "12/08/2023");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: "12/08/2023");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: "12/08/2023");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: "12/08/2023");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: "12/08/2023");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: "12/08/2023");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: "12/08/2023");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: "12/08/2023");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: "12/08/2023");

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: "12/08/2023");

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: "12/08/2023");

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: "12/08/2023");

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: "12/08/2023");

            migrationBuilder.UpdateData(
                table: "ProjectCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: "12/08/2023");

            migrationBuilder.UpdateData(
                table: "ProjectCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: "12/08/2023");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: "12/08/2023");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: "12/08/2023");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: "12/08/2023");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: "12/08/2023");

            migrationBuilder.UpdateData(
                table: "Resumes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: "12/08/2023");

            migrationBuilder.UpdateData(
                table: "Resumes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: "12/08/2023");

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: "12/08/2023");

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: "12/08/2023");

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: "12/08/2023");

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: "12/08/2023");

            migrationBuilder.UpdateData(
                table: "SocialMedias",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: "12/08/2023");

            migrationBuilder.UpdateData(
                table: "SocialMedias",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: "12/08/2023");
        }
    }
}
