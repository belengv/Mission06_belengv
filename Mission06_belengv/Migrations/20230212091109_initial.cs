using Microsoft.EntityFrameworkCore.Migrations;

namespace Mission06_belengv.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Responses",
                columns: table => new
                {
                    EntryId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Category = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Year = table.Column<ushort>(nullable: false),
                    Director = table.Column<string>(nullable: false),
                    Rating = table.Column<string>(nullable: false),
                    Edited = table.Column<bool>(nullable: false),
                    LentTo = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responses", x => x.EntryId);
                });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "EntryId", "Category", "Director", "Edited", "LentTo", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 1, "Drama", "Nikolas Sparks", false, "Megan", "Best movie ever!!", "PG-13", "The Longest Ride", (ushort)2014 });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "EntryId", "Category", "Director", "Edited", "LentTo", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 2, "Action", "Sam Raimi", true, "Carla", "Andrew Garfiels is everyhting!!", "PG", "The Amazing Spider Man", (ushort)2012 });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "EntryId", "Category", "Director", "Edited", "LentTo", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 3, "Action", "Tony Scott", false, "Mom", "How can this movie be so good? ", "PG-13", "Top Gun", (ushort)2022 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Responses");
        }
    }
}
