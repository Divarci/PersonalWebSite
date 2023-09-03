using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositoryLayer.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    EmailConfirm = table.Column<short>(type: "smallint", maxLength: 5, nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuthAccessToken",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthAccessToken", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "AuthRefreshToken",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthRefreshToken", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "NewsFeeds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CreatedDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    UpdatedDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsFeeds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Resumes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    IsPublished = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsEdited = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    UpdatedDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resumes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AboutMes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    IsPublished = table.Column<bool>(type: "bit", nullable: false),
                    IsEdited = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    FileName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ResumeId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    UpdatedDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutMes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AboutMes_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "Resumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Certificates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Date = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Priorty = table.Column<short>(type: "smallint", maxLength: 3, nullable: false),
                    IsPublished = table.Column<bool>(type: "bit", nullable: false),
                    IsEdited = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    ResumeId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    UpdatedDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Certificates_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "Resumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Educations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Date = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Priorty = table.Column<short>(type: "smallint", maxLength: 3, nullable: false),
                    IsPublished = table.Column<bool>(type: "bit", nullable: false),
                    IsEdited = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    ResumeId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    UpdatedDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Educations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Educations_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "Resumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Experiences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Date = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Priorty = table.Column<short>(type: "smallint", maxLength: 3, nullable: false),
                    IsPublished = table.Column<bool>(type: "bit", nullable: false),
                    IsEdited = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    ResumeId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    UpdatedDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experiences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Experiences_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "Resumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HomePages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VideoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsPublished = table.Column<bool>(type: "bit", nullable: false),
                    IsEdited = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    ResumeCvFileName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ResumeCvFileType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ResumeId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    UpdatedDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomePages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomePages_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "Resumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sender = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    IsEdited = table.Column<bool>(type: "bit", nullable: false),
                    ResumeId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    UpdatedDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "Resumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsPublished = table.Column<bool>(type: "bit", nullable: false),
                    IsEdited = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    ResumeId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    UpdatedDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectCategories_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "Resumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Value = table.Column<byte>(type: "tinyint", maxLength: 2, nullable: false),
                    IsPublished = table.Column<bool>(type: "bit", nullable: false),
                    IsEdited = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    ResumeId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    UpdatedDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skills_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "Resumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    LocationUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AboutMeId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    UpdatedDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacts_AboutMes_AboutMeId",
                        column: x => x.AboutMeId,
                        principalTable: "AboutMes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Facts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DaysOfStudy = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    Project = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    CodingLanguage = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    Certificate = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    AboutMeId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    UpdatedDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Facts_AboutMes_AboutMeId",
                        column: x => x.AboutMeId,
                        principalTable: "AboutMes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SocialMedias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GitHub = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: true),
                    Twitter = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: true),
                    LinkedIn = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: true),
                    Youtube = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: true),
                    AboutMeId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    UpdatedDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialMedias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SocialMedias_AboutMes_AboutMeId",
                        column: x => x.AboutMeId,
                        principalTable: "AboutMes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: false),
                    ProjectDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ProjectCategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    UpdatedDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_ProjectCategories_ProjectCategoryId",
                        column: x => x.ProjectCategoryId,
                        principalTable: "ProjectCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    UpdatedDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Resumes",
                columns: new[] { "Id", "CreatedDate", "Description", "IsPublished", "Title", "UpdatedDate" },
                values: new object[] { 1, "29/08/2023", "This is the best resume for now. Continue to use it.", true, "Software Developer London Resume", null });

            migrationBuilder.InsertData(
                table: "Resumes",
                columns: new[] { "Id", "CreatedDate", "Description", "IsEdited", "Title", "UpdatedDate" },
                values: new object[] { 2, "29/08/2023", "This is prepared for after ILR. Do not use this for now.", true, "Software Developer Manchester Resume", null });

            migrationBuilder.InsertData(
                table: "AboutMes",
                columns: new[] { "Id", "CreatedDate", "Description", "FileName", "FileType", "IsPublished", "ResumeId", "Title", "UpdatedDate" },
                values: new object[] { 1, "29/08/2023", "As a recent graduate in architecture with a passion for technology, I am excited to begin a new journey in the field of coding. Despite my lack of professional experience in this field, I am highly motivated and eager to learn and grow.I am committed to dedicating myself to studying coding concepts, practicing my skills, and seeking out opportunities to apply my knowledge to real-world projects. My background in architecture has equipped me with valuable skills such as creativity, problem-solving, and attention to detail, which I believe will be invaluable in my pursuit of a career in coding. My eagerness to learn and my passion for coding are what drive me. I am always eager to take on new challenges and to push myself to the limit in order to achieve my goals. Through my dedication and hard work, I am confident that I can make a meaningful contribution to any team or project that I am a part of.", "Add Picture", "Add Picture", true, 1, "Software Developer London", null });

            migrationBuilder.InsertData(
                table: "AboutMes",
                columns: new[] { "Id", "CreatedDate", "Description", "FileName", "FileType", "IsEdited", "IsPublished", "ResumeId", "Title", "UpdatedDate" },
                values: new object[] { 2, "29/08/2023", "As a recent graduate in architecture with a passion for technology, I am excited to begin a new journey in the field of coding. Despite my lack of professional experience in this field, I am highly motivated and eager to learn and grow.I am committed to dedicating myself to studying coding concepts, practicing my skills, and seeking out opportunities to apply my knowledge to real-world projects. My background in architecture has equipped me with valuable skills such as creativity, problem-solving, and attention to detail, which I believe will be invaluable in my pursuit of a career in coding. My eagerness to learn and my passion for coding are what drive me. I am always eager to take on new challenges and to push myself to the limit in order to achieve my goals. Through my dedication and hard work, I am confident that I can make a meaningful contribution to any team or project that I am a part of.", "Add Picture", "Add Picture", true, false, 2, "Software Developer Manchester", null });

            migrationBuilder.InsertData(
                table: "Certificates",
                columns: new[] { "Id", "CreatedDate", "Date", "IsPublished", "Location", "Priorty", "ResumeId", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "29/08/2023", "February 2023", true, "Udemy Course", (short)1, 1, "Step by Step C#", null },
                    { 2, "29/08/2023", "March 2023", true, "Udemy Course", (short)2, 1, "Ms SQL with querries", null }
                });

            migrationBuilder.InsertData(
                table: "Certificates",
                columns: new[] { "Id", "CreatedDate", "Date", "IsEdited", "IsPublished", "Location", "Priorty", "ResumeId", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 3, "29/08/2023", "April 2023", true, false, "Udemy Course", (short)1, 2, "ASP.NET Framework MVC5", null },
                    { 4, "29/08/2023", "May 2023", true, false, "Udemy Course", (short)2, 2, "ASP.NET Core 6 MVC", null }
                });

            migrationBuilder.InsertData(
                table: "Educations",
                columns: new[] { "Id", "CreatedDate", "Date", "IsPublished", "Location", "Priorty", "ResumeId", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "29/08/2023", "2005 - 2010", true, "YILDIZ TECHNICAL UNIVERSITY", (short)1, 1, "ARCHITECTURE", null },
                    { 2, "29/08/2023", "2001 - 2005", true, "ATATURK HIGH SCHOOL", (short)2, 1, "SCIENCE AND MATH", null }
                });

            migrationBuilder.InsertData(
                table: "Educations",
                columns: new[] { "Id", "CreatedDate", "Date", "IsEdited", "IsPublished", "Location", "Priorty", "ResumeId", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 3, "29/08/2023", "2005 - 2010", true, false, "YILDIZ TECHNICAL UNIVERSITY", (short)1, 2, "ARCHITECTURE", null },
                    { 4, "29/08/2023", "2001 - 2005", true, false, "ATATURK HIGH SCHOOL", (short)2, 2, "SCIENCE AND MATH", null }
                });

            migrationBuilder.InsertData(
                table: "Experiences",
                columns: new[] { "Id", "CreatedDate", "Date", "IsPublished", "Location", "Priorty", "ResumeId", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "29/08/2023", "February 2023 - Present", true, "Freelance, London", (short)1, 1, "Trainee Software Developer", null },
                    { 2, "29/08/2023", "April 2019 - Present", true, "B&H Design Ltd, London", (short)2, 1, "Architect (Director)", null }
                });

            migrationBuilder.InsertData(
                table: "Experiences",
                columns: new[] { "Id", "CreatedDate", "Date", "IsEdited", "IsPublished", "Location", "Priorty", "ResumeId", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 3, "29/08/2023", "July 2011 - April 2019", true, false, "Gul-Na Architecture, Turkey", (short)1, 2, "Architect (Director)", null },
                    { 4, "29/08/2023", "June 2010 - June 2011", true, false, "Engiz Architecture, Turkey", (short)2, 2, "Architectural Assistant", null }
                });

            migrationBuilder.InsertData(
                table: "HomePages",
                columns: new[] { "Id", "CreatedDate", "Description", "FullName", "IsPublished", "ResumeCvFileName", "ResumeCvFileType", "ResumeId", "UpdatedDate", "VideoUrl" },
                values: new object[] { 1, "29/08/2023", "As a recent graduate in architecture with a passion for technology, I am excited to begin a new journey in the field of coding. Despite my lack of professional experience in this field.", "Hasan Divarci", true, "Add Pcture", "Add Pcture", 1, null, "https://youtu.be/RKKoABC31zk'" });

            migrationBuilder.InsertData(
                table: "HomePages",
                columns: new[] { "Id", "CreatedDate", "Description", "FullName", "IsEdited", "IsPublished", "ResumeCvFileName", "ResumeCvFileType", "ResumeId", "UpdatedDate", "VideoUrl" },
                values: new object[] { 2, "29/08/2023", "As a recent graduate in architecture with a passion for technology, I am excited to begin a new journey in the field of coding. Despite my lack of professional experience in this field.", "Hasan Divarci", true, false, "Add Pcture", "Add Pcture", 2, null, "https://youtu.be/RKKoABC31zk'" });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "IsEdited", "ResumeId", "Sender", "Subject", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "29/08/2023", "Welcome to the My Study Projects category. ", "adanali@adamlar.geldi", false, 1, "Melih Canatan", "Deneme Mesaji", null },
                    { 2, "29/08/2023", "Welcome to the My Study Projects category2. ", "mallar@adamlar.geldi", false, 1, "Tarik Canatan", "Deneme Mesaji 2", null },
                    { 3, "29/08/2023", "Welcome to the My Study Projects category3. ", "antalyali@adamlar.geldi", false, 2, "Kazim Canatan", "Deneme Mesaji 3", null },
                    { 4, "29/08/2023", "Welcome to the My Study Projects category4. ", "bursali@adamlar.geldi", false, 2, "Veli Canatan", "Deneme Mesaji 4", null }
                });

            migrationBuilder.InsertData(
                table: "ProjectCategories",
                columns: new[] { "Id", "CreatedDate", "Description", "IsPublished", "ResumeId", "Title", "UpdatedDate" },
                values: new object[] { 1, "29/08/2023", "Welcome to the My Study Projects category. ", true, 1, "Study", null });

            migrationBuilder.InsertData(
                table: "ProjectCategories",
                columns: new[] { "Id", "CreatedDate", "Description", "IsEdited", "IsPublished", "ResumeId", "Title", "UpdatedDate" },
                values: new object[] { 2, "29/08/2023", "Welcome to the Real-World Projects category, where I present a series of practical.", true, false, 2, "Real", null });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "CreatedDate", "IsPublished", "ResumeId", "Title", "UpdatedDate", "Value" },
                values: new object[,]
                {
                    { 1, "29/08/2023", true, 1, "C# Coding Language", null, (byte)65 },
                    { 2, "29/08/2023", true, 1, "Asp.Net Core 6 Mvc", null, (byte)85 }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "CreatedDate", "IsEdited", "IsPublished", "ResumeId", "Title", "UpdatedDate", "Value" },
                values: new object[,]
                {
                    { 3, "29/08/2023", true, false, 2, "HTML", null, (byte)45 },
                    { 4, "29/08/2023", true, false, 2, "CSS", null, (byte)65 }
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "AboutMeId", "Address", "CreatedDate", "Email", "LocationUrl", "Phone", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, "20 Cosmopolitan Court, 67 Main Avenue, Enfield, EN1 1GD", "29/08/2023", "hasan@gmail.com", "1", "0785463212540", null },
                    { 2, 2, "44 Dowsett Road, Manchester, N17 9DD", "29/08/2023", "hasan@gmail.com", "2", "0785463212540", null }
                });

            migrationBuilder.InsertData(
                table: "Facts",
                columns: new[] { "Id", "AboutMeId", "Certificate", "CodingLanguage", "CreatedDate", "DaysOfStudy", "Project", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, 8, 3, "29/08/2023", 180, 12, null },
                    { 2, 2, 10, 2, "29/08/2023", 120, 15, null }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CreatedDate", "Description", "ProjectCategoryId", "ProjectDate", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "29/08/2023", "I'm excited to share details about my new project, which played a pivotal role in advancing my C# skills. This project had a strong emphasis on developing dynamic buttons with assigned dynamic missions, all accomplished through the implementation of complex algorithms. By implementing these complex algorithms, I not only expanded my knowledge of algorithmic concepts but also strengthened my problem-solving abilities. I gained valuable experience in analyzing complex problems, devising efficient solutions, and translating them into clean and well-structured code. This project served as a significant milestone in my C# journey, allowing me to consolidate my skills, broaden my horizons, and tackle more intricate programming challenges. I am proud of the achievements and growth I attained throughout this project, and I eagerly look forward to utilizing the knowledge and experiences gained to create innovative solutions in future endeavors. I'm excited about the opportunities that lie ahead and can't wait to continue expanding my expertise in C# and tackling even more advanced projects.", 1, "2022 June", "Flight Ticket", null },
                    { 2, "29/08/2023", "I am thrilled to share the details of my new project, which represents a significant milestone in my journey as a developer. Building upon the foundational skills I acquired in my first project, I dedicated this endeavor to two key areas: database connections and C# algorithms. In this project, I focused on establishing connections to databases, leveraging the capabilities of SQL and database query languages to interact with data effectively. I invested time and effort in learning about database design, normalization, and the principles of relational databases. I grasped concepts such as tables, primary keys, foreign keys, and relationships, which enabled me to design efficient and well-structured database schemas. Using C#, I honed my skills in implementing database connectivity through frameworks or libraries such as ADO.NET or Entity Framework. I gained proficiency in executing SQL queries, retrieving and manipulating data, and handling transactions to ensure data integrity. I am proud of the progress I made during this project, and I am excited to continue expanding my skills in database management, algorithmic problem-solving, and other facets of software development in future endeavors.", 1, "2022 July", "Education Portal", null },
                    { 3, "29/08/2023", "I'm thrilled to share details about my latest project, a potential professional endeavor, developed using ASP.NET Core 6 MVC. This project represents a significant milestone in my journey as a developer, as it showcases my ability to apply solid disciplines, design patterns, clean code rules, and utilize various libraries and features. Throughout the development process, I prioritized adhering to solid disciplines. By applying this principle, I ensured a well-structured and maintainable codebase, enabling future modifications and enhancements with ease. In pursuit of clean code, I followed established coding conventions and guidelines, emphasizing readability, maintainability, and self-documentation. I employed meaningful naming conventions, utilized appropriate code comments, and organized the codebase logically to enhance collaboration and understandability. To handle user authentication and authorization, I leveraged identity libraries provided by ASP.NET Core, ensuring secure access control and user management. I implemented notification mechanisms to keep users informed about relevant updates, ensuring an engaging and interactive experience. With ASP.NET Core 6 MVC , I am confident in my ability to create innovative, scalable solutions that meet the evolving needs of the industry.", 2, "2022 May", "Portfolio Web Site", null },
                    { 4, "29/08/2023", "I'm thrilled to share details about my latest project, a potential professional endeavor, developed using ASP.NET Core 6 MVC. This project represents a significant milestone in my journey as a developer, as it showcases my ability to apply solid disciplines, design patterns, clean code rules, and utilize various libraries and features. Throughout the development process, I prioritized adhering to solid disciplines. By applying this principle, I ensured a well-structured and maintainable codebase, enabling future modifications and enhancements with ease. In pursuit of clean code, I followed established coding conventions and guidelines, emphasizing readability, maintainability, and self-documentation. I employed meaningful naming conventions, utilized appropriate code comments, and organized the codebase logically to enhance collaboration and understandability. To handle user authentication and authorization, I leveraged identity libraries provided by ASP.NET Core, ensuring secure access control and user management. I implemented notification mechanisms to keep users informed about relevant updates, ensuring an engaging and interactive experience. With ASP.NET Core 6 MVC , I am confident in my ability to create innovative, scalable solutions that meet the evolving needs of the industry.", 2, "2022 April", "Portfolio Web Site", null }
                });

            migrationBuilder.InsertData(
                table: "SocialMedias",
                columns: new[] { "Id", "AboutMeId", "CreatedDate", "GitHub", "LinkedIn", "Twitter", "UpdatedDate", "Youtube" },
                values: new object[,]
                {
                    { 1, 1, "29/08/2023", "https://github.com/", "https://linkdin.com/", "https://twitter.com/", null, "https://youtube.com/" },
                    { 2, 2, "29/08/2023", "https://github.com/", "https://linkdin.com/", "https://twitter.com/", null, "https://youtube.com/" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CreatedDate", "FileName", "FileType", "ProjectId", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "29/08/2023", "Add New File", "Add New File", 1, null },
                    { 2, "29/08/2023", "Add New File", "Add New File", 1, null },
                    { 3, "29/08/2023", "Add New File", "Add New File", 2, null },
                    { 4, "29/08/2023", "Add New File", "Add New File", 2, null },
                    { 5, "29/08/2023", "Add New File", "Add New File", 3, null },
                    { 6, "29/08/2023", "Add New File", "Add New File", 3, null },
                    { 7, "29/08/2023", "Add New File", "Add New File", 4, null },
                    { 8, "29/08/2023", "Add New File", "Add New File", 4, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AboutMes_IsEdited",
                table: "AboutMes",
                column: "IsEdited");

            migrationBuilder.CreateIndex(
                name: "IX_AboutMes_IsPublished",
                table: "AboutMes",
                column: "IsPublished");

            migrationBuilder.CreateIndex(
                name: "IX_AboutMes_ResumeId",
                table: "AboutMes",
                column: "ResumeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_IsEdited",
                table: "Certificates",
                column: "IsEdited");

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_IsPublished",
                table: "Certificates",
                column: "IsPublished");

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_ResumeId",
                table: "Certificates",
                column: "ResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_AboutMeId",
                table: "Contacts",
                column: "AboutMeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Educations_IsEdited",
                table: "Educations",
                column: "IsEdited");

            migrationBuilder.CreateIndex(
                name: "IX_Educations_IsPublished",
                table: "Educations",
                column: "IsPublished");

            migrationBuilder.CreateIndex(
                name: "IX_Educations_ResumeId",
                table: "Educations",
                column: "ResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_IsEdited",
                table: "Experiences",
                column: "IsEdited");

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_IsPublished",
                table: "Experiences",
                column: "IsPublished");

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_ResumeId",
                table: "Experiences",
                column: "ResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_Facts_AboutMeId",
                table: "Facts",
                column: "AboutMeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HomePages_IsEdited",
                table: "HomePages",
                column: "IsEdited");

            migrationBuilder.CreateIndex(
                name: "IX_HomePages_IsPublished",
                table: "HomePages",
                column: "IsPublished");

            migrationBuilder.CreateIndex(
                name: "IX_HomePages_ResumeId",
                table: "HomePages",
                column: "ResumeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_ProjectId",
                table: "Images",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ResumeId",
                table: "Messages",
                column: "ResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectCategories_IsEdited",
                table: "ProjectCategories",
                column: "IsEdited");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectCategories_IsPublished",
                table: "ProjectCategories",
                column: "IsPublished");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectCategories_ResumeId",
                table: "ProjectCategories",
                column: "ResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectCategoryId",
                table: "Projects",
                column: "ProjectCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Resumes_IsEdited",
                table: "Resumes",
                column: "IsEdited");

            migrationBuilder.CreateIndex(
                name: "IX_Resumes_IsPublished",
                table: "Resumes",
                column: "IsPublished");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_IsEdited",
                table: "Skills",
                column: "IsEdited");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_IsPublished",
                table: "Skills",
                column: "IsPublished");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_ResumeId",
                table: "Skills",
                column: "ResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialMedias_AboutMeId",
                table: "SocialMedias",
                column: "AboutMeId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AuthAccessToken");

            migrationBuilder.DropTable(
                name: "AuthRefreshToken");

            migrationBuilder.DropTable(
                name: "Certificates");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Educations");

            migrationBuilder.DropTable(
                name: "Experiences");

            migrationBuilder.DropTable(
                name: "Facts");

            migrationBuilder.DropTable(
                name: "HomePages");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "NewsFeeds");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "SocialMedias");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "AboutMes");

            migrationBuilder.DropTable(
                name: "ProjectCategories");

            migrationBuilder.DropTable(
                name: "Resumes");
        }
    }
}
