using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DatingAPi.Models;

public partial class DatingappContext : DbContext
{
    public DatingappContext()
    {
    }

    public DatingappContext(DbContextOptions<DatingappContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Abonnement> Abonnements { get; set; }

    public virtual DbSet<Conversation> Conversations { get; set; }

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<Passion> Passions { get; set; }

    public virtual DbSet<Pay> Pays { get; set; }

    public virtual DbSet<Quartier> Quartiers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Userabonnement> Userabonnements { get; set; }

    public virtual DbSet<Userconversation> Userconversations { get; set; }

    public virtual DbSet<Userimage> Userimages { get; set; }

    public virtual DbSet<Userlikeprofil> Userlikeprofils { get; set; }

    public virtual DbSet<Userpassion> Userpassions { get; set; }

    public virtual DbSet<Ville> Villes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("Server=localhost;Port=3306;Database=datingapp;Uid=root;Pwd=;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Abonnement>(entity =>
        {
            entity.HasKey(e => e.Idabonnement).HasName("PRIMARY");

            entity.ToTable("abonnements");

            entity.Property(e => e.Idabonnement).HasColumnName("idabonnement");
            entity.Property(e => e.Details)
                .HasColumnType("text")
                .HasColumnName("details");
            entity.Property(e => e.Devise)
                .HasMaxLength(8)
                .HasColumnName("devise");
            entity.Property(e => e.Duree)
                .HasMaxLength(45)
                .HasColumnName("duree");
            entity.Property(e => e.IsPopulaire).HasColumnName("isPopulaire");
            entity.Property(e => e.Nom)
                .HasMaxLength(100)
                .HasColumnName("nom");
            entity.Property(e => e.Prix)
                .HasPrecision(10)
                .HasColumnName("prix");
        });

        modelBuilder.Entity<Conversation>(entity =>
        {
            entity.HasKey(e => e.Idconversation).HasName("PRIMARY");

            entity.ToTable("conversations");

            entity.Property(e => e.Idconversation).HasColumnName("idconversation");
            entity.Property(e => e.NomConversation)
                .HasMaxLength(45)
                .HasColumnName("Nom_conversation");
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.HasKey(e => e.Idmessage).HasName("PRIMARY");

            entity.ToTable("messages");

            entity.Property(e => e.Idmessage).HasColumnName("idmessage");
            entity.Property(e => e.Contenu)
                .HasColumnType("text")
                .HasColumnName("contenu");
            entity.Property(e => e.Dateenvoi)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("dateenvoi");
            entity.Property(e => e.Idconversation).HasColumnName("idconversation");
            entity.Property(e => e.Iduser).HasColumnName("iduser");
        });

        modelBuilder.Entity<Passion>(entity =>
        {
            entity.HasKey(e => e.Idpassion).HasName("PRIMARY");

            entity.ToTable("passions");

            entity.Property(e => e.Idpassion).HasColumnName("idpassion");
            entity.Property(e => e.Nom)
                .HasMaxLength(155)
                .HasColumnName("nom");
        });

        modelBuilder.Entity<Pay>(entity =>
        {
            entity.HasKey(e => e.Idpays).HasName("PRIMARY");

            entity.ToTable("pays");

            entity.Property(e => e.Idpays).HasColumnName("idpays");
            entity.Property(e => e.Code)
                .HasMaxLength(4)
                .HasColumnName("code");
            entity.Property(e => e.Indicatif)
                .HasMaxLength(6)
                .HasColumnName("indicatif");
            entity.Property(e => e.Nom)
                .HasMaxLength(50)
                .HasColumnName("nom");
        });

        modelBuilder.Entity<Quartier>(entity =>
        {
            entity.HasKey(e => e.Idquartier).HasName("PRIMARY");

            entity.ToTable("quartiers");

            entity.Property(e => e.Idquartier).HasColumnName("idquartier");
            entity.Property(e => e.Idville).HasColumnName("idville");
            entity.Property(e => e.Nom)
                .HasMaxLength(100)
                .HasColumnName("nom");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Idusers).HasName("PRIMARY");

            entity.ToTable("users");

            entity.Property(e => e.Idusers).HasColumnName("idusers");
            entity.Property(e => e.CodeSms).HasColumnName("codeSms");
            entity.Property(e => e.Createdat)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("createdat");
            entity.Property(e => e.Datenaissance)
                .HasColumnType("datetime")
                .HasColumnName("datenaissance");
            entity.Property(e => e.Email)
                .HasMaxLength(105)
                .HasColumnName("email");
            entity.Property(e => e.Idquartier).HasColumnName("idquartier");
            entity.Property(e => e.Password)
                .HasMaxLength(45)
                .HasColumnName("password");
            entity.Property(e => e.RefreshToken)
                .HasColumnType("text")
                .HasColumnName("refreshToken");
            entity.Property(e => e.Telephone)
                .HasMaxLength(45)
                .HasColumnName("telephone");
            entity.Property(e => e.Token)
                .HasColumnType("text")
                .HasColumnName("token");
        });

