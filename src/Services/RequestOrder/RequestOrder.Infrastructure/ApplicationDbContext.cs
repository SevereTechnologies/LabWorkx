using Microsoft.EntityFrameworkCore;
using RequestOrder.Domain.Models;
using System.Reflection;

namespace RequestOrder.Infrastructure;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderItem> Items => Set<OrderItem>();
    public DbSet<Procedure> Procedures => Set<Procedure>();
    public DbSet<Technician> Technicians => Set<Technician>();
    public DbSet<Patient> Patients => Set<Patient>();
    public DbSet<Provider> Providers => Set<Provider>();
    public DbSet<Shipper> Shippers => Set<Shipper>();
    public DbSet<Lab> Labs => Set<Lab>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}
