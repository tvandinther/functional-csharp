namespace PartialApplication;

public class AddFactory
{
    public Add AddN(int operand) => new Add(operand);
}

public class Add
{
    private readonly int _operand;
    
    public Add(int operand)
    {
        _operand = operand;
    }
    
    public int AddThis(int value) => _operand + value;
}