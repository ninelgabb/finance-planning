using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace FinancePlanning.Infrastructure;

public class MyDbContext : DbContext
{
    // These properties represent tables in the database
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Bank> Banks { get; set; }
    public DbSet<Distribution> Distributions { get; set; }
    public DbSet<Income> Incomes { get; set; }
    public DbSet<IncomeSource> IncomeSources { get; set; }
    public DbSet<Rule> Orders { get; set; }

    // Optional: Configure connection string or database provider
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // var dbName = Environment.GetEnvironmentVariable("POSTGRES_DB");
        // var dbUser = Environment.GetEnvironmentVariable("POSTGRES_DB_USER");
        // var dbPassword = Environment.GetEnvironmentVariable("POSTGRES_DB_PASSWORD");
        // optionsBuilder.UseNpgsql($"Host=localhost;Port=5430;Database={dbName};Username={dbUser};Password={dbPassword};");
        optionsBuilder.UseNpgsql(
            "Host=localhost;Port=5430;Database=postgres_db;Username=postgres_user;Password=postgres_password;");
    }

    // Optional: Configure the model using Fluent API
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>().HasKey(x => x.Code);
        modelBuilder.Entity<Bank>().HasKey(x => x.Code);
        modelBuilder.Entity<Distribution>().HasKey(x => x.Id);
        modelBuilder.Entity<Income>().HasKey(x => x.Id);
        modelBuilder.Entity<IncomeSource>().HasKey(x => x.Code);
        modelBuilder.Entity<Rule>().HasKey(x => x.Id);
        
        modelBuilder.Entity<Account>()
            .HasOne(x => x.Bank)
            .WithMany(x => x.Accounts)
            .HasForeignKey(x => x.BankCode);

        modelBuilder.Entity<Distribution>()
            .HasOne(x => x.Income)
            .WithMany(x => x.Distributions)
            .HasForeignKey(x => x.IncomeId);
        
        modelBuilder.Entity<Distribution>()
            .HasOne(x => x.Account)
            .WithMany(x => x.Distributions)
            .HasForeignKey(x => x.AccountCode);
        
        modelBuilder.Entity<Income>()
            .HasOne(x => x.IncomeSource)
            .WithMany(x => x.Incomes)
            .HasForeignKey(x => x.IncomeSourceCode);
        
        modelBuilder.Entity<Rule>()
            .HasOne(x => x.Account)
            .WithMany(x => x.Rules)
            .HasForeignKey(x => x.AccountCode);

        modelBuilder.Entity<Rule>()
            .HasOne(x => x.IncomeSource)
            .WithMany(x => x.Rules)
            .HasForeignKey(x => x.IncomeSourceCode);

        modelBuilder.Entity<Bank>()
            .HasData(
                new Bank() { Code = "BCS", Name = "БКС" },
                new Bank() { Code = "T", Name = "T" },
                new Bank() { Code = "CSH", Name = "Наличные" },
                new Bank() { Code = "Ya", Name = "Яндекс" },
                new Bank() { Code = "Oz", Name = "Озон" }
            );
    }
}