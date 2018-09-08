using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MurderWithFriendsAPI.Models
{
    public partial class ItsOnlyHeroesContext : DbContext
    {
        public ItsOnlyHeroesContext()
        {
        }

        public ItsOnlyHeroesContext(DbContextOptions<ItsOnlyHeroesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Character> Character { get; set; }
        public virtual DbSet<CurrencyType> CurrencyType { get; set; }
        public virtual DbSet<Equipment> Equipment { get; set; }
        public virtual DbSet<Experience> Experience { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<ItemType> ItemType { get; set; }
        public virtual DbSet<LoginHistory> LoginHistory { get; set; }
        public virtual DbSet<LoginResult> LoginResult { get; set; }
        public virtual DbSet<Security> Security { get; set; }
        public virtual DbSet<Stats> Stats { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserCurrency> UserCurrency { get; set; }


		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
				optionsBuilder.UseSqlServer("Server=cryptographstudios.database.windows.net;Database=ItsOnlyHeroes;Trusted_Connection=False;  Persist Security Info=False;User ID=Cryptographer;Password=1q2w3e!Q@W#E;");
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Character>(entity =>
            {
                entity.ToTable("Character", "Character");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.BaseStats)
                    .WithMany(p => p.Character)
                    .HasForeignKey(d => d.BaseStatsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Character_Stats");

                entity.HasOne(d => d.Experience)
                    .WithMany(p => p.Character)
                    .HasForeignKey(d => d.ExperienceId)
                    .HasConstraintName("FK_Character_Experience");
            });

            modelBuilder.Entity<CurrencyType>(entity =>
            {
                entity.ToTable("CurrencyType", "Currency");

                entity.Property(e => e.CurrencyTypeName).HasMaxLength(20);

                entity.Property(e => e.ValueInUsd)
                    .HasColumnName("ValueInUSD")
                    .HasColumnType("money");
            });

            modelBuilder.Entity<Equipment>(entity =>
            {
                entity.ToTable("Equipment", "Character");

                entity.HasOne(d => d.Character)
                    .WithMany(p => p.Equipment)
                    .HasForeignKey(d => d.CharacterId)
                    .HasConstraintName("FK_Equipment_Character");

                entity.HasOne(d => d.Experience)
                    .WithMany(p => p.Equipment)
                    .HasForeignKey(d => d.ExperienceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Equipment_Experience");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.Equipment)
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("FK_Equipment_Item");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Equipment)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Equipment_User");
            });

            modelBuilder.Entity<Experience>(entity =>
            {
                entity.ToTable("Experience", "Stats");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.ToTable("Inventory", "Account");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.Inventory)
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("FK_Inventory_Item");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Inventory)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Inventory_User");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("Item", "Item");

                entity.Property(e => e.Description).HasMaxLength(256);

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.HasOne(d => d.BuyCurrency)
                    .WithMany(p => p.Item)
                    .HasForeignKey(d => d.BuyCurrencyId)
                    .HasConstraintName("FK_Item_CurrencyType");

                entity.HasOne(d => d.ItemType)
                    .WithMany(p => p.Item)
                    .HasForeignKey(d => d.ItemTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Item_ItemType");

                entity.HasOne(d => d.Stats)
                    .WithMany(p => p.Item)
                    .HasForeignKey(d => d.StatsId)
                    .HasConstraintName("FK_Item_Stats");
            });

            modelBuilder.Entity<ItemType>(entity =>
            {
                entity.ToTable("ItemType", "Item");

                entity.Property(e => e.ItemTypeDescription).HasMaxLength(256);

                entity.Property(e => e.ItemTypeName).HasMaxLength(20);
            });

            modelBuilder.Entity<LoginHistory>(entity =>
            {
                entity.HasKey(e => e.LoginResultId);

                entity.ToTable("LoginHistory", "Account");

                entity.Property(e => e.LoginResultId).ValueGeneratedOnAdd();

                entity.Property(e => e.Ipaddress)
                    .HasColumnName("IPAddress")
                    .HasMaxLength(50);

                entity.HasOne(d => d.LoginResult)
                    .WithOne(p => p.LoginHistory)
                    .HasForeignKey<LoginHistory>(d => d.LoginResultId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LoginHistory_LoginResult");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.LoginHistory)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_LoginHistory_User");
            });

            modelBuilder.Entity<LoginResult>(entity =>
            {
                entity.ToTable("LoginResult", "Account");

                entity.Property(e => e.Details).HasMaxLength(500);

                entity.Property(e => e.Result).HasMaxLength(50);
            });

            modelBuilder.Entity<Security>(entity =>
            {
                entity.ToTable("Security", "Account");

                entity.Property(e => e.SaltedHash).HasMaxLength(256);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Security)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Security_User");
            });

            modelBuilder.Entity<Stats>(entity =>
            {
                entity.ToTable("Stats", "Stats");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User", "Account");

                entity.Property(e => e.DisplayName).HasMaxLength(50);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<UserCurrency>(entity =>
            {
                entity.ToTable("UserCurrency", "Currency");

                entity.HasOne(d => d.Currency)
                    .WithMany(p => p.UserCurrency)
                    .HasForeignKey(d => d.CurrencyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserCurrency_CurrencyType");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserCurrency)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserCurrency_User");
            });
        }
    }
}
