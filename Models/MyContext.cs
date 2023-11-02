#pragma warning disable CS8618

using Microsoft.EntityFrameworkCore;
namespace ChefsNDishes.Models;


public class MyContext : DbContext 
{   
    public DbSet<Chef> Chefs { get; set; } 
    public DbSet<Dish> Dishes { get; set; } 

    
    public MyContext(DbContextOptions options) : base(options) { }    


    
}
