using System.Collections;

namespace Combinators.ObjectOriented.Combinators;

public class Any<T> : IValidationRule<T>, IEnumerable<IValidationRule<T>>
{
    private readonly IList<IValidationRule<T>> _rules;

    public Any()
    {
        _rules = new List<IValidationRule<T>>();
    }

    public Any(IEnumerable<IValidationRule<T>> rules)
    {
        _rules = rules.ToList();
    }
    
    public void Add(IValidationRule<T> rule) => _rules.Add(rule);
    
    public bool Validate(T value) => 
        _rules.Any(r => r.Validate(value));

    public IEnumerator<IValidationRule<T>> GetEnumerator() => _rules.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}