using CookBookAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CookBookAPI;

public class IngredientDbContext : DbContext
{
    public DbSet<Ingredient> Ingredients { get; set; }
    

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        /*var host = _configuration.GetValue<string>("DataSource:Host");
        var name = _configuration.GetValue<string>("DataSource:Name");
        var user = _configuration.GetValue<string>("DataSource:User");
        var password = _configuration.GetValue<string>("DataSource:Password");*/
        optionsBuilder.UseNpgsql("Server=localhost;Port=5432;User Id=postgres;Password=postgres;Database=cook_food;"); 
        base.OnConfiguring(optionsBuilder);
    }

}