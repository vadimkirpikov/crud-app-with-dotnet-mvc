using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
namespace crud_app.Models;


public class CrudApplicationContext: DbContext
{
    public CrudApplicationContext(DbContextOptions<CrudApplicationContext> options) :
        base(options)
    {
    }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Editor> Editors { get; set; }
}