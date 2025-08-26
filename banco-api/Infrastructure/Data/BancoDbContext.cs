using banco_api.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace banco_api.Infrastructure.Data
{
    public partial class BancoDBContext : DbContext
    {
        public BancoDBContext(DbContextOptions<BancoDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }

        public virtual DbSet<AccountType> AccountTypes { get; set; }

        public virtual DbSet<Client> Clients { get; set; }

        public virtual DbSet<Movement> Movements { get; set; }

        public virtual DbSet<Person> People { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Account__3214EC07DEA625F6");

                entity.ToTable("Account");

                entity.Property(e => e.Id)
                    .HasMaxLength(36)
                    .IsUnicode(false);
                entity.Property(e => e.AccountNumer)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.AccountTypeId)
                    .HasMaxLength(36)
                    .IsUnicode(false);
                entity.Property(e => e.ClientId)
                    .HasMaxLength(36)
                    .IsUnicode(false);
                entity.Property(e => e.InitialBalance).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.AccountType).WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.AccountTypeId)
                    .HasConstraintName("FK__Account__Account__6E01572D");

                entity.HasOne(d => d.Client).WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK__Account__ClientI__6EF57B66");
            });

            modelBuilder.Entity<AccountType>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__AccountT__3214EC07D94E8A1C");

                entity.ToTable("AccountType");

                entity.Property(e => e.Id)
                    .HasMaxLength(36)
                    .IsUnicode(false);
                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Client__3214EC073984390B");

                entity.ToTable("Client");

                entity.Property(e => e.Id)
                    .HasMaxLength(36)
                    .IsUnicode(false);
                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.PersonId)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.HasOne(d => d.Person).WithMany(p => p.Clients)
                    .HasForeignKey(d => d.PersonId)
                    .HasConstraintName("FK__Client__PersonId__693CA210");
            });

            modelBuilder.Entity<Movement>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Movement__3214EC0751B26B52");

                entity.Property(e => e.Id)
                    .HasMaxLength(36)
                    .IsUnicode(false);
                entity.Property(e => e.AccountId)
                    .HasMaxLength(36)
                    .IsUnicode(false);
                entity.Property(e => e.Balance).HasColumnType("decimal(10, 2)");
                entity.Property(e => e.Date).HasColumnType("datetime");
                entity.Property(e => e.MovementType)
                    .HasMaxLength(10)
                    .IsUnicode(false);
                entity.Property(e => e.Value).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Account).WithMany(p => p.Movements)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK__Movements__Accou__71D1E811");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Person__3214EC070B5869FF");

                entity.ToTable("Person");

                entity.Property(e => e.Id)
                    .HasMaxLength(36)
                    .IsUnicode(false);
                entity.Property(e => e.Address)
                    .HasMaxLength(200)
                    .IsUnicode(false);
                entity.Property(e => e.Credential)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.Gender)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false);
                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
