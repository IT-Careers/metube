using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeTube.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChannelsNullablePictures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Channels_Attachments_CoverPictureId",
                table: "Channels");

            migrationBuilder.DropForeignKey(
                name: "FK_Channels_Attachments_ProfilePictureId",
                table: "Channels");

            migrationBuilder.AlterColumn<string>(
                name: "ProfilePictureId",
                table: "Channels",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "CoverPictureId",
                table: "Channels",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddForeignKey(
                name: "FK_Channels_Attachments_CoverPictureId",
                table: "Channels",
                column: "CoverPictureId",
                principalTable: "Attachments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Channels_Attachments_ProfilePictureId",
                table: "Channels",
                column: "ProfilePictureId",
                principalTable: "Attachments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Channels_Attachments_CoverPictureId",
                table: "Channels");

            migrationBuilder.DropForeignKey(
                name: "FK_Channels_Attachments_ProfilePictureId",
                table: "Channels");

            migrationBuilder.AlterColumn<string>(
                name: "ProfilePictureId",
                table: "Channels",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CoverPictureId",
                table: "Channels",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Channels_Attachments_CoverPictureId",
                table: "Channels",
                column: "CoverPictureId",
                principalTable: "Attachments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Channels_Attachments_ProfilePictureId",
                table: "Channels",
                column: "ProfilePictureId",
                principalTable: "Attachments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
