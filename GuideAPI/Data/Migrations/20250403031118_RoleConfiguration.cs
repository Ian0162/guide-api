using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GuideAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class RoleConfiguration : Migration
    {
        /// <inheritdoc />
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
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "cac43a6e-f7bb-4448-baaf-1add431ccbbf", null, "Administrator", "ADMINISTRATOR" },
                    { "cbc43a8e-f7bb-4445-baaf-1add431ffbbf", null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7376));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7710));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7716));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7717));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7718));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7720));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7721));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7722));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7723));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7731));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7732));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7733));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7734));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7735));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7736));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7754));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7756));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7757));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7758));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7759));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7764));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7765));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7771));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7772));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7774));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7785));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7786));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7787));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7789));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7792));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7794));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7795));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7796));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7797));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7813));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7814));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7815));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7816));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7818));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7819));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7820));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7821));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7822));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7824));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7825));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7826));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7827));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7828));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7830));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7831));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7832));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7833));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7834));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7836));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7837));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7838));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7839));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7840));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7842));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7843));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7844));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7845));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7846));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7848));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7849));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7850));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7851));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7852));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7854));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7855));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7856));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7857));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 73,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7858));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 74,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7860));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 75,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7861));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 76,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7862));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 77,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7863));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 78,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7864));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 79,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7866));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 80,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7867));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 81,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7868));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 82,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7869));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 83,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7870));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 84,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7872));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 85,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7873));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 86,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7874));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 87,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7875));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 88,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7877));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 89,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7878));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 90,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7879));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 91,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7880));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 92,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7890));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 93,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7891));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 94,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7892));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 95,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7893));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 96,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7895));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 97,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7896));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 98,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7897));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 99,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7898));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 100,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7900));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 101,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7901));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 102,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7902));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 103,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7903));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 104,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7904));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 105,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7906));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 106,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7907));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 107,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7908));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 108,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7909));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 109,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7911));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 110,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7912));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 111,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7913));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 112,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7914));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 113,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7915));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 114,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7917));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 115,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7918));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 116,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7919));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 117,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7920));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 118,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7921));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 119,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7923));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 120,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7924));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 121,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7925));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 122,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7926));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 123,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7928));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 124,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7929));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 125,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7930));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 126,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7931));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 127,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7933));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 128,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7934));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 129,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7935));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 130,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7936));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 131,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7937));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 132,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7939));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 133,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7940));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 134,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7941));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 135,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7942));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 136,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7944));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 137,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7945));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 138,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7946));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 139,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7947));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 140,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7948));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 141,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7950));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 142,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7951));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 143,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7952));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 144,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7953));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 145,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7955));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 146,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7956));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 147,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7966));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 148,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7967));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 149,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7968));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 150,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7970));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 151,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7971));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 152,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7972));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 153,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7973));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 154,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7975));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 155,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7976));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 156,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7977));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 157,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7978));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 158,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7980));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 159,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7981));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 160,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7982));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 161,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7983));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 162,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7984));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 163,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7986));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 164,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7987));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 165,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7988));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 166,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 167,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7990));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 168,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7992));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 169,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7993));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 170,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7994));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 171,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7995));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 172,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7996));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 173,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7998));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 174,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(7999));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 175,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8000));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 176,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8001));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 177,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8003));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 178,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8004));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 179,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8005));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 180,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8006));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 181,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8007));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 182,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8009));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 183,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8010));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 184,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8011));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 185,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8012));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 186,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8013));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 187,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8015));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 188,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8016));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 189,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8017));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 190,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8018));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 191,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8020));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 192,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8021));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 193,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8022));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 194,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8023));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 195,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8024));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 196,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8026));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 197,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8027));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 198,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8028));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 199,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8029));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 200,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8031));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 201,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8040));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 202,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8041));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 203,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8042));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 204,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8044));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 205,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8045));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 206,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8046));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 207,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8047));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 208,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8048));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 209,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8050));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 210,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8051));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 211,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8052));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 212,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8053));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 213,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8055));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 214,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8056));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 215,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8057));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 216,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8058));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 217,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8059));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 218,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8061));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 219,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8062));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 220,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8063));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 221,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8064));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 222,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8066));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 223,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8067));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 224,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8068));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 225,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8069));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 226,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8070));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 227,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8072));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 228,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8073));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 229,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8074));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 230,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8075));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 231,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8077));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 232,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8078));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 233,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8079));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 234,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8080));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 235,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8081));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 236,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8083));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 237,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8084));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 238,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8085));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 239,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8086));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 240,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8088));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 241,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8089));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 242,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8090));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 243,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8091));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 244,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8233));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 245,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8234));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 246,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8236));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 247,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8237));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 248,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8238));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 249,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8239));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 250,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8241));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 251,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8242));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 252,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8243));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 253,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8244));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 254,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8245));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 255,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8255));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 256,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8256));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 257,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8257));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 258,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8258));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 259,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8260));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 260,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8261));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 261,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8262));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 262,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8263));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 263,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8264));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 264,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8266));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 265,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8267));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 266,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8268));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 267,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8269));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 268,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8271));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 269,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8272));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 270,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8273));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 271,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8274));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 272,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8276));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 273,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8277));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 274,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8278));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 275,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8279));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 276,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8280));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 277,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8282));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 278,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8283));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 279,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8284));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 280,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8285));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 281,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8287));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 282,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8288));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 283,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8289));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 284,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8290));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 285,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8292));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 286,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8293));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 287,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8294));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 288,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8295));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 289,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8297));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 290,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8298));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 291,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8299));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 292,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8300));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 293,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8301));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 294,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8303));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 295,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8304));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 296,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8305));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 297,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8306));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 298,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8308));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 299,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8309));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 300,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8310));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 301,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8311));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 302,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8313));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 303,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8314));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 304,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8315));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 305,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8316));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 306,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8317));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 307,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8319));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 308,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8320));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 309,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8330));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 310,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8331));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 311,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8333));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 312,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8334));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 313,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8335));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 314,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8337));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 315,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8338));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 316,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8339));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 317,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8340));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 318,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8341));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 319,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8343));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 320,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8344));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 321,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8345));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 322,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8346));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 323,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8348));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 324,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8349));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 325,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8350));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 326,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8351));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 327,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8352));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 328,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8354));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 329,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8355));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 330,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8356));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 331,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8357));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 332,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8359));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 333,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8360));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 334,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8361));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 335,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8362));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 336,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8364));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 337,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8365));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 338,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8366));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 339,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8367));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 340,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8368));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 341,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8370));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 342,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8371));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 343,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8372));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 344,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8373));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 345,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8375));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 346,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8376));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 347,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8377));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 348,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8378));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 349,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8379));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 350,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8381));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 351,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8382));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 352,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8383));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 353,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8384));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 354,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8386));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 355,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8387));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 356,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8388));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 357,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8389));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 358,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8391));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 359,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8392));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 360,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8393));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 361,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8394));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 362,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8396));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 363,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8405));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 364,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8406));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 365,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8408));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 366,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8409));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 367,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8410));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 368,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8411));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 369,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8412));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 370,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8414));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 371,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8415));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 372,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8416));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 373,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8417));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 374,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8419));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 375,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8420));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 376,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8421));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 377,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8422));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 378,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8424));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 379,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8425));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 380,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8426));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 381,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8427));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 382,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8428));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 383,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8430));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 384,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8431));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 385,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8432));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 386,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8433));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 387,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8435));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 388,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8436));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 389,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8437));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 390,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8438));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 391,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8440));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 392,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8441));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 393,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8442));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 394,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8443));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 395,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8444));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 396,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8446));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 397,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8447));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 398,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8448));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 399,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8449));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 400,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8451));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 401,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8452));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 402,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8453));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 403,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8454));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 404,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8456));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 405,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8457));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 406,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8458));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 407,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8459));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 408,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8460));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 409,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8462));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 410,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8463));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 411,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8464));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 412,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8465));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 413,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8467));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 414,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8468));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 415,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8469));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 416,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8478));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 417,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8480));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 418,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8481));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 419,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8482));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 420,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8483));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 421,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8485));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 422,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8486));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 423,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8487));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 424,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8488));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 425,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8490));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 426,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8491));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 427,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8492));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 428,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8493));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 429,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8495));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 430,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8496));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 431,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8497));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 432,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8498));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 433,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8499));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 434,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8501));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 435,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8502));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 436,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8503));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 437,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8504));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 438,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8506));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 439,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8507));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 440,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8508));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 441,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8509));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 442,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8511));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 443,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8512));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 444,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8513));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 445,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8514));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 446,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8515));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 447,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8517));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 448,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8518));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 449,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8519));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 450,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8520));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 451,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8522));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 452,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8523));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 453,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8524));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 454,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8525));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 455,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8526));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 456,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8528));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 457,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8529));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 458,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8530));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 459,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8531));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 460,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8533));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 461,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8534));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 462,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8535));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 463,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8536));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 464,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8538));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 465,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8539));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 466,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8540));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 467,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8541));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 468,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8543));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 469,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8544));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 470,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8553));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 471,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8554));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 472,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8555));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 473,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8556));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 474,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8558));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 475,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8559));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 476,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8560));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 477,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8561));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 478,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8563));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 479,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8564));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 480,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8565));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 481,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8566));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 482,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8567));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 483,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8569));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 484,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8570));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 485,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8571));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 486,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8572));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 487,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8574));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 488,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8575));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 489,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8576));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 490,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8577));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 491,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8579));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 492,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8580));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 493,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8581));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 494,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8582));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 495,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8583));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 496,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8585));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 497,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8586));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 498,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8587));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 499,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8588));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 500,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 3, 11, 17, 468, DateTimeKind.Unspecified).AddTicks(8590));

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
        }

        /// <inheritdoc />
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
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(3622));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4015));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4021));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4022));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4024));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4028));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4030));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4032));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4033));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4038));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4040));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4041));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4042));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4043));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4044));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4085));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4086));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4088));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4113));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4115));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4116));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4117));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4118));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4119));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4121));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4129));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4135));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4136));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4148));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4150));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4151));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4152));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4153));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4155));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4156));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4157));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4158));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4160));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4161));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4162));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4163));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4164));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4166));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4167));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4168));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4169));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4170));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4172));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4173));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4174));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4175));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4177));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4178));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4179));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4180));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4181));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4183));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4184));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4185));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4186));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4188));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4189));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4190));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4191));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4192));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4194));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4195));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4196));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4197));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4199));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4200));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 73,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4210));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 74,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4212));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 75,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4213));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 76,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4214));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 77,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4215));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 78,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4216));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 79,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4218));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 80,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4219));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 81,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4220));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 82,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4221));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 83,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4222));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 84,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4224));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 85,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4225));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 86,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4226));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 87,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4227));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 88,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4229));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 89,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4230));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 90,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4231));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 91,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4232));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 92,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4233));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 93,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4235));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 94,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4236));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 95,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4237));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 96,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4238));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 97,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4240));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 98,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4241));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 99,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4242));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 100,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4243));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 101,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4245));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 102,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4246));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 103,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4247));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 104,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4248));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 105,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4250));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 106,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4251));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 107,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4252));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 108,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4253));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 109,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4255));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 110,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4256));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 111,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4257));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 112,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4258));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 113,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4260));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 114,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4261));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 115,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4262));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 116,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4263));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 117,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4265));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 118,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4266));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 119,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4267));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 120,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4268));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 121,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4269));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 122,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4271));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 123,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4272));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 124,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4273));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 125,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4274));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 126,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4276));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 127,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4277));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 128,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4278));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 129,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4291));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 130,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4292));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 131,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4293));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 132,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4294));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 133,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4296));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 134,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4297));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 135,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4298));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 136,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4299));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 137,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4301));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 138,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4302));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 139,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4303));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 140,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4304));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 141,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4306));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 142,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4307));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 143,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4308));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 144,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4309));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 145,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4311));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 146,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4312));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 147,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4313));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 148,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4314));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 149,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4315));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 150,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4317));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 151,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4318));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 152,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4319));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 153,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4320));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 154,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4322));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 155,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4323));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 156,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4324));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 157,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4325));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 158,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4327));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 159,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4328));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 160,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4329));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 161,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4330));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 162,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4332));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 163,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4333));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 164,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4334));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 165,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4335));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 166,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4337));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 167,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4338));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 168,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4339));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 169,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4340));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 170,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4341));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 171,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4343));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 172,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4344));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 173,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4345));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 174,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4346));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 175,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4348));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 176,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4349));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 177,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4350));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 178,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4351));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 179,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4353));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 180,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4354));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 181,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4355));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 182,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4356));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 183,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4386));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 184,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4387));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 185,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4389));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 186,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4390));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 187,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4391));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 188,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4392));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 189,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4394));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 190,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4395));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 191,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4396));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 192,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4397));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 193,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4399));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 194,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4400));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 195,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4401));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 196,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4402));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 197,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4404));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 198,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4405));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 199,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4406));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 200,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4407));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 201,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4409));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 202,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4410));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 203,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4411));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 204,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4412));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 205,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4414));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 206,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4415));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 207,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4416));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 208,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4417));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 209,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4418));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 210,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4420));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 211,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4421));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 212,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4422));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 213,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4423));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 214,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4425));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 215,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4426));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 216,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4427));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 217,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4428));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 218,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4430));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 219,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4431));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 220,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4432));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 221,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4433));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 222,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4435));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 223,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4436));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 224,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4437));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 225,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4438));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 226,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4440));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 227,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4441));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 228,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4442));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 229,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4443));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 230,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4444));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 231,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4446));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 232,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4447));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 233,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4448));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 234,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4449));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 235,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4454));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 236,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4455));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 237,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4468));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 238,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4470));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 239,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4472));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 240,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4474));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 241,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4476));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 242,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4478));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 243,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4479));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 244,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4481));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 245,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4483));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 246,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4485));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 247,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4487));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 248,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4488));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 249,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4490));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 250,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4492));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 251,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4494));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 252,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4496));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 253,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4497));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 254,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4499));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 255,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4501));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 256,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4507));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 257,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4509));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 258,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4511));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 259,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4512));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 260,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4514));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 261,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4516));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 262,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4517));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 263,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4519));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 264,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4521));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 265,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4523));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 266,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4525));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 267,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4527));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 268,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4528));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 269,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4530));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 270,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4532));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 271,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4534));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 272,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4535));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 273,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4537));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 274,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4539));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 275,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4541));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 276,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4542));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 277,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4544));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 278,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4546));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 279,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4548));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 280,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4549));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 281,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4551));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 282,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4553));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 283,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4555));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 284,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4556));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 285,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4558));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 286,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4560));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 287,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4562));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 288,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4563));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 289,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4565));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 290,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4567));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 291,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4580));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 292,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4583));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 293,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4584));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 294,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4586));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 295,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4588));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 296,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4590));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 297,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4592));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 298,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4593));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 299,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4595));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 300,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4597));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 301,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4598));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 302,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4600));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 303,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4602));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 304,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4604));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 305,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4606));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 306,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4608));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 307,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4610));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 308,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4612));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 309,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4614));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 310,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4615));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 311,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4617));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 312,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4619));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 313,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4621));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 314,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4622));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 315,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4624));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 316,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4626));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 317,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4628));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 318,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4630));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 319,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4631));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 320,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4633));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 321,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4635));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 322,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4637));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 323,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4639));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 324,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4641));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 325,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4643));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 326,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4645));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 327,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4646));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 328,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4648));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 329,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4650));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 330,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4652));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 331,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4653));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 332,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4655));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 333,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4657));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 334,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4659));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 335,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4661));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 336,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4664));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 337,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4666));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 338,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4668));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 339,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4670));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 340,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4672));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 341,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4674));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 342,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4676));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 343,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4678));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 344,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4680));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 345,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4692));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 346,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4694));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 347,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4695));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 348,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4697));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 349,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4699));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 350,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4700));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 351,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4702));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 352,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4704));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 353,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4705));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 354,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4707));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 355,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4708));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 356,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4710));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 357,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4712));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 358,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4713));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 359,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4715));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 360,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4716));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 361,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4718));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 362,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4720));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 363,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4721));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 364,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4723));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 365,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4724));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 366,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4726));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 367,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4728));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 368,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4729));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 369,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4731));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 370,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4732));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 371,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4734));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 372,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4736));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 373,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4737));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 374,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4739));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 375,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4740));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 376,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4742));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 377,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4744));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 378,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4745));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 379,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4747));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 380,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4748));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 381,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4750));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 382,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4752));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 383,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4753));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 384,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4755));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 385,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4756));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 386,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4758));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 387,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4760));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 388,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4761));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 389,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4763));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 390,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4765));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 391,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4766));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 392,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4768));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 393,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4769));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 394,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4771));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 395,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4773));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 396,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4774));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 397,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4776));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 398,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4789));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 399,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4791));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 400,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4792));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 401,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4794));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 402,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4795));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 403,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4797));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 404,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4799));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 405,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4800));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 406,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4802));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 407,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4803));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 408,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4805));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 409,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4807));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 410,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4809));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 411,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4810));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 412,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4811));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 413,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4813));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 414,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4814));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 415,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4815));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 416,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4816));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 417,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4818));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 418,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4819));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 419,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4820));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 420,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4821));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 421,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4822));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 422,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4824));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 423,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4825));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 424,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4826));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 425,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4827));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 426,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4829));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 427,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4830));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 428,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4831));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 429,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4832));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 430,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4833));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 431,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4835));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 432,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4836));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 433,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4840));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 434,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4842));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 435,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4844));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 436,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4846));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 437,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4848));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 438,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4850));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 439,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4852));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 440,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4854));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 441,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4856));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 442,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4858));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 443,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4860));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 444,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4862));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 445,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4864));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 446,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4866));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 447,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4868));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 448,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4869));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 449,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4871));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 450,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4873));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 451,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4875));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 452,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4889));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 453,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4891));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 454,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4893));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 455,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4895));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 456,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4897));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 457,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4899));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 458,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4901));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 459,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4903));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 460,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4905));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 461,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4906));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 462,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4908));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 463,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4910));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 464,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4912));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 465,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4914));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 466,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4917));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 467,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4919));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 468,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4921));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 469,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4923));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 470,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4925));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 471,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4927));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 472,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4928));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 473,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4930));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 474,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4931));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 475,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4933));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 476,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4934));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 477,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4936));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 478,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4938));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 479,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4939));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 480,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4941));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 481,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4942));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 482,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4944));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 483,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4945));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 484,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4947));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 485,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4949));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 486,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4951));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 487,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4952));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 488,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4953));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 489,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4954));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 490,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4956));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 491,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4957));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 492,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4958));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 493,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4959));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 494,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4961));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 495,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4962));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 496,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4963));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 497,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4964));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 498,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4966));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 499,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4967));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 500,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 0, 1, 7, 299, DateTimeKind.Unspecified).AddTicks(4968));
        }
    }
}
