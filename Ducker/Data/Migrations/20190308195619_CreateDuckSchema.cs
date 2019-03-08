using Microsoft.EntityFrameworkCore.Migrations;

namespace Ducker.Data.Migrations
{
    public partial class CreateDuckSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ducks",
                columns: table => new
                {
                    Name = table.Column<string>(maxLength: 32, nullable: false),
                    TimesSqueaked = table.Column<int>(nullable: false, defaultValue: 0),
                    Color = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ducks", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Ducks_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ducks_UserId",
                table: "Ducks",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ducks");
        }
    }
}
