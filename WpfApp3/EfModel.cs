using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WpfApp3.Database;

namespace WpfApp3
{
    public partial class EfModel : DbContext
    {
        private static EfModel Instance;
        public static EfModel Init()
        {
        if (Instance==null)
                Instance = new EfModel();
        return Instance;
        }
        public EfModel()
        {
           
        }

        public EfModel(DbContextOptions<EfModel> options)
            : base(options)
        {
        }

        public virtual DbSet<Child> Children { get; set; } = null!;
        public virtual DbSet<DopPersonal> DopPersonals { get; set; } = null!;
        public virtual DbSet<Group> Groups { get; set; } = null!;
        public virtual DbSet<Kruzki> Kruzkis { get; set; } = null!;
        public virtual DbSet<Meropriyatiya> Meropriyatiyas { get; set; } = null!;
        public virtual DbSet<Raspisanie> Raspisanies { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Vospitateli> Vospitatelis { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=cfif31.ru;port=3306;user id=ISPr22-43_NekrasovAI;password=ISPr22-43_NekrasovAI;character set=utf8;database=ISPr22-43_NekrasovAI_02", ServerVersion.Parse("8.0.29-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Child>(entity =>
            {
                entity.HasKey(e => e.IdChildren)
                    .HasName("PRIMARY");

                entity.Property(e => e.IdChildren).HasColumnName("idChildren");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.Fio)
                    .HasMaxLength(60)
                    .HasColumnName("FIO");

                entity.Property(e => e.Group)
                    .HasMaxLength(60)
                    .HasColumnName("group");

                entity.Property(e => e.PhoneParents).HasColumnName("phone_parents");
            });

            modelBuilder.Entity<DopPersonal>(entity =>
            {
                entity.HasKey(e => e.IdDopPersonal)
                    .HasName("PRIMARY");

                entity.ToTable("Dop_personal");

                entity.HasIndex(e => e.Fio, "fk_Dop_personal_Meropriyatiya_idx")
                    .IsUnique();

                entity.Property(e => e.IdDopPersonal).HasColumnName("idDop_personal");

                entity.Property(e => e.Fio)
                    .HasMaxLength(45)
                    .HasColumnName("FIO");

                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.Property(e => e.Profession)
                    .HasMaxLength(45)
                    .HasColumnName("profession");
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.HasKey(e => e.IdGroup)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.Nomer, "fk_Groups_Meropriyatiya");

                entity.Property(e => e.IdGroup).HasColumnName("idGroup");

                entity.Property(e => e.KolVoChild).HasColumnName("kol-voChild");

                entity.Property(e => e.Kruzki)
                    .HasMaxLength(45)
                    .HasColumnName("kruzki");

                entity.Property(e => e.Meropriyatiya)
                    .HasMaxLength(45)
                    .HasColumnName("meropriyatiya");

                entity.Property(e => e.NameVospitateli)
                    .HasMaxLength(45)
                    .HasColumnName("nameVospitateli");

                entity.Property(e => e.Nomer)
                    .HasMaxLength(60)
                    .HasColumnName("nomer");
            });

            modelBuilder.Entity<Kruzki>(entity =>
            {
                entity.HasKey(e => e.IdKruzki)
                    .HasName("PRIMARY");

                entity.ToTable("Kruzki");

                entity.HasIndex(e => e.Name, "fk_Kruzki_Groups_1idx")
                    .IsUnique();

                entity.HasIndex(e => e.Dayofweek, "fk_Kruzki_Raspisanie_idx");

                entity.Property(e => e.IdKruzki).HasColumnName("idKruzki");

                entity.Property(e => e.Assistent)
                    .HasMaxLength(45)
                    .HasColumnName("assistent");

                entity.Property(e => e.Dayofweek)
                    .HasMaxLength(45)
                    .HasColumnName("dayofweek");

                entity.Property(e => e.Group)
                    .HasMaxLength(60)
                    .HasColumnName("group");

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .HasColumnName("name");

                entity.Property(e => e.Vospitatel)
                    .HasMaxLength(45)
                    .HasColumnName("vospitatel");
            });

            modelBuilder.Entity<Meropriyatiya>(entity =>
            {
                entity.HasKey(e => e.IdMeropriyatiya)
                    .HasName("PRIMARY");

                entity.ToTable("Meropriyatiya");

                entity.HasIndex(e => e.Name, "fk_Meropriyatiya_Groups_1idx")
                    .IsUnique();

                entity.Property(e => e.IdMeropriyatiya).HasColumnName("idMeropriyatiya");

                entity.Property(e => e.Assistent)
                    .HasMaxLength(45)
                    .HasColumnName("assistent");

                entity.Property(e => e.Dayofweek)
                    .HasMaxLength(45)
                    .HasColumnName("dayofweek");

                entity.Property(e => e.Group)
                    .HasMaxLength(60)
                    .HasColumnName("group");

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .HasColumnName("name");

                entity.Property(e => e.Vospitatel)
                    .HasMaxLength(45)
                    .HasColumnName("vospitatel");
            });

            modelBuilder.Entity<Raspisanie>(entity =>
            {
                entity.HasKey(e => e.IdRaspisanie)
                    .HasName("PRIMARY");

                entity.ToTable("Raspisanie");

                entity.Property(e => e.IdRaspisanie).HasColumnName("idRaspisanie");

                entity.Property(e => e.Dayofweek)
                    .HasMaxLength(45)
                    .HasColumnName("dayofweek");

                entity.Property(e => e.Kruzki).HasMaxLength(45);

                entity.Property(e => e.Meropriyatiya).HasMaxLength(45);

                entity.Property(e => e.NameVospitateli)
                    .HasMaxLength(45)
                    .HasColumnName("nameVospitateli");

                entity.Property(e => e.Nomer)
                    .HasMaxLength(60)
                    .HasColumnName("nomer");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUsers)
                    .HasName("PRIMARY");

                entity.Property(e => e.IdUsers).HasColumnName("idUsers");

                entity.Property(e => e.Login).HasColumnType("text");

                entity.Property(e => e.NickName).HasMaxLength(45);

                entity.Property(e => e.Pass).HasColumnType("text");

                entity.Property(e => e.Post)
                    .HasMaxLength(45)
                    .HasDefaultValueSql("'User'");
            });

            modelBuilder.Entity<Vospitateli>(entity =>
            {
                entity.HasKey(e => e.IdVospitateli)
                    .HasName("PRIMARY");

                entity.ToTable("Vospitateli");

                entity.HasIndex(e => e.Fio, "fk_Groups_Vospitateli_idx");

                entity.Property(e => e.IdVospitateli).HasColumnName("idVospitateli");

                entity.Property(e => e.Fio)
                    .HasMaxLength(45)
                    .HasColumnName("FIO");

                entity.Property(e => e.Phone)
                    .HasMaxLength(45)
                    .HasColumnName("phone");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
