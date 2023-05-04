using OptionType;

/*
 * Some helpful functions.
 */
int IntToInt(int x) => x + 1;
int IntToInt2(int x) => x * 2;
string IntToString(int x) => x.ToString();

/*
 * The null example.
 */
object? Parse(string input)
{
    try
    {
        return int.Parse(input);
    }
    catch (Exception)
    {
        return null;
    }
}

// By using null, we have to check for null every time we want to use the object.
// This creates a pyramid of doom which can be avoided by using optional types.
var myNullableObject = Parse("5");
if (myNullableObject != null)
{
    // Do something with my object
    var myNullableObject2 = myNullableObject;
    if (myNullableObject2 != null)
    {
        // Do something else with my nullable object
        var myNullableObject3 = myNullableObject2;
        if (myNullableObject3 != null)
        {
            // Do one last this with the nullable object
            var myNullableObject4 = myNullableObject3;
        }
    }
}

// The following examples will use int instead of objects, but the idea is the same.
// In modern C#, there is the Nullable<T> / T? type which can be used (and must be used on primitives, hence using object for
// the first example). The nullable type has two properties: HasValue and Value which are similar to the Option type
// but do not offer the same protections.

/*
 * Hierarchical-type Option example.
 */
var myInt = SafeParse("5");

var numbers = new[] {1, 2, 3, 4, 5}.AsEnumerable();

var q1 = myInt.Select(IntToString);
var q2 =
    from v in myInt
    select IntToString(v);

if (q1 is Some<string> l) Console.WriteLine(l.Value);

var strings1 = numbers.Select(IntToString);
var strings2 = 
    from n in numbers
    select IntToString(n);

var x = myInt switch
{
    Some<int> a => IntToInt2(IntToInt(a.Value)),
    None<int> => 0
};

HierarchicalOption<int> SafeParse(string input)
{
    try
    {
        var value = int.Parse(input);
        return new Some<int>(value);
    }
    catch (Exception)
    {
        return new None<int>();
    }
}

/*
 * Single-type Option example.
 */
var myInt2 = SafeParse2("5");
var k = myInt2.Select(IntToString);
myInt2.Match(IntToString, () => "None");

Option<int> SafeParse2(string input)
{
    try
    {
        var value = int.Parse(input);
        return value;
    }
    catch (Exception)
    {
        return Option<int>.None;
    }
}

/*
 * Hierarchical-type Either example.
 */
var myEither1 = SafeParse3("5");
var r = myEither1.Select(IntToInt);
var output2 = r switch
{
    Right<Exception, int> a => IntToString(a.Value),
    Left<Exception, int> b => b.Value is ArgumentException a ? a.Message : "hmmm..."
};

HierarchicalEither<Exception, int> SafeParse3(string input)
{
    try
    {
        var value = int.Parse(input);
        return new Right<Exception, int>(value);
    }
    catch (Exception e)
    {
        return new Left<Exception, int>(e);
    }
}
    
/*
 * Single-type Either example.
 */
var myEither2 = SafeParse4("5");
var s = myEither2.Select(IntToInt);
var output = s.Match(e => e is ArgumentException a ? a.Message : "hmmm...", IntToString);

Either<Exception, int> SafeParse4(string input)
{
    try
    {
        var value = int.Parse(input);
        return value;
    }
    catch (Exception e)
    {
        return e;
    }
}
