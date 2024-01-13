using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeTube.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attachments",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CloudURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BackupURL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Playlists",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlaylistThumbnailId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Playlists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Playlists_Attachments_PlaylistThumbnailId",
                        column: x => x.PlaylistThumbnailId,
                        principalTable: "Attachments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReactionTypes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ReactionIconId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReactionTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReactionTypes_Attachments_ReactionIconId",
                        column: x => x.ReactionIconId,
                        principalTable: "Attachments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlaylistComment",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PlaylistId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PosterId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaylistComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlaylistComment_AspNetUsers_PosterId",
                        column: x => x.PosterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlaylistComment_Playlists_PlaylistId",
                        column: x => x.PlaylistId,
                        principalTable: "Playlists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VideoFileId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ThumbnailImageId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PlaylistId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Videos_Attachments_ThumbnailImageId",
                        column: x => x.ThumbnailImageId,
                        principalTable: "Attachments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Videos_Attachments_VideoFileId",
                        column: x => x.VideoFileId,
                        principalTable: "Attachments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Videos_Playlists_PlaylistId",
                        column: x => x.PlaylistId,
                        principalTable: "Playlists",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PlaylistReaction",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PlaylistId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TypeId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaylistReaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlaylistReaction_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlaylistReaction_Playlists_PlaylistId",
                        column: x => x.PlaylistId,
                        principalTable: "Playlists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlaylistReaction_ReactionTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "ReactionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlaylistCommentReaction",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CommentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TypeId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaylistCommentReaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlaylistCommentReaction_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlaylistCommentReaction_PlaylistComment_CommentId",
                        column: x => x.CommentId,
                        principalTable: "PlaylistComment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlaylistCommentReaction_ReactionTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "ReactionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VideoComment",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VideoId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PosterId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VideoComment_AspNetUsers_PosterId",
                        column: x => x.PosterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VideoComment_Videos_VideoId",
                        column: x => x.VideoId,
                        principalTable: "Videos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VideoReaction",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VideoId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TypeId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoReaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VideoReaction_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VideoReaction_ReactionTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "ReactionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VideoReaction_Videos_VideoId",
                        column: x => x.VideoId,
                        principalTable: "Videos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VideoCommentReaction",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CommentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TypeId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoCommentReaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VideoCommentReaction_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VideoCommentReaction_ReactionTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "ReactionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VideoCommentReaction_VideoComment_CommentId",
                        column: x => x.CommentId,
                        principalTable: "VideoComment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistComment_PlaylistId",
                table: "PlaylistComment",
                column: "PlaylistId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistComment_PosterId",
                table: "PlaylistComment",
                column: "PosterId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistCommentReaction_CommentId",
                table: "PlaylistCommentReaction",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistCommentReaction_TypeId",
                table: "PlaylistCommentReaction",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistCommentReaction_UserId",
                table: "PlaylistCommentReaction",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistReaction_PlaylistId",
                table: "PlaylistReaction",
                column: "PlaylistId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistReaction_TypeId",
                table: "PlaylistReaction",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistReaction_UserId",
                table: "PlaylistReaction",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Playlists_PlaylistThumbnailId",
                table: "Playlists",
                column: "PlaylistThumbnailId");

            migrationBuilder.CreateIndex(
                name: "IX_ReactionTypes_ReactionIconId",
                table: "ReactionTypes",
                column: "ReactionIconId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoComment_PosterId",
                table: "VideoComment",
                column: "PosterId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoComment_VideoId",
                table: "VideoComment",
                column: "VideoId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoCommentReaction_CommentId",
                table: "VideoCommentReaction",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoCommentReaction_TypeId",
                table: "VideoCommentReaction",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoCommentReaction_UserId",
                table: "VideoCommentReaction",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoReaction_TypeId",
                table: "VideoReaction",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoReaction_UserId",
                table: "VideoReaction",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoReaction_VideoId",
                table: "VideoReaction",
                column: "VideoId");

            migrationBuilder.CreateIndex(
                name: "IX_Videos_PlaylistId",
                table: "Videos",
                column: "PlaylistId");

            migrationBuilder.CreateIndex(
                name: "IX_Videos_ThumbnailImageId",
                table: "Videos",
                column: "ThumbnailImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Videos_VideoFileId",
                table: "Videos",
                column: "VideoFileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlaylistCommentReaction");

            migrationBuilder.DropTable(
                name: "PlaylistReaction");

            migrationBuilder.DropTable(
                name: "VideoCommentReaction");

            migrationBuilder.DropTable(
                name: "VideoReaction");

            migrationBuilder.DropTable(
                name: "PlaylistComment");

            migrationBuilder.DropTable(
                name: "VideoComment");

            migrationBuilder.DropTable(
                name: "ReactionTypes");

            migrationBuilder.DropTable(
                name: "Videos");

            migrationBuilder.DropTable(
                name: "Playlists");

            migrationBuilder.DropTable(
                name: "Attachments");
        }
    }
}
