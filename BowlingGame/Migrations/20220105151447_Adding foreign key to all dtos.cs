using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BowlingGame.Migrations
{
    public partial class Addingforeignkeytoalldtos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FrameDTO_ScoreCardDTO_ScoreCardDTOId",
                table: "FrameDTO");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_ScoreCardDTO_ScoreCardId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_ScoreCardId",
                table: "Players");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ScoreCardDTO",
                table: "ScoreCardDTO");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FrameDTO",
                table: "FrameDTO");

            migrationBuilder.DropIndex(
                name: "IX_FrameDTO_ScoreCardDTOId",
                table: "FrameDTO");

            migrationBuilder.DropColumn(
                name: "ScoreCardId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "ScoreCardDTOId",
                table: "FrameDTO");

            migrationBuilder.RenameTable(
                name: "ScoreCardDTO",
                newName: "ScoreCards");

            migrationBuilder.RenameTable(
                name: "FrameDTO",
                newName: "Frames");

            migrationBuilder.AddColumn<int>(
                name: "PlayerId",
                table: "ScoreCards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ScoreCardId",
                table: "Frames",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ScoreCards",
                table: "ScoreCards",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Frames",
                table: "Frames",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ScoreCards_PlayerId",
                table: "ScoreCards",
                column: "PlayerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Frames_ScoreCardId",
                table: "Frames",
                column: "ScoreCardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Frames_ScoreCards_ScoreCardId",
                table: "Frames",
                column: "ScoreCardId",
                principalTable: "ScoreCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScoreCards_Players_PlayerId",
                table: "ScoreCards",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Frames_ScoreCards_ScoreCardId",
                table: "Frames");

            migrationBuilder.DropForeignKey(
                name: "FK_ScoreCards_Players_PlayerId",
                table: "ScoreCards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ScoreCards",
                table: "ScoreCards");

            migrationBuilder.DropIndex(
                name: "IX_ScoreCards_PlayerId",
                table: "ScoreCards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Frames",
                table: "Frames");

            migrationBuilder.DropIndex(
                name: "IX_Frames_ScoreCardId",
                table: "Frames");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "ScoreCards");

            migrationBuilder.DropColumn(
                name: "ScoreCardId",
                table: "Frames");

            migrationBuilder.RenameTable(
                name: "ScoreCards",
                newName: "ScoreCardDTO");

            migrationBuilder.RenameTable(
                name: "Frames",
                newName: "FrameDTO");

            migrationBuilder.AddColumn<int>(
                name: "ScoreCardId",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ScoreCardDTOId",
                table: "FrameDTO",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ScoreCardDTO",
                table: "ScoreCardDTO",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FrameDTO",
                table: "FrameDTO",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Players_ScoreCardId",
                table: "Players",
                column: "ScoreCardId");

            migrationBuilder.CreateIndex(
                name: "IX_FrameDTO_ScoreCardDTOId",
                table: "FrameDTO",
                column: "ScoreCardDTOId");

            migrationBuilder.AddForeignKey(
                name: "FK_FrameDTO_ScoreCardDTO_ScoreCardDTOId",
                table: "FrameDTO",
                column: "ScoreCardDTOId",
                principalTable: "ScoreCardDTO",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_ScoreCardDTO_ScoreCardId",
                table: "Players",
                column: "ScoreCardId",
                principalTable: "ScoreCardDTO",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
