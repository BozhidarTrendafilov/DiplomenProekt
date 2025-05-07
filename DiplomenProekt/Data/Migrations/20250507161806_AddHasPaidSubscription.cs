using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiplomenProekt.Data.Migrations
{
    public partial class AddHasPaidSubscription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasPaidSubscription",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasPaidSubscription",
                table: "AspNetUsers");
        }
    }
}
