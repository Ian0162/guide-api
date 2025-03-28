using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GuideAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    departmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isHidden = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    createdBy = table.Column<int>(type: "int", nullable: false),
                    updatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departments", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "departments",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "UpdatedAt", "createdBy", "departmentName", "isHidden", "updatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 28, 6, 26, 51, 169, DateTimeKind.Unspecified).AddTicks(2603), null, null, 1, "Software Development", false, null },
                    { 2, new DateTime(2025, 3, 28, 6, 26, 51, 169, DateTimeKind.Unspecified).AddTicks(3024), null, null, 1, "Marketing", false, null },
                    { 3, new DateTime(2025, 3, 28, 6, 26, 51, 169, DateTimeKind.Unspecified).AddTicks(3029), null, null, 1, "Admin", false, null },
                    { 4, new DateTime(2025, 3, 28, 6, 26, 51, 169, DateTimeKind.Unspecified).AddTicks(3031), null, null, 1, "Human Resources", false, null },
                    { 5, new DateTime(2025, 3, 28, 6, 26, 51, 169, DateTimeKind.Unspecified).AddTicks(3052), null, null, 1, "Finance", false, null },
                    { 6, new DateTime(2025, 3, 28, 6, 26, 51, 169, DateTimeKind.Unspecified).AddTicks(3054), null, null, 1, "Operations", false, null },
                    { 7, new DateTime(2025, 3, 28, 6, 26, 51, 169, DateTimeKind.Unspecified).AddTicks(3055), null, null, 1, "Sales", false, null },
                    { 8, new DateTime(2025, 3, 28, 6, 26, 51, 169, DateTimeKind.Unspecified).AddTicks(3056), null, null, 1, "Customer Support", false, null },
                    { 9, new DateTime(2025, 3, 28, 6, 26, 51, 169, DateTimeKind.Unspecified).AddTicks(3058), null, null, 1, "Legal", false, null },
                    { 10, new DateTime(2025, 3, 28, 6, 26, 51, 169, DateTimeKind.Unspecified).AddTicks(3059), null, null, 1, "Product Management", false, null },
                    { 11, new DateTime(2025, 3, 28, 6, 26, 51, 169, DateTimeKind.Unspecified).AddTicks(3060), null, null, 1, "Engineering", false, null },
                    { 12, new DateTime(2025, 3, 28, 6, 26, 51, 169, DateTimeKind.Unspecified).AddTicks(3061), null, null, 1, "Business Development", false, null },
                    { 13, new DateTime(2025, 3, 28, 6, 26, 51, 169, DateTimeKind.Unspecified).AddTicks(3063), null, null, 1, "Quality Assurance", false, null },
                    { 14, new DateTime(2025, 3, 28, 6, 26, 51, 169, DateTimeKind.Unspecified).AddTicks(3064), null, null, 1, "Research & Development", false, null },
                    { 15, new DateTime(2025, 3, 28, 6, 26, 51, 169, DateTimeKind.Unspecified).AddTicks(3065), null, null, 1, "IT Support", false, null },
                    { 16, new DateTime(2025, 3, 28, 6, 26, 51, 169, DateTimeKind.Unspecified).AddTicks(3066), null, null, 1, "Design", false, null },
                    { 17, new DateTime(2025, 3, 28, 6, 26, 51, 169, DateTimeKind.Unspecified).AddTicks(3068), null, null, 1, "Procurement", false, null },
                    { 18, new DateTime(2025, 3, 28, 6, 26, 51, 169, DateTimeKind.Unspecified).AddTicks(3069), null, null, 1, "Training", false, null },
                    { 19, new DateTime(2025, 3, 28, 6, 26, 51, 169, DateTimeKind.Unspecified).AddTicks(3070), null, null, 1, "Public Relations", false, null },
                    { 20, new DateTime(2025, 3, 28, 6, 26, 51, 169, DateTimeKind.Unspecified).AddTicks(3071), null, null, 1, "Compliance", false, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "departments");
        }
    }
}
