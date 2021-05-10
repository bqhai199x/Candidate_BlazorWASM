using Microsoft.EntityFrameworkCore.Migrations;

namespace Candidate_BlazorWASM.Server.Migrations
{
    public partial class InitialRoleSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2c30d76e-cd47-41cc-b15d-4ca69cebf209", "fbb5fb65-6992-4f87-9ba0-fb29b54ad79a", "Viewer", "VIEWER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ab4539a5-0262-474c-804d-6df6d9f1b9dc", "722472d8-fac7-49e3-a5cb-df2f1d027ba0", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c30d76e-cd47-41cc-b15d-4ca69cebf209");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ab4539a5-0262-474c-804d-6df6d9f1b9dc");
        }
    }
}
