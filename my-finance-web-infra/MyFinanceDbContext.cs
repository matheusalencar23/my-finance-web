using Microsoft.EntityFrameworkCore;
using my_finance_web_domain.Entities;

namespace my_finance_web_infra;
public class MyFinanceDbContext : DbContext
{
    public DbSet<PlanoConta> PlanoConta { get; set; }
    public DbSet<Transacao> Transacao { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=localhost;Database=myfinance;User Id=SA;Password=1q2w3e4r@#$;");
    }
}
