using BusinessDomain.Entities;
using DataPersistence.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataPersistence
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
            
        }

        // constructor utilizado en el proyecto de test (DataPersistence.Test)
        public MyDbContext()
        {
            
        }

        public DbSet<Usuario> Usuarios { get; set; }    

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // adding User Secret service to read the appsettings.json
            var configuration = new ConfigurationBuilder()
                .AddUserSecrets<MyDbContext>()
                .Build();

            // getting the oracle connection string settings
            var connectionString = configuration.GetConnectionString("OracleDb");

            optionsBuilder.UseOracle(connectionString);

            // https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-9.0&tabs=windows
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) =>
            modelBuilder.ApplyConfiguration(new UsuarioMap());
    }
}
