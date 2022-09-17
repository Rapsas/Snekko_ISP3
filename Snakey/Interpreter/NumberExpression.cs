namespace Snakey.Interpreter;

public class NumberExpression : IExpression
{
    private readonly int _value;

    public NumberExpression(int value)
    {
        _value = value;
    }

    public Value Execute()
    {
        if (_value == int.MinValue) // Error
            return null;
        return new Value { Number = _value, IsNumber = true };
    }
}
