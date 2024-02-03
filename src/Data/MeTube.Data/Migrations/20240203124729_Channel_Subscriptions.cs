using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeTube.Data.Migrations
{
    /// <inheritdoc />
    public partial class Channel_Subscriptions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChannelChannel");

            migrationBuilder.CreateTable(
                name: "ChannelSubscriptionsMapping",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Timestamp = table.Column<long>(type: "bigint", nullable: false),
                    SubscriberId = table.Column<string>(type: "text", nullable: false),
                    SubscriptionId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChannelSubscriptionsMapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChannelSubscriptionsMapping_Channels_SubscriberId",
                        column: x => x.SubscriberId,
                        principalTable: "Channels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChannelSubscriptionsMapping_Channels_SubscriptionId",
                        column: x => x.SubscriptionId,
                        principalTable: "Channels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChannelSubscriptionsMapping_SubscriberId",
                table: "ChannelSubscriptionsMapping",
                column: "SubscriberId");

            migrationBuilder.CreateIndex(
                name: "IX_ChannelSubscriptionsMapping_SubscriptionId",
                table: "ChannelSubscriptionsMapping",
                column: "SubscriptionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChannelSubscriptionsMapping");

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

            migrationBuilder.CreateIndex(
                name: "IX_ChannelChannel_SubscriptionsId",
                table: "ChannelChannel",
                column: "SubscriptionsId");
        }
    }
}
