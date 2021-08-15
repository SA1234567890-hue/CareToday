using Microsoft.EntityFrameworkCore.Migrations;

namespace identity.Data.Migrations
{
    public partial class Add5_NewColumnsToUsersTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [security].[users] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Confirm_Password], [Id_National], [Password], [Phone], [FirstName], [LastName]) VALUES (N'5de6ba2e-b7e2-4c8a-ac33-5a26ddd1d1c1', N'ahmedosama', N'AHMEDOSAMA', N'ahmedosama@gmail.com', N'AHMEDOSAMA@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEAYVY4uEBbpMEE8P66VElfmw+7ZnSgHmfb/WhP1kLo5mQ7tgcu2mamnPcTZnci49KA==', N'XHAT5A4ODI3WWE3LG6FZJZPPQUBPOBKW', N'd2f5a9ba-fff5-442d-9fec-cf8f550c8ca6', NULL, 0, 0, NULL, 1, 0, NULL, N'20345678912345', NULL, 1238333384, N'ahmed', N'osama')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [security].[users] WHERE UserId='5de6ba2e-b7e2-4c8a-ac33-5a26ddd1d1c1' ");
        }
    }
}
