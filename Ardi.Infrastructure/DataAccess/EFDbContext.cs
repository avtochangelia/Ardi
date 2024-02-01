using Ardi.Domain.ProductManagement;
using Ardi.Domain.PolicyHolderManagement;
using Ardi.Domain.PolicyManagement;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Ardi.Infrastructure.DataAccess;

public class EFDbContext(DbContextOptions options) : DbContext(options)
{
    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<PolicyHolder> Policyholders { get; set; }
    public virtual DbSet<Policy> Policies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(EFDbContext))!);
        base.OnModelCreating(modelBuilder);
    }
}