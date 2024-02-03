using MeTube.Data.Models;
using MeTube.Data.Models.Channels;
using MeTube.Data.Models.Comments;
using MeTube.Data.Models.Playlists;
using MeTube.Data.Models.Reactions;
using MeTube.Data.Models.Videos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MeTube.Data
{
    public class MeTubeDbContext : IdentityDbContext<MeTubeUser, IdentityRole, string>
    {
        public DbSet<Attachment> Attachments { get; set; }

        public DbSet<Video> Videos { get; set; }

        public DbSet<Playlist> Playlists { get; set; }

        public DbSet<ReactionType> ReactionTypes { get; set; }

        public DbSet<Channel> Channels { get; set; }

        public MeTubeDbContext(DbContextOptions<MeTubeDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // TODO: Extract into some kind of constant...
            optionsBuilder.UseNpgsql("Server=127.0.0.1;Port=5432;Database=metube_db;User Id=postgres;Password=1234;");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Video>()
                .HasMany(v => v.Comments)
                .WithOne(vc => vc.Video)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Video>()
                .HasMany(v => v.Reactions)
                .WithOne(vr => vr.Video)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Playlist>()
                .HasMany(pl => pl.Comments)
                .WithOne(plc => plc.Playlist)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Playlist>()
                .HasMany(pl => pl.Reactions)
                .WithOne(plr => plr.Playlist)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<VideoComment>()
                .HasMany(vc => vc.Reactions)
                .WithOne(vcr => vcr.Comment)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<PlaylistComment>()
                .HasMany(plc => plc.Reactions)
                .WithOne(plcr => plcr.Comment)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Channel>()
                .HasMany(c => c.Videos)
                .WithOne(v => v.CreatedBy)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Channel>()
                .HasMany(c => c.VideoComments)
                .WithOne(vc => vc.CreatedBy)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Channel>()
                .HasMany(c => c.Playlists)
                .WithOne(pl => pl.CreatedBy)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Channel>()
                .HasMany(c => c.PlaylistComments)
                .WithOne(plc => plc.CreatedBy)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Video>()
                .HasOne(v => v.DeletedBy);

            builder.Entity<Playlist>()
                .HasOne(pl => pl.DeletedBy);

            builder.Entity<VideoComment>()
                .HasOne(vc => vc.DeletedBy);

            builder.Entity<PlaylistComment>()
                .HasOne(plc => plc.DeletedBy);

            builder.Entity<Video>()
                .HasOne(v => v.UpdatedBy);

            builder.Entity<Playlist>()
                .HasOne(pl => pl.UpdatedBy);

            builder.Entity<VideoComment>()
                .HasOne(vc => vc.UpdatedBy);

            builder.Entity<PlaylistComment>()
                .HasOne(plc => plc.UpdatedBy);

            builder.Entity<Channel>()
                .HasMany(c => c.Subscribers)
                .WithOne(c => c.Subscription);

            builder.Entity<Channel>()
                .HasMany(c => c.Subscriptions)
                .WithOne(c => c.Subscriber);

            base.OnModelCreating(builder);
        }
    }
}