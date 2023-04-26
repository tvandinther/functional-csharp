namespace PartialApplication;

public class DatabaseFactory
{
    public DatabaseClient CreateClient(string connectionString) => new(connectionString);
}

public class DatabaseClient
{
    private readonly string _connectionString;

    public DatabaseClient(string connectionString)
    {
        _connectionString = connectionString;
    }

    public Task<string> Query(string query) => Task.FromResult(_connectionString + " " + query);
}