using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeTube.Data.Migrations
{
    /// <inheritdoc />
    public partial class Channels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlaylistComment_AspNetUsers_CreatedById",
                table: "PlaylistComment");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaylistComment_AspNetUsers_DeletedById",
                table: "PlaylistComment");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaylistComment_AspNetUsers_PosterId",
                table: "PlaylistComment");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaylistComment_AspNetUsers_UpdatedById",
                table: "PlaylistComment");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaylistCommentReaction_AspNetUsers_UserId",
                table: "PlaylistCommentReaction");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaylistReaction_AspNetUsers_UserId",
                table: "PlaylistReaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Playlists_AspNetUsers_CreatedById",
                table: "Playlists");

            migrationBuilder.DropForeignKey(
                name: "FK_Playlists_AspNetUsers_DeletedById",
                table: "Playlists");

            migrationBuilder.DropForeignKey(
                name: "FK_Playlists_AspNetUsers_UpdatedById",
                table: "Playlists");

            migrationBuilder.DropForeignKey(
                name: "FK_VideoComment_AspNetUsers_CreatedById",
                table: "VideoComment");

            migrationBuilder.DropForeignKey(
                name: "FK_VideoComment_AspNetUsers_DeletedById",
                table: "VideoComment");

            migrationBuilder.DropForeignKey(
                name: "FK_VideoComment_AspNetUsers_PosterId",
                table: "VideoComment");

            migrationBuilder.DropForeignKey(
                name: "FK_VideoComment_AspNetUsers_UpdatedById",
                table: "VideoComment");

            migrationBuilder.DropForeignKey(
                name: "FK_VideoCommentReaction_AspNetUsers_UserId",
                table: "VideoCommentReaction");

            migrationBuilder.DropForeignKey(
                name: "FK_VideoReaction_AspNetUsers_UserId",
                table: "VideoReaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Videos_AspNetUsers_CreatedById",
                table: "Videos");

            migrationBuilder.DropForeignKey(
                name: "FK_Videos_AspNetUsers_DeletedById",
                table: "Videos");

            migrationBuilder.DropForeignKey(
                name: "FK_Videos_AspNetUsers_UpdatedById",
                table: "Videos");

            migrationBuilder.DropForeignKey(
                name: "FK_Videos_Attachments_ThumbnailImageId",
                table: "Videos");

            migrationBuilder.DropIndex(
                name: "IX_VideoComment_PosterId",
                table: "VideoComment");

            migrationBuilder.DropIndex(
                name: "IX_PlaylistReaction_UserId",
                table: "PlaylistReaction");

            migrationBuilder.DropIndex(
                name: "IX_PlaylistComment_PosterId",
                table: "PlaylistComment");

            migrationBuilder.DropColumn(
                name: "PosterId",
                table: "VideoComment");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "PlaylistReaction");

            migrationBuilder.DropColumn(
                name: "PosterId",
                table: "PlaylistComment");

            migrationBuilder.RenameColumn(
                name: "ThumbnailImageId",
                table: "Videos",
                newName: "ThumbnailId");

            migrationBuilder.RenameIndex(
                name: "IX_Videos_ThumbnailImageId",
                table: "Videos",
                newName: "IX_Videos_ThumbnailId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "VideoReaction",
                newName: "ChannelId");

            migrationBuilder.RenameIndex(
                name: "IX_VideoReaction_UserId",
                table: "VideoReaction",
                newName: "IX_VideoReaction_ChannelId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "VideoCommentReaction",
                newName: "ChannelId");

            migrationBuilder.RenameIndex(
                name: "IX_VideoCommentReaction_UserId",
                table: "VideoCommentReaction",
                newName: "IX_VideoCommentReaction_ChannelId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "PlaylistCommentReaction",
                newName: "ChannelId");

            migrationBuilder.RenameIndex(
                name: "IX_PlaylistCommentReaction_UserId",
                table: "PlaylistCommentReaction",
                newName: "IX_PlaylistCommentReaction_ChannelId");

            migrationBuilder.AddColumn<string>(
                name: "ChannelId",
                table: "PlaylistReaction",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Channels",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    ProfilePictureId = table.Column<string>(type: "text", nullable: false),
                    CoverPictureId = table.Column<string>(type: "text", nullable: false),
                    About = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Channels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Channels_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Channels_Attachments_CoverPictureId",
                        column: x => x.CoverPictureId,
                        principalTable: "Attachments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Channels_Attachments_ProfilePictureId",
                        column: x => x.ProfilePictureId,
                        principalTable: "Attachments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChannelChannel",
                columns: table => new
                {
                    SubscribersId = table.Column<string>(type: "text", nullable: false),
                    SubscriptionsId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChannelChannel", x => new { x.SubscribersId, x.SubscriptionsId });
                    table.ForeignKey(
                        name: "FK_ChannelChannel_Channels_SubscribersId",
                        column: x => x.SubscribersId,
                        principalTable: "Channels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChannelChannel_Channels_SubscriptionsId",
                        column: x => x.SubscriptionsId,
                        principalTable: "Channels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChannelVideoHistoryMapping",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Timestamp = table.Column<long>(type: "bigint", nullable: false),
                    VideoId = table.Column<string>(type: "text", nullable: false),
                    ChannelId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChannelVideoHistoryMapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChannelVideoHistoryMapping_Channels_ChannelId",
                        column: x => x.ChannelId,
                        principalTable: "Channels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChannelVideoHistoryMapping_Videos_VideoId",
                        column: x => x.VideoId,
                        principalTable: "Videos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistReaction_ChannelId",
                table: "PlaylistReaction",
                column: "ChannelId");

            migrationBuilder.CreateIndex(
                name: "IX_ChannelChannel_SubscriptionsId",
                table: "ChannelChannel",
                column: "SubscriptionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Channels_CoverPictureId",
                table: "Channels",
                column: "CoverPictureId");

            migrationBuilder.CreateIndex(
                name: "IX_Channels_ProfilePictureId",
                table: "Channels",
                column: "ProfilePictureId");

            migrationBuilder.CreateIndex(
                name: "IX_Channels_UserId",
                table: "Channels",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ChannelVideoHistoryMapping_ChannelId",
                table: "ChannelVideoHistoryMapping",
                column: "ChannelId");

            migrationBuilder.CreateIndex(
                name: "IX_ChannelVideoHistoryMapping_VideoId",
                table: "ChannelVideoHistoryMapping",
                column: "VideoId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlaylistComment_Channels_CreatedById",
                table: "PlaylistComment",
                column: "CreatedById",
                principalTable: "Channels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlaylistComment_Channels_DeletedById",
                table: "PlaylistComment",
                column: "DeletedById",
                principalTable: "Channels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlaylistComment_Channels_UpdatedById",
                table: "PlaylistComment",
                column: "UpdatedById",
                principalTable: "Channels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlaylistCommentReaction_Channels_ChannelId",
                table: "PlaylistCommentReaction",
                column: "ChannelId",
                principalTable: "Channels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlaylistReaction_Channels_ChannelId",
                table: "PlaylistReaction",
                column: "ChannelId",
                principalTable: "Channels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Playlists_Channels_CreatedById",
                table: "Playlists",
                column: "CreatedById",
                principalTable: "Channels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Playlists_Channels_DeletedById",
                table: "Playlists",
                column: "DeletedById",
                principalTable: "Channels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Playlists_Channels_UpdatedById",
                table: "Playlists",
                column: "UpdatedById",
                principalTable: "Channels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VideoComment_Channels_CreatedById",
                table: "VideoComment",
                column: "CreatedById",
                principalTable: "Channels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VideoComment_Channels_DeletedById",
                table: "VideoComment",
                column: "DeletedById",
                principalTable: "Channels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VideoComment_Channels_UpdatedById",
                table: "VideoComment",
                column: "UpdatedById",
                principalTable: "Channels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VideoCommentReaction_Channels_ChannelId",
                table: "VideoCommentReaction",
                column: "ChannelId",
                principalTable: "Channels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VideoReaction_Channels_ChannelId",
                table: "VideoReaction",
                column: "ChannelId",
                principalTable: "Channels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_Attachments_ThumbnailId",
                table: "Videos",
                column: "ThumbnailId",
                principalTable: "Attachments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_Channels_CreatedById",
                table: "Videos",
                column: "CreatedById",
                principalTable: "Channels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_Channels_DeletedById",
                table: "Videos",
                column: "DeletedById",
                principalTable: "Channels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_Channels_UpdatedById",
                table: "Videos",
                column: "UpdatedById",
                principalTable: "Channels",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlaylistComment_Channels_CreatedById",
                table: "PlaylistComment");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaylistComment_Channels_DeletedById",
                table: "PlaylistComment");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaylistComment_Channels_UpdatedById",
                table: "PlaylistComment");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaylistCommentReaction_Channels_ChannelId",
                table: "PlaylistCommentReaction");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaylistReaction_Channels_ChannelId",
                table: "PlaylistReaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Playlists_Channels_CreatedById",
                table: "Playlists");

            migrationBuilder.DropForeignKey(
                name: "FK_Playlists_Channels_DeletedById",
                table: "Playlists");

            migrationBuilder.DropForeignKey(
                name: "FK_Playlists_Channels_UpdatedById",
                table: "Playlists");

            migrationBuilder.DropForeignKey(
                name: "FK_VideoComment_Channels_CreatedById",
                table: "VideoComment");

            migrationBuilder.DropForeignKey(
                name: "FK_VideoComment_Channels_DeletedById",
                table: "VideoComment");

            migrationBuilder.DropForeignKey(
                name: "FK_VideoComment_Channels_UpdatedById",
                table: "VideoComment");

            migrationBuilder.DropForeignKey(
                name: "FK_VideoCommentReaction_Channels_ChannelId",
                table: "VideoCommentReaction");

            migrationBuilder.DropForeignKey(
                name: "FK_VideoReaction_Channels_ChannelId",
                table: "VideoReaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Videos_Attachments_ThumbnailId",
                table: "Videos");

            migrationBuilder.DropForeignKey(
                name: "FK_Videos_Channels_CreatedById",
                table: "Videos");

            migrationBuilder.DropForeignKey(
                name: "FK_Videos_Channels_DeletedById",
                table: "Videos");

            migrationBuilder.DropForeignKey(
                name: "FK_Videos_Channels_UpdatedById",
                table: "Videos");

            migrationBuilder.DropTable(
                name: "ChannelChannel");

            migrationBuilder.DropTable(
                name: "ChannelVideoHistoryMapping");

            migrationBuilder.DropTable(
                name: "Channels");

            migrationBuilder.DropIndex(
                name: "IX_PlaylistReaction_ChannelId",
                table: "PlaylistReaction");

            migrationBuilder.DropColumn(
                name: "ChannelId",
                table: "PlaylistReaction");

            migrationBuilder.RenameColumn(
                name: "ThumbnailId",
                table: "Videos",
                newName: "ThumbnailImageId");

            migrationBuilder.RenameIndex(
                name: "IX_Videos_ThumbnailId",
                table: "Videos",
                newName: "IX_Videos_ThumbnailImageId");

            migrationBuilder.RenameColumn(
                name: "ChannelId",
                table: "VideoReaction",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_VideoReaction_ChannelId",
                table: "VideoReaction",
                newName: "IX_VideoReaction_UserId");

            migrationBuilder.RenameColumn(
                name: "ChannelId",
                table: "VideoCommentReaction",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_VideoCommentReaction_ChannelId",
                table: "VideoCommentReaction",
                newName: "IX_VideoCommentReaction_UserId");

            migrationBuilder.RenameColumn(
                name: "ChannelId",
                table: "PlaylistCommentReaction",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_PlaylistCommentReaction_ChannelId",
                table: "PlaylistCommentReaction",
                newName: "IX_PlaylistCommentReaction_UserId");

            migrationBuilder.AddColumn<string>(
                name: "PosterId",
                table: "VideoComment",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "PlaylistReaction",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PosterId",
                table: "PlaylistComment",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_VideoComment_PosterId",
                table: "VideoComment",
                column: "PosterId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistReaction_UserId",
                table: "PlaylistReaction",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistComment_PosterId",
                table: "PlaylistComment",
                column: "PosterId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlaylistComment_AspNetUsers_CreatedById",
                table: "PlaylistComment",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlaylistComment_AspNetUsers_DeletedById",
                table: "PlaylistComment",
                column: "DeletedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlaylistComment_AspNetUsers_PosterId",
                table: "PlaylistComment",
                column: "PosterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlaylistComment_AspNetUsers_UpdatedById",
                table: "PlaylistComment",
                column: "UpdatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlaylistCommentReaction_AspNetUsers_UserId",
                table: "PlaylistCommentReaction",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlaylistReaction_AspNetUsers_UserId",
                table: "PlaylistReaction",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Playlists_AspNetUsers_CreatedById",
                table: "Playlists",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Playlists_AspNetUsers_DeletedById",
                table: "Playlists",
                column: "DeletedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Playlists_AspNetUsers_UpdatedById",
                table: "Playlists",
                column: "UpdatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VideoComment_AspNetUsers_CreatedById",
                table: "VideoComment",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VideoComment_AspNetUsers_DeletedById",
                table: "VideoComment",
                column: "DeletedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VideoComment_AspNetUsers_PosterId",
                table: "VideoComment",
                column: "PosterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VideoComment_AspNetUsers_UpdatedById",
                table: "VideoComment",
                column: "UpdatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VideoCommentReaction_AspNetUsers_UserId",
                table: "VideoCommentReaction",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VideoReaction_AspNetUsers_UserId",
                table: "VideoReaction",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_AspNetUsers_CreatedById",
                table: "Videos",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_AspNetUsers_DeletedById",
                table: "Videos",
                column: "DeletedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_AspNetUsers_UpdatedById",
                table: "Videos",
                column: "UpdatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_Attachments_ThumbnailImageId",
                table: "Videos",
                column: "ThumbnailImageId",
                principalTable: "Attachments",
                principalColumn: "Id");
        }
    }
}
