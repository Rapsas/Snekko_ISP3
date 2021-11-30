namespace Snakey.Interpreter
{
    public class NumberExpression : IExpression
    {
        private int _value;

        public NumberExpression(int value)
        {
            _value = value;
        }

        public Value Execute()
        {
            return new Value {Number = _value, IsNumber = true};
        }
    }
}