        modelBuilder.Entity<Userabonnement>(entity =>
        {
            entity.HasKey(e => e.IduserAbonnement).HasName("PRIMARY");

            entity.ToTable("userabonnements");

            entity.Property(e => e.IduserAbonnement).HasColumnName("iduserAbonnement");
            entity.Property(e => e.Createdat)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("createdat");
            entity.Property(e => e.Datedebut)
                .HasColumnType("datetime")
                .HasColumnName("datedebut");
            entity.Property(e => e.Datefin)
                .HasColumnType("datetime")
                .HasColumnName("datefin");
            entity.Property(e => e.IdAbonnement).HasColumnName("idAbonnement");
            entity.Property(e => e.Iduser).HasColumnName("iduser");
        });

        modelBuilder.Entity<Userconversation>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("userconversations");

            entity.Property(e => e.Idconversation).HasColumnName("idconversation");
            entity.Property(e => e.Iduser).HasColumnName("iduser");
        });

        modelBuilder.Entity<Userimage>(entity =>
        {
            entity.HasKey(e => e.IduserImage).HasName("PRIMARY");

            entity.ToTable("userimages");

            entity.Property(e => e.IduserImage).HasColumnName("iduserImage");
            entity.Property(e => e.Filename)
                .HasColumnType("text")
                .HasColumnName("filename");
            entity.Property(e => e.Iduser).HasColumnName("iduser");
        });

        modelBuilder.Entity<Userlikeprofil>(entity =>
        {
            entity.HasKey(e => e.IduserLikeProfil).HasName("PRIMARY");

            entity.ToTable("userlikeprofil");

            entity.Property(e => e.IduserLikeProfil).HasColumnName("iduserLikeProfil");
            entity.Property(e => e.Iduser1).HasColumnName("iduser1");
            entity.Property(e => e.Iduser2).HasColumnName("iduser2");
        });

        modelBuilder.Entity<Userpassion>(entity =>
        {
            entity.HasKey(e => e.IduserPassion).HasName("PRIMARY");

            entity.ToTable("userpassions");

            entity.Property(e => e.IduserPassion).HasColumnName("iduserPassion");
            entity.Property(e => e.Idpassion).HasColumnName("idpassion");
            entity.Property(e => e.Iduser).HasColumnName("iduser");
        });

        modelBuilder.Entity<Ville>(entity =>
        {
            entity.HasKey(e => e.Idville).HasName("PRIMARY");

            entity.ToTable("villes");

            entity.Property(e => e.Idville).HasColumnName("idville");
            entity.Property(e => e.Idpays).HasColumnName("idpays");
            entity.Property(e => e.Nom)
                .HasMaxLength(155)
                .HasColumnName("nom");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
