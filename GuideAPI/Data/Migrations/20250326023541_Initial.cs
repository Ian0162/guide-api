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
                    createdDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    createdBy = table.Column<int>(type: "int", nullable: false),
                    updatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departments", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "departments",
                columns: new[] { "Id", "createdBy", "createdDate", "deleteDate", "departmentName", "isHidden", "updatedBy", "updatedDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 3, 26, 2, 35, 41, 111, DateTimeKind.Unspecified).AddTicks(5556), null, "Software Development", false, null, null },
                    { 2, 1, new DateTime(2025, 3, 26, 2, 35, 41, 111, DateTimeKind.Unspecified).AddTicks(5895), null, "Marketing", false, null, null },
                    { 3, 1, new DateTime(2025, 3, 26, 2, 35, 41, 111, DateTimeKind.Unspecified).AddTicks(5901), null, "Admin", false, null, null },
                    { 4, 1, new DateTime(2025, 3, 26, 2, 35, 41, 111, DateTimeKind.Unspecified).AddTicks(5902), null, "Human Resources", false, null, null },
                    { 5, 1, new DateTime(2025, 3, 26, 2, 35, 41, 111, DateTimeKind.Unspecified).AddTicks(5903), null, "Finance", false, null, null },
                    { 6, 1, new DateTime(2025, 3, 26, 2, 35, 41, 111, DateTimeKind.Unspecified).AddTicks(5904), null, "Operations", false, null, null },
                    { 7, 1, new DateTime(2025, 3, 26, 2, 35, 41, 111, DateTimeKind.Unspecified).AddTicks(5906), null, "Sales", false, null, null },
                    { 8, 1, new DateTime(2025, 3, 26, 2, 35, 41, 111, DateTimeKind.Unspecified).AddTicks(5907), null, "Customer Support", false, null, null },
                    { 9, 1, new DateTime(2025, 3, 26, 2, 35, 41, 111, DateTimeKind.Unspecified).AddTicks(5908), null, "Legal", false, null, null },
                    { 10, 1, new DateTime(2025, 3, 26, 2, 35, 41, 111, DateTimeKind.Unspecified).AddTicks(5909), null, "Product Management", false, null, null },
                    { 11, 1, new DateTime(2025, 3, 26, 2, 35, 41, 111, DateTimeKind.Unspecified).AddTicks(5911), null, "Engineering", false, null, null },
                    { 12, 1, new DateTime(2025, 3, 26, 2, 35, 41, 111, DateTimeKind.Unspecified).AddTicks(5912), null, "Business Development", false, null, null },
                    { 13, 1, new DateTime(2025, 3, 26, 2, 35, 41, 111, DateTimeKind.Unspecified).AddTicks(5913), null, "Quality Assurance", false, null, null },
                    { 14, 1, new DateTime(2025, 3, 26, 2, 35, 41, 111, DateTimeKind.Unspecified).AddTicks(5915), null, "Research & Development", false, null, null },
                    { 15, 1, new DateTime(2025, 3, 26, 2, 35, 41, 111, DateTimeKind.Unspecified).AddTicks(5916), null, "IT Support", false, null, null },
                    { 16, 1, new DateTime(2025, 3, 26, 2, 35, 41, 111, DateTimeKind.Unspecified).AddTicks(5917), null, "Design", false, null, null },
                    { 17, 1, new DateTime(2025, 3, 26, 2, 35, 41, 111, DateTimeKind.Unspecified).AddTicks(5918), null, "Procurement", false, null, null },
                    { 18, 1, new DateTime(2025, 3, 26, 2, 35, 41, 111, DateTimeKind.Unspecified).AddTicks(5919), null, "Training", false, null, null },
                    { 19, 1, new DateTime(2025, 3, 26, 2, 35, 41, 111, DateTimeKind.Unspecified).AddTicks(5921), null, "Public Relations", false, null, null },
                    { 20, 1, new DateTime(2025, 3, 26, 2, 35, 41, 111, DateTimeKind.Unspecified).AddTicks(5922), null, "Compliance", false, null, null }
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
