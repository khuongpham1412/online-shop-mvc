using Microsoft.EntityFrameworkCore;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ShopDbContext;

public class OnlineShopDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=LAPTOP-0N9NUIQQ\SQLEXPRESS;Database=OnlineShopMVC;Trusted_Connection=True;");
    }

    public virtual DbSet<Account> Accounts { get; set; }
    public virtual DbSet<Customer> Customers { get; set; }
    public virtual DbSet<Employee> Employees { get; set; }
    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<Category> Categories { get; set; }
    public virtual DbSet<ProductSizeColor> ProductSizeColors { get; set; }
    public virtual DbSet<Size> Sizes { get; set; }
    public virtual DbSet<Color> Colors { get; set; }
    public virtual DbSet<Order> Orders { get; set; }
    public virtual DbSet<OrderDetail> OrderDetails { get; set; }
}
