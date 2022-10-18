using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkProject.Migrations
{
    public partial class CreateBlogTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Desc = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "Date", "Desc", "Image", "IsDeleted", "Title" },
                values: new object[] { 1, new DateTime(2022, 10, 17, 22, 29, 18, 129, DateTimeKind.Local).AddTicks(371), " Class aptent taciti sociosqu ad litora torquent per conubia nostra", "blog-feature-img-1.jpg", false, "Flower Power" });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "Date", "Desc", "Image", "IsDeleted", "Title" },
                values: new object[] { 2, new DateTime(2022, 10, 17, 22, 29, 18, 129, DateTimeKind.Local).AddTicks(7123), " Class aptent taciti sociosqu ad litora torquent per conubia nostra", "blog-feature-img-3.jpg", false, "Flower Power" });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "Date", "Desc", "Image", "IsDeleted", "Title" },
                values: new object[] { 3, new DateTime(2022, 10, 17, 22, 29, 18, 129, DateTimeKind.Local).AddTicks(7144), " Class aptent taciti sociosqu ad litora torquent per conubia nostra", "blog-feature-img-4.jpg", false, "Flower Power" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blogs");
        }
    }
}
