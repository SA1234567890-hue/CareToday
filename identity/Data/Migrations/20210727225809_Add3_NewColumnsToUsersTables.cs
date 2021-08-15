using Microsoft.EntityFrameworkCore.Migrations;

namespace identity.Data.Migrations
{
    public partial class Add3_NewColumnsToUsersTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                schema: "security",
                table: "users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                schema: "security",
                table: "users",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                schema: "security",
                table: "users");

            migrationBuilder.DropColumn(
                name: "LastName",
                schema: "security",
                table: "users");
        }
    }
}
