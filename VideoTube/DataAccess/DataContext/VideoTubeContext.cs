using System;
using Entities.Entities;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccess.DataContext
{
    public class VideoTubeContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Comment> Comments => Set<Comment>();
        public DbSet<Video> videos => Set<Video>();

        public VideoTubeContext()
        {}

        public VideoTubeContext(DbContextOptions<VideoTubeContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(u =>
            {
                u.ToTable("User");
                u.HasKey(k => k.Id);
                u.Property(n => n.Name).HasMaxLength(100).IsRequired(true);
                u.Property(ur => ur.UrlPicture).HasColumnType("text");
            });

            modelBuilder.Entity<Comment>(c => {
                c.ToTable("Comment");
                c.HasKey(k => k.Id);
                c.Property(t => t.Text).IsRequired(true).HasColumnType("text");

                c.HasOne(u => u.Users)
                .WithMany(c => c.Comments)
                .HasForeignKey(fk => fk.UserId);

                c.HasOne(u => u.Videos)
                .WithMany(c => c.Comments)
                .HasForeignKey(fk => fk.VideoId);
            });

            modelBuilder.Entity<Video>(v =>
            {
                v.ToTable("Video");
                v.HasKey(k => k.Id);
                v.Property(t => t.Title).IsRequired(true).HasMaxLength(200);
                v.Property(d => d.Description).HasColumnType("text");
                v.Property(l => l.Likes);
                v.Property(d => d.Dislikes);
                v.Property(t => t.ThumbnailUrl).HasColumnType("text");
                v.Property(u => u.UloapDate).IsRequired(true);
                v.Property(u => u.UserID);
                v.Property(ur => ur.Url).IsRequired(true).HasColumnType("text");
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false);
                IConfiguration configuration = builder.Build();
                var _connectionString = configuration.GetSection("ConnectionStrings:VideoConexion").Value;
                optionsBuilder.UseNpgsql(_connectionString.ToString());
            }
        }
    }
}
