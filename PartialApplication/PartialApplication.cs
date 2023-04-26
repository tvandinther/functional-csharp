namespace PartialApplication;

public static class Addition
{
    public static Func<int, int> AddN(int operand) => b => Add(operand, b);
    private static int Add(int a, int b) => a + b;
}

public static class Database
{
    public static Func<string, Task<string>> CreateClient(string connectionString) => async query => await Query(connectionString, query);
    private static Task<string> Query(string connectionString, string query) => Task.FromResult(connectionString + " " + query);
}