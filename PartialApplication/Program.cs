using PartialApplication;

Console.WriteLine("Consider this basic partial application example using addition...\n");

Console.WriteLine("Using a typical OOP approach of a factory to create an adder:");
var adder = new AddFactory().AddN(1);
Console.WriteLine(adder.AddThis(2)); // 3

Console.WriteLine("Using partial application to capture the first operand:");
var add1 = Addition.AddN(1);
// The first operand is now captured, so we can invoke the function with the second operand
Console.WriteLine(add1(2)); // 3

/*
 * Partial application is a useful refactoring technique. Whenever you have a function that takes
 * multiple arguments, you can refactor it into a function that takes one argument and returns
 * a function that takes the remaining arguments. This allows you to capture the first argument
 * and reuse the function with different remaining arguments.
 */

Console.WriteLine("Consider this database example...\n");
const string connectionString = "Server=.;Database=master;Trusted_Connection=True;";

Console.WriteLine("Using a typical OOP approach of a factory to create a database client:");
var databaseClient1 = new DatabaseFactory().CreateClient(connectionString);
var result1 = await databaseClient1.Query("SELECT * FROM [Users]");

Console.WriteLine(result1);

Console.WriteLine("Using partial application to capture the connection string:");
var makeQuery = Database.CreateClient(connectionString);
var result2a = await makeQuery("SELECT * FROM [Users]");
var result2b = await makeQuery("SELECT * FROM [Users] WHERE [Id] = 1");

Console.WriteLine(result2a);
Console.WriteLine(result2b);

Console.WriteLine("Because `CreateClient` returns a function, we can inline the invocation to give this funky syntax:");
var result2c = await Database.CreateClient(connectionString)("SELECT * FROM [Users]");

Console.WriteLine(result2c);