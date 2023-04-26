using FunctionComposition;

/*
 * We want to take a number, add 1, multiply by 2, and then convert to a string.
 */

// Given our steps:
int Add1(int x) => x + 1;
int MultiplyBy2(int x) => x * 2;
string ConvertToString(int x) => x.ToString();

// We can compose them using our composition helper extension method `Then`
var result = 1
    .Then(Add1)
    .Then(MultiplyBy2)
    .Then(ConvertToString);
    
Console.WriteLine(result); // "4"

// We can also lazily compose these functions, but before we can do that we need to redefine our steps.

/*
 * The local functions can also be expressed using lambda expressions.
 * C# treats lambda expressions differently from local functions.
 * Defining our steps as lambda expressions allows us to use them as first-class values.
 * This means they work with our composition extension methods.
 */
var add1 = (int x) => x + 1;
var multiplyBy2 = (int x) => x * 2;
var convertToString = (int x) => x.ToString();

var lazy = 
    add1
    .ThenLazily(multiplyBy2)
    .ThenLazily(convertToString);
/*
 * In the argument for `LazyThen` we can pass either the lambda or the local function.
 * This is because the local function is implicitly convertible to a delegate.
 * Note that this implicit conversion does not work for method dispatching.
 * This is why we cannot use our extension method on the local function.
 */

// To get our value we must then execute the composed function
var result2 = lazy(1);
Console.WriteLine(result2); // "4"

// C# does some weird duck typing with LINQ and the LINQ query syntax. Let's hack it.
// We can redefine `Then` and name it `Select`.
var result3 = 1.Select(add1).Select(multiplyBy2).Select(convertToString);
Console.WriteLine(result3); // "4"

// But we can also use the LINQ query syntax for an equivalent expression.
var result4 = 
    from x in 1
    select add1(x) into y
    select multiplyBy2(y) into z
    select convertToString(z);
              
Console.WriteLine(result4); // "4"