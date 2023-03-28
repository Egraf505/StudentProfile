using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentProfile.Persistence.Migrations
{
    public partial class UpdateTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Events_EventId",
                table: "Skills");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Students_StudentId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Skills_EventId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Skills_StudentId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Skills");

            migrationBuilder.CreateTable(
                name: "EventSkill",
                columns: table => new
                {
                    EventsId = table.Column<int>(type: "int", nullable: false),
                    SkillsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventSkill", x => new { x.EventsId, x.SkillsId });
                    table.ForeignKey(
                        name: "FK_EventSkill_Events_EventsId",
                        column: x => x.EventsId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventSkill_Skills_SkillsId",
                        column: x => x.SkillsId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SkillStudent",
                columns: table => new
                {
                    SkillsId = table.Column<int>(type: "int", nullable: false),
                    StudentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillStudent", x => new { x.SkillsId, x.StudentsId });
                    table.ForeignKey(
                        name: "FK_SkillStudent_Skills_SkillsId",
                        column: x => x.SkillsId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SkillStudent_Students_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventSkill_SkillsId",
                table: "EventSkill",
                column: "SkillsId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillStudent_StudentsId",
                table: "SkillStudent",
                column: "StudentsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventSkill");

            migrationBuilder.DropTable(
                name: "SkillStudent");

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Skills",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Skills",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Skills_EventId",
                table: "Skills",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_StudentId",
                table: "Skills",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Events_EventId",
                table: "Skills",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Students_StudentId",
                table: "Skills",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");
        }
    }
}
