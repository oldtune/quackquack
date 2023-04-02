using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    YearOfBirth = table.Column<int>(type: "integer", nullable: false),
                    Education = table.Column<string>(type: "text", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false),
                    Gender = table.Column<string>(type: "text", nullable: false),
                    Language = table.Column<string>(type: "text", nullable: false),
                    AvatarUrl = table.Column<string>(type: "text", nullable: false),
                    ModifiedDateUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedDateUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Domain = table.Column<string>(type: "text", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModifiedDateUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedDateUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ProfileId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Companies_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BlogPlatforms",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ModifiedDateUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedDateUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CompanyId = table.Column<int>(type: "integer", nullable: true),
                    CompanyId1 = table.Column<string>(type: "text", nullable: true),
                    ProfileId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPlatforms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogPlatforms_Companies_CompanyId1",
                        column: x => x.CompanyId1,
                        principalTable: "Companies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BlogPlatforms_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Domain = table.Column<string>(type: "text", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DemoLink = table.Column<string>(type: "text", nullable: false),
                    CompanyId = table.Column<string>(type: "text", nullable: true),
                    ModifiedDateUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedDateUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ProfileId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Projects_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BlogPosts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    PostedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    BlogPlatformId = table.Column<string>(type: "text", nullable: false),
                    ProfileId = table.Column<string>(type: "text", nullable: false),
                    ModifiedDateUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedDateUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogPosts_BlogPlatforms_BlogPlatformId",
                        column: x => x.BlogPlatformId,
                        principalTable: "BlogPlatforms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlogPosts_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogPlatforms_CompanyId1",
                table: "BlogPlatforms",
                column: "CompanyId1");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPlatforms_ProfileId",
                table: "BlogPlatforms",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPosts_BlogPlatformId",
                table: "BlogPosts",
                column: "BlogPlatformId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPosts_ProfileId",
                table: "BlogPosts",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_ProfileId",
                table: "Companies",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_CompanyId",
                table: "Projects",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProfileId",
                table: "Projects",
                column: "ProfileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogPosts");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "BlogPlatforms");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Profiles");
        }
    }
}
