using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoList_WebAppDemo.Migrations
{
    public partial class addToDoListToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ToDoLists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    DateOfCreation = table.Column<string>(nullable: true),
                    CreatorId = table.Column<int>(nullable: false),
                    DateOfLastChange = table.Column<string>(nullable: true),
                    IdOfTheEditor = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoLists", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToDoLists");
        }
    }
}
