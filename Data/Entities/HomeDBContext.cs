using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Data.Entities
{
    public partial class HomeDBContext : DbContext
    {
        public HomeDBContext()
        {
        }

        public HomeDBContext(DbContextOptions<HomeDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Album> Album { get; set; }
        public virtual DbSet<AlbumPrice> AlbumPrice { get; set; }
        public virtual DbSet<AlbumRating> AlbumRating { get; set; }
        public virtual DbSet<Artist> Artist { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Contacts> Contacts { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<DepartmentEmployee> DepartmentEmployee { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<Language> Language { get; set; }
        public virtual DbSet<MusicType> MusicType { get; set; }
        public virtual DbSet<RatingType> RatingType { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<SiteStyleType> SiteStyleType { get; set; }
        public virtual DbSet<Song> Song { get; set; }
        public virtual DbSet<SongPrice> SongPrice { get; set; }
        public virtual DbSet<SystemType> SystemType { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<VersionHistory> VersionHistory { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Album>(entity =>
            {
                entity.HasKey(e => e.UniqueId);

                entity.ToTable("ALBUM");

                entity.Property(e => e.UniqueId)
                    .HasColumnName("UniqueID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AlbumPriceId).HasColumnName("AlbumPriceID");

                entity.Property(e => e.ArtistId).HasColumnName("ArtistID");

                entity.Property(e => e.CopyRightInfo).HasMaxLength(500);

                entity.Property(e => e.CoverPath).HasMaxLength(1000);

                entity.Property(e => e.MusicTypeId).HasColumnName("MusicTypeID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Released).HasColumnType("datetime");

                entity.HasOne(d => d.AlbumPrice)
                    .WithMany(p => p.Album)
                    .HasForeignKey(d => d.AlbumPriceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ALBUM_ALBUM_PRICE");

                entity.HasOne(d => d.Artist)
                    .WithMany(p => p.Album)
                    .HasForeignKey(d => d.ArtistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ALBUM_ARTIST");

                entity.HasOne(d => d.MusicType)
                    .WithMany(p => p.Album)
                    .HasForeignKey(d => d.MusicTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ALBUM_MUSIC_TYPE");
            });

            modelBuilder.Entity<AlbumPrice>(entity =>
            {
                entity.HasKey(e => e.UniqueId);

                entity.ToTable("ALBUM_PRICE");

                entity.Property(e => e.UniqueId)
                    .HasColumnName("UniqueID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Price).HasColumnType("decimal(9, 2)");
            });

            modelBuilder.Entity<AlbumRating>(entity =>
            {
                entity.HasKey(e => e.UniqueId);

                entity.ToTable("ALBUM_RATING");

                entity.Property(e => e.UniqueId)
                    .HasColumnName("UniqueID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AlbumId).HasColumnName("AlbumID");

                entity.Property(e => e.RatingTypeId).HasColumnName("RatingTypeID");

                entity.HasOne(d => d.Album)
                    .WithMany(p => p.AlbumRating)
                    .HasForeignKey(d => d.AlbumId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ALBUM_RATING_ALBUM");

                entity.HasOne(d => d.RatingType)
                    .WithMany(p => p.AlbumRating)
                    .HasForeignKey(d => d.RatingTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ALBUM_RATING_RATING_TYPE");
            });

            modelBuilder.Entity<Artist>(entity =>
            {
                entity.HasKey(e => e.UniqueId);

                entity.ToTable("ARTIST");

                entity.Property(e => e.UniqueId)
                    .HasColumnName("UniqueID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasKey(e => e.UniqueId);

                entity.ToTable("COMPANY");

                entity.Property(e => e.UniqueId).ValueGeneratedNever();

                entity.Property(e => e.Address1)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Address2)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.OrganizationNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PostalCode)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Contacts>(entity =>
            {
                entity.HasKey(e => e.ContactId);

                entity.ToTable("CONTACTS");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.UniqueId);

                entity.ToTable("DEPARTMENT");

                entity.Property(e => e.UniqueId).ValueGeneratedNever();

                entity.Property(e => e.Address1)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Address2)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PostalCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.CompanyUnique)
                    .WithMany(p => p.Department)
                    .HasForeignKey(d => d.CompanyUniqueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DEPARTMENT_COMPANY");
            });

            modelBuilder.Entity<DepartmentEmployee>(entity =>
            {
                entity.HasKey(e => e.UniqueId);

                entity.ToTable("DEPARTMENT_EMPLOYEE");

                entity.Property(e => e.UniqueId).ValueGeneratedNever();

                entity.HasOne(d => d.DepartmentUnique)
                    .WithMany(p => p.DepartmentEmployee)
                    .HasForeignKey(d => d.DepartmentUniqueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DEPARTMENT_EMPLOYEE_DEPARTMENT");

                entity.HasOne(d => d.EmployeeUnique)
                    .WithMany(p => p.DepartmentEmployee)
                    .HasForeignKey(d => d.EmployeeUniqueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DEPARTMENT_EMPLOYEE_EMPLOYEE");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.UniqueId)
                    .HasName("PK__CUSTOMER__A2A2A54AF97F42A1");

                entity.ToTable("EMPLOYEE");

                entity.Property(e => e.UniqueId).ValueGeneratedNever();

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.EmployeeNumber).HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.IdCard).HasMaxLength(20);

                entity.Property(e => e.Initials).HasMaxLength(10);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Mobil).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.HasOne(d => d.GenderUnique)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.GenderUniqueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EMPLOYEE_GENDER");

                entity.HasOne(d => d.LanguageUnique)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.LanguageUniqueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EMPLOYEE_LANGUAGE");

                entity.HasOne(d => d.SiteStyleTypeUnique)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.SiteStyleTypeUniqueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EMPLOYEE_SITE_STYLE_TYPE");

                entity.HasOne(d => d.UserUnique)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.UserUniqueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EMPLOYEE_USER");
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.HasKey(e => e.UniqueId)
                    .HasName("PK__GENDER");

                entity.ToTable("GENDER");

                entity.HasIndex(e => e.Name)
                    .HasName("UQ_GENDER_Name")
                    .IsUnique();

                entity.Property(e => e.UniqueId).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.HasKey(e => e.UniqueId)
                    .HasName("PK__LANGUAGE__A2A2A54A798D135B");

                entity.ToTable("LANGUAGE");

                entity.HasIndex(e => e.Code)
                    .HasName("UQ_LANGUAGE_Code")
                    .IsUnique();

                entity.HasIndex(e => e.Name)
                    .HasName("UQ_LANGUAGE_Name")
                    .IsUnique();

                entity.Property(e => e.UniqueId).ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<MusicType>(entity =>
            {
                entity.HasKey(e => e.UniqueId);

                entity.ToTable("MUSIC_TYPE");

                entity.Property(e => e.UniqueId)
                    .HasColumnName("UniqueID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<RatingType>(entity =>
            {
                entity.HasKey(e => e.UniqueId);

                entity.ToTable("RATING_TYPE");

                entity.Property(e => e.UniqueId)
                    .HasColumnName("UniqueID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.UniqueId)
                    .HasName("PK__ROLE__A2A2A54AEB045052");

                entity.ToTable("ROLE");

                entity.HasIndex(e => e.Code)
                    .HasName("UQ_ROLE_Code")
                    .IsUnique();

                entity.HasIndex(e => e.Name)
                    .HasName("UQ_ROLE_Name")
                    .IsUnique();

                entity.Property(e => e.UniqueId).ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SiteStyleType>(entity =>
            {
                entity.HasKey(e => e.UniqueId)
                    .HasName("PK_SITE_STYLE");

                entity.ToTable("SITE_STYLE_TYPE");

                entity.Property(e => e.UniqueId).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Song>(entity =>
            {
                entity.HasKey(e => e.UniqueId);

                entity.ToTable("SONG");

                entity.Property(e => e.UniqueId)
                    .HasColumnName("UniqueID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AlbumId).HasColumnName("AlbumID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.SongPriceId).HasColumnName("SongPriceID");

                entity.Property(e => e.Time).HasColumnType("time(0)");

                entity.HasOne(d => d.Album)
                    .WithMany(p => p.Song)
                    .HasForeignKey(d => d.AlbumId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SONG_ALBUM");

                entity.HasOne(d => d.SongPrice)
                    .WithMany(p => p.Song)
                    .HasForeignKey(d => d.SongPriceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SONG_SONG_PRICE");
            });

            modelBuilder.Entity<SongPrice>(entity =>
            {
                entity.HasKey(e => e.UniqueId);

                entity.ToTable("SONG_PRICE");

                entity.Property(e => e.UniqueId)
                    .HasColumnName("UniqueID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Price).HasColumnType("decimal(9, 2)");
            });

            modelBuilder.Entity<SystemType>(entity =>
            {
                entity.HasKey(e => e.UniqueId);

                entity.ToTable("SYSTEM_TYPE");

                entity.Property(e => e.UniqueId).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UniqueId)
                    .HasName("PK__USER__A2A2A54A966542D1");

                entity.ToTable("USER");

                entity.HasIndex(e => e.Username)
                    .HasName("UQ_USER_Login")
                    .IsUnique();

                entity.Property(e => e.UniqueId).ValueGeneratedNever();

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Token).HasMaxLength(500);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => e.UniqueId);

                entity.ToTable("USER_ROLE");

                entity.HasIndex(e => new { e.UserUniqueId, e.RoleUniqueId })
                    .HasName("IX_USER_ROLE")
                    .IsUnique();

                entity.Property(e => e.UniqueId).ValueGeneratedNever();

                entity.HasOne(d => d.RoleUnique)
                    .WithMany(p => p.UserRole)
                    .HasForeignKey(d => d.RoleUniqueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Role_User");

                entity.HasOne(d => d.UserUnique)
                    .WithMany(p => p.UserRole)
                    .HasForeignKey(d => d.UserUniqueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Role");
            });

            modelBuilder.Entity<VersionHistory>(entity =>
            {
                entity.HasKey(e => e.UniqueId);

                entity.ToTable("VERSION_HISTORY");

                entity.Property(e => e.UniqueId).ValueGeneratedNever();

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Number)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.LanguageUnique)
                    .WithMany(p => p.VersionHistory)
                    .HasForeignKey(d => d.LanguageUniqueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VERSION_HISTORY_LANGUAGE");

                entity.HasOne(d => d.SystemTypeUnique)
                    .WithMany(p => p.VersionHistory)
                    .HasForeignKey(d => d.SystemTypeUniqueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VERSION_HISTORY_SYSTEM_TYPE");
            });
        }
    }
}
