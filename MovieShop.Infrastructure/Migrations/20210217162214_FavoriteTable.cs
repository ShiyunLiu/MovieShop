using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieShop.Infrastructure.Migrations
{
    public partial class FavoriteTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "Favoirte",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieIdId = table.Column<int>(type: "int", nullable: true),
                    UserIdId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favoirte", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Favoirte_Movie_MovieIdId",
                        column: x => x.MovieIdId,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Favoirte_User_UserIdId",
                        column: x => x.UserIdId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Favoirte_MovieIdId",
                table: "Favoirte",
                column: "MovieIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Favoirte_UserIdId",
                table: "Favoirte",
                column: "UserIdId");
    }


        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Favoirte");
        }
    }
}
