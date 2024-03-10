namespace Infrastructure.Dapper;
using Npgsql;
using global::Dapper;
public class DapperContext
{
    private readonly string _connectionString =
    "Host=localhost;Port=5432;Database=.NetExam2;User Id=postgres;Password=20080820;";

    public NpgsqlConnection Connection()
    {
        return new NpgsqlConnection(_connectionString);
    }
}
