﻿// <auto-generated />
using System;
using MeTube.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MeTube.Data.Migrations
{
    [DbContext(typeof(MeTubeDbContext))]
    [Migration("20240204115612_ChannelsNullablePictures")]
    partial class ChannelsNullablePictures
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MeTube.Data.Models.Attachment", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("BackupURL")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CloudURL")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Attachments");
                });

            modelBuilder.Entity("MeTube.Data.Models.Channels.Channel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("About")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CoverPictureId")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ProfilePictureId")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CoverPictureId");

                    b.HasIndex("ProfilePictureId");

                    b.HasIndex("UserId");

                    b.ToTable("Channels");
                });

            modelBuilder.Entity("MeTube.Data.Models.Channels.ChannelSubscriptionsMapping", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("SubscriberId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SubscriptionId")
                        .HasColumnType("text");

                    b.Property<long>("Timestamp")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("SubscriberId");

                    b.HasIndex("SubscriptionId");

                    b.ToTable("ChannelSubscriptionsMapping");
                });

            modelBuilder.Entity("MeTube.Data.Models.Channels.ChannelVideoHistoryMapping", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ChannelId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("Timestamp")
                        .HasColumnType("bigint");

                    b.Property<string>("VideoId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ChannelId");

                    b.HasIndex("VideoId");

                    b.ToTable("ChannelVideoHistoryMapping");
                });

            modelBuilder.Entity("MeTube.Data.Models.Comments.PlaylistComment", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CreatedById")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DeletedById")
                        .HasColumnType("text");

                    b.Property<DateTime>("DeletedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("PlaylistCommentId")
                        .HasColumnType("text");

                    b.Property<string>("PlaylistId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UpdatedById")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("DeletedById");

                    b.HasIndex("PlaylistCommentId");

                    b.HasIndex("PlaylistId");

                    b.HasIndex("UpdatedById");

                    b.ToTable("PlaylistComment");
                });

            modelBuilder.Entity("MeTube.Data.Models.Comments.VideoComment", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CreatedById")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DeletedById")
                        .HasColumnType("text");

                    b.Property<DateTime>("DeletedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UpdatedById")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("VideoCommentId")
                        .HasColumnType("text");

                    b.Property<string>("VideoId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("DeletedById");

                    b.HasIndex("UpdatedById");

                    b.HasIndex("VideoCommentId");

                    b.HasIndex("VideoId");

                    b.ToTable("VideoComment");
                });

            modelBuilder.Entity("MeTube.Data.Models.MeTubeUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("MeTube.Data.Models.Playlists.Playlist", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("CreatedById")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DeletedById")
                        .HasColumnType("text");

                    b.Property<DateTime>("DeletedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PlaylistThumbnailId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UpdatedById")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("DeletedById");

                    b.HasIndex("PlaylistThumbnailId");

                    b.HasIndex("UpdatedById");

                    b.ToTable("Playlists");
                });

            modelBuilder.Entity("MeTube.Data.Models.Reactions.PlaylistCommentReaction", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ChannelId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CommentId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TypeId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ChannelId");

                    b.HasIndex("CommentId");

                    b.HasIndex("TypeId");

                    b.ToTable("PlaylistCommentReaction");
                });

            modelBuilder.Entity("MeTube.Data.Models.Reactions.PlaylistReaction", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ChannelId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PlaylistId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TypeId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ChannelId");

                    b.HasIndex("PlaylistId");

                    b.HasIndex("TypeId");

                    b.ToTable("PlaylistReaction");
                });

            modelBuilder.Entity("MeTube.Data.Models.Reactions.ReactionType", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ReactionIconId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ReactionIconId");

                    b.ToTable("ReactionTypes");
                });

            modelBuilder.Entity("MeTube.Data.Models.Reactions.VideoCommentReaction", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ChannelId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CommentId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TypeId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ChannelId");

                    b.HasIndex("CommentId");

                    b.HasIndex("TypeId");

                    b.ToTable("VideoCommentReaction");
                });

            modelBuilder.Entity("MeTube.Data.Models.Reactions.VideoReaction", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ChannelId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TypeId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("VideoId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ChannelId");

                    b.HasIndex("TypeId");

                    b.HasIndex("VideoId");

                    b.ToTable("VideoReaction");
                });

            modelBuilder.Entity("MeTube.Data.Models.Videos.Video", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("CreatedById")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DeletedById")
                        .HasColumnType("text");

                    b.Property<DateTime>("DeletedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PlaylistId")
                        .HasColumnType("text");

                    b.Property<string>("ThumbnailId")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UpdatedById")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("VideoFileId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("DeletedById");

                    b.HasIndex("PlaylistId");

                    b.HasIndex("ThumbnailId");

                    b.HasIndex("UpdatedById");

                    b.HasIndex("VideoFileId");

                    b.ToTable("Videos");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("MeTube.Data.Models.Channels.Channel", b =>
                {
                    b.HasOne("MeTube.Data.Models.Attachment", "CoverPicture")
                        .WithMany()
                        .HasForeignKey("CoverPictureId");

                    b.HasOne("MeTube.Data.Models.Attachment", "ProfilePicture")
                        .WithMany()
                        .HasForeignKey("ProfilePictureId");

                    b.HasOne("MeTube.Data.Models.MeTubeUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("CoverPicture");

                    b.Navigation("ProfilePicture");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MeTube.Data.Models.Channels.ChannelSubscriptionsMapping", b =>
                {
                    b.HasOne("MeTube.Data.Models.Channels.Channel", "Subscriber")
                        .WithMany("Subscriptions")
                        .HasForeignKey("SubscriberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MeTube.Data.Models.Channels.Channel", "Subscription")
                        .WithMany("Subscribers")
                        .HasForeignKey("SubscriptionId");

                    b.Navigation("Subscriber");

                    b.Navigation("Subscription");
                });

            modelBuilder.Entity("MeTube.Data.Models.Channels.ChannelVideoHistoryMapping", b =>
                {
                    b.HasOne("MeTube.Data.Models.Channels.Channel", "Channel")
                        .WithMany("History")
                        .HasForeignKey("ChannelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MeTube.Data.Models.Videos.Video", "Video")
                        .WithMany()
                        .HasForeignKey("VideoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Channel");

                    b.Navigation("Video");
                });

            modelBuilder.Entity("MeTube.Data.Models.Comments.PlaylistComment", b =>
                {
                    b.HasOne("MeTube.Data.Models.Channels.Channel", "CreatedBy")
                        .WithMany("PlaylistComments")
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("MeTube.Data.Models.Channels.Channel", "DeletedBy")
                        .WithMany()
                        .HasForeignKey("DeletedById");

                    b.HasOne("MeTube.Data.Models.Comments.PlaylistComment", null)
                        .WithMany("Replies")
                        .HasForeignKey("PlaylistCommentId");

                    b.HasOne("MeTube.Data.Models.Playlists.Playlist", "Playlist")
                        .WithMany("Comments")
                        .HasForeignKey("PlaylistId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MeTube.Data.Models.Channels.Channel", "UpdatedBy")
                        .WithMany()
                        .HasForeignKey("UpdatedById");

                    b.Navigation("CreatedBy");

                    b.Navigation("DeletedBy");

                    b.Navigation("Playlist");

                    b.Navigation("UpdatedBy");
                });

            modelBuilder.Entity("MeTube.Data.Models.Comments.VideoComment", b =>
                {
                    b.HasOne("MeTube.Data.Models.Channels.Channel", "CreatedBy")
                        .WithMany("VideoComments")
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("MeTube.Data.Models.Channels.Channel", "DeletedBy")
                        .WithMany()
                        .HasForeignKey("DeletedById");

                    b.HasOne("MeTube.Data.Models.Channels.Channel", "UpdatedBy")
                        .WithMany()
                        .HasForeignKey("UpdatedById");

                    b.HasOne("MeTube.Data.Models.Comments.VideoComment", null)
                        .WithMany("Replies")
                        .HasForeignKey("VideoCommentId");

                    b.HasOne("MeTube.Data.Models.Videos.Video", "Video")
                        .WithMany("Comments")
                        .HasForeignKey("VideoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CreatedBy");

                    b.Navigation("DeletedBy");

                    b.Navigation("UpdatedBy");

                    b.Navigation("Video");
                });

            modelBuilder.Entity("MeTube.Data.Models.Playlists.Playlist", b =>
                {
                    b.HasOne("MeTube.Data.Models.Channels.Channel", "CreatedBy")
                        .WithMany("Playlists")
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("MeTube.Data.Models.Channels.Channel", "DeletedBy")
                        .WithMany()
                        .HasForeignKey("DeletedById");

                    b.HasOne("MeTube.Data.Models.Attachment", "PlaylistThumbnail")
                        .WithMany()
                        .HasForeignKey("PlaylistThumbnailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MeTube.Data.Models.Channels.Channel", "UpdatedBy")
                        .WithMany()
                        .HasForeignKey("UpdatedById");

                    b.Navigation("CreatedBy");

                    b.Navigation("DeletedBy");

                    b.Navigation("PlaylistThumbnail");

                    b.Navigation("UpdatedBy");
                });

            modelBuilder.Entity("MeTube.Data.Models.Reactions.PlaylistCommentReaction", b =>
                {
                    b.HasOne("MeTube.Data.Models.Channels.Channel", "Channel")
                        .WithMany()
                        .HasForeignKey("ChannelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MeTube.Data.Models.Comments.PlaylistComment", "Comment")
                        .WithMany("Reactions")
                        .HasForeignKey("CommentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MeTube.Data.Models.Reactions.ReactionType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Channel");

                    b.Navigation("Comment");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("MeTube.Data.Models.Reactions.PlaylistReaction", b =>
                {
                    b.HasOne("MeTube.Data.Models.Channels.Channel", "Channel")
                        .WithMany("PlaylistReactions")
                        .HasForeignKey("ChannelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MeTube.Data.Models.Playlists.Playlist", "Playlist")
                        .WithMany("Reactions")
                        .HasForeignKey("PlaylistId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MeTube.Data.Models.Reactions.ReactionType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Channel");

                    b.Navigation("Playlist");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("MeTube.Data.Models.Reactions.ReactionType", b =>
                {
                    b.HasOne("MeTube.Data.Models.Attachment", "ReactionIcon")
                        .WithMany()
                        .HasForeignKey("ReactionIconId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ReactionIcon");
                });

            modelBuilder.Entity("MeTube.Data.Models.Reactions.VideoCommentReaction", b =>
                {
                    b.HasOne("MeTube.Data.Models.Channels.Channel", "Channel")
                        .WithMany()
                        .HasForeignKey("ChannelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MeTube.Data.Models.Comments.VideoComment", "Comment")
                        .WithMany("Reactions")
                        .HasForeignKey("CommentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MeTube.Data.Models.Reactions.ReactionType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Channel");

                    b.Navigation("Comment");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("MeTube.Data.Models.Reactions.VideoReaction", b =>
                {
                    b.HasOne("MeTube.Data.Models.Channels.Channel", "Channel")
                        .WithMany("VideoReactions")
                        .HasForeignKey("ChannelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MeTube.Data.Models.Reactions.ReactionType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MeTube.Data.Models.Videos.Video", "Video")
                        .WithMany("Reactions")
                        .HasForeignKey("VideoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Channel");

                    b.Navigation("Type");

                    b.Navigation("Video");
                });

            modelBuilder.Entity("MeTube.Data.Models.Videos.Video", b =>
                {
                    b.HasOne("MeTube.Data.Models.Channels.Channel", "CreatedBy")
                        .WithMany("Videos")
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("MeTube.Data.Models.Channels.Channel", "DeletedBy")
                        .WithMany()
                        .HasForeignKey("DeletedById");

                    b.HasOne("MeTube.Data.Models.Playlists.Playlist", null)
                        .WithMany("Videos")
                        .HasForeignKey("PlaylistId");

                    b.HasOne("MeTube.Data.Models.Attachment", "Thumbnail")
                        .WithMany()
                        .HasForeignKey("ThumbnailId");

                    b.HasOne("MeTube.Data.Models.Channels.Channel", "UpdatedBy")
                        .WithMany()
                        .HasForeignKey("UpdatedById");

                    b.HasOne("MeTube.Data.Models.Attachment", "VideoFile")
                        .WithMany()
                        .HasForeignKey("VideoFileId");

                    b.Navigation("CreatedBy");

                    b.Navigation("DeletedBy");

                    b.Navigation("Thumbnail");

                    b.Navigation("UpdatedBy");

                    b.Navigation("VideoFile");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("MeTube.Data.Models.MeTubeUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("MeTube.Data.Models.MeTubeUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MeTube.Data.Models.MeTubeUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("MeTube.Data.Models.MeTubeUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MeTube.Data.Models.Channels.Channel", b =>
                {
                    b.Navigation("History");

                    b.Navigation("PlaylistComments");

                    b.Navigation("PlaylistReactions");

                    b.Navigation("Playlists");

                    b.Navigation("Subscribers");

                    b.Navigation("Subscriptions");

                    b.Navigation("VideoComments");

                    b.Navigation("VideoReactions");

                    b.Navigation("Videos");
                });

            modelBuilder.Entity("MeTube.Data.Models.Comments.PlaylistComment", b =>
                {
                    b.Navigation("Reactions");

                    b.Navigation("Replies");
                });

            modelBuilder.Entity("MeTube.Data.Models.Comments.VideoComment", b =>
                {
                    b.Navigation("Reactions");

                    b.Navigation("Replies");
                });

            modelBuilder.Entity("MeTube.Data.Models.Playlists.Playlist", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Reactions");

                    b.Navigation("Videos");
                });

            modelBuilder.Entity("MeTube.Data.Models.Videos.Video", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Reactions");
                });
#pragma warning restore 612, 618
        }
    }
}
