using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PROJECT_68_BE.Models
{
    public partial class Anime68Context : DbContext
    {
        public Anime68Context()
        {
        }

        public Anime68Context(DbContextOptions<Anime68Context> options)
            : base(options)
        {
        }

        public virtual DbSet<AirDate> AirDate { get; set; }
        public virtual DbSet<AnimeType> AnimeType { get; set; }
        public virtual DbSet<Animes> Animes { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Studio> Studio { get; set; }
        public virtual DbSet<Viewer> Viewer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=DESKTOP-Q6N4J46;Database=Anime68;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AirDate>(entity =>
            {
                entity.ToTable("Air_Date");

                entity.Property(e => e.AirDateId).HasColumnName("Air_Date_ID");

                entity.Property(e => e.AirDateName)
                    .HasColumnName("Air_Date_Name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<AnimeType>(entity =>
            {
                entity.ToTable("Anime_Type");

                entity.Property(e => e.AnimeTypeId).HasColumnName("Anime_Type_ID");

                entity.Property(e => e.AnimeTypeDescription).HasColumnName("Anime_Type_Description");

                entity.Property(e => e.AnimeTypeName)
                    .IsRequired()
                    .HasColumnName("Anime_Type_Name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Animes>(entity =>
            {
                entity.HasKey(e => e.AnimeId);

                entity.Property(e => e.AnimeId).HasColumnName("Anime_ID");

                entity.Property(e => e.AirDateId).HasColumnName("Air_Date_ID");

                entity.Property(e => e.AnimeImg)
                    .HasColumnName("Anime_Img")
                    .HasMaxLength(50);

                entity.Property(e => e.AnimeName)
                    .IsRequired()
                    .HasColumnName("Anime_Name")
                    .HasMaxLength(100);

                entity.Property(e => e.AnimeSource)
                    .HasColumnName("Anime_Source")
                    .HasMaxLength(500);

                entity.Property(e => e.AnimeTypeId).HasColumnName("Anime_Type_ID");

                entity.Property(e => e.CommentId).HasColumnName("Comment_ID");

                entity.Property(e => e.EpsodesTotal).HasColumnName("Epsodes_Total");

                entity.Property(e => e.StudioId).HasColumnName("Studio_ID");

                entity.HasOne(d => d.AnimeType)
                    .WithMany(p => p.Animes)
                    .HasForeignKey(d => d.AnimeTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Animes_Air_Date");

                entity.HasOne(d => d.AnimeTypeNavigation)
                    .WithMany(p => p.Animes)
                    .HasForeignKey(d => d.AnimeTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Animes_Anime_Type");

                entity.HasOne(d => d.Comment)
                    .WithMany(p => p.Animes)
                    .HasForeignKey(d => d.CommentId)
                    .HasConstraintName("FK_Animes_Comment");

                entity.HasOne(d => d.Studio)
                    .WithMany(p => p.Animes)
                    .HasForeignKey(d => d.StudioId)
                    .HasConstraintName("FK_Animes_Studio");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.Property(e => e.CommentId).HasColumnName("Comment_ID");

                entity.Property(e => e.CmtDate)
                    .HasColumnName("Cmt_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ViewerId).HasColumnName("Viewer_ID");

                entity.HasOne(d => d.Viewer)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.ViewerId)
                    .HasConstraintName("FK_Comment_Viewer");
            });

            modelBuilder.Entity<News>(entity =>
            {
                entity.Property(e => e.NewsId).HasColumnName("News_ID");

                entity.Property(e => e.NewContent).HasColumnName("New_Content");

                entity.Property(e => e.NewName)
                    .HasColumnName("New_Name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Studio>(entity =>
            {
                entity.Property(e => e.StudioId).HasColumnName("Studio_ID");

                entity.Property(e => e.StudioDescription).HasColumnName("Studio_Description");

                entity.Property(e => e.StudioName)
                    .HasColumnName("Studio_Name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Viewer>(entity =>
            {
                entity.Property(e => e.ViewerId).HasColumnName("Viewer_ID");

                entity.Property(e => e.ViewerEmail)
                    .IsRequired()
                    .HasColumnName("Viewer_Email")
                    .HasMaxLength(50);

                entity.Property(e => e.ViewerName)
                    .IsRequired()
                    .HasColumnName("Viewer_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.ViewerPassword)
                    .IsRequired()
                    .HasColumnName("Viewer_Password")
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
