using MeTube.Data;
using MeTube.Data.Models;
using MeTube.Data.Repository;
using MeTube.Data.Repository.Channels;
using MeTube.Data.Repository.Comments;
using MeTube.Data.Repository.Playlists;
using MeTube.Data.Repository.Reactions;
using MeTube.Data.Repository.Videos;
using MeTube.Service;
using MeTube.Service.Attachments;
using MeTube.Service.Channels;
using MeTube.Service.Comments;
using MeTube.Service.Playlists;
using MeTube.Service.Reactions;
using MeTube.Service.Videos;
using MeTube.Web.Seed;
using MeTube.Web.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MeTube.Web
{
    public class Program
    {
        public static void ConfigureServices(WebApplicationBuilder builder)
        {
            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<MeTubeDbContext>(options =>
                options.UseNpgsql(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddTransient<AttachmentRepository, AttachmentRepository>();
            builder.Services.AddTransient<ReactionTypeRepository, ReactionTypeRepository>();
            builder.Services.AddTransient<ChannelRepository, ChannelRepository>();
            builder.Services.AddTransient<VideoRepository, VideoRepository>();
            builder.Services.AddTransient<PlaylistRepository, PlaylistRepository>();
            builder.Services.AddTransient<VideoCommentRepository, VideoCommentRepository>();
            builder.Services.AddTransient<VideoReactionRepository, VideoReactionRepository>();
            builder.Services.AddTransient<PlaylistCommentRepository, PlaylistCommentRepository>();
            builder.Services.AddTransient<PlaylistReactionRepository, PlaylistReactionRepository>();

            builder.Services.AddTransient<ICloudinaryService, CloudinaryService>();
            builder.Services.AddTransient<IAttachmentService, AttachmentService>();
            builder.Services.AddTransient<IReactionTypeService, ReactionTypeService>();
            builder.Services.AddTransient<IVideoService, VideoService>();
            builder.Services.AddTransient<IPlaylistService, PlaylistService>();
            builder.Services.AddTransient<IVideoCommentService, VideoCommentService>();
            builder.Services.AddTransient<IPlaylistCommentService, PlaylistCommentService>();
            builder.Services.AddTransient<IChannelService, ChannelService>();

            builder.Services.AddTransient<IVideoFacade, VideoFacade>();

            builder.Services.AddDefaultIdentity<MeTubeUser>(options => {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 3;
            })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<MeTubeDbContext>();
            builder.Services.AddRazorPages();
            builder.Services.AddControllersWithViews();

            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();
        }

        public static void ConfigureApp(WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.SeedRoles();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "AdminArea",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapRazorPages();
        }

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            ConfigureServices(builder);
            var app = builder.Build();
            ConfigureApp(app);
            app.Run();
        }
    }
}