using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using my_finance_web_domain.Entities;

namespace my_finance_web_infra;
public class MyFinanceDbContext : DbContext
{
    private readonly IConfiguration _configuration;
    public DbSet<PlanoConta> PlanoConta { get; set; }
    public DbSet<Transacao> Transacao { get; set; }
    public MyFinanceDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = _configuration.GetConnectionString("Database");
        optionsBuilder.UseSqlServer(connectionString);
    }
}
