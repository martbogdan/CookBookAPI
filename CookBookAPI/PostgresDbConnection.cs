using Npgsql;
namespace CookBookAPI;

public class PostgresDbConnection
{

    private readonly IConfiguration _configuration;

    public PostgresDbConnection(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public NpgsqlConnection GetConnection()
    {
        var host = _configuration.GetValue<string>("DataSource:Host");
        var name = _configuration.GetValue<string>("DataSource:Name");
        var user = _configuration.GetValue<string>("DataSource:User");
        var password = _configuration.GetValue<string>("DataSource:Password");
        var cs = $"Host={host};Username={user};Password={password};Database={name}";
        return new NpgsqlConnection(cs);
    }
    public string GetDbVersion()
    {
        using var con = GetConnection();
        con.Open();

        var sql = "SELECT version()";

        using var cmd = new NpgsqlCommand(sql, con);

        var version = cmd.ExecuteScalar().ToString();
        var r = $"PostgreSQL version: {version}";
        Console.WriteLine(r);
        return r;
    }
}