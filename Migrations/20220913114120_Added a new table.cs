using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealleoschoolindAPI.Migrations
{
    public partial class Addedanewtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "course",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseFees = table.Column<double>(type: "float", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedOn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_course", x => x.CourseId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "course");
        }
    }
}
