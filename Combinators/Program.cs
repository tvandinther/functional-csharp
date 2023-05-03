using Combinators.Functional;
using Combinators.ObjectOriented;
using Combinators.ObjectOriented.Combinators;
using Combinators.ObjectOriented.GenericRules;
using Combinators.ObjectOriented.Rules;

Console.WriteLine(@"
The password must meet all of the following requirements:
    - At least 8 characters
    - Contains at least one number
    - Meets any of the following:
       - Contains punctuation
       - Contains brackets
    - If there are less than three numbers:
         - Contains exactly two symbols
");

do
{
    var password = PromptForPassword();

    var validatePassword = GetPasswordValidator();
    var validPassword = validatePassword(password);


    if (validPassword)
        PrintCreatingAccount();
    else
        PrintInvalidPassword();

    Console.WriteLine("Press 'q' to quit or any other key to try again.");
} while (Console.ReadKey(true).Key != ConsoleKey.Q);

/*
 * This is an example of how to use the functional combinators.
 */
Func<string, bool> GetPasswordValidator()
{
    var numbers = "0123456789".ToCharArray();
    var punctuation = ".,?!:;\"\'~-/".ToCharArray();
    var symbols = "@#$%^&*|\\+=<>".ToCharArray();
    var brackets = "()[]{}".ToCharArray();

    return Combinators.Functional.Combinators.All(
        GenericRules.LengthAtLeast<string, char>(8),
        GenericRules.ContainsAny<string, char>(numbers),
        Combinators.Functional.Combinators.Any(
            GenericRules.ContainsAny<string, char>(punctuation),
            GenericRules.ContainsAny<string, char>(brackets)
        ),
        Combinators.Functional.Combinators.If(
            GenericRules.ContainsAtMost<string, char>(2, numbers),
            GenericRules.ContainsExactly<string, char>(2, symbols)
        )
    );
}

/*
 * This is an example of how to use the functional combinators, broken into steps.
 */
Func<string, bool> GetPasswordValidatorb()
{
    var numbers = "0123456789".ToCharArray();
    var punctuation = ".,?!:;\"\'~-/".ToCharArray();
    var symbols = "@#$%^&*|\\+=<>".ToCharArray();
    var brackets = "()[]{}".ToCharArray();

    var containsANumber = GenericRules.ContainsAny<string, char>(numbers);
    var atLeast8Characters = GenericRules.LengthAtLeast<string, char>(8);
    var containsPunctuation = GenericRules.ContainsAny<string, char>(punctuation);
    var containsBrackets = GenericRules.ContainsAny<string, char>(brackets);
    var containsAtMost2Numbers = GenericRules.ContainsAtMost<string, char>(2, numbers);
    var contains2Symbols = GenericRules.ContainsExactly<string, char>(2, symbols);
    
    var containsPunctuationOrBrackets = Combinators.Functional.Combinators.Any(
        containsPunctuation,
        containsBrackets
    );
    var contains2SymbolsIfAlsoContainsAtMost2Numbers = Combinators.Functional.Combinators.If(
        containsAtMost2Numbers,
        contains2Symbols
    );
    
    return Combinators.Functional.Combinators.All(
        containsANumber,
        atLeast8Characters,
        containsPunctuationOrBrackets,
        contains2SymbolsIfAlsoContainsAtMost2Numbers
    );
}

/*
 * This is an example of how to use the object-oriented combinators.
 */
IValidationRule<string> GetPasswordValidator2a()
{
    return new All<string>
    {
        new ContainsANumber(),
        new AtLeast8Characters(),
        new Any<string>
        {
            new ContainsPunctuation(),
            new ContainsBrackets()
        },
        new If<string>(
            new ContainsAtMost2Numbers(), 
            new Contains2Symbols()
            )
    };
}

/*
 * This is an example of how to use the object-oriented combinators, using more generic rules.
 */
IValidationRule<string> GetPasswordValidator2b()
{
    var numbers = "0123456789".ToCharArray();
    var punctuation = ".,?!:;\"\'~-/".ToCharArray();
    var symbols = "@#$%^&*|\\+=<>".ToCharArray();
    var brackets = "()[]{}".ToCharArray();
    
    return new All<string>
    {
        new Contains<string, char>(numbers),
        new LengthAtLeast<string, char>(8),
        new Any<string>
        {
            new Contains<string, char>(punctuation),
            new Contains<string, char>(brackets)
        },
        new If<string>(new ContainsAtMost<string, char>(2, numbers), 
            new ContainsExactly<string, char>(2, symbols)
            )
    };
}

/*
 * Helper methods for I/O.
 */
string PromptForPassword()
{
    Console.Write("Enter your password: ");
    return Console.ReadLine() ?? string.Empty;
}

void PrintCreatingAccount()
{
    Console.BackgroundColor = ConsoleColor.Green;
    Console.ForegroundColor = ConsoleColor.Black;
    Console.Write(" Creating your account... ");
    Console.ResetColor();
    Console.WriteLine();
}

void PrintInvalidPassword()
{
    Console.BackgroundColor = ConsoleColor.Red;
    Console.ForegroundColor = ConsoleColor.Black;
    Console.Write(" The entered password does not meet the requirements. ");
    Console.ResetColor();
    Console.WriteLine();
}
