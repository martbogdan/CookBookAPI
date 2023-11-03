using CookBookAPI.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CookBookAPI.Repository;

public class IngredientRepository
{
    public IngredientRepository(IngredientDbContext context)
    {
        _context = context;
    }

    private readonly IngredientDbContext _context;

    public EntityEntry<Ingredient> Create(Ingredient ingredient)
    {
        var entityEntry = _context.Add(ingredient);
        _context.SaveChanges();
        return entityEntry;
    }

    public Ingredient? GetById(int id)
    {
        var ingredient = _context.Find<Ingredient>(id);
        return ingredient;
    }

    public Ingredient[] GetAll()
    {
        return _context.Ingredients.ToArray();
    }
}