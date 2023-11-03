using System.Net;
using CookBookAPI.Models;
using Humanizer;
using Microsoft.AspNetCore.Http.HttpResults;
using Npgsql;

namespace CookBookAPI.Repository;

public class RecipeRepository
{
    private readonly PostgresDbConnection _connection;

    public RecipeRepository(PostgresDbConnection connection)
    {
        _connection = connection;
    }

    public List<Recipe> GetAll()
    {
        var sql = "SELECT * FROM recipe";
        using var connection = _connection.GetConnection();
        connection.Open();
        using var cmd = new NpgsqlCommand(sql, connection);
        using var reader = cmd.ExecuteReader();
        List<Recipe> recipes = new List<Recipe>();
        while (reader.Read())
        {
            recipes.Add(new Recipe()
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                Description = reader.GetString(2)
            });
        }

        return recipes;
    }

    public Recipe GetById(int id)
    {
        var sql = $"select * from recipe where id={id}";
        using var connection = _connection.GetConnection();
        connection.Open();

        using var cmd = new NpgsqlCommand(sql, connection);
        using var reader = cmd.ExecuteReader();
        if (reader.Read())
        {
            return new Recipe()
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                Description = reader.GetString(2)
            };
        }

        throw new HttpRequestException($"No such Recipe in DB with id: {id}");
    }

    public int Save(Recipe recipe)
    {
        using var connection = _connection.GetConnection();
        connection.Open();
        var sql = $"insert into recipe(name, description) values ('{recipe.Name}','{recipe.Description}')";
        using var cmd = new NpgsqlCommand(sql, connection);
        cmd.CommandText = sql;
        return cmd.ExecuteNonQuery();
    }


}