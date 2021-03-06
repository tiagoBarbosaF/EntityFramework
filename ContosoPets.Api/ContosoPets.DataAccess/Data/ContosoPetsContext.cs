using ContosoPets.Domain.Models;

using Microsoft.EntityFrameworkCore;

namespace ContosoPets.DataAccess.Data;

public class ContosoPetsContext : DbContext
{
    public ContosoPetsContext(DbContextOptions<ContosoPetsContext> options) : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductOrder> ProductOrders { get; set; }
}

