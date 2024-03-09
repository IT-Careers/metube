using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeTube.Data.Migrations
{
    /// <inheritdoc />
    public partial class PlaylistVideosMapping : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Videos_Playlists_PlaylistId",
                table: "Videos");

            migrationBuilder.DropIndex(
                name: "IX_Videos_PlaylistId",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "PlaylistId",
                table: "Videos");

            migrationBuilder.CreateTable(
                name: "PlaylistVideoMapping",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Timestamp = table.Column<long>(type: "bigint", nullable: false),
                    PlaylistId = table.Column<string>(type: "text", nullable: false),
                    VideoId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaylistVideoMapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlaylistVideoMapping_Playlists_PlaylistId",
                        column: x => x.PlaylistId,
                        principalTable: "Playlists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlaylistVideoMapping_Videos_VideoId",
                        column: x => x.VideoId,
                        principalTable: "Videos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistVideoMapping_PlaylistId",
                table: "PlaylistVideoMapping",
                column: "PlaylistId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistVideoMapping_VideoId",
                table: "PlaylistVideoMapping",
                column: "VideoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlaylistVideoMapping");

            migrationBuilder.AddColumn<string>(
                name: "PlaylistId",
                table: "Videos",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Videos_PlaylistId",
                table: "Videos",
                column: "PlaylistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_Playlists_PlaylistId",
                table: "Videos",
                column: "PlaylistId",
                principalTable: "Playlists",
                principalColumn: "Id");
        }
    }
}
