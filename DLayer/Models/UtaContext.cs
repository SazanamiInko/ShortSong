using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DLayer.Models;

public partial class UtaContext : DbContext
{
    public UtaContext()
    {
    }

    public UtaContext(DbContextOptions<UtaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MSeazon> MSeazons { get; set; }

    public virtual DbSet<THaiku> THaikus { get; set; }

    public virtual DbSet<THistory> THistories { get; set; }

    public virtual DbSet<TPreference> TPreferences { get; set; }

    public virtual DbSet<TShortSong> TShortSongs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=C:\\Users\\Public\\Documents\\Data\\uta.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MSeazon>(entity =>
        {
            entity.HasKey(e => e.Code);

            entity.ToTable("M_Seazon");

            entity.HasIndex(e => e.Value, "IX_M_Seazon_Value").IsUnique();

            entity.Property(e => e.Value).HasDefaultValueSql("''");
        });

        modelBuilder.Entity<THaiku>(entity =>
        {
            entity.ToTable("T_Haiku");

            entity.HasIndex(e => e.Haiku, "IX_T_Haiku_Haiku").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Haiku).HasColumnType("VARCHAR(17)");
        });

        modelBuilder.Entity<THistory>(entity =>
        {
            entity.ToTable("T_History");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Before).HasColumnType("VARCHAR(70)");
            entity.Property(e => e.Comment).HasColumnType("VARCHAR(100)");
        });

        modelBuilder.Entity<TPreference>(entity =>
        {
            entity.ToTable("T_Preference");

            entity.HasIndex(e => e.Uta, "IX_T_Preference_Uta").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Author).HasColumnType("VARCHAR(20)");
            entity.Property(e => e.Book).HasColumnType("VARCHAR(20)");
            entity.Property(e => e.CreateDate).HasColumnType("VARCHAR(20)");
            entity.Property(e => e.Era).HasColumnType("VARCHAR(10)");
            entity.Property(e => e.Index).HasColumnType("VARCHAR(100)");
            entity.Property(e => e.Memo).HasColumnType("VARCHAR(100)");
            entity.Property(e => e.Uta).HasColumnType("VARCHAR(50)");
        });

        modelBuilder.Entity<TShortSong>(entity =>
        {
            entity.ToTable("T_ShortSong");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("''")
                .HasColumnType("VARCHAR(20)");
            entity.Property(e => e.Delete).HasDefaultValueSql("'0'");
            entity.Property(e => e.English)
                .HasDefaultValueSql("''")
                .HasColumnType("VARCHAR(200)");
            entity.Property(e => e.Front)
                .HasDefaultValueSql("''")
                .HasColumnType("VARCHAR(50)");
            entity.Property(e => e.Index).HasColumnType("VARCHAR(200)");
            entity.Property(e => e.Kana)
                .HasDefaultValueSql("''")
                .HasColumnType("VARCHAR(100)");
            entity.Property(e => e.Memo).HasColumnType("VARCHAR(500)");
            entity.Property(e => e.RefUta).HasColumnType("VARCHAR(50)");
            entity.Property(e => e.Seazon).HasDefaultValueSql("'0'");
            entity.Property(e => e.UpdateCount).HasDefaultValueSql("'0'");
            entity.Property(e => e.UpdateDate)
                .HasDefaultValueSql("''")
                .HasColumnType("VARCHAR(20)");
            entity.Property(e => e.Uta)
                .HasDefaultValueSql("''")
                .HasColumnType("VARCHAR(50)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
