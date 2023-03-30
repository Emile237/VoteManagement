using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace VoteV2.Models
{
    public partial class VoteContext : DbContext
    {
        public VoteContext()
        {
        }

        public VoteContext(DbContextOptions<VoteContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Candidat> Candidats { get; set; } = null!;
        public virtual DbSet<Candidature> Candidatures { get; set; } = null!;
        public virtual DbSet<Etudiant> Etudiants { get; set; } = null!;
        public virtual DbSet<Poste> Postes { get; set; } = null!;
        public virtual DbSet<Vote> Votes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
               optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Vote;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidat>(entity =>
            {
                entity.HasKey(e => e.IdCandidat)
                    .HasName("PK__candidat__C4E86D4568985931");

                entity.ToTable("candidat");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.Nom)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Prenom)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("prenom");
            });

            modelBuilder.Entity<Candidature>(entity =>
            {
                entity.HasKey(e => e.Idcandidature)
                    .HasName("PK__candidat__653BF0C06D049F77");

                entity.ToTable("candidature");

                entity.HasOne(d => d.poste)
                    .WithMany(p => p.Candidatures)
                    .HasForeignKey(d => d.IdPoste)
                    .HasConstraintName("idposte");

                entity.HasOne(d => d.candidat)
                    .WithMany(p => p.Candidatures)
                    .HasForeignKey(d => d.Idcandidat)
                    .HasConstraintName("idcandidat");
            });

            modelBuilder.Entity<Etudiant>(entity =>
            {
                entity.HasKey(e => e.IdEtudiant)
                    .HasName("PK__etudiant__B17EA2BC57B7F58D");

                entity.ToTable("etudiant");

                entity.Property(e => e.Code)
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Poste>(entity =>
            {
                entity.HasKey(e => e.Idposte)
                    .HasName("PK__poste__B20D3A2F6A32FD2C");

                entity.ToTable("poste");

                entity.Property(e => e.Appelation)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Description).HasColumnType("text");
            });

            modelBuilder.Entity<Vote>(entity =>
            {
                entity.HasKey(e => e.Idvote)
                    .HasName("PK__vote__6B4F5F17835D1E3F");

                entity.ToTable("vote");

                entity.Property(e => e.Idvote).ValueGeneratedNever();

                entity.HasOne(d => d.IdCandidatureNavigation)
                    .WithMany(p => p.Votes)
                    .HasForeignKey(d => d.IdCandidature)
                    .HasConstraintName("idcandidature");

                entity.HasOne(d => d.IdEtudiantNavigation)
                    .WithMany(p => p.Votes)
                    .HasForeignKey(d => d.IdEtudiant)
                    .HasConstraintName("idetudiant");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
