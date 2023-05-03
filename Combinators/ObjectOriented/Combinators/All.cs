using System.Collections;

namespace Combinators.ObjectOriented.Combinators;

public class All<T> : IValidationRule<T>, IEnumerable<IValidationRule<T>>
{
    private IList<IValidationRule<T>> _rules;

    public All()
    {
        _rules = new List<IValidationRule<T>>();
    }
    
    public All(IEnumerable<IValidationRule<T>> rules)
    {
        _rules = rules.ToList();
    }

    public void Add(IValidationRule<T> rule) => _rules.Add(rule);
    
    public bool Validate(T value) => 
        _rules.All(r => r.Validate(value));

    public IEnumerator<IValidationRule<T>> GetEnumerator() => _rules.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}