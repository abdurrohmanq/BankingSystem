using BankingSystem.Domain.Entities.Accounts;
using BankingSystem.Domain.Entities.Deposits;
using BankingSystem.Domain.Entities.Loans;
using BankingSystem.Domain.Entities.Transactions;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.Data.Contexts;

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
	{
	}

	public DbSet<Account> Accounts { get; set; }
	public DbSet<Deposit> Deposits { get; set; }
	public DbSet<Loan> Loans { get; set; }
	public DbSet<Transaction> Transactions { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		modelBuilder.Entity<Account>()
			.Property(t => t.Balance)
			.HasColumnType("decimal(18, 2)");

		modelBuilder.Entity<Deposit>()
			.HasOne(d => d.Account)
			.WithMany(d => d.Deposits)
			.HasForeignKey(d => d.AccountId);

		modelBuilder.Entity<Deposit>()
			.Property(t => t.Amount)
			.HasColumnType("decimal(18, 2)");

		modelBuilder.Entity<Loan>()
			.HasOne(l => l.Account)
			.WithMany(l => l.Loans)
			.HasForeignKey(l => l.AccountId);

		modelBuilder.Entity<Loan>()
			.Property(t => t.Amount)
			.HasColumnType("decimal(18, 2)");

		modelBuilder.Entity<Transaction>()
			.HasOne(a => a.SourceAccount)
			.WithMany(a => a.SendTransactions)
			.HasForeignKey(a => a.SourceAccountId)
			.OnDelete(DeleteBehavior.NoAction);
		
		modelBuilder.Entity<Transaction>()
			.HasOne(a => a.TargetAccount)
			.WithMany(a => a.ReceiveTransactions)
			.HasForeignKey(a => a.TargetAccountId)
            .OnDelete(DeleteBehavior.NoAction);

		modelBuilder.Entity<Transaction>()
			.Property(t => t.Amount)
			.HasColumnType("decimal(18, 2)");
	}
}
