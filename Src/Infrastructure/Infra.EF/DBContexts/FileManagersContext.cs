
using Domain.Entites.FilePdfManagers;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infra.EF;

public class FileManagersContext : DbContext
{
    public FileManagersContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);



    }
    // public DbSet<Person> Persons { get; set; }
    // public DbSet<City> Citys { get; set; }
    public DbSet<FilePdfManager> FilePdfManager { get; set; }

}

