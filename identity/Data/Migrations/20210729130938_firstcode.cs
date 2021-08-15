using Microsoft.EntityFrameworkCore.Migrations;

namespace identity.Data.Migrations
{
    public partial class firstcode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [security].[userRoler](UserId,RoleId) SELECT '5de6ba2e-b7e2-4c8a-ac33-5a26ddd1d1c1',ID FROM [security].[roles]");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [security].[userRoler] WHERE Id='5de6ba2e-b7e2-4c8a-ac33-5a26ddd1d1c1'");
        }
    }
}
