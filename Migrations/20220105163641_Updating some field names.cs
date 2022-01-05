using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BowlingGame.Migrations
{
    public partial class Updatingsomefieldnames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Guid",
                table: "Players",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "FrameNumber",
                table: "Frames",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Shot1",
                table: "Frames",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Shot2",
                table: "Frames",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FrameNumber",
                table: "Frames");

            migrationBuilder.DropColumn(
                name: "Shot1",
                table: "Frames");

            migrationBuilder.DropColumn(
                name: "Shot2",
                table: "Frames");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Players",
                newName: "Guid");
        }
    }
}
