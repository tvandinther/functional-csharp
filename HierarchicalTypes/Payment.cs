namespace HierarchicalTypes;

public class Payment
{
    public Guid Id { get; } = Guid.NewGuid();
    public DateTime Date { get; } = DateTime.UtcNow;
    public decimal Amount { get; }
    public PaymentMethod Method { get; }
    
    public Payment(decimal amount, PaymentMethod method)
    {
        Amount = amount;
        Method = method;
    }
}