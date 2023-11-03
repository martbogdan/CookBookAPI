using CookBookAPI.Models;
using CookBookAPI.Repository;

namespace CookBookAPI.Service;

public class RecipeService
{
    private readonly RecipeRepository _repository;

    public RecipeService(RecipeRepository repository)
    {
        _repository = repository;
    }

    public Recipe GetRecipeBy(int id)
    {
        return _repository.GetById(id);
    }

    public Recipe[] GetAll()
    {
        return _repository.GetAll().ToArray();
    }

    public Recipe AddRecipe(Recipe recipe)
    {
        _repository.Save(recipe);
        return recipe;
    }
}