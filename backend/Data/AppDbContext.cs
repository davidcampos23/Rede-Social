using backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace backend.Data;

public class AppDbContext : DbContext
{
    //public DbSet<Posts> posts { get; set;}
    public DbSet<Register> registers {get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(connectionString:"DataSource=app.db;Cache=Shared");
    }
}

