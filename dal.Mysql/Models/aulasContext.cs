using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace dal.Mysql.Models
{
    public partial class aulasContext : DbContext
    {
        public aulasContext()
        {
        }

        public aulasContext(DbContextOptions<aulasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categorium> Categoria { get; set; } = null!;
        public virtual DbSet<Estoque> Estoques { get; set; } = null!;
        public virtual DbSet<Produtoss> Produtosses { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;database=aulas;uid=root;pwd=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.33-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Categorium>(entity =>
            {
                entity.ToTable("categoria");

                entity.Property(e => e.Nome).HasMaxLength(60);
            });

            modelBuilder.Entity<Estoque>(entity =>
            {
                entity.ToTable("estoque");

                entity.HasIndex(e => e.ProdutoId, "fk_pro_esto_idx");

                entity.HasOne(d => d.Produto)
                    .WithMany(p => p.Estoques)
                    .HasForeignKey(d => d.ProdutoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pro_esto");
            });

            modelBuilder.Entity<Produtoss>(entity =>
            {
                entity.ToTable("produtoss");

                entity.Property(e => e.Corr).HasMaxLength(50);

                entity.Property(e => e.Nomee).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
