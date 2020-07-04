using Microsoft.EntityFrameworkCore.Migrations;

namespace s17624_APBD_KolokwiumPoprawa.Migrations
{
    public partial class addedFirefighterAction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FirefighterActions",
                columns: table => new
                {
                    IdFirefighter = table.Column<int>(nullable: false),
                    IdAction = table.Column<int>(nullable: false),
                    FirefighterIdFirefighter = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FirefighterActions", x => new { x.IdAction, x.IdFirefighter });
                    table.ForeignKey(
                        name: "FK_FirefighterActions_Firefighters_FirefighterIdFirefighter",
                        column: x => x.FirefighterIdFirefighter,
                        principalTable: "Firefighters",
                        principalColumn: "IdFirefighter",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FirefighterActions_Actions_IdAction",
                        column: x => x.IdAction,
                        principalTable: "Actions",
                        principalColumn: "IdAction",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FirefighterActions_FirefighterIdFirefighter",
                table: "FirefighterActions",
                column: "FirefighterIdFirefighter");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FirefighterActions");
        }
    }
}
