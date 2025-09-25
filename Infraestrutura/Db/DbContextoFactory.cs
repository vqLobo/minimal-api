using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace MinimalApi.Infraestrutura.Db;

public class DbContextoFactory : IDesignTimeDbContextFactory<DbContexto>
{
    public DbContexto CreateDbContext(string[] args)
    {
        // Criando uma configuração mock para design time (migrations)
        var configurationBuilder = new ConfigurationBuilder();
        configurationBuilder.AddInMemoryCollection(new[]
        {
            new KeyValuePair<string, string?>("ConnectionStrings:mysql", "Server=localhost;Database=minimal_api;Uid=root;Pwd=root;")
        });
        
        var configuration = configurationBuilder.Build();
        
        return new DbContexto(configuration);
    }
}