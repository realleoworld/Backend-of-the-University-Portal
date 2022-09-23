using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealleoschoolindAPI.Migrations
{
    public partial class addednewfieldisActive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "Student",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isActive",
                table: "Student");
        }
    }
}
